using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5TTI_ClaudeMael_Transposition
{
    public struct Methods
    {

        public string RetireEspaces(string chaine)
        {
            string chaineFinale = "";
            int length = chaine.Length;
            for(int i = 0; i < length; i++)
            {
                if (chaine[i] != ' ')
                {
                    chaineFinale += chaine[i];
                }
            }
            return chaineFinale;
        }


        public void CreerMatrice(string key, string texte, out char[,] matrice)
        {
            int d1 = (texte.Length / key.Length) + 2;
            int d2 = key.Length;
            if(texte.Length % key.Length != 0)
            {
                d1 += 1;
            }
            matrice = new char[d1, d2];
        }

        public void EcritChainesDansMatrice(string key, string texte, ref char[,] matrice)
        {
            for(int i = 0;i < matrice.GetLength(1) ;i++) 
            {
                matrice[0, i] = key[i];
            }
            int k = 0;
            for(int i = 2; i < matrice.GetLength(0); i++)
            {
                int j = 0;
                while(j < matrice.GetLength(1) && k < texte.Length)
                {
                    matrice[i, j] = texte[k];
                    k++;
                    j++;
                }
            }
        }

        public void triLigne1(ref char[,] matrice)
        {
            bool permut;
            do
            {
                permut = false;
                for( int i = 0; i < matrice.GetLength(1)-1; i++)
                {
                    if (matrice[0, i] > matrice[0, i + 1])
                    {
                        char x = matrice[0, i];
                        matrice[0, i] = matrice[0, i + 1];
                        matrice[0,i + 1] = x;
                        permut = true;

                    }
                }
            } while (permut == true);
        }

        public void CreerMatriceOutil(string key, out char[,] matriceTriee)
        {
            matriceTriee = new char[3, key.Length];
            for(int i = 0; i < matriceTriee.GetLength(1); i++)
            {
                matriceTriee[0, i] = key[i];
                matriceTriee[2, i] = '0';
            }
            triLigne1(ref matriceTriee);

            for(int i = 1; i <= matriceTriee.GetLength(1); i++)
            {
                matriceTriee[1, i - 1] = Char.Parse(i.ToString());
            }
        }


        public void ReporteOrdre(ref char[,] matrice, ref char[,] matriceOutil)
        {
            for(int i = 0; i < matrice.GetLength(1); i++)
            {
                bool trouve = false;
                int j = 0;
                while (trouve == false && j < matriceOutil.GetLength(1))
                {
                    if ((matrice[0, i] == matriceOutil[0, j]) && (matriceOutil[2, j] != '1'))
                    {
                        matrice[1, i] = matriceOutil[1, j];
                        matriceOutil[2, j] = '1';
                        trouve = true;
                    }
                    j++;
                }
            }
        }

        public string ConstruitCryptage(char[,] matrice)
        {
            int i = 1;
            string chaineCrypt = "";
            while (i <= matrice.GetLength(1))
            {
                
                bool trouve = false;
                int j = 0;
                while(!trouve && j < matrice.GetLength(1))
                {
                    if(char.Parse(i.ToString()) == matrice[1, j])
                    {
                        for (int k = 2; k < matrice.GetLength(0); k++)
                        {
                            chaineCrypt += matrice[k, j];
                        }

                        chaineCrypt += " ";
                        trouve = true;
                        i++;
                    }
                    j++;
                }
            }
            return chaineCrypt;
        }

        public string ConcateneMatrice(char[,] grid)
        {
            string concatene = "";
            for (int row = 0; row <= grid.GetLength(0) - 1; row++)
            {
                string ligne = "[";
                for (int column = 0; column <= grid.GetLength(1) - 1; column++)
                {
                    ligne = ligne + grid[row, column];
                    if (column != grid.GetLength(1) - 1)
                    {
                        ligne = ligne + ",";
                    }
                    else
                    {
                        ligne = ligne + "]";
                    }
                }
                concatene = concatene + "\n" + ligne;
            }
            return concatene;
        }
    }
}
