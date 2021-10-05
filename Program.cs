using System;

namespace jeu_de_maths
{
    class Program
    {
        enum e_Operateur
        {
            ADDITION = 1,
            MULTIPLICATION = 2,
            SOUSTRACTION = 3
        }

        static bool PoserQuestion(int min, int max)
        {
            Random rand = new Random();
            int reponseInt = 0;

            while (true)
            {
                int a = rand.Next(min, max +1);
                int b = rand.Next(min, max + 1);
                e_Operateur o = (e_Operateur)rand.Next(1, 4); // o => 1 ou 2, 1 = addition / 2 = multiplication
                int resultatAttendu;

                if (o == e_Operateur.ADDITION) // Addition
                {
                    Console.Write(a + " + " + b + " = ");
                    resultatAttendu = a + b;
                }
                else if (o == e_Operateur.MULTIPLICATION) // Multiplication
                {
                    Console.Write(a + " x " + b + " = ");
                    resultatAttendu = a * b;
                }
                else if (o == e_Operateur.SOUSTRACTION) // Multiplication
                {
                    Console.Write(a + " - " + b + " = ");
                    resultatAttendu = a - b;
                }
                else
                {
                    // cas inconnu
                    Console.WriteLine("Erreur : opérateur inconnu");
                    return false;
                }


                string reponse = Console.ReadLine();
                try
                {
                    reponseInt = int.Parse(reponse);
                    if (reponseInt == resultatAttendu)
                    {
                        return true;
                    }
                    return false;
                }
                catch
                {
                    Console.WriteLine("Erreur : vous devez rentrer un nombre.");
                }
            }
            // reponseInt
        }

        static void Main(string[] args)
        {
            const int NOMBRE_MIN = 1;
            const int NOMBRE_MAX = 10;
            const int NB_QUESTIONS = 5;

            int points = 0;

            for (int i = 0; i < NB_QUESTIONS; i++)
            {
                Console.WriteLine("Question n° " + (i+1) + " / " + NB_QUESTIONS);

                bool bonneReponse = PoserQuestion(NOMBRE_MIN, NOMBRE_MAX);
                if (bonneReponse)
                {
                    Console.WriteLine("Bonne réponse !");
                    points++;
                }
                else
                {
                    Console.WriteLine("Mauvaise réponse !");
                }

                Console.WriteLine("Nombre de points : " + points + "/" + NB_QUESTIONS);

                int moyenne = NB_QUESTIONS / 2;

                if (points == NB_QUESTIONS)
                {
                    Console.WriteLine("Excellent !");
                }
                else if (points == 0)
                {
                    Console.WriteLine("Révisez vos maths !");
                }
                else if (points > moyenne)
                {
                    Console.WriteLine("Pas mal!");
                }
                else
                {
                    Console.WriteLine("Peut mieux faire !");
                }
            }

        }
    }
}
