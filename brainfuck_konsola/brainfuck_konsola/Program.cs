using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Data.Common;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace brainfuck_konsola
{
    internal class Program
    {
        static void Instrukcja() // obiekt odpowiedzialny za wyświetlenie tego, co robi program oraz przykładów.
        {
            Console.Write("\nProgram ma zadanie interpretować każdą z 8 podstawowych funkcji Brainfuck'a:");
            Console.Write("\n|---------------------------------------------------------------------------------------------------------|");
            Console.Write("\n| znak |                 instrukcja                  | znak |                 instrukcja                  |");
            Console.Write("\n|---------------------------------------------------------------------------------------------------------|");
            Console.Write("\n|   >  |        Zwiększ wartość wskaźnika o 1.       |  <   |       Zmniejsz wartość wskaźnika o 1.       |");
            Console.Write("\n|---------------------------------------------------------------------------------------------------------|");
            Console.Write("\n|   +  |       Zwiększ w bieżącej pozycji o 1.       |  -   |       Zmniejsz w bieżącej pozycji o 1.      |");
            Console.Write("\n|---------------------------------------------------------------------------------------------------------|");
            Console.Write("\n|   .  |         Wypisz znak w danej pozycji.        |  ,   |          Pobierz znak z klawiatury.         |");
            Console.Write("\n|---------------------------------------------------------------------------------------------------------|");
            Console.Write("\n|   [  |  Skocz bezpośrednio do odpowiadającego ele- |  ]   |    Skocz do odpowiadającego elementu '['.   |");
            Console.Write("\n|      | mentu o 1, jeśli w bieżącej pozycji jest 0. |      |                                             |");
            Console.Write("\n|---------------------------------------------------------------------------------------------------------|");
            Console.Write("\n\nNależy pamiętać również o tym, że jakikolwiek tekst, poza powyższymi znakami, zostanie potraktowany, jako komentarz. Poniżej przykłady:");
            Console.Write("\n|---------------------------------------------------------------------------------------------------------|");
            Console.Write("\n|                                  Kod w Brainfuck'u                                   |     Rezultat     |");
            Console.Write("\n|---------------------------------------------------------------------------------------------------------|");
            Console.Write("\n| ++++++++++[>+++++++>++++++++++>+++>+<<<<-]>++.>+.+++++++..+++.>++.<<+++++++++++++++. |   Hello world!   |");
            Console.Write("\n| >.+++.------.--------.>+.                                                            |                  |");
            Console.Write("\n|---------------------------------------------------------------------------------------------------------|");
            Console.Write("\n| +++++++++++[>+++++++>+++++++++++>+++++++++>+++<<<<-]>-.>----.----------.>--.<+++++++ |    Moje imię     |");
            Console.Write("\n| +.+++++++.>>-.<<<+++++++++++.>-----------.-----.>+++.---.<++.+++++++.--------.--.    |    i nazwisko    |");
            Console.Write("\n|---------------------------------------------------------------------------------------------------------|");
            Console.Write("\n| ++++++++++[>+++++++>+++++++++++>++++++++++<<<-]>----.>++++.>---.++++++++.+++++.----- |    Brainfuck     |");
            Console.Write("\n| ---.<+++.>---.++++++++.                                                              |                  |");
            Console.Write("\n|---------------------------------------------------------------------------------------------------------|");
            Console.Write("\n\nW celu uruchomienia programu należy, będąc w menu, wcisnąć 'p' i wybrać plik do zinterpretowania go, a więc:");
            Console.Write("\n\t1. Będąc w menu wyboru wciskamy 'p'.");
            Console.Write("\n\t2. Wpisujemy nazwę pliku, który chcemy zinterpretować, np. hello-world.txt.");
            Console.Write("\n\t3. Otrzymujemy interpretację instrukcji Brainfuck'a.");
            Console.Write("\n\nPracę wykonał Łukasz Wojdalski.");
            Console.Write("\n\nProszę wybrać jedną z tych opcji: H (info), P (kompilacja) lub E (wyjście): ");
        }
        static void ProgramGłówny()
        {
            int[] numer = new int[30000];
            Encoding utf8 = Encoding.UTF8;

            Console.Write("\n\nJaki plik zamierzasz wrzucić do interpretera?\t");
            string plik = Console.ReadLine();
            try
            {
                StreamReader czytaj = new StreamReader("C:\\Users\\" + Environment.UserName + "\\source\\repos\\brainfuck_konsola\\brainfuck_konsola\\" + plik + ".txt");
                //StreamReader czytaj = new StreamReader("C:\\Users\\" + Environment.UserName + "\\Desktop\\projekt_wik-main\\brainfuck_konsola\\brainfuck_konsola\\" + plik + ".txt");
                string ciąg = czytaj.ReadToEnd();
                Console.WriteLine(ciąg);
                char[] bf = ciąg.ToCharArray();
                string odpowiedź = string.Empty;
                int i = 0, j = 0;
                int różnica = 0;
                string wejściowa;
                char znak;
                int czynnik = 0;
                for (int szukacz = 0; szukacz < bf.Length; szukacz++) // Procedura sprawdzająca, czy po użyciu pętli (jeśli jest) nie dojdzie do zapętlenia interpretera.
                {
                    if (bf[szukacz] == '[')
                    {
                        do
                        {
                            if (bf[i] == '+')
                            {
                                if (czynnik == 255) czynnik = 0;
                                else czynnik += 1;
                            }
                            else if (bf[i] == '-')
                            {
                                if (czynnik == 0) czynnik = 255;
                                else czynnik -= 1;
                            }
                            i++;
                        } while (bf[i] != '[');
                        do
                        {
                            i++;
                        } while (bf[i] != '<' && bf[i] != '>');
                        if (bf[i] == '<')
                            do
                            {
                                i++;
                            } while (bf[i] != '>');
                        else if (bf[i] != '>')
                            do
                            {
                                i++;
                            } while (bf[i] != '<');
                        while (bf[i] != ']')
                        {
                            if (bf[i] == '-')
                            {
                                różnica += 1;
                                if (różnica > 255) różnica = 0;
                            }
                            else if (bf[i] == '+')
                            {
                                różnica -= 1;
                                if (różnica < 0) różnica = 255;
                            }
                            i++;
                        }
                        if (różnica == 0 || (różnica % 2 == 0 && czynnik % 2 == 1))
                        {
                            Console.WriteLine("Doszło do zapętlenia programu. Nastąpi powrót do menu głównego.");
                            goto Menu;
                        }
                    }
                }
                i = 0;
                do
                {
                    if (bf[i] == '.')
                    {
                        string wartość = Convert.ToString(numer[j]);
                        znak = (char)numer[j];
                        odpowiedź += znak;
                    }
                    else if (bf[i] == ',')
                    {
                        do
                        {
                            Console.Write("Podaj dowolny znak z tablicy ASCII: ");
                            wejściowa = Console.ReadLine();
                            if (wejściowa.Length != 1) Console.WriteLine("Proszę podać tylko jeden znak.");
                            else
                            {
                                Byte[] tablicaBitów = utf8.GetBytes(wejściowa);
                                foreach (Byte b in tablicaBitów)
                                    numer[j] = b;
                            }
                        } while (wejściowa.Length != 1);
                    }
                    else if (bf[i] == '+')
                    {
                        numer[j] += 1;
                        if (numer[j] > 255) numer[j] -= 256;
                    }
                    else if (bf[i] == '-')
                    {
                        numer[j] -= 1;
                        if (numer[j] < 0) numer[j] += 256;
                    }
                    else if (i == bf.Length) Console.WriteLine(odpowiedź);
                    else if (bf[i] == '<')
                    {
                        if (j == 0) j = numer.Length - 1;
                        else j -= 1;
                    }
                    else if (bf[i] == '>')
                    {
                        if (j == 29999) j = 0;
                        else j += 1;
                    }
                    else if (bf[i] == '[')
                    {
                        do
                        {
                            i = 0;
                            do
                            {
                                i++;
                            } while (bf[i] != '[');
                            while (bf[i] != ']')
                            {
                                for (bf[i] = '['; bf[i] != ']'; i++)
                                {
                                    if (bf[i] == '+')
                                    {
                                        numer[j] += 1;
                                        if (numer[j] > 255) numer[j] = 0;
                                        //Console.Write(numer[j] + ", ");
                                    }
                                    else if (bf[i] == '-')
                                    {
                                        numer[j] -= 1;
                                        if (numer[j] < 0) numer[j] = 255;
                                        //Console.Write(numer[j] + ", ");
                                    }
                                    else if (bf[i] == '<')
                                    {
                                        if (j == 0) j = numer.Length - 1;
                                        else j -= 1;
                                        //Console.Write(j + ", ");
                                    }
                                    else if (bf[i] == '>')
                                    {
                                        if (j == numer.Length - 1) j = 0;
                                        else j += 1;
                                        //Console.Write(j + ", ");
                                    }
                                    else if (bf[i] == '.')
                                    {
                                        string wartość = Convert.ToString(numer[j]);
                                        znak = (char)numer[j];
                                        odpowiedź += znak;
                                    }
                                    else if (bf[i] == ',')
                                    {
                                        do
                                        {
                                            Console.Write("Podaj dowolny znak z tablicy ASCII: ");
                                            wejściowa = Console.ReadLine();
                                            if (wejściowa.Length != 1) Console.WriteLine("Proszę podać tylko jeden znak.");
                                            else
                                            {
                                                Byte[] tablicaBitów = utf8.GetBytes(wejściowa);
                                                foreach (Byte b in tablicaBitów)
                                                    numer[j] = b;
                                            }
                                        } while (wejściowa.Length != 1);
                                    }
                                }
                                //Console.WriteLine();
                                if (numer[j] < 0) numer[j] += 256;
                                else if (numer[j] > 255) numer[j] -= 256;
                            }
                        } while (numer[j] != 0); 
                    }
                    i++;
                    if (i == bf.Length) Console.WriteLine(odpowiedź);
                } while (i < bf.Length);
                czytaj.Close();
            }
            catch (System.IO.FileNotFoundException)
            {
                Console.Write($"Nie odnaleziono pliku {plik}.txt. Nastąpi powrót do menu głównego.");
            }
            Menu:
            Console.Write("\nProszę wybrać jedną z tych opcji: H (pomoc i info), P (kompilacja) lub E (wyjście): ");
        }
        static void Main(string[] args)
        {
            Console.Write("Witamy w interpreterze języka Brainfuck. Aby rozpocząć pracę, należy wybrać polecenie. (h - pomoc i informacje prawno-autorskie; -p <ścieżka do pliku> - uruchom wskazany kod Brainfuck; -e - wyjdź z programu): "); 
            ConsoleKeyInfo opcja = Console.ReadKey();
            do
            {
                if (opcja.Key != ConsoleKey.H && opcja.Key != ConsoleKey.P && opcja.Key != ConsoleKey.E)
                {
                    Console.Write("\n\nProszę wybrać jedną z tych opcji: H (pomoc i info), P (kompilacja) lub E (wyjście): ");
                    opcja = Console.ReadKey();
                }
                else if (opcja.Key == ConsoleKey.H)
                {
                    Instrukcja();
                    opcja = Console.ReadKey();
                }
                else if (opcja.Key == ConsoleKey.P)
                {
                    ProgramGłówny();
                    opcja = Console.ReadKey();
                }
            } while (opcja.Key != ConsoleKey.E);
            Console.Write("\n\nProgram zostanie zamknięty po naciśnięciu dowolnego klawisza...");
            Console.ReadKey();
        }
    }
}
