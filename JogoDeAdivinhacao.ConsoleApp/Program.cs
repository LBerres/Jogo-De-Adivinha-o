using System.ComponentModel.Design;

namespace JogoDeAdivinhacao.ConsoleApp
{
    // Versão 4: Criar Múltiplas Tentativas
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("----------------------------------------");
                Console.WriteLine("Jogo de Adivinhação");
                Console.WriteLine("----------------------------------------");

                // Escolha de dificuldade
                Console.WriteLine("Escolha Um Nível de Dificuldade:");
                Console.WriteLine("----------------------------------------");
                Console.WriteLine("1 - Fácil (10 Tentativas)");
                Console.WriteLine("2 - Médio (5 Tentativas)");
                Console.WriteLine("3 - Difícil (3 Tentativas)");
                Console.WriteLine("----------------------------------------");

                int totalDeTentativas = 0;

                Console.Write("Digite Sua Escolha: ");
                string entrada = Console.ReadLine();

                if (entrada == "1")
                    totalDeTentativas = 10;
                else if (entrada == "2")
                    totalDeTentativas = 5;
                else if (entrada == "3")
                    totalDeTentativas = 3;

                // Geração de número secreto
                Random geradorDeNumeros = new Random();

                int numeroSecreto = geradorDeNumeros.Next(1, 21);

                // Loop de tentativas do jogo
                for (int tentativa = 1; tentativa <= totalDeTentativas; tentativa++)
                {
                    Console.Clear();
                    Console.WriteLine("----------------------------------------");
                    Console.WriteLine($"Tentativa {tentativa} de {totalDeTentativas}");
                    Console.WriteLine("----------------------------------------");

                    // Lógica do jogo
                    Console.Write("Digite Um Número Entre 1 e 20: ");
                    int numeroDigitado = Convert.ToInt32(Console.ReadLine());

                    if (numeroDigitado == numeroSecreto)
                    {
                        Console.WriteLine("----------------------------------------");
                        Console.WriteLine("Parabéns! Você Acertou!");
                        Console.WriteLine("----------------------------------------");

                        break;
                    }

                    if (tentativa == totalDeTentativas)
                    {
                        Console.WriteLine("----------------------------------------");
                        Console.WriteLine($"Que Pena! Você Usou Todas as Tentativas. O Número Era {numeroSecreto}.");
                        Console.WriteLine("----------------------------------------");

                        break;
                    }

                    else if (numeroDigitado > numeroSecreto)
                    {
                        Console.WriteLine("----------------------------------------");
                        Console.WriteLine("O Número Digitado é Maior Que o Número Secreto.");
                        Console.WriteLine("----------------------------------------");
                    }
                    else
                    {
                        Console.WriteLine("----------------------------------------");
                        Console.WriteLine("O Número Digitado é Menor Que o Número Secreto.");
                        Console.WriteLine("----------------------------------------");
                    }

                    Console.WriteLine("Aperte ENTER Para Continuar...");
                    Console.ReadLine();
                }

                Console.Write("Deseja Continuar? (S/N): ");
                string opcaoContinuar = Console.ReadLine().ToUpper();

                if (opcaoContinuar != "S")
                    break;
            }

        }
    }
}
