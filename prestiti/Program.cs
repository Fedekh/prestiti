using prestiti.Classes;
using System;
using System.Collections.Generic;

namespace prestiti
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("QUESTI SONO I NOSTRI CLIENTI\n\r");

            List<Cliente> clientList = new List<Cliente>();
            List<Prestito> loanList = new List<Prestito>();

            Banca bank = new Banca("Banca1", clientList, loanList);

            for (int i = 1; i <= 20; i++)
            {
                Cliente cliente = new Cliente($"Cliente {i}", $"2{i}", i * 1000);
                clientList.Add(cliente);
            }

            Random random = new Random();
            for (int i = 1; i <= 30; i++)
            {
                double totale = random.Next(5000, 20000);
                double rata = totale / random.Next(12, 60);
                DateTime inizio = DateTime.Now.AddDays(-random.Next(1, 365));
                DateTime fine = inizio.AddMonths(random.Next(12, 60));
                Cliente cliente = clientList[random.Next(clientList.Count)];

                Prestito prestito = new Prestito(totale, rata, inizio, fine);
                loanList.Add(prestito);

                cliente.Prestiti.Add(prestito);
            }

            int numero = 0;
            while (numero != 8)
            {
                Console.WriteLine("\n\rChe vuoi fare?\n\r1) Visualizza tutti i clienti\n\r2) Aggiungi cliente\n\r3) Modifica cliente\n\r4) Vedere info cliente\n\r5) Cancellare cliente\n\r6) Vedere prestito in base al codice fiscale\n\r7)Aggiungi un prestito \n\r8) Esci\n\r");

                if (int.TryParse(Console.ReadLine(), out numero))
                {
                    switch (numero)
                    {
                        case 1:
                            Console.WriteLine($"Lista di tutti i clienti: ({clientList.Count})");
                            foreach (Cliente c in clientList)
                            {
                                Console.WriteLine(c);
                            }
                            break;

                        case 2:
                            Console.WriteLine("Inserisci tutti i dati del nuovo cliente:");
                            Console.Write("Nome: ");
                            string name = Console.ReadLine();
                            Console.Write("Codice fiscale: ");
                            string codice = Console.ReadLine();
                            Console.Write("Stipendio: ");
                            double stipendio;
                            while (!double.TryParse(Console.ReadLine(), out stipendio))
                            {
                                Console.WriteLine("Inserisci un valore valido per lo stipendio.");
                            }
                            bank.AddCliente(new Cliente(name, codice, stipendio));
                            break;

                        case 3:
                            Console.WriteLine("Cerca cliente per codice fiscale:");
                            string codice1 = Console.ReadLine();
                            Cliente clienteDaModificare = bank.SearchCliente(codice1);

                            if (clienteDaModificare != null)
                            {
                                Console.WriteLine($"Cliente trovato: {clienteDaModificare}");
                                Console.WriteLine("Modifica i campi reinserendo nome, codice fiscale e stipendio:");
                                Console.Write("Nuovo nome: ");
                                string newName = Console.ReadLine();
                                Console.Write("Nuovo codice fiscale: ");
                                string newCode = Console.ReadLine();
                                Console.Write("Nuovo stipendio: ");
                                double newStipendio;
                                while (!double.TryParse(Console.ReadLine(), out newStipendio))
                                {
                                    Console.WriteLine("Inserisci un valore valido per lo stipendio.");
                                }

                                bank.UpdateCliente(codice1, new Cliente(newName, newCode, newStipendio));
                                Console.WriteLine("Cliente aggiornato con successo.");
                            }
                            else
                            {
                                Console.WriteLine("Cliente non trovato.");
                            }
                            break;

                        case 4:
                            Console.WriteLine("Cerca cliente per codice fiscale:");
                            string codice2 = Console.ReadLine();
                            Cliente clienteDaVisualizzare = bank.SearchCliente(codice2);

                            if (clienteDaVisualizzare != null)
                            {
                                Console.WriteLine($"Cliente trovato: {clienteDaVisualizzare}");
                            }
                            else
                            {
                                Console.WriteLine("Cliente non trovato.");
                            }
                            break;

                        case 5:
                            Console.WriteLine("Elimina cliente per codice fiscale:");
                            string codice3 = Console.ReadLine();
                            bank.RemoveCliente(codice3);
                            break;

                        case 6:
                            Console.WriteLine("Cerca tutti i prestiti di un cliente per codice fiscale:");
                            string codice4 = Console.ReadLine();
                            Cliente clienteForPrint = bank.SearchCliente(codice4);

                            if (clienteForPrint != null)
                            {
                                Console.WriteLine($"Prestiti per il cliente con codice fiscale {codice4}:");
                                foreach (var prestito in clienteForPrint.Prestiti)
                                {
                                    Console.WriteLine(prestito.ToString());
                                }
                            }
                            else
                            {
                                Console.WriteLine("Cliente non trovato.");
                            }
                            break;

                        case 7:
                            Console.WriteLine("Aggiungi un prestito a un cliente:");
                            Console.Write("Inserisci il codice fiscale del cliente: ");
                            string codiceFiscaleCliente = Console.ReadLine();

                            Cliente cliente = bank.SearchCliente(codiceFiscaleCliente);

                            if (cliente != null)
                            {
                                Console.Write("Inserisci l'importo totale del prestito: ");
                                double totalePrestito;
                                if (double.TryParse(Console.ReadLine(), out totalePrestito))
                                {
                                    Console.Write("Inserisci l'importo della rata: ");
                                    double rataPrestito;
                                    if (double.TryParse(Console.ReadLine(), out rataPrestito))
                                    {

                                        Prestito nuovoPrestito = new Prestito
                                        {
                                            Totale = totalePrestito,
                                            Rata = rataPrestito,
                                            Inizio = DateTime.Now,
                                            Fine = DateTime.Now.AddMonths(1)
                                        };

                                        cliente.Prestiti.Add(nuovoPrestito);
                                        nuovoPrestito.Cliente = cliente;

                                        Console.WriteLine("Prestito aggiunto con successo:");
                                        
                                        foreach (var prestito in cliente.Prestiti)
                                        {
                                            Console.WriteLine($"Cliente: {cliente.Name}, Codice Fiscale: {cliente.CodiceFiscale}\n\rPrestito: {prestito.Totale}, Data Inizio: {prestito.Inizio:dd/MM/yyyy}, Data Fine: {prestito.Fine:dd/MM/yyyy}");
                                        }
                                        Console.ReadLine(); 
                                    }
                                    else
                                    {
                                        Console.WriteLine("Inserisci un importo valido per la rata del prestito.");
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Inserisci un importo valido per il totale del prestito.");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Cliente non trovato. Impossibile aggiungere il prestito.");
                            }
                            break;




                        case 8:
                            Console.WriteLine("Programma terminato.");
                            break;

                    }
                }
                else
                {
                    Console.WriteLine("Inserisci un numero valido da 1 a 7.");
                }
            }
        }
    }
}
