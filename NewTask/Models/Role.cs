using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace NewTask.Models
{
    public class Role
    {
        [Key]
        [Index(IsUnique =true )]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Role_id { get; set; }
        public string Role_name { get; set; }
    }
}