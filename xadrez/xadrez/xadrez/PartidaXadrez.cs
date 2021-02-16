using System;
using tabuleiro;

namespace xadrez
{
    class PartidaXadrez
    {
        public Tabuleiro Tab {get; private set;}
        private int Turno;
        private Cor JogadorAtual;
        public bool Terminada { get; private set; }

        public PartidaXadrez()
        {
            Tab = new Tabuleiro(8, 8);
            Turno = 1;
            JogadorAtual = Cor.Branco;
            Terminada = false;
            ColocarPeca();
        }

        public void ExecutaMovimento(Posicao origem, Posicao destino)
        {
            Peca p = Tab.RetirarPeca(origem);
            p.IncrementarQuantidadeMovimentos();
            Peca pecaCapturada = Tab.RetirarPeca(destino);
            Tab.ColocarPeca(p, destino);
        }

        public void ColocarPeca()
        {
            Tab.ColocarPeca(new Torre(Cor.Azul, Tab), new PosicaoXadrez('c', 1).ToPosicao());
            Tab.ColocarPeca(new Torre(Cor.Azul, Tab), new PosicaoXadrez('c', 2).ToPosicao());
            Tab.ColocarPeca(new Torre(Cor.Azul, Tab), new PosicaoXadrez('d', 2).ToPosicao());
            Tab.ColocarPeca(new Torre(Cor.Azul, Tab), new PosicaoXadrez('e', 2).ToPosicao());
            Tab.ColocarPeca(new Torre(Cor.Azul, Tab), new PosicaoXadrez('e', 1).ToPosicao());
            Tab.ColocarPeca(new Rei(Cor.Azul, Tab), new PosicaoXadrez('d', 1).ToPosicao());

            Tab.ColocarPeca(new Torre(Cor.Preto, Tab), new PosicaoXadrez('c', 7).ToPosicao());
            Tab.ColocarPeca(new Torre(Cor.Preto, Tab), new PosicaoXadrez('c', 8).ToPosicao());
            Tab.ColocarPeca(new Torre(Cor.Preto, Tab), new PosicaoXadrez('d', 7).ToPosicao());
            Tab.ColocarPeca(new Torre(Cor.Preto, Tab), new PosicaoXadrez('e', 7).ToPosicao());
            Tab.ColocarPeca(new Torre(Cor.Preto, Tab), new PosicaoXadrez('e', 8).ToPosicao());
            Tab.ColocarPeca(new Rei(Cor.Preto, Tab), new PosicaoXadrez('d', 8).ToPosicao());
        }
    }
}
