using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplicationASPGarage.Models;

namespace WebApplicationASPGarage.Controllers
{
    public class VoituresController : ApiController, IDisposable
    {
        private EFVoitureDbContext _DbContext = new EFVoitureDbContext();
        /// <summary>
        /// WEB API pour récupérer la liste des voitures
        /// au format JSON
        /// 
        /// </summary>
        /// <returns>liste des voitures</returns>
        // GET api/voitures
        [HttpGet]
        public IEnumerable<Voiture> GetVoitures()
        {
            return _DbContext.Voitures.ToList();
        }

        // rechercher une voiture par son id
        // GET api/voitures/5

        /// <summary>
        /// Chercher une voiture par ID
        /// </summary>
        /// <param name="id">Voiture cherché ou HTTP not found</param>
        /// <returns></returns>
        [HttpGet]
        public Voiture GetVoiture(int id)
        {
            Voiture voiture = _DbContext.Voitures.SingleOrDefault(x => x.Numero == id);
            if (voiture == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            return voiture;
        }


        // Ajouter une voiture 
        // POST api/voitures
        [HttpPost]
        public Voiture AjoutVoiture(Voiture voiture)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            _DbContext.Voitures.Add(voiture);

            if (_DbContext.SaveChanges() > 0) return voiture;
            else
                throw new HttpResponseException(HttpStatusCode.BadRequest);
        }

        // Modifier une voiture
        // PUT api/voitures/5
        [HttpPut]
        public void ModifVoiture(Voiture voiture)
        {
            Voiture voitureAModifier = _DbContext.Voitures.SingleOrDefault(x => x.Numero == voiture.Numero);
            if (voitureAModifier == null)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            voitureAModifier.Matricule = voiture.Matricule; voitureAModifier.Nom = voiture.Nom; voitureAModifier.Marque = voiture.Marque;
            voitureAModifier.NumeroChassis = voiture.NumeroChassis; voitureAModifier.Photo = voiture.Photo;

            _DbContext.SaveChanges();
        }

        //Supprimer une voiture
        // DELETE api/voitures/5
        [HttpDelete]
        public void SupprimerVoiture(int id)
        {
            Voiture voitureASupprimer = _DbContext.Voitures.SingleOrDefault(x => x.Numero == id);
            if (voitureASupprimer == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            _DbContext.Voitures.Remove(voitureASupprimer);
            _DbContext.SaveChanges();
        }
    }
}
