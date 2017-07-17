using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Microsoft.AspNet.Identity;
using MVC.Dtos;
using MVC.Models;

namespace MVC.Controllers
{
    public class FollowingsController : ApiController
    {
        private DbContext _context;

        public FollowingsController()
        {
            _context = new ApplicationDbContext();
        }

        //public IHttpActionResult Follow(FollowingDto dto)
        //{

        //    var userId = User.Identity.GetUserId();

        //    if (_context.Followings.Any())


        //}


    }
}
