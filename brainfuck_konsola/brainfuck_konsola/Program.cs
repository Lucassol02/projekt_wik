using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace brainfuck_konsola
{
    internal class Program
    {
        static void Instrukcja(ConsoleKeyInfo opcja) // obiekt odpowiedzialny za wyświetlenie tego, co robi program oraz przykładów.
        {
            Console.Write("\nProgram ma zadanie interpretować każdą z 8 podstawowych funkcji Brainfuck'a:");
            Console.Write("\n|---------------------------------------------------------------------------------------------------------|");
            Console.Write("\n| znak |                 instrukcja                  | znak |                 instrukcja                  |");
            Console.Write("\n|---------------------------------------------------------------------------------------------------------|");
            Console.Write("\n|   >  |       Zwiększ wartość wskaźnika o 1.        |  <   |       Zmniejsz wartość wskaźnika o 1.       |");
            Console.Write("\n|---------------------------------------------------------------------------------------------------------|");
            Console.Write("\n|   +  |       Zwiększ w bieżącej pozycji o 1.       |  -   |       Zmniejsz w bieżącej pozycji o 1.      |");
            Console.Write("\n|---------------------------------------------------------------------------------------------------------|");
            Console.Write("\n|   +  |       Zwiększ w bieżącej pozycji o 1.       |  -   |       Zmniejsz w bieżącej pozycji o 1.      |");
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
        public void Konwerter(int numerAscii)
        {

        }
        static void Main(string[] args)
        {
            Console.Write("Witamy w interpreterze języka Brainfuck. Aby rozpocząć pracę, należy wybrać polecenie. (h - informacje prawno-autorskie; -p <ścieżka do pliku> - uruchom wskazany kod Brainfuck; -e - wyjdź z programu): "); 
            ConsoleKeyInfo opcja = Console.ReadKey();
            do
            {
                if (opcja.Key != ConsoleKey.H && opcja.Key != ConsoleKey.P && opcja.Key != ConsoleKey.E)
                {
                    Console.Write("\n\nProszę wybrać jedną z tych opcji: H (info), P (kompilacja) lub E (wyjście): ");
                    opcja = Console.ReadKey();
                }
                else if (opcja.Key == ConsoleKey.H)
                {
                    Instrukcja(opcja);
                    opcja = Console.ReadKey();
                }
                else if (opcja.Key == ConsoleKey.P)
                {
                    int numer = 0;

                    Console.Write("\n\nJaki plik zamierzasz wrzucić do interpretera?\t");
                    string plik = Console.ReadLine();
                    StreamReader czytaj = new StreamReader("C:\\Users\\" + Environment.UserName + "\\source\\repos\\brainfuck_konsola\\brainfuck_konsola\\" + plik + ".txt");
                    //StreamReader czytaj = new StreamReader("C:\\Users\\" + Environment.UserName + "\\Desktop\\brainfuck_konsola-main\\brainfuck_konsola\\brainfuck_konsola\\" + plik + ".txt");
                    string ciąg = czytaj.ReadToEnd();
                    Console.WriteLine(ciąg);
                    char[] bf = ciąg.ToCharArray();
                    string odpowiedź = string.Empty;
                    int j = 0;
                    int[] wskaźnik = new int[30000];
                    for (int i = 0; i < bf.Length; i++)
                    {
                        if (bf[i] == '.')
                        {
                            string wartość = Convert.ToString(numer);
                            int liczba = Convert.ToInt32(wartość, 16);
                            string wartośćLiczby = Char.ConvertFromUtf32(liczba);
                            char znak = (char)liczba;
                            odpowiedź += znak;
                        }
                        else if (bf[i] == '+') numer += 1;
                        else if (bf[i] == '-') numer -= 1;
                    }
                    Console.WriteLine(odpowiedź);
                    czytaj.Close();
                    Console.Write("\n\nProszę wybrać jedną z tych opcji: H (info), P (kompilacja) lub E (wyjście): ");
                    opcja = Console.ReadKey();
                }
            } while (opcja.Key != ConsoleKey.E);
            Console.Write("\n\nProgram zostanie zamknięty po naciśnięciu dowolnego klawisza...");
            Console.ReadKey();
        }
    }
}
