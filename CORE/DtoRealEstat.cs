using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace CORE
{
    public class DtoRealEstat
    {
        public int id_realestat { get; set; }


        [Required]
        public string libelle_realestat { get; set; }
        [Required]
        public string description_realestat { get; set; }
        public Nullable<System.DateTime> added_at { get; set; }
        public Nullable<System.DateTime> update_at { get; set; }
        public string location_realestat { get; set; }
        public string owner { get; set; }
        public Nullable<decimal> price { get; set; }
        public int type_realestat { get; set; }

        public string libelle_type_realestat { get; set; }
        public string photo_realestat { get; set; }
        public string id_publisher { get; set; }
        public string cheminPhotoPrincipale { get; set; }
        public string cheminPhoto1 { get; set; }
        public string cheminPhoto2 { get; set; }
        public string cheminPhoto3 { get; set; }

        public string is_payed { get; set; }
        [Required]
        public string numero_telephone { get; set; }
        public string is_valid { get; set; }
        public Nullable<System.DateTime> validated_at { get; set; }
        public string validated_by { get; set; }


        public HttpPostedFileBase photoPrincipale { get; set; }
        public HttpPostedFileBase photo1 { get; set; }
        public HttpPostedFileBase photo2 { get; set; }
        public HttpPostedFileBase photo3 { get; set; }
    }
}
