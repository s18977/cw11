using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace cw11.DTOs.Request
{
    public class DoctorModifyRequest
    {
        [Required(ErrorMessage = "Musisz podać chociaż index doktora")]
        public int IdDoctor { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
    }
}
