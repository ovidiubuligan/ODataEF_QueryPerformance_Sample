using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.OData.Builder;
using Microsoft.OData.Edm;
using ODataEF_QueryPerformance_Sample.DataModel;

namespace ODataEF_QueryPerformance_Sample.OData
{
    public class EFSampleODataModelBuilder
    {
        public IEdmModel DefineEdmModel(IServiceProvider services)
        {
            ODataConventionModelBuilder builder = new ODataConventionModelBuilder(services);
            builder.EntitySet<User>("Users");
            builder.EntitySet<Role>("Roles");
            builder.EntitySet<UserRole>("UserRoles");


            var edmModel = builder.GetEdmModel();
            return edmModel;
        }
    }
}
