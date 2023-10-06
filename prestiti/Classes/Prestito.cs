using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prestiti.Classes
{
    public class Prestito
    {   
        public double Totale { get; set; }
        public double Rata { get; set; }

        public DateTime Inizio { get; set; }
        public DateTime Fine { get;set; }

        public Banca Banca { get; set; }

        public Cliente Cliente { get; set; }

        public Prestito() { }

        public Prestito(double totale, double rata, DateTime inizio, DateTime fine)
        {
            Totale = totale;
            Rata = rata;
            Inizio = inizio;
            Fine = fine;
         
        }

        public override string ToString()
        {
            return $"Il totale è {Totale} con rate da {Rata}.\n\r Inizio prestito {Inizio}, fine prestito{Fine}";
        }
    }
}
