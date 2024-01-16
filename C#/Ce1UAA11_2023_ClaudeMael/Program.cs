using System.Runtime.CompilerServices;

namespace Ce1UAA11_2023_ClaudeMael
{
    internal class Program
    {
        static void Main(string[] args)
        {

            int nDes; // Nombre de dés à lancer
            int[] pointsJoueurs = new int[2]; // Points des différents joueurs
            int pointsAAteindre = 50;

            string[] listeDesSortis = new string[2]; // Liste des sorties de lancés de dés de chaque joueurs
            string commentaire; // Commentaire de résumé de partie.
            

            char repeatProg; // Répétition du programme

            do // Lancement du programme
            {
                bool fini = false;
                Console.WriteLine("Bienvenue dans notre jeu de dés !\n----------------------\nAvec combien de dés voulez-vous jouer ? Entre 6 et 8");
                LireUInt(out nDes);

                pointsJoueurs[0] = 0;
                pointsJoueurs[1] = 0;

                while (!fini) // Répétitions des tours jusqu'à ce qu'un joueur ait + 50 points
                {
                    TourJoueur(1, nDes, ref listeDesSortis, ref pointsJoueurs);
                    TourJoueur(2, nDes, ref listeDesSortis, ref pointsJoueurs);
                    if (pointsJoueurs[0] >= pointsAAteindre || pointsJoueurs[1] >= pointsAAteindre) // Vérification de condition de fin de partie
                    {
                        fini = true;
                    }
                }
                CreerCommentaire(pointsJoueurs, listeDesSortis, out commentaire); // Création du récapitulatif de la partie.
                Console.WriteLine(commentaire);

                Console.WriteLine("\n\nJeu terminé ! Voulez-vous recommencer ? O = Recommencer"); // Recommencer le programme
                string nUser = Console.ReadLine();
                while(!(char.TryParse(nUser, out repeatProg)))
                {
                    Console.WriteLine("Entrée invalide, O pour recommencer.");
                    nUser = Console.ReadLine();
                }
            } while (char.ToUpper(repeatProg) == 'O');
        }

        /// <summary>
        /// Modifier les deux tableaux (à la place correspondant au joueur) 
        /// afin de mémoriser les points obtenus au cours d’un lancer et les cumuler à ceux déjà obtenus. 
        /// Ajouter les dés sortis à la suite des lancers déjà obtenus.
        /// </summary>
        /// <param name="numeroJoueur"> non vide valant 1 ou 2 | numéro du joueur </param>
        /// <param name="nDes"> non vide compris entre 6 et 8. || nombre de dés utilisés </param>
        /// <param name="listeDesSortis"> ensemble des dés sortis dans la partie </param>
        /// <param name="pointsJoueurs"> total des points obtenus par les joueurs </param>
        static void TourJoueur(int numeroJoueur, int nDes, ref string[] listeDesSortis, ref int[] pointsJoueurs)
        {
            int[] desSortis;
            int pointLancer;

            string chaine;

            desSortis = LanceDes(nDes);
            chaine = Concatene(desSortis);

            listeDesSortis[numeroJoueur - 1] = listeDesSortis[numeroJoueur - 1] + chaine + "\n";
            ComptePoints(desSortis, out pointLancer);
            if (pointLancer != -1) // Vérification des triples 1 dans un lancé de dés
            {
                pointsJoueurs[numeroJoueur - 1] = pointsJoueurs[numeroJoueur - 1] + pointLancer; // Ajout des points gagnés dans ce tour
            }
            else
            {
                pointsJoueurs[numeroJoueur - 1] = 0; // Triple 1 détecté, réinitialisation des points
            }
        }

        /// <summary>
        /// génère un tableau contenant nDes valeurs aléatoires entières comprises entre 1 et 6
        /// </summary>
        /// <param name="nDes"> non vide | nombre de dés à lancer </param>
        /// <param name="desSortis"> ensemble des dés sortis dans un lancer </param>
        static int[] LanceDes(int nDes)
        {
            Random random = new Random();
            int[] desSortis = new int[nDes];

            for (int i = 0; i < nDes; i++)
            {
                desSortis[i] = random.Next(1, 7);
            }
            return desSortis;

        }

