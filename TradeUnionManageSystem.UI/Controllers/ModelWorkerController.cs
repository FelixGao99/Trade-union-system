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
using TradeUnionManageSystem.UI.Extensions;
using TradeUnionManageSystem.UI.Models.FilterModel;

namespace TradeUnionManageSystem.UI.Controllers
{
    public class ModelWorkerController : Controller
    {
        private MyContext db = new MyContext();

        // GET: ModelWorker
        public ActionResult Index()
        {
            ViewBag.Title = "劳模管理";
            return View(db.ModelWorkers.ToList());
        }



        // GET: ModelWorker/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ModelWorker modelWorker = db.ModelWorkers.Find(id);
            if (modelWorker == null)
            {
                return HttpNotFound();
            }
            return View(modelWorker);
        }

        // GET: ModelWorker/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ModelWorker/Create
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,EmployeeID,WorkStatus,WorkingUnit,WorkingPosition,ModelWorkderType,ModelWorkerLevel,CreateTime,SalaryPerMonth,OtherIncome,HaveAllowance,HaveMedicalTreatment,UnitLocation,Address,PhoneNumber")] ModelWorker modelWorker)
        {
            if (ModelState.IsValid)
            {
                db.ModelWorkers.Add(modelWorker);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(modelWorker);
        }

        // GET: ModelWorker/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ModelWorker modelWorker = db.ModelWorkers.Find(id);
            if (modelWorker == null)
            {
                return HttpNotFound();
            }
            return View(modelWorker);
        }

        // POST: ModelWorker/Edit/5
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,EmployeeID,WorkStatus,WorkingUnit,WorkingPosition,ModelWorkderType,ModelWorkerLevel,CreateTime,SalaryPerMonth,OtherIncome,HaveAllowance,HaveMedicalTreatment,UnitLocation,Address,PhoneNumber")] ModelWorker modelWorker)
        {
            if (ModelState.IsValid)
            {
                db.Entry(modelWorker).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(modelWorker);
        }

        // GET: ModelWorker/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ModelWorker modelWorker = db.ModelWorkers.Find(id);
            if (modelWorker == null)
            {
                return HttpNotFound();
            }
            return View(modelWorker);
        }

        // POST: ModelWorker/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ModelWorker modelWorker = db.ModelWorkers.Find(id);
            db.ModelWorkers.Remove(modelWorker);
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
