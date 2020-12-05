using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ExternalPracFin.Models
{
    public class DeleteModel
    {
        [Required(ErrorMessage = "Id is required")]
        public int Id { get; set; }
    }
}