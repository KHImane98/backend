using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API1.ViewModels
{
    public class AddRecomViewModel
    {
        public string Commentaire { get; set; }
        public int? Avis { get; set; }
        public int categorieId { get; set; }

        public int? personne_metierId { get; set; }
        public int? serviceId { get; set; }

    }
    public class RecommandationModel
    {
        public string Commentaire { get; set; }
        public int? Avis { get; set; }
        public int? Id { get; set; }
        public Service Service { get; set; }

        public Personne_metier Personne_metier { get; set; }

    }
    public class ServiceModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    public class Personne_metierModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}