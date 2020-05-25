using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using cw11.DTOs.Request;
using cw11.DAL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace cw11.Controllers
{
    [Route("api/doctors")]
    [ApiController]
    public class DoctorController : ControllerBase
    {
        private readonly CodeFirstContext _context;

        public DoctorController(CodeFirstContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetDoctor(int id)
        {
            if (_context.Doctor.Find(id) == null)
            {
                return NotFound("Doktor nie widnieje w bazie danych");
            }

            return Ok(_context.Doctor.Find(id).ToString());
        }

        [HttpPost]
        [Route("modify")]
        public IActionResult ModifyDoctor(DoctorModifyRequest request)
        {
            try
            {
                var doc = _context.Doctor.Find(request.IdDoctor);

                if (doc.FirstName != request.FirstName && request.FirstName != null)
                {
                    doc.FirstName = request.FirstName;
                }
                else if (doc.LastName != request.LastName && request.LastName != null)
                {
                    doc.LastName = request.LastName;
                }
                else if (doc.Email != request.Email && request.Email != null)
                {
                    doc.Email = request.Email;
                }

                _context.Doctor.Update(doc);
                _context.SaveChanges();
            }catch (Exception ex)
            { 
                return BadRequest("Błąd podczas modyfikacji danych lekarza\n" + ex.Message);
            }

            return Ok("Zmiany zapisane");
        }

        [HttpPost]
        [Route("add")]
        public IActionResult AddNewDoctor(DoctorAddRequest request)
        {
            try
            {
                var doc = new Doctor();
                doc.FirstName = request.FirstName;
                doc.LastName = request.LastName;
                doc.Email = request.Email;

                if (doc != null)
                {
                    _context.Doctor.Add(doc);
                    _context.SaveChanges();
                }
                else
                {
                    return BadRequest("Obiekt pusty!");
                }
            }catch (Exception ex)
            {
                return BadRequest("Nie mozna dodac doktora" + ex.Message);
            }
            return Ok("Dodano doktora");
        }

        [HttpDelete]
        public IActionResult DeleteDoctor(DoctorModifyRequest request)
        {
            try
            {
                var doc = _context.Doctor.Find(request.IdDoctor);

                if (doc != null)
                {
                    _context.Doctor.Remove(doc);
                    _context.SaveChanges();
                }
            } catch (Exception ex)
            {
                return BadRequest("Nie usunięto doktora. Wystąpił błąd" + ex.Message);
            }
            return Ok("Doktor usunięty");
        }
    }
}