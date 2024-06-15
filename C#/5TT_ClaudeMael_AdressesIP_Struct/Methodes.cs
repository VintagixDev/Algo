using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace _5TT_ClaudeMael_AdressesIP
{
    public struct Methodes
    {

        /// <summary>
        /// Ajouter un nom dans la liste des noms
        /// </summary>
        /// <param name="nom">Nom à ajouter à noms</param>
        /// <param name="pointer">pointer est différent (en dessous) de la taille de noms</param>
        /// <param name="noms">tableau contenant tous les noms</param>
        /// <returns></returns>
        public bool AjouteNom(string nom, ref int pointer, ref AdresseIP[] adressesIP)
        {
            if(pointer < adressesIP.Length)
            {
                adressesIP[pointer].nom = nom;
                pointer++;
                return true;
            }
            return false;
        }
        /// <summary>
        /// Ajouter une adresse IP dans la matrice contenant toutes les adresses IP.
        /// </summary>
        /// <param name="ip">IP à ajouter à la matrice</param>
        /// <param name="pointer">pointer est différent (en dessous) du nombre de lignes d'adressesIp</param>
        /// <param name="adressesIp">matrice contenant toute les IPs</param>
        /// <returns></returns>
        public bool AjouteAdresseIp(byte[] adresseIp, int pointer, ref AdresseIP[] adressesIp)
        {
            if(pointer < adressesIp.Length)
            {
                for(int i = 0; i < 4; i++)
                {
                    adressesIp[pointer].ip[i] = adresseIp[i];
                }
                
                return true;
            }
            return false;
        }

        /// <summary>
        /// Lire l'entrée utilisateur d'une IP entière
        /// </summary>
        /// <param name="ip">variable contenant l'IP finale</param>
        public void LireAdresseIp(out byte[] ip)
        {
            ip = new byte[4];
            byte octet;
            for(int i = 0; i < 4; i++)
            {
                LireOctet("Veuillez entrer l'octet n°" + i + " de votre adresse IP", out octet);
                ip[i] = octet;
            }
        }

        /// <summary>
        /// Retourne une adresse IP concaténée
        /// </summary>
        /// <param name="ip">adresse IP à concaténer</param>
        /// <returns></returns>
        public string ConcateneAdresse(byte[] ip)
        {
            string message = "";
            for(int i = 0; i < ip.Length; i++)
            {
                message += ip[i];
                if(i < ip.Length - 1)
                {
                    message += ".";
                }
            }
            return message;
        }

        /// <summary>
        /// Lire l'entrée utilisateur (octet)
        /// </summary>
        /// <param name="question">Question posée à l'utilisateur</param>
        /// <param name="octet">Variable contenant l'octet entré</param>
        public void LireOctet(string question, out byte octet)
        {
            Console.WriteLine(question);
            string nUser = Console.ReadLine();
            while(!byte.TryParse(nUser, out octet))
            {
                Console.WriteLine(question);
                nUser = Console.ReadLine();
            }
        }

        /// <summary>
        /// Concatène toute la liste des adresses IP liées avec les utilisateurs concernés
        /// </summary>
        /// <param name="pointer">>pointer est différent (en dessous) du nombre de lignes d'adressesIp</param>
        /// <param name="adressesIp">Liste d'adresse IP</param>
        /// <returns></returns>
        public string ConcateneTout(int pointer, AdresseIP[] adressesIp)
        {
            string message = "Liste d'adresse IP (" + pointer+"):\n\n";
            byte[] ip = new byte[4];

            for (int i = 0; i < pointer; i++)
            {
                for(int j = 0; j < 4; j++)
                {
                    ip[j] = adressesIp[i].ip[j];
                }
                message += i + " | " + adressesIp[i].nom + ": " + ConcateneAdresse(ip) + "\n";
            }
            return message;
        }

    }
}
