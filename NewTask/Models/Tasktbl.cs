using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace NewTask.Models
{
    public class Tasktbl
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Task_id { get; set; }
        public string Task_Name { get; set; }
        public string Task_description { get; set; }
        public int Pro_id { get; set; }
        public int User_Id { get; set; }
        public string Due_date { get; set; }
        public CodePrio Priority { get; set; }
        public enum CodePrio
        {
            low,medium,high
        }
        public virtual Project proj { get; set; }
        public virtual User user { get; set; }

    }
}