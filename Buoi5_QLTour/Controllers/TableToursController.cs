using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Buoi5_QLTour.Models;

namespace Buoi5_QLTour.Controllers
{
    public class TableToursController : Controller
    {
        private TourEntities1 db = new TourEntities1();

        // GET: TableTours
        public async Task<ActionResult> Index()
        {
            return View(await db.TableTours.ToListAsync());
        }

        // GET: TableTours/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TableTour tableTour = await db.TableTours.FindAsync(id);
            if (tableTour == null)
            {
                return HttpNotFound();
            }
            return View(tableTour);
        }

        // GET: TableTours/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TableTours/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,TourName")] TableTour tableTour)
        {
            if (ModelState.IsValid)
            {
                db.TableTours.Add(tableTour);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(tableTour);
        }

        // GET: TableTours/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TableTour tableTour = await db.TableTours.FindAsync(id);
            if (tableTour == null)
            {
                return HttpNotFound();
            }
            return View(tableTour);
        }

        // POST: TableTours/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,TourName")] TableTour tableTour)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tableTour).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(tableTour);
        }

        // GET: TableTours/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TableTour tableTour = await db.TableTours.FindAsync(id);
            if (tableTour == null)
            {
                return HttpNotFound();
            }
            return View(tableTour);
        }

        // POST: TableTours/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            TableTour tableTour = await db.TableTours.FindAsync(id);
            db.TableTours.Remove(tableTour);
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
