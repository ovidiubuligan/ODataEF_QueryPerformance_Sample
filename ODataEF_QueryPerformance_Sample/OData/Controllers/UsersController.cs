using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.OData;
using Microsoft.AspNet.OData.Query;
using Microsoft.EntityFrameworkCore;
using ODataEF_QueryPerformance_Sample.DataModel;

namespace ODataEF_QueryPerformance_Sample.OData.Controllers
{
    public class UsersController : ODataController
    {
        [EnableQuery(
            MaxExpansionDepth = 1,
            PageSize = 50,
            MaxTop = 100,
            // max numver of nodes in filter clause
            MaxNodeCount = 10,
            AllowedQueryOptions = AllowedQueryOptions.Filter |
                                  AllowedQueryOptions.Expand |
                                  AllowedQueryOptions.Skip |
                                  AllowedQueryOptions.Top |
                                  AllowedQueryOptions.OrderBy |
                                  AllowedQueryOptions.Select,

            // see https://stackoverflow.com/questions/16052326/entity-framework-with-odataweb-api-is-sending-order-by-clause-by-default-to-sq
            // once you disable EnsureStableOrdering $top and $skip don't make sense . 
            // you will have to add an $orderBy clause to make it work (can use the primary id for ex)
            EnsureStableOrdering = false
         )]
        public IQueryable<User> Get(ODataQueryOptions<User> options)
        {
            var context = new EFContext();
            var usersQueryable = context.Users.AsQueryable();

            return usersQueryable;
        }



    }
}
