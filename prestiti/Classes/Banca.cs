using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prestiti.Classes
{
    public class Banca
    {
        public string Name { get; set; }
        public List<Cliente> Clienti { get; set; }

        public List<Prestito> Prestiti { get; set; }
        public Banca()
        {
          
            
        }
        public Banca(string name, List<Cliente> clienti, List<Prestito> prestiti)
        {
            Name = name;
            Clienti = clienti;
            Prestiti = prestiti;
        }

        public List<Cliente> GetClienti()
        {
            return Clienti.ToList();
        }

        public void AddCliente(Cliente cliente)
        {
            Clienti.Add(cliente);
            Console.WriteLine($"Cliente {cliente.Name} inserito correttamente");
        }
        public void RemoveCliente(string codiceFiscale)
        {
            Cliente clienteDaRimuovere = Clienti.FirstOrDefault(c => c.CodiceFiscale == codiceFiscale);

            if (clienteDaRimuovere != null)
            {
                Clienti.Remove(clienteDaRimuovere);
                Console.WriteLine($"{clienteDaRimuovere.Name} è stato rimosso.");
            }
            else
            {
                Console.WriteLine("Cliente non trovato.");
            }
        }
        public Cliente SearchCliente(string codiceFiscale)
        {
            return Clienti.FirstOrDefault(c => c.CodiceFiscale == codiceFiscale);
        }
        public void UpdateCliente(string codiceFiscale, Cliente newCliente)
        {
            Cliente clienteDaModificare = SearchCliente(codiceFiscale);

            if (clienteDaModificare != null)
            {
                clienteDaModificare.Name = newCliente.Name;
                clienteDaModificare.CodiceFiscale = newCliente.CodiceFiscale;
                Console.WriteLine($"{clienteDaModificare.Name} è stato modificato correttamente.");
            }
            else
            {
                Console.WriteLine("Cliente non trovato.");
            }
        }


        public List<Prestito> GetTotalPrestiti(string codice)
        {
            if (!string.IsNullOrEmpty(codice) && Prestiti != null)
            {
                List<Prestito> totalPrestiti = Prestiti.Where(p => p.Cliente != null && p.Cliente.CodiceFiscale == codice).ToList();
                return totalPrestiti;
            }
            return new List<Prestito>(); 
        }

        public void PrintAllPrestitiOfCliente(string codice)
        {
            List<Prestito> prestitiCliente = GetTotalPrestiti(codice);

            if (prestitiCliente.Count > 0) 
            {
                Console.WriteLine($"Prestiti per il cliente con codice fiscale {codice}:");
                foreach (var prestito in prestitiCliente)
                {
                    Console.WriteLine(prestito.ToString());
                }
            }
            else
            {
                Console.WriteLine("Nessun prestito trovato per questo cliente.");
            }
        }



        public void AddPrestitoToCliente(string codiceFiscale, Prestito prestito)
        {
            Cliente cliente = Clienti.FirstOrDefault(c => c.CodiceFiscale == codiceFiscale);

            if (cliente != null)
            {
                cliente.Prestiti.Add(prestito);
                prestito.Cliente = cliente;
                Console.WriteLine($"Prestito aggiunto al cliente {cliente.Name} con successo.");
            }
            else
            {
                Console.WriteLine("Cliente non trovato. Impossibile aggiungere il prestito.");
            }
        }





    }
}
