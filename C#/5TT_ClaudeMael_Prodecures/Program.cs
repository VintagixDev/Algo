using System.Threading.Tasks.Dataflow;

namespace _5TT_ClaudeMael_Prodecures
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] table;
            int n;
            Methodes methodes = new Methodes();
            methodes.LireEntier("Veuillez entrer le nombre de place que vous voulez dans votre tableau", out n);
            methodes.GenererTableau(n, out table);
            Console.WriteLine("Résultat: " + methodes.Concatener(table));
        }
    }
}