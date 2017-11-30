using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace NewTask.Models
{
    public class Project
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Pro_id { get; set; }
        [Required]
        public string Project_Name{ get; set; }
        [Required]
        [StringLength(150)]
        public string Description { get; set; }
        public string Code { get; set; }
        public DateTime Start_date { get; set; }
        public DateTime End_date { get; set; }
        [Required]
        public string Duration { get; set; }
        [Required]
        public string Status { get; set; }
        public string FileName { get; set; }

    }
}