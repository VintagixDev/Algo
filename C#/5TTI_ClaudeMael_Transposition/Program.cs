namespace _5TTI_ClaudeMael_Transposition
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Methods methods = new Methods();

            char repeatProg;

            do
            {
                Console.Clear();
                Console.WriteLine("Bienvenue dans votre application de cryptage.\nVeuillez entrer la clé de cryptage: (max 9 charactères)");
                
                
                string key = Console.ReadLine();
                while(key.Length >= 10)
                {
                    Console.WriteLine("Veuillez entrer une clé en dessous de 9 caractères");
                    key = Console.ReadLine();
                }
                Console.Clear();



                Console.WriteLine("Veuillez entrer ce que vous voulez crypter:");
                string texte = Console.ReadLine();
                texte = methods.RetireEspaces(texte);
                char[,] matrice;
                char[,] matriceOutil;
                methods.CreerMatrice(key, texte, out matrice);
                methods.EcritChainesDansMatrice(key, texte, ref matrice);
                methods.CreerMatriceOutil(key, out matriceOutil);
                methods.ReporteOrdre(ref matrice, ref matriceOutil);

                string final = methods.ConstruitCryptage(matrice);
                Console.WriteLine("\n " + final);

                Console.WriteLine("Voulez-vous recommencer le programme ? O = Oui");
                string nUser = Console.ReadLine();
                while(!char.TryParse(nUser, out repeatProg)){
                    Console.WriteLine("Entrée incorrecte, O = Oui");
                    nUser = Console.ReadLine();
                }
            } while (char.ToUpper(repeatProg) == 'O');
            Console.WriteLine("\n\nFin du programme");
        }
    }
}
