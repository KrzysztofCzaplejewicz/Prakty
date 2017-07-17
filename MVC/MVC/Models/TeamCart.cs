using MVC.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC.Models
{
    public partial class TeamCart
    {
        Context _db = new Context();

        string TeamCartId { get; set; }
        public const string CartSessionKey = "CartId";

        public static TeamCart GetCart(HttpContextBase context)
        {
            var cart = new TeamCart();
            cart.TeamCartId = cart.GetCartId(context);
            return cart;
        }

        public static TeamCart GetCart(Controller controller)
        {
            return GetCart(controller.HttpContext);
        }


        public void AddToCart(Team team)
        {
            var cartIteam = _db.Carts.SingleOrDefault(c => c.CartId == TeamCartId && c.TeamId == team.Id);

            if (cartIteam == null)
            {
                cartIteam = new Cart
                {
                    TeamId = team.Id,
                    CartId = TeamCartId,
                    Count = 1,
                    DateCreated = DateTime.Now

                };

                _db.Carts.Add(cartIteam);


            }

            else
            {
                cartIteam.Count++;
            }

            _db.SaveChanges();


        }

        public int Remove(int id)
        {
            var cartItem = _db.Carts
                .SingleOrDefault(cart => cart.CartId == TeamCartId 
            && cart.RecordId == id);

            int itemCount = 0;

            if (cartItem != null)
            {
                if (cartItem.Count > 1)
                {
                    cartItem.Count--;
                    itemCount = cartItem.Count;
                }

                else
                {
                    _db.Carts.Remove(cartItem);
                }

                _db.SaveChanges();
            }

            return itemCount;
        }

        public void EmptyCart()
        {
            var cartItems = _db.Carts.Where(cart => cart.CartId == TeamCartId);

            foreach (var cartItem in cartItems)
            {
                _db.Carts.Remove(cartItem);
            }
            _db.SaveChanges();
        }

        public List<Cart> GetCartItems()
        {
            return _db.Carts.Where(cart => cart.CartId == TeamCartId).ToList();
        }

        
        public int GetCount()
        {
            int? count = (from cartItems in _db.Carts
                where cartItems.CartId == TeamCartId
                select (int?) cartItems.Count).Sum();

            return count ?? 0;
        }


        public int CreateOrder(Order order)
        {
            decimal orderTotal = 0;
            var cartItems = GetCartItems();
            // Iterate over the items in the cart, adding the order details for each
            foreach (var item in cartItems)
            {
                var orderDetail = new OrderDetail
                {
                    TeamId = item.TeamId,
                    OrderId = order.OrderId,
                    Quantity = item.Count
                };

                _db.OrderDetails.Add(orderDetail);
            }
            // Set the order's total to the orderTotal count
            order.Total = orderTotal;
            // Save the order
            _db.SaveChanges();
            // Empty the shopping cart
            EmptyCart();
            // Return the OrderId as the confirmation number
            return order.OrderId;
        }

        // We're using HttpContextBase to allow access to cookies.
        public string GetCartId(HttpContextBase context)
        {
            if (context.Session[CartSessionKey] == null)
            {
                if (!string.IsNullOrWhiteSpace(context.User.Identity.Name))
                {
                    context.Session[CartSessionKey] = context.User.Identity.Name;
                }
                else
                {

                    Guid tempCartId = Guid.NewGuid();
                    // Send tempCartId back to client as a cookie
                    context.Session[CartSessionKey] = tempCartId.ToString();
                }
            }
            return context.Session[CartSessionKey].ToString();
        }

        // When a user has logged in, migrate their shopping cart to
        // be associated with their username
        public void MigrateCart(string userName)
        {
            var shoppingCart = _db.Carts.Where(c => c.CartId == TeamCartId);
            foreach (Cart item in shoppingCart)
            {
                item.CartId = userName;
            }
            _db.SaveChanges();

        }
    }
}