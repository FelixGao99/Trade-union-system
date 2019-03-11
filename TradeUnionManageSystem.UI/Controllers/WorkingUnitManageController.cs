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
    public class WorkingUnitManageController : Controller
    {
        private MyContext db = new MyContext();

        // GET: WorkingUnitManage
        public ActionResult Index()
        {
            return View(db.WorkingUnits.ToList());
        }

        // GET: WorkingUnitManage/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WorkingUnit workingUnit = db.WorkingUnits.Find(id);
            if (workingUnit == null)
            {
                return HttpNotFound();
            }
            return View(workingUnit);
        }

        // GET: WorkingUnitManage/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: WorkingUnitManage/Create
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,WorkingUnitName")] WorkingUnit workingUnit)
        {
            if (ModelState.IsValid)
            {
                db.WorkingUnits.Add(workingUnit);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(workingUnit);
        }

        // GET: WorkingUnitManage/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WorkingUnit workingUnit = db.WorkingUnits.Find(id);
            if (workingUnit == null)
            {
                return HttpNotFound();
            }
            return View(workingUnit);
        }

        // POST: WorkingUnitManage/Edit/5
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,WorkingUnitName")] WorkingUnit workingUnit)
        {
            if (ModelState.IsValid)
            {
                db.Entry(workingUnit).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(workingUnit);
        }

        // GET: WorkingUnitManage/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WorkingUnit workingUnit = db.WorkingUnits.Find(id);
            if (workingUnit == null)
            {
                return HttpNotFound();
            }
            return View(workingUnit);
        }

        // POST: WorkingUnitManage/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            WorkingUnit workingUnit = db.WorkingUnits.Find(id);
            db.WorkingUnits.Remove(workingUnit);
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
