using System;
using System.Collections.Generic;
using System.Text;

namespace ModelObjet
{
    public class Bibliotheque
    {
        public int IdBibliotheque { get; set; }
        public string NomBibliotheque { get; set; }


        /*
        public void AjouterUnDocument(Document unDocument)
        {
            LesDocuments.Add(unDocument);
        }
        

        public List<Livre> GetLesLivres()
        {
            return LesDocuments.OfType<Livre>().ToList();
        }
        public List<Film> GetLesFilms()
        {
            return LesDocuments.OfType<Film>().ToList();
        }
        */
    }
}
