using System;
using System.Security.Cryptography;

namespace TestNotationPolonaise
{
    class Program
    {
        /// <summary>
        /// saisie d'une réponse d'un caractère parmi 2
        /// </summary>
        /// <param name="message">message à afficher</param>
        /// <param name="carac1">premier caractère possible</param>
        /// <param name="carac2">second caractère possible</param>
        /// <returns>caractère saisi</returns>
        static char saisie(string message, char carac1, char carac2)
        {
            char reponse;
            do
            {
                Console.WriteLine();
                Console.Write(message + " (" + carac1 + "/" + carac2 + ") ");
                reponse = Console.ReadKey().KeyChar;
            } while (reponse != carac1 && reponse != carac2);
            return reponse;
        }

        /// <summary>
        /// Saisie de formules en notation polonaise pour tester la fonction de calcul
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            char reponse;
            // boucle sur la saisie de formules
            do
            {
                Console.WriteLine();
                Console.WriteLine("entrez une formule polonaise en séparant chaque partie par un espace = ");
                string laFormule = Console.ReadLine();
                // affichage du résultat
                String formule = laFormule;
                string[] tab = formule.Split();

                int nbCase = tab.Length;
                int placeTab = tab.Length - 1;

                while (nbCase > 1)
                {
                    while (placeTab > 0 && tab[placeTab] != "+" && tab[placeTab] != "-" && tab[placeTab] != "/" && tab[placeTab] != "*")
                    {
                        placeTab--;
                    }

                    // récupération des deux valeurs :

                    float a = float.Parse(tab[placeTab + 1]);
                    float b = float.Parse(tab[placeTab + 2]);

                    float result = 0;
                    switch(tab[placeTab])
                    {
                        case ("+"):
                            result = a +b;
                            break;
                        case ("-"):
                            result = a - b;
                            break;
                        case ("*"):
                            result = a * b;
                            break;
                        case ("/"):
                            result = a / b;
                            break;

                    };

                    // on place le résulat dans le tableau à la place du signe utilisé
                    tab[placeTab] = result.ToString();

                    for (int j = placeTab + 1; j < nbCase - 2; j++)
                    {
                        tab[j] = tab[j + 2];
                    }
 
                    nbCase = nbCase - 2;                
                }

                Console.WriteLine(tab[0]);


                //Console.WriteLine("Résultat =  " + Polonaise(laFormule));
                reponse = saisie("Voulez-vous continuer ?", 'O', 'N');
            } while (reponse == 'O');
        }
    }
}
