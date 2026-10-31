class Program
{
    static void Main()
    {
        Mapa mapa = new Mapa();
        Cobra cobra = new Cobra();

        ConsoleKey teclaAtual = ConsoleKey.RightArrow;

        while (true)
        {
            //verificar se o usuário apertou alguma tecla
            if (Console.KeyAvailable)
            {
                ConsoleKeyInfo teclaInfo = Console.ReadKey(true);

                //se apertar ESC, encerra o jogo;
                if(teclaInfo.Key == ConsoleKey.Escape)
                {
                    Console.Write("FIM DE JOGO!");
                    break;
                }
                //guarda a tecla apertada para a cobra continuar andando
                teclaAtual = teclaInfo.Key;
            }

            //atualiza o jogo
            cobra.Mover(teclaAtual);
            //renderiza na tela
            Console.Clear();
            mapa.CriaMapa(); // desenhar bordas
            cobra.Desenhar(); // desenha a cobra

            //pausa
            System.Threading.Thread.Sleep(150);
        }
    }
}