using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL;
using CORE;
using REALESTATS.Models;

namespace REALESTATS.Controllers
{
    public class HomeController : Controller
    {
        BusinessRealEstat businessRealEstat = new BusinessRealEstat();
        BusinessRef busRef = new BusinessRef();

        public ActionResult Index()
        {

            return RedirectToAction("Liste");
        }

        public ActionResult Filter()
        {
            List<DtoRealEstat> dtoRealEstats = new List<DtoRealEstat>();

            dtoRealEstats = businessRealEstat.FilterRealEstats("");
            ViewBag.listTypeRealEstat = busRef.GetAllTypeeRealStats();

            return View(dtoRealEstats);
        }
        [HttpPost]
        public ActionResult Filter(string criteria)
        {
            List<DtoRealEstat> dtoRealEstats = new List<DtoRealEstat>();

            dtoRealEstats = businessRealEstat.FilterRealEstats(criteria);
            ViewBag.listTypeRealEstat = busRef.GetAllTypeeRealStats();
 
            return View( dtoRealEstats);
        }


        public ActionResult MyPublications() {
            List<DtoRealEstat> dtoRealEstats = new List<DtoRealEstat>();
            string idPublisher = User.Identity.Name;
            dtoRealEstats = businessRealEstat.GetMyRealEstats(idPublisher);
            ViewBag.listTypeRealEstat = busRef.GetAllTypeeRealStats();
            return View(dtoRealEstats);
        }

        public ActionResult ChangeLanguage(string lang)
        {
            Session["lang"] = lang;
            return RedirectToAction("Index", "Home", new { language = lang });
        }

        public ActionResult Liste()
        {
            List<DtoRealEstat> dtoRealEstats = new List<DtoRealEstat>();

            dtoRealEstats = businessRealEstat.GetAllRealEstats();
            ViewBag.listTypeRealEstat = busRef.GetAllTypeeRealStats();
            return View(dtoRealEstats);
        }

        [Authorize]
        public ActionResult Create()
        {
            ViewBag.listTypeRealStat = busRef.GetAllTypeeRealStats();

            return View();
        }

        [Authorize]

        [HttpPost]
        public ActionResult Create(ModelRealEstat model)
        {
             
            if (ModelState.IsValid)
            {
                if (User.Identity.IsAuthenticated) model.id_publisher = User.Identity.Name;

                string pathImages = System.Configuration.ConfigurationManager.AppSettings["imagesPath"];

                if (model.photoPrincipale != null)
                {
                    string FileName = Path.GetFileNameWithoutExtension(model.photoPrincipale.FileName);

                    //To Get File Extension  
                    string FileExtension = Path.GetExtension(model.photoPrincipale.FileName);

                    //Add Current Date To Attached File Name  
                    FileName = DateTime.Now.ToString("yyyyMMddHHmmss") + "-" + FileName.Trim() + FileExtension;

                    //var cheminRapport = Path.Combine("", pathImages + "/");
                    var path = Path.Combine(Server.MapPath(pathImages), FileName);

                    model.photoPrincipale.SaveAs(path);
                    model.cheminPhotoPrincipale = pathImages + FileName;
                }


                if (model.photo1 != null)
                {
                    string FileName = Path.GetFileNameWithoutExtension(model.photo1.FileName);

                    //To Get File Extension  
                    string FileExtension = Path.GetExtension(model.photo1.FileName);

                    //Add Current Date To Attached File Name  
                    FileName = DateTime.Now.ToString("yyyyMMddHHmmss") + "-" + FileName.Trim() + FileExtension;

                    //var cheminRapport = Path.Combine("", pathImages + "/");
                    var path = Path.Combine(Server.MapPath(pathImages), FileName);

                    model.photo1.SaveAs(path);
                    model.cheminPhoto1 = pathImages + FileName;
                }

                if (model.photo2 != null)
                {
                    string FileName = Path.GetFileNameWithoutExtension(model.photo2.FileName);

                    //To Get File Extension  
                    string FileExtension = Path.GetExtension(model.photo2.FileName);

                    //Add Current Date To Attached File Name  
                    FileName = DateTime.Now.ToString("yyyyMMddHHmmss") + "-" + FileName.Trim() + FileExtension;

                    //var cheminRapport = Path.Combine("", pathImages + "/");
                    var path = Path.Combine(Server.MapPath(pathImages), FileName);

                    model.photo2.SaveAs(path);
                    model.cheminPhoto2 = pathImages + FileName;
                }
                if (model.photo3 != null)
                {
                    string FileName = Path.GetFileNameWithoutExtension(model.photo3.FileName);

                    //To Get File Extension  
                    string FileExtension = Path.GetExtension(model.photo3.FileName);

                    //Add Current Date To Attached File Name  
                    FileName = DateTime.Now.ToString("yyyyMMddHHmmss") + "-" + FileName.Trim() + FileExtension;

                    //var cheminRapport = Path.Combine("", pathImages + "/");
                    var path = Path.Combine(Server.MapPath(pathImages), FileName);

                    model.photo3.SaveAs(path);
                    model.cheminPhoto3 = pathImages + FileName;
                }

                DtoRealEstat dtoRealEstat = new DtoRealEstat();


                dtoRealEstat.description_realestat = model.description_realestat;
                    dtoRealEstat.added_at = DateTime.Now;
                    dtoRealEstat.type_realestat = model.type_realestat;
                    dtoRealEstat.id_publisher = model.id_publisher;
                    dtoRealEstat.libelle_realestat = model.libelle_realestat;
                    dtoRealEstat.location_realestat = model.location_realestat;
                    dtoRealEstat.photo_realestat = model.photo_realestat;
                    dtoRealEstat.price = model.price;
                    dtoRealEstat.owner = model.owner;
                    dtoRealEstat.numero_telephone = model.numero_telephone;
                    dtoRealEstat.cheminPhotoPrincipale = model.cheminPhotoPrincipale;
                    dtoRealEstat.cheminPhoto1 = model.cheminPhoto1;
                    dtoRealEstat.cheminPhoto2 = model.cheminPhoto2;
                    dtoRealEstat.cheminPhoto3 = model.cheminPhoto3;
                    //is_payed = model.is_payed,
                    dtoRealEstat.is_valid = "N";
                    


                bool result = businessRealEstat.AddRealStat(dtoRealEstat);
                if (result)
                {
                    TempData["success"] = Resource.Successfully;
                    return RedirectToAction("Liste");
                }
                else
                {
                    TempData["error"] = Resource.ErrorOccured;

                    ViewBag.listTypeRealStat = busRef.GetAllTypeeRealStats();

                    return View(model);
                }
            }
                ViewBag.listTypeRealStat = busRef.GetAllTypeeRealStats();

                return View(model);
        }

        public ActionResult Details(int id_realestat) {

            DtoRealEstat model = new DtoRealEstat();

            model = businessRealEstat.GetRealEstatById(id_realestat);
            return View(model);
        }

        public List<DtoRealEstat> ByType(int id_type) {

            List<DtoRealEstat> dtoRealEstatsByType = new List<DtoRealEstat>();
            dtoRealEstatsByType = businessRealEstat.GetRealEstatsByType(id_type);

            return dtoRealEstatsByType;
        
        }



        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}