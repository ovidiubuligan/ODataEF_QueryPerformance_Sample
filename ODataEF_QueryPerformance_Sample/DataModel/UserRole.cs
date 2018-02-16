using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ODataEF_QueryPerformance_Sample.DataModel
{
    public class UserRole
    {
        [Key]
        public int Id { get; set; }

        public int UserId { get; set; }

        public int RoleId { get; set; }

        [ForeignKey("UserId")]
        public virtual User User { get; set; }

        [ForeignKey("RoleId")]
        public virtual Role Role { get; set; }



    }
}