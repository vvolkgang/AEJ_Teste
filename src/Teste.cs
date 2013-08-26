using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AED_entregaCSharp
{
    static class Teste1
    {
        /// <summary>
        /// Pretende-se um algoritmo que proceda à leitura da nota do teste de 
        /// cada aluno de uma turma e indique a diferença entre a maior e a menor 
        /// nota. Não sabemos quantos akunos são pelo que deve usar uma sentinela
        ///  na leitura das notas ( não deve usar arrays )
        /// </summary>
        public static void questao1_G1()
        {
            float nota = 0, notaMax = 0, notaMin = 21;
            int i = 1;
            string rsp = "";

            bool terminar = false;
            do
            {
                Console.Write("\nIndique a nota do aluno numero " + i + ": ");
                nota = float.Parse(Console.ReadLine()); //pode dar erro
                if (i == 1)
                {
                    notaMax = nota;
                    notaMin = nota;
                }
                else
                {
                    if (nota > notaMax)
                        notaMax = nota;
                    else
                        if (nota < notaMin)
                            notaMin = nota;
                }

                Console.WriteLine("\nDeseja introduzir mais dados? (s / n )");
                rsp = Console.ReadLine().ToLower(); //pode dar erro!

                if (rsp[0] == 'n')
                    terminar = true;

                i++;
            } while (!terminar);

            Console.WriteLine("Maior nota registada> {0}\nMenor nota registada> {1}\nDiferenca Max-Min> {2}", notaMax, notaMin, (notaMax - notaMin));
        }

        /// <summary>
        /// 2 - Desenvolva um algoritmo que leia uma dada quantia em euros, inferior a 5€, 
        /// e determine o nº minimo de moedas de 2€, 1€, 0,5€, 0,2€, 0,1€, 0,05€, 0,02€ e 0,01€ que lhe corresponde.
        /// </summary>
        public static void questao2_G1()
        {
            float quantia = 0;
            byte m2euros = 0, m1euro = 0, m50cents = 0, m20cents = 0, m10cents = 0, m5cents = 0, m2cents = 0, m1cent = 0;

            Console.WriteLine("\n\nIndique a quantia inicial: ");
            quantia = float.Parse(Console.ReadLine()); //pode dar erro!

            quantia = contaNumMoedas(quantia, 2, out m2euros);
            quantia = contaNumMoedas(quantia, 1, out m1euro);
            quantia = contaNumMoedas(quantia, 0.50f, out m50cents);
            quantia = contaNumMoedas(quantia, 0.20f, out m20cents);
            quantia = contaNumMoedas(quantia, 0.10f, out m10cents);
            quantia = contaNumMoedas(quantia, 0.05f, out m5cents);
            quantia = contaNumMoedas(quantia, 0.02f, out m2cents);
            quantia = contaNumMoedas(quantia, 0.01f, out m1cent);

            if (m2euros > 0)
                Console.WriteLine("Numero de moedas de 2 euros> " + m2euros);

            if (m1euro > 0)
                Console.WriteLine("Numero de moedas de 1 euro> " + m1euro);

            if (m50cents > 0)
                Console.WriteLine("Numero de moedas de 50 centimos> " + m50cents);

            if (m20cents > 0)
                Console.WriteLine("Numero de moedas de 20 centimos> " + m20cents);
            if (m10cents > 0)
                Console.WriteLine("Numero de moedas de 10 centimos> " + m10cents);

            if (m5cents > 0)
                Console.WriteLine("Numero de moedas de 5 centimos> " + m5cents);

            if (m2cents > 0)
                Console.WriteLine("Numero de moedas de 2 centimos> " + m2cents);

            if (m1cent > 0)
            {
                if (quantia > 0)
                    m1cent++;

                Console.WriteLine("Numero de moedas de 1 centimos> " + m1cent);
            }
            Console.WriteLine("Quantia restante> " + quantia);
        }

        private static float contaNumMoedas(float quantia, float valorMoeda, out byte moedas)
        {
            moedas = 0;

            while (quantia >= valorMoeda)
            {
                quantia -= valorMoeda;
                moedas++;
            }

            return quantia;
        }

        /// <summary>
        /// Considere uma matriz de dimensão 24x10 onde se pretende registar os valores da temperatura em 10 freguesias de Barcelos ao longo de um dia, medidas de hora a hora ( da 1 às 25h )
        /// 1 - Especifique e defina as variáveis a utilizar ( tendo em conta os pedidos formulados nas alíneas a seguir )
        /// 2 - Desenvolva um algoritmo capaz de:
        /// a) Proceder à leitura dos valores da temperatura nas 10 freguesias, de hora a hora, e de os armazenar na matirz ( 10 leituras por cada hora ).
        /// b) Identificar as freguesias ( 1,2,....9 ou 10 ) onde se verificou a temperatura média mais elevada.
        /// c) Procurar a temperatura mais elevada desse dia e indicar em que freguesia e a que horas ocorreu ( ignore a possibilidade de existirem valores repetidos na matriz )
        /// </summary>
        public static void questaoG2()
        {
            byte nFreg = 2, nTemp = 2;
            float[,] mTemperaturas = new float[nFreg, nTemp]; //guarda as temperaturas todas
            float[] mMedias = new float[nFreg]; //guarda a media das temperaturas de cada freguesia


            Console.WriteLine();
            float tempSum = 0, tempMax = 0, tempMaxFreg = 0, tempMaxHora = 0, aux = 0;
            for (int i = 0; i < nFreg; i++)
            {
                for (int k = 0; k < nTemp; k++)
                {
                    Console.WriteLine("\nIndique a temperatura da freguesia " + (i + 1) + " na hora " + (k + 1) + ":");
                    aux = float.Parse(Console.ReadLine()); //pode dar erro!

                    tempSum += aux;
                    mTemperaturas[i, k] = aux;
                    if (i == 0 && k == 0)
                        tempMax = aux;
                    else
                    {
                        if (tempMax < aux)
                        {
                            tempMax = aux;
                            tempMaxFreg = i;
                            tempMaxHora = k;
                        }
                    }
                }

                mMedias[i] = tempSum / nTemp;

                tempSum = 0;
            }


            //apresenta a media mais elevada
            float max = mMedias[0];
            float fregMedMax = 1;
            for (int i = 1; i < mMedias.Length; i++)
            {
                if (max < mMedias[i])
                {
                    max = mMedias[i];
                    fregMedMax = i;
                }
            }

            bool first = true;
            Console.Write("\n\nFreguesia com a media mais elevada> ");
            for (int i = 0; i < mMedias.Length; i++)
            {
                if (mMedias[i] == max)
                    if (first)
                    {
                        Console.Write(i + 1);
                        first = false;
                    }
                    else
                        Console.Write(", " + (i + 1));
            }
            Console.Write(".\n");

            Console.WriteLine("Temperatura maxima registada foi> " + tempMax + ", na freguesia " + (tempMaxFreg + 1) + " as " + (tempMaxHora + 1) + " horas.\n");

        }
    }
}
