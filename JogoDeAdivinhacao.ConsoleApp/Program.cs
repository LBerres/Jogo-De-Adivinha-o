using System.ComponentModel.Design;

namespace JogoDeAdivinhacao.ConsoleApp
{
    // Desafio - Refatoração do Código.
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                MenuInicial();

                int totalDeTentativas = EscolhaDeDificuldade();

                // Geração Do Número Aleatório
                Random geradorDeNumeros = new Random();
                int numeroSecreto = geradorDeNumeros.Next(1, 21);

                // Declarando o Armazenamento dos Números Já Chutados
                int[] numerosChutados = new int[100];
                int contadorNumerosChutados = 0;

                // Sistema de Pontuação
                int pontuacao = 1000;

                EstruturaDoJogo(totalDeTentativas, pontuacao, numerosChutados, contadorNumerosChutados, numeroSecreto);

                string opcaoContinuar = MenuFinal();

                if (opcaoContinuar != "S")
                    break;
            }

        }

        static void MenuInicial()
        {
            Console.Clear();
            Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("                                                  Jogo de Adivinhação                                                   ");
            Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");

        }

        static int EscolhaDeDificuldade()
        {
            Console.WriteLine("Escolha Um Nível de Dificuldade:");
            Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("1 - Fácil (10 Tentativas)");
            Console.WriteLine("2 - Médio (5 Tentativas)");
            Console.WriteLine("3 - Difícil (3 Tentativas)");
            Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");

            int totalDeTentativas = 0;

            Console.Write("Digite Sua Escolha: ");
            string entrada = Console.ReadLine();

            if (entrada == "1")
                totalDeTentativas = 10;
            else if (entrada == "2")
                totalDeTentativas = 5;
            else if (entrada == "3")
                totalDeTentativas = 3;

            return totalDeTentativas;
        }

        // Lógica Do Jogo
        static void EstruturaDoJogo(int totalDeTentativas, int pontuacao, int[] numerosChutados, int contadorNumerosChutados, int numeroSecreto)
        {
            for (int tentativa = 1; tentativa <= totalDeTentativas; tentativa++)
            {
                MenuInGame(tentativa, totalDeTentativas, pontuacao, numerosChutados);

                int numeroDigitado;
                bool numeroRepetido;

                do
                {
                    numeroRepetido = false;

                    Console.Write("Digite Um Número Entre 1 e 20: ");
                    numeroDigitado = Convert.ToInt32(Console.ReadLine());

                    NumerosRepetidos(numeroRepetido, numeroDigitado, numerosChutados);

                } while (numeroRepetido == true);

                numerosChutados[contadorNumerosChutados] = numeroDigitado;
                contadorNumerosChutados++;

                if (numeroDigitado == numeroSecreto)
                {
                    Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");
                    Console.WriteLine("                                              Parabéns! Você Acertou!                                                   ");
                    Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");

                    break;
                }

                else if (tentativa == totalDeTentativas)
                {
                    Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");
                    Console.WriteLine($"Que Pena! Você Usou Todas as Tentativas. O Número Era {numeroSecreto}.");
                    Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");

                    break;
                }

                else if (numeroDigitado > numeroSecreto)
                {
                    Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");
                    Console.WriteLine("                                 O Número Digitado é Maior Que o Número Secreto.");
                    Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");

                    pontuacao -= Math.Abs((numeroDigitado - numeroSecreto) / 2);
                }
                else
                {
                    Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");
                    Console.WriteLine("                                 O Número Digitado é Menor Que o Número Secreto.");
                    Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");

                    pontuacao -= Math.Abs((numeroDigitado - numeroSecreto) / 2);
                }

                Console.WriteLine("Aperte ENTER Para Continuar...");
                Console.ReadLine();
            }
        }
        static void MenuInGame(int tentativa, int totalDeTentativas, int pontuacao, int[] numerosChutados)
        {
            Console.Clear();
            Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine($"Tentativa {tentativa} de {totalDeTentativas}");
            Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("Pontuação: " + pontuacao + " Pontos");
            Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("Números Já Chutados: ");

            for (int i = 0; i < numerosChutados.Length; i++)
            {
                if (numerosChutados[i] > 0)
                    Console.Write(numerosChutados[i] + " ");
            }

            Console.WriteLine();
            Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");

        }
        static bool NumerosRepetidos(bool numeroRepetido, int numeroDigitado, int[] numerosChutados)
        {
            for (int i = 0; i < numerosChutados.Length; i++)
            {
                if (numerosChutados[i] == numeroDigitado)

                {
                    Console.WriteLine("Você Já Digitou Este Número! Aperte ENTER Para Tentar Novamente......");
                    Console.ReadLine();

                    numeroRepetido = true;
                    break;
                }
            }
            return numeroRepetido = true;
        }

        static string MenuFinal()
        {
            Console.Write("Deseja Continuar? (S/N): ");
            string opcaoContinuar = Console.ReadLine()!.ToUpper();

            return opcaoContinuar;
        }
    }
}
