namespace _5TTI_MaelAndras_TriSelection
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Methodes methodes = new Methodes();
            int[] table = methodes.TableauRandom(5);
            int replaceValue;
            int replaceIndex;
            Console.WriteLine(string.Join(", ", table)+ "\n-------------");
            for (int i = 0; i <= table.Length-2; i++) {
                replaceIndex = i;
                replaceValue = table[i];
                for(int checkIndex = i+1; checkIndex <= table.Length-1; checkIndex++)
                {
                    if(table[checkIndex] < replaceValue)
                    {
                        replaceValue = table[checkIndex];
                        replaceIndex = checkIndex;
                    }
                }
                if(replaceIndex != i)
                {
                    table[replaceIndex] = table[i];
                    table[i] = replaceValue;
                }
            }
            Console.WriteLine(methodes.Concatene(table));
        }
    }
}