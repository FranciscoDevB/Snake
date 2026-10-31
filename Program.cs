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

        // gerar posições aleatorias para comidas
        Random random = new Random();
        Ponto comida = new Ponto(random.Next(1, mapa.Largura - 1), random.Next(1, mapa.Altura - 1));

        //desenha a comida inicial na tela
        Console.SetCursorPosition(comida.X, comida.Y);
        Console.Write("*");

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
                    Console.SetCursorPosition(15, 10); // Centraliza no meio
                    Console.Write("Você saiu do Jogo!");
                    Console.SetCursorPosition(12, 12);
                    Console.ReadKey();
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

            //só move a cobra se o usuario ja tiver apertado alguma seta para começar
            if (teclaAtual.HasValue)
            {
                Ponto cabecaAtual = cobra.Lista_Pontos[0];
                int proximoX = cabecaAtual.X;
                int proximoY = cabecaAtual.Y;

                //descobre onde a cabeça vai no proximo passo
                if (teclaAtual.Value == ConsoleKey.RightArrow) proximoX++;
                else if (teclaAtual.Value == ConsoleKey.LeftArrow) proximoX--;
                else if (teclaAtual.Value == ConsoleKey.UpArrow) proximoY--;
                else if (teclaAtual.Value == ConsoleKey.DownArrow) proximoY++;

                // Verifica se a cabeça vai colidir com a parede (usando <= e >= para evitar valores negativos)
                if (proximoX <= 0 || proximoX >= mapa.Largura - 1 || 
                    proximoY <= 0 || proximoY >= mapa.Altura - 1)
                {
                    Console.Clear();
                    Console.SetCursorPosition(8, 10); // Centraliza no meio
                    Console.WriteLine("GAME OVER! A cobra bateu na parede.");
                    Console.SetCursorPosition(12, 12);
                    Console.WriteLine("Pressione qualquer tecla para sair...");
                    Console.ReadKey();
                    break;
                }

                //verifica se a cobra vai bater nela mesma (inicia no 1, pois o 0 é a cabeça)
                bool bateuNoCorpo = false;
                for(int i = 1; i < cobra.Lista_Pontos.Count; i++)
                {
                    if(proximoX == cobra.Lista_Pontos[i].X && proximoY == cobra.Lista_Pontos[i].Y)
                    {
                        // Se bater no pescoço (i == 1), ignoramos para não dar falso game over na meia-volta
                        if(i == 1)
                        {
                            break;
                        }

                        bateuNoCorpo = true;
                        break;
                    }
                }

                if (bateuNoCorpo)
                {
                    Console.Clear();
                    Console.SetCursorPosition(6, 10); // Centraliza no meio
                    Console.WriteLine("GAME OVER! A cobra bateu no próprio corpo.");
                    Console.SetCursorPosition(12, 12);
                    Console.WriteLine("Pressione qualquer tecla para sair...");
                    Console.ReadKey();
                    break;
                }

                //verifica se a cobra comeu
                bool comeu = (proximoX == comida.X && proximoY == comida.Y);

                if (!comeu)
                {
                    // Apaga a cauda antiga apenas se não for crescer
                    Ponto caudaAntiga = cobra.Lista_Pontos[cobra.Lista_Pontos.Count - 1];
                    Console.SetCursorPosition(caudaAntiga.X, caudaAntiga.Y);
                    Console.Write(" ");
                }
                else
                {
                    // Se comeu, sorteia uma nova posição para a comida
                    comida.X = random.Next(1, mapa.Largura - 1);
                    comida.Y = random.Next(1, mapa.Altura - 1);

                    Console.SetCursorPosition(comida.X, comida.Y);
                    Console.Write("*");
                }

                //move a cobra (se true, ela comeu e cresce)
                cobra.Mover(teclaAtual.Value, comeu);
            }

            //desenha a cobra atualizada
            cobra.Desenhar();   
            
            //pausa (velocidade controlada)
            System.Threading.Thread.Sleep(180);
        }
    }
}