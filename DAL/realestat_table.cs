//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré à partir d'un modèle.
//
//     Des modifications manuelles apportées à ce fichier peuvent conduire à un comportement inattendu de votre application.
//     Les modifications manuelles apportées à ce fichier sont remplacées si le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DAL
{
    using System;
    using System.Collections.Generic;
    
    public partial class realestat_table
    {
        public int id_realestat { get; set; }
        public string libelle_realestat { get; set; }
        public string description_realestat { get; set; }
        public Nullable<System.DateTime> added_at { get; set; }
        public Nullable<System.DateTime> update_at { get; set; }
        public string location_realestat { get; set; }
        public string added_by { get; set; }
        public Nullable<decimal> price { get; set; }
        public string photo_realestat { get; set; }
        public string id_publisher { get; set; }
        public Nullable<int> id_type { get; set; }
        public string chemin_photo1 { get; set; }
        public string chemin_photo2 { get; set; }
        public string chemin_photo3 { get; set; }
        public string chemin_photo_principale { get; set; }
        public string is_payed { get; set; }
        public string numero_telephone { get; set; }
        public string is_valid { get; set; }
        public Nullable<System.DateTime> validated_at { get; set; }
        public string validated_by { get; set; }
    
        public virtual typerealstat_table typerealstat_table { get; set; }
    }
}
