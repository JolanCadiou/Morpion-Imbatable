using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Collections;
using System.Globalization;

namespace TTC_1._0
{
    class Program
    {
        static char[] jeu = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
        static char[] jeu2 = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
        static List<string> fichierScore = new List<string>();
        static int choice;
        static int player = 0;
        static int rez = 0;
        static bool cConfirm = false;
        static int _choix = 0;
        static int x;
        static int score;
        static int winner;


        static void Main(string[] args)
        {
            string solitude;
            bool will = true;
            string p;
            Console.WriteLine("Tapez 1 pour jouer seul et 2 pour jouer à 2");
            solitude = Console.ReadLine();
            Console.WriteLine("The first player got the X and the second got the O");
            afficherJeu();
            while (will)
            {
                while (rez == 0)
                {
                    Console.WriteLine("Choisissez un case où jouer");
                    if (player % 2 == 0)
                    {
                        choice = Int32.Parse(Console.ReadLine());
                        while (cConfirm != true)
                        {
                            if (jeu[choice] == 'X' || jeu[choice] == 'O')
                            {
                                Console.WriteLine("This case is already taken, please choose another one");
                                choice = Int32.Parse(Console.ReadLine());
                            }
                            else
                            {
                                jeu[choice] = 'X';
                                cConfirm = true;
                            }
                        }
                        cConfirm = false;
                    }
                    else
                    {
                        if (solitude == "1")
                            vsIA();
                        else
                            vs();

                    }
                    _choix = 0;
                    afficherJeu();
                    player++;
                    rez = check();

                }
                checkWinner();
                lireScore();
                if(solitude == "1")
                {
                    lireScoreJcIA();
                }
                else
                {
                    lireScoreJcJ();
                }             
                duh();
                ecrireScore();
                Console.WriteLine("Voulez-vous rejouez ? o/n");
                p = Console.ReadLine();
                if (p == "o")
                {
                    honte();
                    player = 0;
                    rez = 0;

                }
                else
                {
                    will = false;
                }

            }
        }




        static void honte()
            {
                jeu[1] = '1';
                jeu[2] = '2';
                jeu[3] = '3';
                jeu[4] = '4';
                jeu[5] = '5';
                jeu[6] = '6';
                jeu[7] = '7';
                jeu[8] = '8';
                jeu[9] = '9';
            }


        static void checkWinner()
            {
                if (rez == -1)
                {
                    Console.WriteLine("It's a draw");
                    winner = 0;
                }
                else
                {
                    if (player % 2 != 0)
                    {
                        Console.WriteLine("Player 1 has won");
                        winner = 1;
                    }
                    else
                    {
                        Console.WriteLine("Player 2 has won");
                        winner = 2;
                    }
                }
            }

        static void afficherJeu()
            {

                Console.WriteLine(" {0}  |  {1}  |  {2}", jeu[1], jeu[2], jeu[3]);
                Console.WriteLine(" {0}  |  {1}  |  {2}", jeu[4], jeu[5], jeu[6]);
                Console.WriteLine(" {0}  |  {1}  |  {2}", jeu[7], jeu[8], jeu[9]);
            }

        static int check()
            {
                if (jeu[1] == jeu[2] && jeu[2] == jeu[3])
                {
                    return 1;
                }
                else if (jeu[4] == jeu[5] && jeu[5] == jeu[6])
                {
                    return 1;
                }
                else if (jeu[7] == jeu[8] && jeu[8] == jeu[9])
                {
                    return 1;
                }
                else if (jeu[1] == jeu[4] && jeu[4] == jeu[7])
                {
                    return 1;
                }
                else if (jeu[2] == jeu[5] && jeu[5] == jeu[8])
                {
                    return 1;
                }
                else if (jeu[3] == jeu[6] && jeu[6] == jeu[9])
                {
                    return 1;
                }
                else if (jeu[1] == jeu[5] && jeu[5] == jeu[9])
                {
                    return 1;
                }
                else if (jeu[3] == jeu[5] && jeu[5] == jeu[7])
                {
                    return 1;
                }
                else if (jeu[1] != '1' && jeu[2] != '2' && jeu[3] != '3' && jeu[4] != '4' && jeu[5] != '5' && jeu[6] != '6' && jeu[7] != '7' && jeu[8] != '8' && jeu[9] != '9')
                {
                    return -1;
                }
                else
                {
                    return 0;
                }
            }

