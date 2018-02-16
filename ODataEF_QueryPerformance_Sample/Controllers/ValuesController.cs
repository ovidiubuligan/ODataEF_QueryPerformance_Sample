using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ODataEF_QueryPerformance_Sample.DataModel;

namespace ODataEF_QueryPerformance_Sample.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        // GET api/values
        [HttpGet]
        public IEnumerable<User> Get()
        {

            var dbContext = new EFContext();
            dbContext.Configuration.LazyLoadingEnabled = false;

            var users = dbContext.Users.Take(100).ToList();

            return users;
        }

        // GET api/values/5
        [HttpGet("search")]
        public IActionResult SearchCustomer([FromQuery(Name = "username")] string username)
        {
            var dbContext = new EFContext();
            dbContext.Configuration.LazyLoadingEnabled = false;
            var users = dbContext.Users
                        .Where(u => u.UserName.Contains(username))
                        .Take(100);
                        
            return Ok(users);
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

    }
}
