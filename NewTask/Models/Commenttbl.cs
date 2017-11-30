using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace NewTask.Models
{
    public class Commenttbl
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Comment_id { get; set; }
        public int Pro_id { get; set; }
        public int Task_id { get; set; }
        [Required]
        public string comment { get; set; }

        public virtual Tasktbl tasktbl { get; set; }
        public virtual Project proj { get; set; }
    }
}