using System;
using System.Collections.Generic;
using System.Text;

namespace ModelObjet
{
    public class Livre
    {
        public int IdLivre { get; set; }
        public string Titre { get; set; }
        public string Etat { get; set; }
        public int PrixLivre { get; set; }
        public string Photo { get; set; }
        public string Resume { get; set; }
        public int NumDoc { get; set; }
        public int NumAuteur { get; set; }
    }
}
