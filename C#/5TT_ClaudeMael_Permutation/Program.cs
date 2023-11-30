using System.Runtime.Versioning;

namespace _5TT_ClaudeMael_Permutation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            char repeatProg;
            do
            {

                int[] liste = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
                uint decalage;
                do
                {
                    LireEntier("Veuillez entrer le nombre de décalage", out decalage);
                    if (!(decalage <= liste.Length))
                    {
                        Console.WriteLine("Le décalage doit être inférieur au nombre d'éléments de la liste qui est de : " + liste.Length);
                    }
                } while (!(decalage <= liste.Length));

                PermCirculaire(decalage, ref liste);
                Console.WriteLine("Voici votre liste décalée de " + decalage + "\n" + string.Join(", ", liste));
                Console.WriteLine("-------------------------");
                SuppressionsDoublons();
                string nUser;
                Console.WriteLine("Voulez-vous recommencer le programme? O = Oui");
                nUser = Console.ReadLine();
                while (!(char.TryParse(nUser, out repeatProg)))
                {
                    Console.WriteLine("Entrée incorrecte. O = Oui");
                    nUser = Console.ReadLine();
                }

            } while (char.ToUpper(repeatProg) == 'O'); 
        }

        static void SuppressionsDoublons()
        {
            int[] liste = { 3, 5, 9, 10, 12, 13, 13, 13, 13, 15, 16 };
            int size = 0;
            for (int i = 0; i < liste.Length; i++)
            {
                try
                {
                    if (liste[i] != liste[i + 1])
                    {
                        size++;
                    }
                }
                catch (Exception e)
                {
                    size++;
                }
            }
            int[] listeSansDoublons = new int[size];
            int doublonsIndex = 0;
            for (int i = 0; i < liste.Length; i++)
            {

                if (!listeSansDoublons.Contains(liste[i]))
                {

                    listeSansDoublons[doublonsIndex] = liste[i];
                    doublonsIndex++;
                }
                    Console.WriteLine(string.Join(",", listeSansDoublons));
                
            }
            
            
        }

        static void PermCirculaire(uint decalage, ref int[] liste)
        {
            for(int index = 0; index < decalage; index++)
            {
                int temp = liste[0];
                for(int j = 0; j < liste.Length; j++)
                {
                    if (j < liste.Length-1)
                    {
                        liste[j] = liste[j + 1];
                    }
                }
                liste[liste.Length - 1] = temp;
            }
        }

        static void LireEntier(string question, out uint decalage)
        {
            string nUser;
            Console.WriteLine(question);
            nUser = Console.ReadLine();
            while(!uint.TryParse(nUser, out decalage)) 
            {
                Console.WriteLine("Entrée invalide.");
                Console.WriteLine(question);
                nUser = Console.ReadLine();
            }
        }
    }
}