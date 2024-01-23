using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5TTI_MaelAndras_TriSelection
{
    public struct Methodes
    {

        public int[] TableauRandom(int tailleTableau)
        {

            //création d'un tableau aléatoire
            int[] tableau = new int[tailleTableau];
            Random alea = new Random();

            for (int i = 0; i < tailleTableau; i++)
            {
                tableau[i] = alea.Next(1, 101);

            }
            return tableau;

        }

        public int[] InitiateArray(int[] tableau)
        {
            int[] initiatedArray = new int[tableau.Length];
            for (int i = 0; i < tableau.Length; i++)
            {
                initiatedArray[i] = tableau[i];
            }
            return initiatedArray;
        }
        public string Concatene(int[] tableau)
        {
            string message = "";
            for(int i = 0;i < tableau.Length; i++)
            {
                message = message + tableau[i];
                if(i+1 < tableau.Length)
                {
                    message += ", ";
                }
            }
            return message;
        }

        public void LireEntier(string question, out int n)
        {
            string nUser;
            Console.Write(question);
            nUser = Console.ReadLine();
            while (!int.TryParse(nUser, out n))
            {
                Console.WriteLine("Attention ! vous devez taper un nombre réel !");
                nUser = Console.ReadLine();
            }
        }

    }
}
