using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prestiti.Classes
{
    public class Cliente
    {
        public string Name { get; set; }
        public string CodiceFiscale { get; set; }
        public double Stipendio { get; set; }

        public Banca Banca { get; set; }

        public List<Prestito> Prestiti { get; set; } = new List<Prestito>();
       public Cliente() { }

        public Cliente( string name, string codice, double stipendio)
        {
            Name = name;
            CodiceFiscale = codice;
            Stipendio = stipendio;

        }

      
        public override string ToString()
        {
            return $"\n\rNome Cliente: {Name}\n - Codice fiscale: {CodiceFiscale}\n Stipendio percepito: {Stipendio} € \n\r";
        }
    }
}
