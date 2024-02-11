using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using CORE;
using System.Data.SqlClient;

namespace BLL
{
    public class BusinessAdmin
    {
        realestats_dbEntities _cnx = new realestats_dbEntities();

        public List<DtoRole> GetAllRoles() {

            var entRoles = _cnx.AspNetRoles.ToList();
            List<DtoRole> dtoRoles = new List<DtoRole>();
            foreach(var item in entRoles)
            {
                dtoRoles.Add(new DtoRole
                {
                    id_role = item.Id,
                    libelle_role = item.Name,
                });
            }

            return dtoRoles;
        }

        public List<DtoRealEstat> GetAllTmpRealEstats()
        {
            List<DtoRealEstat> dtoTmpRealEstats = new List<DtoRealEstat>();
            var entTmpRealEstats = _cnx.tmp_realestat_table.ToList();

            foreach(var item in entTmpRealEstats)
            {
                dtoTmpRealEstats.Add(new DtoRealEstat
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

            return dtoTmpRealEstats;
        }

        public bool ValidateRealEstats(DtoRealEstat model)
        {
            try
            {

                var entREalEstat = _cnx.tmp_realestat_table.Find(model.id_realestat);
                entREalEstat.is_valid = "O";
                //_cnx.SaveChanges();
                _cnx.realestat_table.Add(new realestat_table
                {
                    description_realestat = entREalEstat.description_realestat,
                    added_at = entREalEstat.added_at,
                    added_by = entREalEstat.added_by,
                    chemin_photo1 = entREalEstat.chemin_photo1,
                    chemin_photo2 = entREalEstat.chemin_photo2,
                    chemin_photo3 = entREalEstat.chemin_photo3,
                    chemin_photo_principale = entREalEstat.chemin_photo_principale,
                    id_publisher = entREalEstat.id_publisher,
                    id_type = entREalEstat.id_type,
                    is_payed = entREalEstat.is_payed,
                    is_valid = entREalEstat.is_valid,
                    libelle_realestat = entREalEstat.libelle_realestat,
                    location_realestat = entREalEstat.location_realestat,
                    numero_telephone = entREalEstat.numero_telephone,
                    price = entREalEstat.price,
                    typerealstat_table = entREalEstat.typerealstat_table,
                    update_at = DateTime.Now,
                    validated_at = DateTime.Now,
                    validated_by = entREalEstat.validated_by,



                });

                //_cnx.SaveChanges();
             
                // delete from tmp table 
                _cnx.tmp_realestat_table.Remove(entREalEstat);


                _cnx.SaveChanges();

                return true;
            }
            catch (SqlException ex)
            {

                string msg = ex.Message.ToString();
                return false;
            }

        }

        public bool DeleteRealEstat(DtoRealEstat model)
        {

            DtoRealEstat dtoRealEstat = new DtoRealEstat();
            var entRealEstat = _cnx.realestat_table.Find(model.id_realestat);
            try
            {
                _cnx.realestat_table.Remove(entRealEstat);
                _cnx.SaveChanges();
                return true;

            }
            catch (Exception ex)
            {
                string msg = ex.Message.ToString();
                return false;
            }

        }

        public bool DeleteTmpRealEstat(DtoRealEstat model)
        {

            var entRealEstat = _cnx.tmp_realestat_table.Find(model.id_realestat);
            try
            {
                _cnx.tmp_realestat_table.Remove(entRealEstat);
                _cnx.SaveChanges();
                return true;

            }
            catch (Exception ex)
            {
                string msg = ex.Message.ToString();
                return false;
            }

        }

        public List<DtoRealEstat> GetAllValidatedRealEstats()
        {
            List<DtoRealEstat> dtoTmpRealEstats = new List<DtoRealEstat>();
            var entTmpRealEstats = _cnx.tmp_realestat_table.Where(x => x.is_valid == "1").ToList();

            foreach (var item in entTmpRealEstats)
            {
                dtoTmpRealEstats.Add(new DtoRealEstat
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
                    validated_at = item.validated_at,
                    validated_by = item.validated_by,
                    is_payed = item.is_payed,


                });
            }

            return dtoTmpRealEstats;
        }

        public bool AddType(DtoTypeRealStat model)
        {
            try
            {

                var entType = _cnx.typerealstat_table.Add(new typerealstat_table
                {
                    type_ar = model.type_ar,
                    type_fr = model.type_fr
                });
                _cnx.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                string msg = ex.Message.ToString();
                return false;
            }

        }

        public DtoRealEstat GetRealEstatById(int id_realestat)
        {
            DtoRealEstat dtoRealEstat = new DtoRealEstat();
            var entRealEstat = _cnx.realestat_table.Find(id_realestat);
            if (entRealEstat != null)
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

            }

            return dtoRealEstat;
        }

        public DtoRealEstat GetTmpRealEstatById(int id_realestat)
        {
            DtoRealEstat dtoRealEstat = new DtoRealEstat();
            var entRealEstat = _cnx.tmp_realestat_table.Find(id_realestat);
            if (entRealEstat != null)
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

        public List<DtoUser> GetAllUsers() {

            var entUsers = _cnx.AspNetUsers.ToList();
            List<DtoUser> dtoUsers = new List<DtoUser>();
            foreach(var itemUser in entUsers)
            {
                dtoUsers.Add(new DtoUser
                {
                    id_user = itemUser.Id,
                    userName = itemUser.UserName,
                    //role = itemUser.
                    //role = itemUser.
                });

            }

            return dtoUsers;

        }

        // businessAdmin class end
    }
}
