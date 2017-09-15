using System.Collections.Generic;

namespace VideoStore
{
    public class LoginRepository
    {
        public List<Login> GetLogins()
        {
            return new List<Login>
            {
                new Login(){UserName = "Admin", Password = "12345"},
                new Login(){UserName = "User", Password = "12345"}
            };
        }
    }
}