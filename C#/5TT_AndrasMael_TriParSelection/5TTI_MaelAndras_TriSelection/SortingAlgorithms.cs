using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5TTI_MaelAndras_TriSelection
{
    public struct SortingAlgorithms
    {

        public void TriParSelection(ref int[] table)
        {
            int replaceValue;
            int replaceIndex;
            for (int i = 0; i <= table.Length - 2; i++)
            {
                replaceIndex = i;
                replaceValue = table[i];
                for (int checkIndex = i + 1; checkIndex <= table.Length - 1; checkIndex++)
                {
                    if (table[checkIndex] < replaceValue)
                    {
                        replaceValue = table[checkIndex];
                        replaceIndex = checkIndex;
                    }
                }
                if (replaceIndex != i)
                {
                    table[replaceIndex] = table[i];
                    table[i] = replaceValue;
                }
            }
        }

        public void TriIntuitif(ref int[] table)
        {
            int echange;
            for(int i = 0; i <= table.Length - 2; i++)
            {
                for(int j = i+1; j <= table.Length - 1; j++)
                {
                    if (table[i] > table[j])
                    {
                        echange = table[i];
                        table[i] = table[j];
                        table[j] = echange;
                    }
                }
            }
        }
        public void TriABulle(ref int[] table)
        {
            bool isSorted = true;
            int replace;
            while(isSorted == true)
            {
                isSorted = false;
                for(int i = 0; i <= table.Length - 2; i++)
                {
                    if (table[i] > table[i + 1])
                    {
                        replace = table[i];
                        table[i] = table[i + 1];
                        table[i + 1] = replace;
                        isSorted = true;
                    }
                }
            }
        }

        public void TriShell(ref int[] table)
        {
            int ecart = table.Length;
            bool swap;
            do
            {
                ecart = ecart / 2;
                do{
                    swap = false;
                    for( int i = 0; i <= table.Length - ecart; i++)
                    {
                        if (table[i] > table[i + ecart])
                        {
                            int replace = table[i];
                            table[i] = table[i + ecart];
                            table[i + ecart] = replace;
                            swap = true;
                        }
                    }
                } while (swap != false);
            } while (ecart != 1);
        }
    }
}
