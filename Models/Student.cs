using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StudentApplication1.Models
{
    public class Student
    {
        public int StudentId { get; set; }

        [Display(Name ="Name")]
        public string StudentName { get; set; }

        public int StudentAge { get; set; }
    }
}