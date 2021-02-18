using System;
using System.Collections.Generic;
using tabuleiro;
using xadrez;

namespace xadrez
{
    class Tela
    {

        public static void ImprimirPartida(PartidaXadrez partida)
        {
            Tela.ImprimirTabuleiro(partida.Tab);
            ImprimirPecasCapturadas(partida);
            Console.WriteLine("\n\n-> Turno: " + partida.Turno);
            Console.WriteLine("-> Aguardando Jogada: " + partida.JogadorAtual);
        }

        public static void ImprimirPecasCapturadas(PartidaXadrez partida)
        {
            Console.WriteLine("\n\n-> Peças Capturadas: ");
            Console.Write("-> Azuis: ");
            ImprimirConjunto(partida.PecasCapturadas(Cor.Azul));
            Console.Write("\n-> Verdes: ");
            ConsoleColor aux = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Green;
            ImprimirConjunto(partida.PecasCapturadas(Cor.Verde));
            Console.ForegroundColor = aux;
            Console.WriteLine("");
        }

        public static void ImprimirConjunto(HashSet<Peca> conjunto)
        {
            Console.Write("[");
            foreach(Peca x in conjunto)
            {
                Console.Write(x + " ");
            }
            Console.Write("]");
        }

        public static void ImprimirTabuleiro(Tabuleiro tab)
        {
            for(int i=0; i<tab.Linhas; i++)
            {
                Console.Write(8 - i + " ");

                for(int j=0; j<tab.Colunas; j++)
                {
                    ImprimirPeca(tab.peca(i, j));
                }
                Console.WriteLine();
            }
            Console.Write("  A B C D E F G H");
        }

        public static void ImprimirTabuleiro(Tabuleiro tab, bool[,] posicoesPossiveis)
        {
            ConsoleColor fundoOriginal = Console.BackgroundColor;
            ConsoleColor fundoAlterado = ConsoleColor.DarkGray;
            

            for (int i = 0; i < tab.Linhas; i++)
            {
                Console.Write(8 - i + " ");

                for (int j = 0; j < tab.Colunas; j++)
                {
                    if (posicoesPossiveis[i,j])
                    {
                        Console.BackgroundColor = fundoAlterado;
                    }
                    else
                    {
                        Console.BackgroundColor = fundoOriginal;
                    }
                    ImprimirPeca(tab.peca(i, j));
                    Console.BackgroundColor = fundoOriginal;
                }
                Console.WriteLine();
            }
            Console.Write("  A B C D E F G H");
            Console.BackgroundColor = fundoOriginal;
        }

        public static PosicaoXadrez LerPosicaoXadrez()
        {
            string s = Console.ReadLine();
            char coluna = s[0];
            int linha = int.Parse(s[1] + "");
            return new PosicaoXadrez(coluna, linha);
        }

        public static void ImprimirPeca(Peca peca)
        {
            ConsoleColor fundoOriginal = Console.BackgroundColor;
            ConsoleColor fundoAlterado = ConsoleColor.White;

            if (peca == null)
            {
                Console.Write("- ");
            }
            else
            {
                if (peca.Cor == Cor.Azul)
                {
                    ConsoleColor aux = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.Write(peca);
                    Console.ForegroundColor = aux;
                }
                else
                {
                    ConsoleColor aux = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write(peca);
                    Console.ForegroundColor = aux;
                }
                Console.Write(" ");
            }
        }
    }
}
