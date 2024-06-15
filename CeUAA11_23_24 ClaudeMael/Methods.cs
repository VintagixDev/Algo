using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace CeUAA11_23_24_ClaudeMael
{
    public struct Methods
    {

        /// <summary>
        /// A partir d'une chaîne de caractères, en créer une nouvelle tout en majuscules, sans espaces et ou on a remplacé les W par des V
        /// </summary>
        /// <param name="chaineDepart">Chaîne à nettoyer</param>
        /// <returns></returns>
        public string PreparationChaine(string chaineDepart)
        {
            string chainePropre = "";
            for(int i = 0; i < chaineDepart.Length; i++)
            {
                if (chaineDepart[i] == 'W')
                {
                    chainePropre += 'V';
                }
                else
                {
                    if (chaineDepart[i] != ' ')
                    {
                        chainePropre += char.ToUpper(chaineDepart[i]);
                    }
                }
            }
            return chainePropre;
        }
        /// <summary>
        /// recherche un caractère dans une chaîne renvoie vrai si trouvé, faux sinon
        /// </summary>
        /// <param name="x">caractère à rechercher</param>
        /// <param name="chaine">chaîne à parcourir</param>
        /// <returns></returns>
        public bool RechercheCharDansChaine(char x, string chaine)
        {
            bool trouve = false;
            int i = 0;
            while(i < chaine.Length && !trouve)
            {
                if (chaine[i] == x)
                {
                    trouve = true;
                }
                i++;
            }
            return trouve;
            
        }

        /// <summary>
        /// Construit un string à partir d'un autre, sans redondance
        /// </summary>
        /// <param name="mot">mot à simplifier</param>
        /// <returns></returns>
        public string CreeMotSansDoublon(string mot)
        {
            string final = "";
            for(int i = 0; i < mot.Length; i++)
            {
                if (!RechercheCharDansChaine(mot[i], final)){
                    final += mot[i];
                }
            }
            return final;
        }

        /// <summary>
        /// Construction d’une chaîne de caractères commençant par le mot clé épuré suivi de toutes les lettres de l’alphabet non encore utilisées (en ignorant le W)
        /// </summary>
        /// <param name="motCle">Clé</param>
        /// <returns></returns>
        public string CreeAlphabetOrdonne(string motCle)
        {
            
            string alphabetOrdonne = CreeMotSansDoublon(motCle);
            string alphabet = "ABCDEFGHIJKLMNOPQRSTUVXYZ";
            for(int i = 0; i < alphabet.Length; i++)
            {
                if (!RechercheCharDansChaine(alphabet[i], motCle))
                {
                    alphabetOrdonne += alphabet[i];
                }
            }
            return alphabetOrdonne;
        }

        /// <summary>
        /// Construction et remplissage de la matrice qui permettra le codage de l’alphabet
        /// </summary>
        /// <param name="motCle">clé prenant les premières places de la matrice</param>
        /// <param name="matAlphabet">matrice contenant l'alphabet ordonné selon la méthode</param>
        public void CreeEtRemplitMatriceAlphabet(string motCle, out char[,] matAlphabet)
        {
            int k = 0;
            matAlphabet = new char[5, 5];
            string alphabet = CreeAlphabetOrdonne(motCle);
            for(int i = 0; i < 5; i++)
            {
                for(int j = 0; j < 5; j++)
                {
                    matAlphabet[i, j] = alphabet[k];
                    k++;
                }
            }
        }

        /// <summary>
        /// Crée le code d'une lettre en extrayant les coordonnées ligne / colonne dans la matrice Alphabe
        /// </summary>
        /// <param name="lettre">lettre dont on cherche le code</param>
        /// <param name="matAlphabet">matrice reprenant les lettres majuscules de l'alphabet</param>
        /// <returns></returns>
        public byte Code(char lettre, char[,] matAlphabet)
        {
            int ligne = 0;
            int colonne = 0;
            bool trouve = false;
            string codeLettre;
            while(ligne <= 4 && !trouve)
            {
                colonne = 0;
                while(colonne <= 4 && !trouve)
                {

                    if (matAlphabet[ligne, colonne] == lettre)
                    {
                        trouve = true;
                    }
                    colonne++;
                }
                ligne++;
            }
            codeLettre = ligne.ToString() + colonne.ToString();
            byte codeFinal = byte.Parse(codeLettre);
            return codeFinal;
        }

        /// <summary>
        /// Créer et remplir la matrice des codes, elle comporte toujours 3 lignes
        /// (1° ligne codes des lettres de la phrase de départ, 2° ligne codes des lettres de la seconde clé
        /// (répétés autant de fois qu'il faut pour couvrir tout le tableau))
        /// </summary>
        /// <param name="matAlphabet">matrice reprenant les lettres majuscules de l'alphabet</param>
        /// <param name="cle2">seconde clé</param>
        /// <param name="phrase">phrase à traiter</param>
        /// <param name="matCodes">matrice de calcul des codes</param>
        public void CreeEtRemplitMatriceCodes(char[,] matAlphabet, string cle2, string phrase, out byte[,] matCodes)
        {
            int k = 0;
            matCodes = new byte[3, phrase.Length];
            int codeTemp;
            for(int col = 0; col < phrase.Length; col++)
            {
                matCodes[0, col] = Code(char.ToUpper(phrase[col]), matAlphabet);
                matCodes[1, col] = Code(char.ToUpper(cle2[k]), matAlphabet);
                if(k < cle2.Length-1)
                {
                    k++;
                }
                else
                {
                    k = 0;
                }
                codeTemp = matCodes[0, col] + matCodes[1, col];
                if(codeTemp >= 100)
                {
                    codeTemp -= 100;
                }
                matCodes[2, col] = (byte)codeTemp;
            }
        }

        /// <summary>
        /// Création de la phrase cryptée par concaténation des informations de la dernière ligne de matriceCode par regroupement de 6 caractères séparés par un espace
        /// </summary>
        /// <param name="matriceCodes">matrice contenant les numériques des lettres cryptées</param>
        /// <returns></returns>
        public string CreePhraseCodee(byte[,] matriceCodes)
        {
            int compteBloc = 0;
            string chaineCodee = "";
            for(int i = 0; i < matriceCodes.GetLength(1); i++)
            {
                if (matriceCodes[2,i] < 10)
                {
                    chaineCodee += "0" + matriceCodes[2, i].ToString();
                }
                else
                {
                    chaineCodee += matriceCodes[2, i].ToString();
                }
                compteBloc++;
                if(compteBloc == 3)
                {
                    chaineCodee += ' ';
                    compteBloc = 0;
                }
            }
            return chaineCodee;
        }

        /// <summary>
        /// Concaténer une matrice de caractère.
        /// </summary>
        /// <param name="matrice">Matrice à concaténer</param>
        /// <param name="space">Sert à savoir si on ajoute un espace entre les valeurs ou non</param>
        /// <returns></returns>
        public string AfficherMatriceChar(char[,] matrice, bool space)
        {
            string final = "";
            for( int i = 0;i < matrice.GetLength(0); i++)
            {
                for( int j = 0;j < matrice.GetLength(1); j++)
                {
                    final += matrice[i, j];
                    if (space)
                    {
                        final += " ";
                    }
                }
                final += "\n";
            }
            return final;
        }

        /// <summary>
        /// Concaténer une matrice de bytes.
        /// </summary>
        /// <param name="matrice">Matrice à concaténer</param>
        /// <param name="space">Sert à savoir si on ajoute un espace entre les valeurs ou non</param>
        /// <returns></returns>
        public string AfficherMatriceByte(byte[,] matrice, bool space)
        {
            string final = "";
            for (int i = 0; i < matrice.GetLength(0); i++)
            {
                for (int j = 0; j < matrice.GetLength(1); j++)
                {
                    final += matrice[i, j];
                    if (space)
                    {
                        final += " ";
                    }
                }
                final += "\n";
            }
            return final;
        }


    }
}
