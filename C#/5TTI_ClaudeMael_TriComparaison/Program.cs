using System;
using System.Diagnostics;
using System.Runtime.ExceptionServices;

namespace _5TTI_MaelAndras_TriSelection

{
    internal class Program
    {
        static void Main(string[] args)
        {
            int userInput;
            string aUser;
            char repeatProg;

            // instances
            Methodes methodes = new Methodes();
            SortingAlgorithms algos = new SortingAlgorithms();
            
            // Chronomètre
            Stopwatch chrono = new Stopwatch();
            long millisec;
            do
            {

                methodes.LireEntier("Combien d'éléments voulez-vous dans votre tableau ?", out userInput);

                // tableau random
                int[] table = methodes.TableauRandom(userInput);
                int[] tableATrier;

                Console.WriteLine("Tableau à trier : \n" + methodes.Concatene(table) + "\n-------------");

                for (int i = 0; i <= 4; i++)
                {

                    chrono = Stopwatch.StartNew();
                    tableATrier = methodes.InitiateArray(table);
                    string tri = "";
                    switch (i)
                    {
                        case 0:
                            algos.TriParSelection(ref tableATrier);
                            tri = "Tri par Sélection";
                            break;
                        case 1:
                            algos.TriIntuitif(ref tableATrier);
                            tri = "Tri Intuitif";
                            break;
                        case 2:
                            algos.TriABulle(ref tableATrier);
                            tri = "Tri à Bulle";
                            break;
                        case 3:
                            algos.TriShell(ref tableATrier);
                            tri = "Tri Shell";
                            break;
                        case 4:
                            algos.TriInsertion(ref tableATrier);
                            tri = "Tri par Insertion";
                            break;
                    }
                    chrono.Stop();
                    millisec = chrono.ElapsedMilliseconds;
                    // résultat final
                    Console.WriteLine($"{tri} : {millisec} millisecondes");
                }

                // Répéter le programme
                do
                {
                    Console.WriteLine("Voulez-vous recommencer le programme ? O = Recommencer.");
                    aUser = Console.ReadLine();
                } while (!char.TryParse(aUser, out repeatProg));
            } while (char.ToUpper(repeatProg) == 'O');

        }
    }
}