        /// <summary>
        /// Concatène une liste dans un message.
        /// </summary>
        /// <param name="desSortis"> défini | ensemble des dés sortis dans un lancer </param>
        /// <param name="chaine"> Message concaténé </param>
        static string Concatene(int[] desSortis)
        {
            string chaine = "";
            for(int i = 0; i < desSortis.Length; i++)
            {
                chaine += desSortis[i]+",";
            }

            return chaine;
        }

        /// <summary>
        /// compte le nombre d’occurrences de faceDe dans desSortis. Si face n’est pas présent, face = 0
        /// </summary>
        /// <param name="desSortis"> défini | ensemble des dés sortis dans un lancer </param>
        /// <param name="face"> défini | face du dé à rechercher et compter </param>
        /// <param name="nOccurrences"> nombre de fois que faceDe se trouve dans desSortis </param>
        static void CompteOccurrences(int[] desSortis, int face, out int nOccurrences)
        {
            nOccurrences = 0;
            for (int i = 0; i < desSortis.Length-1; i++)
            {
                if (desSortis[i] == face)
                {
                    nOccurrences++;
                }
            }
        }

        /// <summary>
        /// déterminer les points obtenus dans un lancer sur base de la règle de l’énoncé (suites et triple 1). Dans le cas du triple 1, pointsLancer = -1
        /// </summary>
        /// <param name="desSortis"> défini | ensemble des dés sortis dans un lancer </param>
        /// <param name="pointLancer"> total des points obtenus dans un lancer </param>
        static void ComptePoints(int[] desSortis, out int pointLancer)
        {
            pointLancer = 0;
            int longueurSuite = 0;
            int nOccurrences = 0;
            int face = 1;
            
            bool triple1 = false;
            bool fini = false;


            while (!fini && !triple1)
            {
                CompteOccurrences(desSortis, face, out nOccurrences);
                if(nOccurrences >= 1)
                {
                    longueurSuite = longueurSuite + 1;
                }
                else
                {
                    if(face == 1 && nOccurrences == 3)
                    {
                        triple1 = true;
                    }
                    fini = true;
                }
                face++;
            }

            if (triple1)
            {
                pointLancer = -1; // -1 = triple 1 dans le lancer
            }
            else
            {
                if(longueurSuite != 0)
                {
                    pointLancer = 5 * (longueurSuite - 1); //Multiplier les points du lancer par 5 en fonction de la taille de la suite
                }
            }
        }

        /// <summary>
        /// Produire le commentaire adapté à la situation : joueur 1 ou 2 gagne avec x points ou match nul
        /// </summary>
        /// <param name="pointsJoueurs"> défini | total des points obtenus par les joueurs </param>
        /// <param name="listeDesSortis"> défini | ensemble des dés sortis dans la partie </param>
        /// <param name="commentaire"> commentaire obtenu </param>
        static void CreerCommentaire(int[] pointsJoueurs, string[] listeDesSortis, out string commentaire)
        {
            // Ajouter les ensemble de dés sortis par joueur
            commentaire = "Dés sorti pour le joueur 1\n" + listeDesSortis[0] + "\n\nDés sorti pour le joueur 2\n" + listeDesSortis[1] + "\n\n"; 
            if (pointsJoueurs[0] > pointsJoueurs[1])
            {
                commentaire += "Joueur 1 gagne avec " + pointsJoueurs[0] + " points contre " + pointsJoueurs[1];
            }
            else
            {
                if (pointsJoueurs[1] > pointsJoueurs[0])
                {
                    commentaire += "Joueur 2 gagne avec " + pointsJoueurs[1] + " points contre " + pointsJoueurs[0];
                }
                else
                {
                    commentaire += "Match nul avec " + pointsJoueurs[0] + " points";
                }
            }
        }

        /// <summary>
        /// Lire les UInt des entrées utilisateur
        /// </summary>
        /// <param name="nDes"> ensemble des dés sortis dans un lancer </param>
        static void LireUInt(out int nDes)
        {
            string nUser = Console.ReadLine();
            while(!int.TryParse(nUser, out nDes) || nDes < 6 || nDes > 8)
            {
               
                Console.WriteLine("Entrée invalide, choisissez entre 6 et 8.");
                nUser = Console.ReadLine();
            }
        }

    }
}