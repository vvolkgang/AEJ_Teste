using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AED_entregaCSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            string rsp = "";

            bool terminar = false;
            do
            {
                printMenu();

                Console.WriteLine("\nEscolha a questao que quer executar: (exemplo, 1.1, 1.2)");
                rsp = Console.ReadLine();

                switch (rsp)
                {
                    case "1.1": Teste1.questao1_G1(); break;
                    case "1.2": Teste1.questao2_G1(); break;
                    case "2": Teste1.questaoG2(); break;
                    default: Console.WriteLine("\n\tEnganou-se no numero da questao!"); break;
                }

                terminar = askExit();
            } while (!terminar);
        }

        private static bool askExit()
        {
            Console.WriteLine("\nDeseja terminar a aplicacao? (s / n )");
            string rsp = Console.ReadLine().ToLower(); //pode dar erro!

            if (rsp[0] == 's')
                return true;

            return false;
        }

        private static void printMenu()
        {
            Console.WriteLine();
            Console.WriteLine(" ************************************************");
            Console.WriteLine(" *                  Teste AED                   *");
            Console.WriteLine(" ************************************************");
            Console.WriteLine(" *                                              *");
            Console.WriteLine(" * GRUPO 1 - Elementos e estruturas fundamentais*");
            Console.WriteLine(" * 1.1 - Introduzir notas, ver max, min e diff. *");
            Console.WriteLine(" * 1.2 - Troco em moedas.                       *");
            Console.WriteLine(" *                                              *");
            Console.WriteLine(" * GRUPO 2 - Arrays                             *");
            Console.WriteLine(" * Temperaturas em 10 freguesias de Barcelos.   *");
            Console.WriteLine(" *                                              *");
            Console.WriteLine(" * NOTA: Foi reduzido o numero de freguesias e  *");
            Console.WriteLine(" * horas para facilitar o teste, 2 freguesias e *");
            Console.WriteLine(" * 2 horas.                                     *");
            Console.WriteLine(" *                                              *");
            Console.WriteLine(" ************************************************");
            Console.WriteLine();
        }
    }
}
