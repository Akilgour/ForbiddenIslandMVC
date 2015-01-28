using MvcForbiddenIsland.Factory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcForbiddenIsland.Controllers
{
    public class IslandController : Controller
    {
        //
        // GET: /Island/

        public ActionResult Index()
        {
            var islandFactory = new IslandFactory();

            
            var island = islandFactory.Create();

            return View(island);
        }

    //    //
    //    // GET: /Island/Details/5

    //    public ActionResult Details(int id)
    //    {
    //        return View();
    //    }

    //    //
    //    // GET: /Island/Create

    //    public ActionResult Create()
    //    {
    //        return View();
    //    }

    //    //
    //    // POST: /Island/Create

    //    [HttpPost]
    //    public ActionResult Create(FormCollection collection)
    //    {
    //        try
    //        {
    //            // TODO: Add insert logic here

    //            return RedirectToAction("Index");
    //        }
    //        catch
    //        {
    //            return View();
    //        }
    //    }

    //    //
    //    // GET: /Island/Edit/5

    //    public ActionResult Edit(int id)
    //    {
    //        return View();
    //    }

    //    //
    //    // POST: /Island/Edit/5

    //    [HttpPost]
    //    public ActionResult Edit(int id, FormCollection collection)
    //    {
    //        try
    //        {
    //            // TODO: Add update logic here

    //            return RedirectToAction("Index");
    //        }
    //        catch
    //        {
    //            return View();
    //        }
    //    }

    //    //
    //    // GET: /Island/Delete/5

    //    public ActionResult Delete(int id)
    //    {
    //        return View();
    //    }

    //    //
    //    // POST: /Island/Delete/5

    //    [HttpPost]
    //    public ActionResult Delete(int id, FormCollection collection)
    //    {
    //        try
    //        {
    //            // TODO: Add delete logic here

    //            return RedirectToAction("Index");
    //        }
    //        catch
    //        {
    //            return View();
    //        }
    //    }
     }
}
