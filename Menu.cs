using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterMind_v2
{
    class Menu
    {
        New_Game new_game;
        public Menu()
        {
            menu_principal();
        }

        void menu_principal()
        {
            bool sair = false;
            while (true)
            {
                if (sair) break;
                Console.Clear();
                Console.WriteLine("1. Iniciar Jogo\nEscape para sair");
                var keyData = Console.ReadKey(false).Key;
                Console.Clear();
                switch (keyData)
                {
                    case ConsoleKey.D1:
                    case ConsoleKey.NumPad1:
                        subMenu();
                        break;
                    case ConsoleKey.Escape:
                        sair = true;
                        break;
                }
            }
        }

        void subMenu()
        {
          
            bool sair = false;
            
            while (true)
            {
                if (sair) break;
                Console.Clear();
                Console.WriteLine("1. New Game\nEscape para sair");

                var keyData = Console.ReadKey(false).Key;
                Console.Clear();
                switch (keyData)
                {
                    case ConsoleKey.D1:
                    case ConsoleKey.NumPad1:
                        Console.Write("Escreva o seu Nome:");
                        string nome_jogador = Console.ReadLine();
                        new_game = new New_Game( nome_jogador);
                        Console.ReadLine();
                        break;

                    case ConsoleKey.Escape:
                        sair = true;
                        break;
                }
            }

        }
    }
}
