using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace NewTask.Models
{
    public class User_assign_project
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserAssignid { get; set; }
        public int User_id { get; set; }
        public int Pro_id { get; set; }
        public virtual User user { get; set; }
        public virtual Project project { get; set; }

    }
}