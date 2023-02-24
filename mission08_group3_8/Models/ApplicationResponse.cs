using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace mission08_group3_8.Models
{
    public class ApplicationResponse
    {
        [Key]
        [Required]
        public int TaskID { get; set; }
        [Required]
        public string Task { get; set; }
        [Required]
        public string DueDate { get; set; }
        public int Quadrant { get; set; }
        public bool Completed { get; set;  }

        public int CategoryID { get; set; }
        public Category Category { get; set; }
    }
}
