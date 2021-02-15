using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JogoDaVelha2._0
{
    class Program
    {
        static void Main(string[] args)
        {
            string[,] tabuleiro = new string[3, 3];
            int situacao;

            iniciaMatriz(tabuleiro);

            for(int i = 0; i < 9; i++)
            {
                Console.Clear();

                imprimeMatriz(tabuleiro);

                if (i > 4) {
                    situacao = verificaStatus(tabuleiro);
                    if (situacao == 1) { 
                        Console.WriteLine("Jogador X ganhou");
                        break;
                    }
                    else if (situacao == 2) { 
                        Console.WriteLine("Jogador O ganhou");
                        break;
                    }
                    else if (i == 8)
                        Console.WriteLine("Velha");
                }

                if (i % 2 == 0)
                    Console.WriteLine("Vez do jogador X\n");
                else
                    Console.WriteLine("Vez do jogador O\n");

                solicitaPosicao(tabuleiro, i);
            }

            Console.ReadKey();
        }

        static void iniciaMatriz(string[,] matriz)
        {
            for (int i = 0; i < matriz.GetLength(0); i++)
                for (int y = 0; y < matriz.GetLength(1); y++)
                    matriz[i, y] = i + "," + y;
        }

        static void imprimeMatriz(string[,] matriz)
        {
            Console.WriteLine("\t-------------------------");
            for (int i = 0; i < matriz.GetLength(0); i++)
            {
                for (int y = 0; y < matriz.GetLength(1); y++)
                    Console.Write("\t|  " + matriz[i, y]);

                Console.Write("\t|"); // DEIXAR MATRIZ EM UM FORMATO DE TABULEIRO
                Console.WriteLine("");
                Console.Write("\t-------------------------");
                Console.WriteLine("");
            }
            Console.WriteLine("");
        }

        static void solicitaPosicao(string[,] matriz, int jogador)
        {
            try
            {
                int linha, coluna;

                do // VERIFICAÇÃO CÉLULA JÁ INSERIDA
                {
                        Console.Write("Informe a linha: ");
                        linha = int.Parse(Console.ReadLine());

                        Console.Write("Informe a coluna: ");
                        coluna = int.Parse(Console.ReadLine());
                } while (matriz[linha, coluna] == " X" || matriz[linha, coluna] == " O");

                if (jogador % 2 == 0)
                    matriz[linha, coluna] = " X";
                else
                    matriz[linha, coluna] = " O";
            }
            catch (Exception)
            {
                Console.WriteLine("Digite apenas números dentro da matriz");
                solicitaPosicao(matriz, jogador);
            }
        }

        static int verificaStatus(string[,] matriz)
        {
            string comparar;

            // VERIFICA DIAGONAL PRINCIPAL
            comparar = matriz[0, 0];
            if (comparar == matriz[1, 1] && comparar == matriz[2, 2])
                if (comparar == " X")
                    return 1;
                else
                    return 2;

            // VERIFICA DIAGONAL SECUNDARIA
            comparar = matriz[2, 0];
            if (comparar == matriz[1, 1] && comparar == matriz[0, 2])
                if (comparar == " X")
                    return 1;
                else
                    return 2;

            // VERIFICA HORIZONTAL
            for (int i = 0; i < 3; i++)
            {
                comparar = matriz[i, 0];
                if (comparar == matriz[i, 1] && comparar == matriz[i, 2])
                   if (comparar == " X")
                       return 1;
                   else
                       return 2;
            }

            // VERIFICA VERTICAL
            for(int y = 0; y < 3; y++)
            {
                comparar = matriz[0, y];
                if (comparar == matriz[1, y] && comparar == matriz[2, y])
                    if (comparar == " X")
                        return 1;
                    else
                        return 2;
            }
            
            return 0;
        }
    }
}