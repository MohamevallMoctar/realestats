using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CORE;
using DAL;

namespace BLL
{
    public class BusinessRealEstat
    {
        realestats_dbEntities _cnx = new realestats_dbEntities();

        public List<DtoRealEstat> GetAllRealEstats() {

            List<DtoRealEstat> dtoRealEstats = new List<DtoRealEstat>();
            var entRealEstats = _cnx.realestat_table.ToList();

            foreach(var item in entRealEstats)
            {
                dtoRealEstats.Add(new DtoRealEstat
                {
                    id_realestat = item.id_realestat,
                    libelle_realestat = item.libelle_realestat,
                    description_realestat = item.description_realestat,
                    type_realestat = (int) item.id_type,
                    cheminPhotoPrincipale = item.chemin_photo_principale,
                    location_realestat = item.location_realestat,
                    price = item.price,
                    libelle_type_realestat = item.typerealstat_table.type_ar,
                    added_at = item.added_at,
                    owner = item.added_by, 
                    update_at = item.update_at,
                    photo_realestat = item.photo_realestat,

                    numero_telephone = item.numero_telephone,

                });
            }

            return dtoRealEstats;

        }

        public List<DtoRealEstat> FilterRealEstats(string criteria)
        {
            List<DtoRealEstat> dtoRealEstats = new List<DtoRealEstat>();
            var entRealEstats = _cnx.realestat_table.ToList();
            entRealEstats = entRealEstats.Where(x => x.libelle_realestat.Contains(criteria)).ToList();
            entRealEstats = entRealEstats.Where(x => x.description_realestat.Contains(criteria)).ToList();


            foreach (var item in entRealEstats)
            {
                dtoRealEstats.Add(new DtoRealEstat
                {
                    id_realestat = item.id_realestat,
                    libelle_realestat = item.libelle_realestat,
                    description_realestat = item.description_realestat,
                    type_realestat = (int)item.id_type,
                    cheminPhotoPrincipale = item.chemin_photo_principale,
                    location_realestat = item.location_realestat,
                    price = item.price,
                    libelle_type_realestat = item.typerealstat_table.type_ar,
                    added_at = item.added_at,
                    owner = item.added_by,
                    update_at = item.update_at,
                    photo_realestat = item.photo_realestat,

                    numero_telephone = item.numero_telephone,

                });
            }
            criteria = criteria.ToLower();
            return dtoRealEstats;
        }

        public List<DtoRealEstat> GetMyRealEstats(string idPublisher)
        {
            List<DtoRealEstat> dtoRealEstats = new List<DtoRealEstat>();
            var entRealEstats = _cnx.realestat_table.Where(x => x.id_publisher == idPublisher).ToList();

            foreach (var item in entRealEstats)
            {
                dtoRealEstats.Add(new DtoRealEstat
                {
                    id_realestat = item.id_realestat,
                    libelle_realestat = item.libelle_realestat,
                    description_realestat = item.description_realestat,
                    type_realestat = (int)item.id_type,
                    cheminPhotoPrincipale = item.chemin_photo_principale,
                    location_realestat = item.location_realestat,
                    price = item.price,
                    libelle_type_realestat = item.typerealstat_table.type_ar,
                    added_at = item.added_at,
                    owner = item.added_by,
                    update_at = item.update_at,
                    photo_realestat = item.photo_realestat,

                    numero_telephone = item.numero_telephone,

                });
            }

            return dtoRealEstats;
        }

        public List<DtoRealEstat> GetAllPayedRealEstats()
        {

            List<DtoRealEstat> dtoRealEstats = new List<DtoRealEstat>();
            var entRealEstats = _cnx.realestat_table.Where( x => x.is_payed == "1" ).ToList();

            foreach (var item in entRealEstats)
            {
                dtoRealEstats.Add(new DtoRealEstat
                {
                    id_realestat = item.id_realestat,
                    libelle_realestat = item.libelle_realestat,
                    description_realestat = item.description_realestat,
                    type_realestat = (int)item.id_type,
                    cheminPhotoPrincipale = item.chemin_photo_principale,
                    location_realestat = item.location_realestat,
                    price = item.price,
                    libelle_type_realestat = item.typerealstat_table.type_ar,
                    added_at = item.added_at,
                    owner = item.added_by,
                    update_at = item.update_at,
                    photo_realestat = item.photo_realestat,

                    numero_telephone = item.numero_telephone,

                });
            }

            return dtoRealEstats;

        }


