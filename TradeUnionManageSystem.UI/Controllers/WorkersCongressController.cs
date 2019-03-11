using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TradeUnionManageSystem.BLL;
using TradeUnionManageSystem.BLL.Models;

namespace TradeUnionManageSystem.UI.Controllers
{
    public class WorkersCongressController : Controller
    {
        private MyContext db = new MyContext();

        // GET: WorkersCongress
        public ActionResult Index()
        {
            return View(db.WorkersCongresses.ToList());
        }




        // GET: WorkersCongress/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WorkersCongress workersCongress = db.WorkersCongresses.Find(id);
            if (workersCongress == null)
            {
                return HttpNotFound();
            }
            return View(workersCongress);
        }

        // GET: WorkersCongress/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: WorkersCongress/Create
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,CongressSession,CongressTime,UnitCode,CreateTime,RepresentAmount,AttendanceAmount,ProposalAmount")] WorkersCongress workersCongress)
        {
            if (ModelState.IsValid)
            {
                db.WorkersCongresses.Add(workersCongress);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(workersCongress);
        }

        // GET: WorkersCongress/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WorkersCongress workersCongress = db.WorkersCongresses.Find(id);
            if (workersCongress == null)
            {
                return HttpNotFound();
            }
            return View(workersCongress);
        }

        // POST: WorkersCongress/Edit/5
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,CongressSession,CongressTime,UnitCode,CreateTime,RepresentAmount,AttendanceAmount,ProposalAmount")] WorkersCongress workersCongress)
        {
            if (ModelState.IsValid)
            {
                db.Entry(workersCongress).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(workersCongress);
        }

        // GET: WorkersCongress/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WorkersCongress workersCongress = db.WorkersCongresses.Find(id);
            if (workersCongress == null)
            {
                return HttpNotFound();
            }
            return View(workersCongress);
        }

        // POST: WorkersCongress/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            WorkersCongress workersCongress = db.WorkersCongresses.Find(id);
            db.WorkersCongresses.Remove(workersCongress);
            db.SaveChanges();
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
