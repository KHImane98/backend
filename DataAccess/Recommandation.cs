//------------------------------------------------------------------------------
// <auto-generated>
//    Ce code a été généré à partir d'un modèle.
//
//    Des modifications manuelles apportées à ce fichier peuvent conduire à un comportement inattendu de votre application.
//    Les modifications manuelles apportées à ce fichier sont remplacées si le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DataAccess
{
    using System;
    using System.Collections.Generic;
    
    public partial class Recommandation
    {
        public int Id { get; set; }
        public Nullable<bool> Status { get; set; }
        public Nullable<int> Avis { get; set; }
        public string Commentaire { get; set; }
        public System.DateTime Created { get; set; }
        public System.DateTime Updated { get; set; }
        public bool Enabled { get; set; }
        public Nullable<int> UserId { get; set; }
        public Nullable<int> Personne_metierId { get; set; }
        public Nullable<int> ServiceId { get; set; }
    
        public virtual Personne_metier Personne_metier { get; set; }
        public virtual Service Service { get; set; }
        public virtual User User { get; set; }
    }
}
