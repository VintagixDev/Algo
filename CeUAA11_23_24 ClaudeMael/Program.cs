namespace CeUAA11_23_24_ClaudeMael
{
    internal class Program
    {
        static void Main(string[] args)
        {

            // Instanciation de la structure Methods
            Methods methods = new Methods();

            // Variables
            string texteACrypter; // Texte à crypter
            string motCle1; // Premier mot clé
            string motCle2; // Deuxième mot clé
            string phraseCryptee; // Phrase cryptée

            // Matrices
            char[,] matAlphabet; // Matrice contenant le premier mot clé + l'alphabet
            byte[,] matCodes; // Matrice contenant les différents codes

            // Recommencer le programme
            string nUser; // Entrée de l'utilisateur
            char repeatProg; // Savoir si l'utilisateur veux recommencer le programme
            do
            {

                Console.Clear();
                //Message de bienvenue
                Console.WriteLine("Bienvenue dans la méthode de cryptage des Nihilistes.\n");

                //Message à crypter
                Console.WriteLine("Veuillez entrer la phrase que vous voulez crypter.\n» Faites attention à ne pas utiliser d'accents, de chiffres ou d'autres caractères.");
                texteACrypter = Console.ReadLine();

                //Mots Clés
                Console.WriteLine("\nVeuillez entrer votre premier mot clé:");
                motCle1 = Console.ReadLine();

                Console.WriteLine("\nVeuillez entrer votre deuxième mot clé:");
                motCle2 = Console.ReadLine();

                // Préparation de la chaîne à crypter (MAJ sans W)
                texteACrypter = methods.PreparationChaine(texteACrypter);

                // Préparation du premier mot clé + alphabet
                motCle1 = methods.PreparationChaine(motCle1);
                motCle1 = methods.CreeAlphabetOrdonne(motCle1);

                // Création de la première matrice
                methods.CreeEtRemplitMatriceAlphabet(motCle1, out matAlphabet);
                Console.WriteLine("\n\nPremière matrice:\n" + methods.AfficherMatriceChar(matAlphabet, false));

                // Création de la deuxième matrice contenant les codes
                methods.CreeEtRemplitMatriceCodes(matAlphabet, motCle2, texteACrypter, out matCodes);
                Console.WriteLine("Deuxième matrice:\n" + methods.AfficherMatriceByte(matCodes, true));

                // Cryptage final
                phraseCryptee = methods.CreePhraseCodee(matCodes);
                Console.WriteLine("Voici votre phrase cryptée:\n» " + phraseCryptee);

                // Recommencer le programme
                Console.WriteLine("\n\nVoulez-vous recommencer le programme ? O = Oui");
                nUser = Console.ReadLine();
                if(!char.TryParse(nUser, out repeatProg)){
                    Console.WriteLine("Entrée incorrecte, O = Oui");
                    nUser = Console.ReadLine();
                }
            } while (char.ToUpper(repeatProg) == 'O');
        }
    }
}