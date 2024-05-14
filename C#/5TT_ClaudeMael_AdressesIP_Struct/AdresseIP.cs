using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5TT_ClaudeMael_AdressesIP
{
    public struct AdresseIP
    {
        public byte[] ip;
        public string nom;

        public AdresseIP()
        {
            ip = new byte[4];
            for(int i = 0; i < 4; i++)
            {
                ip[i] = 0;
            }
            nom = "";
        }
    }
}
