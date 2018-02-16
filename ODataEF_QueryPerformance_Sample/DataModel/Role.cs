using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ODataEF_QueryPerformance_Sample.DataModel
{
    public class Role
    {

        [Key]
        public int Id { get; set; }

        [StringLength(100)]
        public string Name { get; set; }
        public string Descripton { get; set; }

        public string Col1 { get; set; }
        
        public virtual ICollection<UserRole> UserRoles { get; set; }
    }
}
