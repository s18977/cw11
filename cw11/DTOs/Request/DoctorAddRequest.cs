using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace cw11.DTOs.Request
{
    public class DoctorAddRequest
    {
        [Required(ErrorMessage = "Musisz podać Imię doktora")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Musisz podać Nazwisko doktora")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Musisz podać Email doktora")]
        public string Email { get; set; }
    }
}