        static void boardCheck(int i)
            {
                if (i == 1)
                {
                    if (jeu[2] == jeu[3] || jeu[4] == jeu[7] || jeu[5] == jeu[9])
                        x = 5;
                }
                else if(i == 2)
                {
                    if (jeu[1] == jeu[3] || jeu[5] == jeu[8] )
                        x = 5;
                }
                else if (i == 3)
                {
                    if (jeu[1] == jeu[2] || jeu[5] == jeu[7] || jeu[6] == jeu[9])
                        x = 5;
                }
                else if (i == 4)
                {
                    if (jeu[1] == jeu[7] || jeu[5] == jeu[6])
                        x = 5;
                }
                else if (i == 6)
                {
                    if (jeu[4] == jeu[5] || jeu[3] == jeu[9])
                        x = 5;
                }
                else if (i == 7)
                {
                    if (jeu[1] == jeu[4] || jeu[8] == jeu[9] || jeu[5] == jeu[3])
                        x = 5;
                }
                else if (i == 8)
                {
                    if (jeu[7] == jeu[9] || jeu[2] == jeu[5])
                        x = 5;
                }
                else if (i == 9)
                {
                    if (jeu[1] == jeu[5] || jeu[3] == jeu[6] || jeu[7] == jeu[8])
                        x = 5;
                }
                else
                    x = 2;
            }

        static int theChoix()
            {
                if (jeu[5] == '5')
                    return 5;
                else if (jeu[5] != '5' && jeu[1] == '1' && jeu[2] == '2' && jeu[3] == '3' && jeu[4] == '4' && jeu[6] == '6' && jeu[7] == '7' && jeu[8] == '8' && jeu[9] == '9')
                    return 1;
                else
                {
                    simul(jeu);
                    return _choix;
                }
            }

        static void simul(char[] platAct)
            {
                char[] platSim = platAct;
                int i = 1;
                if (_choix == 0)
                {
                    while (i != 10)
                    {
                        if (_choix == 0)
                        {                           
                            if (platSim[i] == jeu2[i])
                            {
                                boardCheck(i);

                                if (x == 5)
                                    _choix = i;

                            }
                        }
                        i++;
                    }
                    i = 1;
                }
               
                if (_choix == 0)
                {
                    while (i != 10)
                    {
                        if (platSim[i] == jeu2[i])
                            _choix = i;
                        i++;
                        
                    }
                    i = 1;
                }
                if(_choix != 0)
                {
                }
                i = 1;
            }

        static void vsIA()
            {
                x = 0;
                choice = theChoix();
                while (cConfirm != true)
                {
                    choice = theChoix();
                    if (jeu[choice] == 'X' || jeu[choice] == 'O')
                    {
                        Console.WriteLine("This case is already taken, please choose another one");
                        choice = Int32.Parse(Console.ReadLine());
                    }
                    else
                    {
                        jeu[choice] = 'O';
                        cConfirm = true;
                    }
                }
                cConfirm = false;
            }

        static void vs()
            {
                while (cConfirm != true)
                {
                    choice = Int32.Parse(Console.ReadLine());
                    if (jeu[choice] == 'X' || jeu[choice] == 'O')
                    {
                        Console.WriteLine("This case is already taken, please choose another one");
                        choice = Int32.Parse(Console.ReadLine());
                    }
                    else
                    {
                        jeu[choice] = 'O';
                        cConfirm = true;
                    }
                }
                cConfirm = false;
            }

