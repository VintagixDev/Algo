namespace _5TTI_MaelAndras_TriSelection
{
    internal class Program
    {
        static void Main(string[] args)
        {

            // instances
            Methodes methodes = new Methodes();
            SortingAlgorithms algos = new SortingAlgorithms();

            // tableau random
            int[] table = methodes.TableauRandom(5);

            Console.WriteLine(string.Join(", ", table) + "\n-------------");

            //algos.TriParSelection(ref table);

            //algos.TriIntuitif(ref table);

            //algos.TriABulle(ref table);

            algos.TriShell(ref table);

            // résultat final
            Console.WriteLine(methodes.Concatene(table));
        }
    }
}