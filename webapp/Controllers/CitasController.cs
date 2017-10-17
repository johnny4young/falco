using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Falco.WebApi.DAL;
using Falco.WebApi.Models;

namespace FalcoMvc.Controllers
{
    [Authorize]
    public class CitasController : Controller
    {
        private ContextModel db = new ContextModel();

        // GET: Citas
        public async Task<ActionResult> Index()
        {
            var cita = db.Cita.Include(c => c.tipoCita);
            return View(await cita.ToListAsync());
        }

        // GET: Citas/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cita cita = await db.Cita.FindAsync(id);
            if (cita == null)
            {
                return HttpNotFound();
            }
            return View(cita);
        }

        // GET: Citas/Create
        public ActionResult Create()
        {
            ViewBag.TipoCitaId = new SelectList(db.TipoCita, "Id", "Descripcion");
            return View();
        }

        // POST: Citas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,PacientId,Fecha,TipoCitaId")] Cita cita)
        {
            if (ModelState.IsValid)
            {
                db.Cita.Add(cita);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.TipoCitaId = new SelectList(db.TipoCita, "Id", "Descripcion", cita.TipoCitaId);
            return View(cita);
        }

        // GET: Citas/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cita cita = await db.Cita.FindAsync(id);
            if (cita == null)
            {
                return HttpNotFound();
            }
            ViewBag.TipoCitaId = new SelectList(db.TipoCita, "Id", "Descripcion", cita.TipoCitaId);
            return View(cita);
        }

        // POST: Citas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,PacientId,Fecha,TipoCitaId")] Cita cita)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cita).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.TipoCitaId = new SelectList(db.TipoCita, "Id", "Descripcion", cita.TipoCitaId);
            return View(cita);
        }

        // GET: Citas/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cita cita = await db.Cita.FindAsync(id);
            if (cita == null)
            {
                return HttpNotFound();
            }
            return View(cita);
        }

        // POST: Citas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Cita cita = await db.Cita.FindAsync(id);
            db.Cita.Remove(cita);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
