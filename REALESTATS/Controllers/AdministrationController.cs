using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL;
using CORE;

namespace REALESTATS.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdministrationController : Controller
    {
        BusinessAdmin busAdmin = new BusinessAdmin();
        BusinessRef busRef = new BusinessRef();
        
        // GET: Administration
        public ActionResult Index()
        {
            
            return RedirectToAction("Publications");
        }



        // all temp Publications
        public ActionResult Publications()
        {
            List<DtoRealEstat> dtoTmpRealEstats = new List<DtoRealEstat>();
            dtoTmpRealEstats = busAdmin.GetAllTmpRealEstats();

            return View(dtoTmpRealEstats);
        }

        public ActionResult Details(int id_realestat)
        {

            DtoRealEstat model = new DtoRealEstat();

            model = busAdmin.GetTmpRealEstatById(id_realestat);
            return View(model);
        }

        // Validate  Publication
        public ActionResult Validate(int id)
        {
            DtoRealEstat dtoRealEstat = new DtoRealEstat();
            dtoRealEstat = busAdmin.GetTmpRealEstatById(id);
            return View(dtoRealEstat);
        }

        //  Validate Publication
        [HttpPost]
        public ActionResult Validate(DtoRealEstat model)
        {

            bool result  = busAdmin.ValidateRealEstats(model);
            if (result)
            {

                TempData["success"] = Resource.Successfully;
                return RedirectToAction("Publications");

            }
            else
            {
                TempData["error"] = Resource.ErrorOccured;
                return RedirectToAction("Liste");
            }
        }


        // Validate  Publication
        public ActionResult Delete(int id)
        {
            DtoRealEstat dtoRealEstat = new DtoRealEstat();
            dtoRealEstat = busAdmin.GetTmpRealEstatById(id);
            return View(dtoRealEstat);
        }

        //  Validate Publication
        [HttpPost]
        public ActionResult Delete(DtoRealEstat model)
        {
            
            
            bool result  = busAdmin.DeleteTmpRealEstat(model);
            if (result)
            {

                TempData["success"] = Resource.Successfully;
                return RedirectToAction("Publications");

            }
            else
            {
                TempData["error"] = Resource.ErrorOccured;
                return RedirectToAction("Publications");
            }
        }


        // All Validated  Publications
        public ActionResult ValidatePublications()
        {
            List<DtoRealEstat> dtoRealEstats = new List<DtoRealEstat>();
            dtoRealEstats = busAdmin.GetAllValidatedRealEstats();
            return View(dtoRealEstats);
        }

        //Users
        public ActionResult Users()
        {
            List<DtoUser> dtoUsers = new List<DtoUser>();
             dtoUsers = busAdmin.GetAllUsers();
           
            return View(dtoUsers);
        }

        public ActionResult Types()
        {
            List<DtoTypeRealStat> dtoTypeRealStats = new List<DtoTypeRealStat>();
            dtoTypeRealStats = busRef.GetAllTypeeRealStats();

            return View(dtoTypeRealStats);
                
        }

        public ActionResult AddType()
        {
            return View();
        }

        [HttpPost]

        public ActionResult AddType(DtoTypeRealStat model)
        {
            if (ModelState.IsValid)
            {
                bool result = busAdmin.AddType(model);
                if (result)
                {
                    TempData["success"] = Resource.Successfully;
                    return View(new DtoTypeRealStat());
                }
                else
                {
                    TempData["error"] = Resource.ErrorOccured;

                    return View(model);
                }
            }
            else
            {
                TempData["error"] = Resource.ErrorOccured;

                return View(model);

            }
        }



        // adminisrationController class end 
    }
}