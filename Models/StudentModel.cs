using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ExternalPracFin.Models
{
    public class StudentModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="Name is required")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Course is required")]
        public string Course { get; set; }
        [Required(ErrorMessage = "Year is Required")]
        public string Year { get; set; }
        [Required(ErrorMessage = "Gender is required")]
        public char Gender { get; set; }
    }
}