using System;
using System.Collections.Generic;
using System.Text;

namespace ModelObjet
{
    public class Document
    {
        public int IdDoc { get; set; }
        public string Titre { get; set; }
        public string Etat { get; set; }
        public int NumBibliotheque { get; set; }

        public virtual string GetInfos()
        {
            return Titre + " - " + Etat;
        }
    }
}
