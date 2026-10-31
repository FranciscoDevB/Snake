class Program
{
    static void Main()
    {
        
        // Define o tamanho fixo da janela do console para caber o mapa 
        Console.SetWindowSize(50, 25);
        Console.SetBufferSize(50, 25);

        Console.Clear();

        Mapa mapa = new Mapa();
        Cobra cobra = new Cobra();

        //começa parada
        ConsoleKey? teclaAtual = null;
        // Limpa a tela uma única vez no início do jogo
        Console.Clear();
        mapa.CriaMapa();

        while (true)
        {
            //verificar se o usuário apertou alguma tecla
            if (Console.KeyAvailable)
            {
                ConsoleKeyInfo teclaInfo = Console.ReadKey(true);

                //se apertar ESC, encerra o jogo;
                if(teclaInfo.Key == ConsoleKey.Escape)
                {
                    Console.Clear();
                    Console.Write("Você saiu do Jogo!");
                    break;
                }
                
                if (teclaInfo.Key == ConsoleKey.RightArrow || 
                    teclaInfo.Key == ConsoleKey.LeftArrow || 
                    teclaInfo.Key == ConsoleKey.UpArrow || 
                    teclaInfo.Key == ConsoleKey.DownArrow)
                {
                  //guarda a tecla apertada para a cobra continuar andando
                    teclaAtual = teclaInfo.Key;  
                }

            }

            //só move a cobra se o ususario ja tiver apertado alguma seta para começar
            if (teclaAtual.HasValue)
            {
                //apaga a cauda antiga antes de mover
                Ponto caudaAntiga = cobra.Lista_Pontos[cobra.Lista_Pontos.Count - 1];
                Console.SetCursorPosition(caudaAntiga.X, caudaAntiga.Y);
                Console.Write(" ");
                //move a cobra para a posição nova
                cobra.Mover(teclaAtual.Value);

                //checa se a cabeça teve colisões
                Ponto cabeca = cobra.Lista_Pontos[0];

                //se bater, game over
                if(cabeca.X <= 0 || cabeca.X >= mapa.Largura - 1 || cabeca.Y <= 0 || cabeca.Y >= mapa.Altura - 1)
                {
                    Console.Clear();
                    Console.WriteLine("GAME OVER! A cobra bateu na parede.");
                    break;
                }
            }
            cobra.Desenhar();

            //pausa
            System.Threading.Thread.Sleep(120);
        }
    }
}