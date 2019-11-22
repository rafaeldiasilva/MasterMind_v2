using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterMind_v2
{
    class New_Game:Game
    {
        string nome;
        public New_Game(string _nome_jogador)
        {
            nome = _nome_jogador;
            
            run();
            escreverGanhou_Perdeu_Solucao(base.buscarCoresSolucao(), tentativas);
        }

        public override void escreverGanhou_Perdeu_Solucao(string solucaoCores, string jogada)
        {
            if (Ganhou_Perdeu)
                Console.WriteLine($"{nome_jogador()} jogou isto: {jogada} e Ganhou o Jogo, a solucao era: {solucaoCores}");
            else
                Console.WriteLine($"{nome_jogador()} jogou isto: {jogada} e Perdeu o Jogo, a solucao era: {solucaoCores}");

        }

        public override string nome_jogador()
        {
            return nome;
        }


    }
}
