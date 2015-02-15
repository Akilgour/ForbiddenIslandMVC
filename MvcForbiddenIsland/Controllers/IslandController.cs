using MvcForbiddenIsland.DAL;
using MvcForbiddenIsland.Factory;
using MvcForbiddenIsland.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace MvcForbiddenIsland.Controllers
{
    public class IslandController : Controller
    {
        //
        // GET: /Island/

        private ForbiddenIslandContext db = new ForbiddenIslandContext();


        public ActionResult Index()
        {
            //var islandFactory = new IslandFactory();
            //Island island;

            //island = islandFactory.Create();

            //var islandTileList = db.IslandTile.ToList();
            //foreach (var islandTile in islandTileList)
            //{
            //    db.IslandTile.Remove(islandTile);
            //}

            //foreach (var item in island.IslandBoard)
            //{
            //      db.IslandTile.Add(item);
            //}

             var islandTileList = db.IslandTile.ToList();
             var playerList = db.Player.ToList();

            var islandFactory = new IslandFactory();
            Island island;

            island = islandFactory.Create(islandTileList);


            
            return View(island);
        }


        // [HttpPost]
        //public ActionResult Index()
        //{
        //   Island island = ViewBag.Island;

        //    return View(island);
        //}
 

    //    //
    //    // GET: /Island/Details/5

    //    public ActionResult Details(int id)
    //    {
    //        return View();
    //    }

    //    //
    //    // GET: /Island/Create
     //  
        [HttpPost]
        public ActionResult SelectRateBand(string id)
        {
            //Some code here
            return View();
        }

        public ActionResult Create(int Rowid, int Columnid)
        {
        return View();
        }

        public ActionResult Create(int Rowid )
        {
            return View();
        }


        public ActionResult Create()
        {
            return View();               
        }

        [HttpPost]
        public void SubmitTimesheet()
        {

            string uri = "";

            //foreach (var billingCode in model.BillingCodes)
            //{
            //    //do stuff with each of these
            //}
        }



        [HttpPost]
        public ActionResult CalculateSimpleInterestResult()
        {
            var islandFactory = new IslandFactory();


            var island = islandFactory.Create();

            return View(island);
        }

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
