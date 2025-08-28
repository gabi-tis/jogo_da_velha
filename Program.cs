using System;

class JogoDaVelha
{
    static char[,] tabuleiro = {
        { '1', '2', '3' },
        { '4', '5', '6' },
        { '7', '8', '9' }
    };

    static int jogadorAtual = 1;
    static char simboloAtual = 'X';

    static void Main()
    {
        int jogadas = 0;
        bool jogoAtivo = true;

        while (jogoAtivo)
        {
            Console.Clear();
            MostrarTabuleiro();
            Console.WriteLine($"Jogador {jogadorAtual} ({simboloAtual}), escolha uma posição: ");
            string entrada = Console.ReadLine();

            if (int.TryParse(entrada, out int posicao) && posicao >= 1 && posicao <= 9)
            {
                if (MarcarPosicao(posicao))
                {
                    jogadas++;
                    if (VerificarVitoria())
                    {
                        Console.Clear();
                        MostrarTabuleiro();
                        Console.WriteLine($"🎉 Jogador {jogadorAtual} venceu!");
                        jogoAtivo = false;
                    }
                    else if (jogadas == 9)
                    {
                        Console.Clear();
                        MostrarTabuleiro();
                        Console.WriteLine("😐 Empate!");
                        jogoAtivo = false;
                    }
                    else
                    {
                        jogadorAtual = jogadorAtual == 1 ? 2 : 1;
                        simboloAtual = simboloAtual == 'X' ? 'O' : 'X';
                    }
                }
                else
                {
                    Console.WriteLine("Posição já ocupada. Pressione Enter para tentar novamente.");
                    Console.ReadLine();
                }
            }
            else
            {
                Console.WriteLine("Entrada inválida. Pressione Enter para tentar novamente.");
                Console.ReadLine();
            }
        }
    }

    static void MostrarTabuleiro()
    {
        Console.WriteLine("-------------");
        for (int i = 0; i < 3; i++)
        {
            Console.Write("| ");
            for (int j = 0; j < 3; j++)
            {
                Console.Write($"{tabuleiro[i, j]} | ");
            }
            Console.WriteLine("\n-------------");
        }
    }

    static bool MarcarPosicao(int posicao)
    {
        int linha = (posicao - 1) / 3;
        int coluna = (posicao - 1) % 3;

        if (tabuleiro[linha, coluna] != 'X' && tabuleiro[linha, coluna] != 'O')
        {
            tabuleiro[linha, coluna] = simboloAtual;
            return true;
        }
        return false;
    }

    static bool VerificarVitoria()
    {
        // Linhas e colunas
        for (int i = 0; i < 3; i++)
        {
            if ((tabuleiro[i, 0] == simboloAtual && tabuleiro[i, 1] == simboloAtual && tabuleiro[i, 2] == simboloAtual) ||
                (tabuleiro[0, i] == simboloAtual && tabuleiro[1, i] == simboloAtual && tabuleiro[2, i] == simboloAtual))
                return true;
        }

        // Diagonais
        if ((tabuleiro[0, 0] == simboloAtual && tabuleiro[1, 1] == simboloAtual && tabuleiro[2, 2] == simboloAtual) ||
            (tabuleiro[0, 2] == simboloAtual && tabuleiro[1, 1] == simboloAtual && tabuleiro[2, 0] == simboloAtual))
            return true;

        return false;
    }
}
