using System;
using tabuleiro;

namespace xadrez
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Tabuleiro t = new Tabuleiro(8, 8);

                t.ColocarPeca(new Torre(Cor.Preto, t), new Posicao(0, 0));
                t.ColocarPeca(new Torre(Cor.Preto, t), new Posicao(1, 3));
                t.ColocarPeca(new Rei(Cor.Preto, t), new Posicao(2, 4));
                t.ColocarPeca(new Rei(Cor.Preto, t), new Posicao(0, 20));

                Tela.ImprimirTabuleiro(t);

                
            }
            catch (TabuleiroException e)
            {
                Console.WriteLine("Erro: "  + e.Message);
            }
        }
    }
}
