using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace NewTask.Models
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int User_id { get; set; }
        [Required]
        public string  User_name{ get; set; }
        [EmailAddress]
        public string  User_Email{ get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Default_Password { get; set; }
        [Required]
        public string User_status{ get; set; }
        [Required]
        public string Designation { get; set; }


    }
}