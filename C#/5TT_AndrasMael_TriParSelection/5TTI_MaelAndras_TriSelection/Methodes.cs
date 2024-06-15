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
    }
}
