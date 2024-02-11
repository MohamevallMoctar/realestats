using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace REALESTATS.Models
{
    public class ModelRealEstat
    {
        public int id_realestat { get; set; }


        [Required(ErrorMessageResourceType = (typeof(REALESTATS.Resource)), ErrorMessageResourceName = "MessagePublicationNameRequired")]
        public string libelle_realestat { get; set; }
        [Required(ErrorMessageResourceType = (typeof(REALESTATS.Resource)), ErrorMessageResourceName = "MessagePublicationDescRequired")]

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
        [Required(ErrorMessageResourceType = (typeof(REALESTATS.Resource)), ErrorMessageResourceName = "MessagePublicationPhoneRequired")]
        [MaxLength(8, ErrorMessageResourceName = "MessagePublicationPhoneMaxLength", ErrorMessageResourceType = (typeof(REALESTATS.Resource)))]

        [MinLength(8, ErrorMessageResourceName = "MessagePublicationPhoneMinLength", ErrorMessageResourceType = (typeof(REALESTATS.Resource)))]

        //[DataType(DataType.PhoneNumber, ErrorMessageResourceName = "MessagePublicationPhoneOnlyDigits", ErrorMessageResourceType = (typeof(REALESTATS.Resource)))]


        public string numero_telephone { get; set; }
        public string is_valid { get; set; }
        public Nullable<System.DateTime> validated_at { get; set; }
        public string validated_by { get; set; }


        [Required(ErrorMessageResourceType = (typeof(REALESTATS.Resource)), ErrorMessageResourceName = "MessagePublicationPhotoPrincipaleRequired")]
        public HttpPostedFileBase photoPrincipale { get; set; }
        public HttpPostedFileBase photo1 { get; set; }
        public HttpPostedFileBase photo2 { get; set; }
        public HttpPostedFileBase photo3 { get; set; }
    }
}
