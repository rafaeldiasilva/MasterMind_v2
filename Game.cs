using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterMind_v2
{
    public abstract class Game
    {
        Random random;
        Dictionary<int, string> BibCores = new Dictionary<int, string>();
        int tamanho_array_solucao, numero_tentativas, numero_tentativas_max;
        int[] DesafioCores, Jogada;
        readonly string[] CORES;
        public string tentativas { get; set; }
        public string output_solucao_jogador { get; set; }
        public virtual bool Ganhou_Perdeu { get; set; }

    public Game()
        {
            tentativas = "";
            output_solucao_jogador = "";
            numero_tentativas_max = 1;
            tamanho_array_solucao = 4;
            numero_tentativas = 1;
            DesafioCores = new int[tamanho_array_solucao];
            Jogada = new int[tamanho_array_solucao];
            CORES = new string[]{ "Azul", "Verde", "Amarelo", "Vermelho", "Castanho", "Rosa", "Roxo", "Laranja", "Ameixa", "Preto" };
            random = new Random();
        }
        public abstract string nome_jogador();
       
        int RandomNumber(int min, int max)
        {
            return this.random.Next(min, max);
        }
        public void run()
        {   tentativas = ArrayIntToString(Jogada);
            AddCores();
            SorteioCores();
            PedirEscolha();
            while (numero_tentativas < numero_tentativas_max)
            {   
                
                
                if (!VerificarGanhou(VerificarJogada(Jogada, DesafioCores)))
                {   numero_tentativas++;
                    output_solucao_jogador = ArrayIntToString(OutputSolucaoJogador(VerificarJogada(Jogada, DesafioCores)));
                    
                    ImprimirHistoricoJogada(tentativas, output_solucao_jogador);
                    
                    PedirEscolha();
                }
                else if( VerificarGanhou(VerificarJogada(Jogada, DesafioCores)))
                {
                    Ganhou_Perdeu = true;
                    break;
                }
            } 
            if(!VerificarGanhou(VerificarJogada(Jogada, DesafioCores)) && numero_tentativas == numero_tentativas_max)
            {
                Ganhou_Perdeu = false;
            }
        }
        public abstract void escreverGanhou_Perdeu_Solucao(string solucaoCores, string jogada);
        public string buscarCoresSolucao()
        {
            string cores = "";
            for(int i = 0; i < DesafioCores.Length; i++)
            {
               if (i == 0)
                    cores = $"[{BibCores[DesafioCores[i]]} ";
               else if (i > 0 && i < DesafioCores.Length - 1)
                    cores += $",{BibCores[DesafioCores[i]]}, ";
                else
                    cores += $"{BibCores[DesafioCores[i]]}]";
            }
            return cores;
        }

        void ImprimirHistoricoJogada(string tentativas, string output_solucao_jogador)
        {
            Console.WriteLine("\nTentativa        Resultado");
            Console.WriteLine(tentativas + " "+ output_solucao_jogador+"\n");
        }

        void AddCores()
        {
            for(int i = 1; i <= this.CORES.Length; i++)
            {
                this.BibCores.Add(i, CORES[i - 1]);
            }
        }

        void SorteioCores()
        {
            for (int i = 0; i < DesafioCores.Length; i++)
            {
                this.DesafioCores[i] = BibCores.Keys.ElementAt(RandomNumber(0, BibCores.Count));
            }

        }

        void Info()
        {
            Console.WriteLine("Escolha uma cor pelo Digito correspondente\n" +
            "[1 - Azul] [2 - Verde] [3 - Amarelo]\n" +
            "[4 - Vermelho] [5 - Castanho] [6 - Rosa]\n" +
            "[7 - Roxo] [8 - Laranja] [9 - Ameixa] [10 - Preto] ");
        }

        void PedirEscolha()
        {
            Info();
            for (int i = 0; i < Jogada.Length; i++)
            {
                while (true)
                {
                    Console.Write(i + 1 + "º Cor: ");
                    Jogada[i] = Convert.ToInt32(Console.ReadLine());
                    if (Jogada[i] >= 1 && Jogada[i] <= 10)
                        break;
                    else
                        Console.WriteLine("Opcao Invalida, escolha um numero entre 1 a 10");
                }
                
            }
        }

        int[] VerificarJogada(int[] Jogada, int[] DesafioCores)
        {
            int[] solucao = new int[DesafioCores.Length];
            for (int i = 0; i < Jogada.Length; i++)
            {
                for (int j = 0; j < DesafioCores.Length; j++)
                {
                    if (Jogada[i] == DesafioCores[j])
                    {
                        if (i == j)
                        {
                            solucao[i] = 2;
                            break;
                        }

                        else
                            solucao[i] = 1;
                    }
                    else
                    {
                        if (solucao[i] == 1)
                            continue;
                        solucao[i] = 0;
                    }
                }
            }
            return solucao;
        }

        bool VerificarGanhou(int[] solucao)
        {
            for (int i = 0; i < solucao.Length; i++)
            {
                if (solucao[i] != 2)
                {
                    return false;
                }
            }
            return true;
        }

        int[] OutputSolucaoJogador(int[] solucao)
        {
            int[] cloneArray = new int[4];
            int[] randArray = new int[] { RandomNumber(0, 4), -1, -1, -1 };
            bool flag = false, flag1 = false;
            int randNum;
            int aux = 0;

            //solucao.ToList().Sort();

            while (!flag)
            {
                randNum = RandomNumber(0, 4);

                for (int j = 0; j < randArray.Length; j++)
                {
                    if (randNum == randArray[j])
                    {
                        flag1 = true;
                        break;
                    }

                }
                if (!flag1)
                {
                    randArray[++aux] = randNum;
                }
                flag1 = false;
                if (randArray[randArray.Length - 1] != -1)
                    flag = true;

            }

            for (int i = 0; i < solucao.Length; i++)
            {
                cloneArray[i] = solucao[randArray[i]];
            }

            return cloneArray;
        }

        string ArrayIntToString(int[] array)
        { string arrayString = "";

            for (int i = 0; i < array.Length; i++) {

                if (i == 0)
                    arrayString = $"[{array[i]} ";

                else if (i > 0 && i < array.Length - 1)
                    arrayString += $",{array[i]}, ";

                else
                    arrayString += $"{array[i]}]";
            }
            return arrayString;
        }
    }
}

