using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using Web_Api.Entities;
using System.IO;
namespace Web_Api.Controllers
{
    public class PrintersController : ApiController
    {
        private Inventarizacia_ob_VUZaEntities db = new Inventarizacia_ob_VUZaEntities();

        // GET: api/Printers
        public IQueryable<Printer> GetPrinter()
        {
            return db.Printer;
        }


        [Route("api/getPrinters")]
        public IHttpActionResult GetPrinters(int invent_nom )
        {
            var Printers = db.Printer.ToList().Where(p => p.Item_Id == invent_nom).ToList();
            return Ok(Printers);
        }


        // GET: api/Printers/5
        [ResponseType(typeof(Printer))]
        public IHttpActionResult GetPrinter(int id)
        {
            Printer printer = db.Printer.Find(id);
            if (printer == null)
            {
                return NotFound();
            }

            return Ok(printer);
        }

        // PUT: api/Printers/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPrinter(int id, Printer printer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != printer.Id_printer)
            {
                return BadRequest();
            }

            db.Entry(printer).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PrinterExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Printers
        [ResponseType(typeof(Printer))]
        public IHttpActionResult PostPrinter(Printer printer)
        {
            //printer.CreationDate = DateTime.Now;
            if (string.IsNullOrWhiteSpace(printer.Serial_number_printer) || printer.Serial_number_printer.Length > 10)
                ModelState.AddModelError("Serial_number_printer", "Серийный номер должен быть меньше 10 символов");
            if (string.IsNullOrWhiteSpace(printer.Type_oborudovaniya))
                ModelState.AddModelError("Type_oborudovaniya","не заполнен тип оборудования");
            if (string.IsNullOrWhiteSpace(printer.Nazvanie))
                ModelState.AddModelError("Nazvanie", "не заполнено название");
            if (string.IsNullOrWhiteSpace(printer.Type_printera))
                ModelState.AddModelError("Type_printera", "не заполнен тип принтера");
            if (string.IsNullOrWhiteSpace(printer.Cvetnost_pechati))
                ModelState.AddModelError("Cvetnost_pechati", "не заполнена цветность печати");
            if (string.IsNullOrEmpty(printer.Max_speed_pechati.ToString()))
                ModelState.AddModelError("Max_speed_pechati", "не заполнена макс скорость печати");
            if (string.IsNullOrWhiteSpace(printer.Max_format_pechati))
                ModelState.AddModelError("Max_format_pechati", "не заполнен макс формат печати");
            if (!(db.Sklad.ToList().FirstOrDefault(p => p.ID_item == printer.Item_Id) is Printer))
                ModelState.AddModelError("id", "не заполнен id");
            

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Printer.Add(printer);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = printer.Id_printer }, printer);
        }

        // DELETE: api/Printers/5
        [ResponseType(typeof(Printer))]
        public IHttpActionResult DeletePrinter(int id)
        {
            Printer printer = db.Printer.Find(id);
            if (printer == null)
            {
                return NotFound();
            }

            db.Printer.Remove(printer);
            db.SaveChanges();

            return Ok(printer);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PrinterExists(int id)
        {
            return db.Printer.Count(e => e.Id_printer == id) > 0;
        }
    }
}