        public List<DtoRealEstat> GetRealEstatsByType(int id_type)
        {

            List<DtoRealEstat> dtoRealEstats = new List<DtoRealEstat>();
            var entRealEstats = _cnx.realestat_table.Where(x => x.id_type == id_type).ToList();

            foreach (var item in entRealEstats)
            {
                dtoRealEstats.Add(new DtoRealEstat
                {
                    id_realestat = item.id_realestat,
                    libelle_realestat = item.libelle_realestat,
                    description_realestat = item.description_realestat,
                    location_realestat = item.location_realestat,
                    type_realestat = (int)item.id_type,
                    cheminPhotoPrincipale = item.chemin_photo_principale,
                    price = item.price,
                    libelle_type_realestat = item.typerealstat_table.type_ar,
                    added_at = item.added_at,
                    owner = item.added_by,
                    update_at = item.update_at,
                    photo_realestat = item.photo_realestat,

                });
            }

            return dtoRealEstats;

        }



        public bool AddRealStat(DtoRealEstat model)
        {
            try
            {
                var entRealStat = _cnx.tmp_realestat_table.Add(new tmp_realestat_table
                {
                    
                    description_realestat = model.description_realestat,
                    added_at = DateTime.Now,
                    id_type = model.type_realestat,
                    id_publisher = model.id_publisher,
                    libelle_realestat = model.libelle_realestat,
                    location_realestat = model.location_realestat,
                    photo_realestat = model.photo_realestat,
                    price = model.price,
                    added_by = model.owner,
                    numero_telephone = model.numero_telephone,
                    chemin_photo_principale = model.cheminPhotoPrincipale,
                    chemin_photo1 = model.cheminPhoto1,
                    chemin_photo2 = model.cheminPhoto2,
                    chemin_photo3 = model.cheminPhoto3,
                    //is_payed = model.is_payed,
                    is_valid = "N",
                    

                });
                _cnx.SaveChanges();
                return true;
            }
            catch (SqlException ex)
            {
                string msg = ex.Message.ToString();
                return false;
            }
           


        }

        public DtoRealEstat GetRealEstatById(int id_realestat)
        {
            DtoRealEstat dtoRealEstat = new DtoRealEstat();
            var entRealEstat = _cnx.realestat_table.Find(id_realestat);
            if(entRealEstat != null)
            {
                dtoRealEstat.id_realestat = entRealEstat.id_realestat;
                dtoRealEstat.libelle_realestat = entRealEstat.libelle_realestat;
                dtoRealEstat.description_realestat = entRealEstat.description_realestat;
                dtoRealEstat.libelle_type_realestat = entRealEstat.typerealstat_table.type_ar;
                dtoRealEstat.location_realestat = entRealEstat.location_realestat;
                dtoRealEstat.owner = entRealEstat.id_publisher;
                dtoRealEstat.id_publisher = entRealEstat.id_publisher;
                dtoRealEstat.price = entRealEstat.price;
                dtoRealEstat.added_at = entRealEstat.added_at;
                dtoRealEstat.cheminPhotoPrincipale = entRealEstat.chemin_photo_principale;
                   dtoRealEstat.cheminPhoto1 = entRealEstat.chemin_photo1;
                    dtoRealEstat.cheminPhoto2 = entRealEstat.chemin_photo2;
                    dtoRealEstat.cheminPhoto3 = entRealEstat.chemin_photo3;

                dtoRealEstat.numero_telephone = entRealEstat.numero_telephone;

            }

            return dtoRealEstat;
        }
    }
}
