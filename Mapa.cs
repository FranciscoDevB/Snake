using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;

class Mapa
{
    public int Largura = 40;
    public int Altura = 20;
    public Mapa(){
        CriaMapa();
    }
    public void CriaMapa()
    {   
        for(int a =0; a<Altura; a++)
        {
            for(int l =0; l<Largura; l++)
            {
                if(l == 0 || l == Largura - 1 || a == 0 || a == Altura - 1)
                {
                    Console.Write("#");
                }
                else
                    Console.Write(" ");
            }
            System.Console.WriteLine();
        } 
    }
}