using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace brainfuck_konsola
{
    internal class Program
    {
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
                    Console.Write("\n| >.+++.------.--------.>+.>.                                                          |                  |");
                    Console.Write("\n|---------------------------------------------------------------------------------------------------------|");
                    Console.Write("\n| +++++++++++[>+++++++>+++++++++++>+++++++++>+++<<<<-]>-.>----.----------.>--.<+++++++ |    Moje imię     |");
                    Console.Write("\n| +.+++++++.>>-.<<<+++++++++++.>-----------.-----.>+++.---.<++.+++++++.--------.--.    |    i nazwisko    |");
                    Console.Write("\n|---------------------------------------------------------------------------------------------------------|");
                    Console.Write("\n| ++++++++++[>+++++++>+++++++++++>++++++++++<<<-]>----.>++++.>---.++++++++.+++++.----- |    Brainfuck     |");
                    Console.Write("\n| ---.<+++.>---.++++++++.                                                              |                  |");
                    Console.Write("\n|---------------------------------------------------------------------------------------------------------|");
                    Console.Write("\n\nPracę wykonał Łukasz Wojdalski.");
                    Console.Write("\n\nProszę wybrać jedną z tych opcji: H (info), P (kompilacja) lub E (wyjście): ");
                    opcja = Console.ReadKey();
                }
                else if (opcja.Key == ConsoleKey.P)
                {
                    Console.Write("\n\nTu się zadzieje cała magia.");
                    Console.Write("\n\nProszę wybrać jedną z tych opcji: H (info), P (kompilacja) lub E (wyjście): ");
                    opcja = Console.ReadKey();
                }
            } while (opcja.Key != ConsoleKey.E);
            Console.Write("\n\nProgram zostanie zamknięty po naciśnięciu dowolnego klawisza.");
            Console.ReadKey();
        }
    }
}
