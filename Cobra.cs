class Cobra
{
    public List <Ponto> Lista_Pontos;
    public Cobra()
    {
        Lista_Pontos = new List<Ponto>();
        Lista_Pontos.Add(new Ponto (20,10)); // cabeça
        Lista_Pontos.Add(new Ponto(19,10)); // meio
        Lista_Pontos.Add(new Ponto(18,10)); // cauda
    }

    public void Desenhar()
    {
        foreach(Ponto p in Lista_Pontos)
        {
            Console.SetCursorPosition(p.X, p.Y);
            Console.Write("O");
        }
    }
    public void Mover(ConsoleKey tecla)
    {
        // Pegar posição atual da cabeça (indiice 0)
        Ponto cabecaAtual = Lista_Pontos[0];
        //definir posição da cabeça nova
        int novoX = cabecaAtual.X;
        int novoY = cabecaAtual.Y;

        //andar com o x e y de acordo com a tecla pressionada
        if(tecla == ConsoleKey.RightArrow)
        {
            novoX ++; // se for para a direita, o x aumenta
        }
        else if (tecla == ConsoleKey.LeftArrow)
        {
            novoX --; // esquerda, x diminui
        }
        else if(tecla == ConsoleKey.UpArrow)
        {
            novoY--; // se for pra cima, y diminui
        }
        else if (tecla == ConsoleKey.DownArrow)
        {
            novoY++; // se for pra baixo, y aumenta
        }
        //criar nova cabeça com a posição calculada
        Ponto novaCabeca = new Ponto(novoX, novoY);
        //Insere nova cabeça no começo da lista       
        Lista_Pontos.Insert(0, novaCabeca);
        //Remove a calda antiga para manter o tamanho
        Lista_Pontos.RemoveAt(Lista_Pontos.Count - 1);

    }
}