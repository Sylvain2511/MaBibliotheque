using Microsoft.EntityFrameworkCore.Query.Internal;
using System;
using System.Collections.Generic;
using System.Text;

namespace ModelObjet
{
    public class Film
    {
        public int IdFilm { get; set; }
        public string Titre { get; set; }
        public string Etat { get; set; }
        public int PrixFilm { get; set; }
        public string Photo { get; set; }
        public int NumDoc { get; set; }
        public int NumReal { get; set; }
        /*
        public override string GetInfos()
        {
            string infos = "";
            foreach (string s in LesActeurs)
            {
                infos = s + " - " + infos;
            }
            infos = base.GetInfos() + " - " + infos;
            return infos;
            
        }
        */

        
    }
}