        static int Convert(string value, NumberStyles style, IFormatProvider provider)
            {
            try
            {
                int number = Int32.Parse(value, style, provider);
                return number;
            }
            catch (FormatException)
            {
                Console.WriteLine("Problème durant laa convertion '{0}'.", value);
                return 0;
            }
            catch (OverflowException)
            {
                Console.WriteLine("'{0}' En dehors de la limite des int.", value);
                return 0;
            }
        }

        static void lireScore()
            {
            StreamReader objReader = new StreamReader("Test.txt");
            string sLine = "";
            ArrayList arrText = new ArrayList();
            int i = 1;
            while (i != 16)
            {
                sLine = objReader.ReadLine();
                if(i == 8)
                {
                    fichierScore.Add(" ");
                }
                else if (i%2 == 0)
                {
                    score = Convert(sLine, NumberStyles.Float | NumberStyles.AllowThousands, new CultureInfo("en-GB"));
                    if (sLine != null)
                        arrText.Add(sLine);
                    fichierScore.Add(sLine);
                }
                else
                {
                    fichierScore.Add(sLine);
                }
                i++;

            }
            objReader.Close();
        }

        static void lireScoreJcIA()
        {
            StreamReader objReader = new StreamReader("Test.txt");
            string sLine = "";
            ArrayList arrText = new ArrayList();
            int i = 1;
            string fil;

            while (i != 16)
            {
                sLine = objReader.ReadLine();
                if (winner == 0)
                {
                    
                    if (i == 14)
                    {
                        score = Convert(sLine, NumberStyles.Float | NumberStyles.AllowThousands, new CultureInfo("en-GB"));
                        score++;
                        fil = score.ToString();
                        fichierScore[13] = fil;
                    }
                }
                else if (winner == 1)
                {
                    if(i == 10)
                    { 
                    score = Convert(sLine, NumberStyles.Float | NumberStyles.AllowThousands, new CultureInfo("en-GB"));
                    score++;
                    fil = score.ToString();
                    fichierScore[9] = fil;
                    }
                }
                else
                {
                    if(i == 12)
                    { 
                    score = Convert(sLine, NumberStyles.Float | NumberStyles.AllowThousands, new CultureInfo("en-GB"));
                    score++;
                    fil = score.ToString();
                    fichierScore[11] = fil;
                    }
                }
                i++;

            }
            objReader.Close();
        }

        static void lireScoreJcJ()
        {
            StreamReader objReader = new StreamReader("Test.txt");
            string sLine = "";
            ArrayList arrText = new ArrayList();
            int i = 1;
            string fil;

            while (i != 16)
            {
                sLine = objReader.ReadLine();
                if (winner == 0)
                {

                    if (i == 6)
                    {
                        score = Convert(sLine, NumberStyles.Float | NumberStyles.AllowThousands, new CultureInfo("en-GB"));
                        score++;
                        fil = score.ToString();
                        fichierScore[5] = fil;
                    }
                }
                else if (winner == 1)
                {
                    if(i == 2)
                    { 
                    score = Convert(sLine, NumberStyles.Float | NumberStyles.AllowThousands, new CultureInfo("en-GB"));
                    score++;
                    fil = score.ToString();
                    fichierScore[1] = fil;
                    }
                }
                else
                {
                    if(i == 4)
                    { 
                    score = Convert(sLine, NumberStyles.Float | NumberStyles.AllowThousands, new CultureInfo("en-GB"));
                    score++;
                    fil = score.ToString();
                    fichierScore[3] = fil;
                    }
                }
                i++;

            }
            objReader.Close();
        }

        static void duh()
        {
            int i = 0;
            while (i != 15)
            {
                //Console.WriteLine("");
                if(i%2 == 0)
                {
                    Console.Write(fichierScore[i]);
                    
                    Console.WriteLine("");

                }
                else
                {
                    Console.Write(fichierScore[i]);
                    Console.Write(" ");

                }
                
                i++;
            }
        }

        static void ecrireScore()
        {
            System.IO.File.WriteAllLines(@"Test.txt", fichierScore);
            
        }
    
    }
}

