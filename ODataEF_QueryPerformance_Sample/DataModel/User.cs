using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ODataEF_QueryPerformance_Sample.DataModel
{

    public class User
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        public string UserName { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }

        public int Age { get; set; }

        public virtual ICollection<UserRole> UserRoles { get; set; }
        
    }
}
