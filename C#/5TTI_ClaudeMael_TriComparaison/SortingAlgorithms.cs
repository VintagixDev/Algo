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
            int n = table.Length;
            int ec = n / 2;
            bool permut;
            while(ec >= 1)
            {
                do
                {
                    permut = false;
                    for(int i = 0; i <= n-1-ec; i++)
                    {
                        if (table[i] > table[i + ec])
                        {
                            int swapValue = table[i];
                            table[i] = table[i+ec];
                            table[i + ec] = swapValue;
                            permut = true;
                        }
                    }
                } while (permut == true);
                ec = ec / 2;
            }
        }

        public void TriInsertion(ref int[] table)
        {
            int n = table.Length;
            for(int j = 1; j <= n-1; j++)
            {
                int x = table[j];
                int i = j - 1;
                bool bpp = false;
                while(x < table[i] && !bpp)
                {
                    table[i + 1] = table[i];
                    if (i == 0)
                    {
                        bpp = true;
                    }
                    else
                    {
                        i = i - 1;
                    }
                }
                if (bpp)
                {
                    table[0] = x;
                }
                else
                {
                    table[i + 1] = x;
                }
            }
        }
    }
}
