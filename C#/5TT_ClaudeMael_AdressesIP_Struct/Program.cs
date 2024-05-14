using System.Data;
using System.Reflection;

namespace _5TT_ClaudeMael_AdressesIP
{
    internal class Program
    {
        static void Main(string[] args)
        {

            const int maxLength = 20;

            AdresseIP[] adressesIP = new AdresseIP[maxLength];
            for(int i = 0; i < maxLength; i++)
            {
                adressesIP[i] = new AdresseIP();
            }
            string nom;
            int pointer = 0;
            bool stopProg = false;


            Methodes methodes = new Methodes();

                
            

            Console.WriteLine("1: Ajouter une adresse IP\n" +
                "2: Consulter la liste des adresses IP\n" +
               "3: Arrêter le programme\n");
            Console.WriteLine("> Bienvenue dans votre gestionnaire d'adresse IP.");
            do
            {
                switch (Console.ReadKey().Key)
                {

                    // Enregistrer une adresse IP
                    case ConsoleKey.NumPad1:
                        Console.Clear();
                        methodes.LireAdresseIp(out byte[] ip);

                        if(methodes.AjouteAdresseIp(ip, pointer, ref adressesIP))
                        {

                            Console.WriteLine("Quel nom voulez-vous associer à cette adresse IP ?");
                            nom = Console.ReadLine();
                            methodes.AjouteNom(nom, ref pointer, ref adressesIP);
                            Console.Clear();
                            Console.WriteLine("1: Ajouter une adresse IP\n" +
                            "2: Consulter la liste des adresses IP\n" +
                           "3: Arrêter le programme\n");
                            Console.WriteLine("> Adresse " + methodes.ConcateneAdresse(ip) + " ajoutée au nom de " + nom);
                        }
                        else
                        {
                            Console.Clear();
                           Console.WriteLine("1: Ajouter une adresse IP\n" +
                           "2: Consulter la liste des adresses IP\n" +
                          "3: Arrêter le programme\n");

                            Console.WriteLine("> La liste est pleine, impossible d'encoder une nouvelle IP.");
                        }
                        break;

                    // Consulter la liste des adresses IP enregistrées
                    case ConsoleKey.NumPad2:

                        Console.Clear();
                        Console.WriteLine("1: Ajouter une adresse IP\n" +
                        "2: Consulter la liste des adresses IP\n" +
                       "3: Arrêter le programme\n");

                        if(pointer == 0)
                        {
                            Console.WriteLine("> La liste d'adresse IP est vide.");
                        }
                        else
                        {
                            Console.WriteLine(methodes.ConcateneTout(pointer, adressesIP));
                        }
                        break;

                    // Arrêter le programme
                    case ConsoleKey.NumPad3:
                        Console.Clear();
                        Console.WriteLine("> Merci d'avoir utilisé notre programme.");
                        stopProg = true;
                        break;
                }

            } while (stopProg == false);
        }
    }
}