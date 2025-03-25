using System.ComponentModel.Design;

namespace JogoDeAdivinhacao.ConsoleApp
{
    internal class Program
    {
        // Versão 3: Verificar se o jogador acertou
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("-------------------------------------------------------------");
                Console.WriteLine("Jogo de Adivinhação");
                Console.WriteLine("-------------------------------------------------------------");

                // Lógica do Jogo
                Random geradorDeNumeros = new Random();

                int numerosecreto = geradorDeNumeros.Next(1, 21);

                Console.Write("Digite Um Número (de 1 à 20) Para Chutar: ");
                int numerodigitado = Convert.ToInt32(Console.ReadLine());

                if (numerodigitado == numerosecreto)
                {
                    Console.WriteLine("-------------------------------------------------------------");
                    Console.WriteLine("Parabéns, Você Acertou!");
                    Console.WriteLine("-------------------------------------------------------------");
                    Console.ReadLine();
                }
                else if (numerodigitado > numerosecreto)
                {
                    Console.WriteLine("-------------------------------------------------------------");
                    Console.WriteLine("O Número Digitado Foi Maior que o Número Secreto!");
                    Console.WriteLine("-------------------------------------------------------------");
                    Console.ReadLine();
                }
                else
                {
                    Console.WriteLine("-------------------------------------------------------------");
                    Console.WriteLine("O Número Digitado Foi Menor que o Número Secreto!");
                    Console.WriteLine("-------------------------------------------------------------");
                    Console.ReadLine();
                }

                Console.Write("Deseja continuar? (S/N): ");
                string opcaoContinuar = Console.ReadLine().ToUpper();

                if (opcaoContinuar != "S")
                            break;
            }
            
        }
    }
}
