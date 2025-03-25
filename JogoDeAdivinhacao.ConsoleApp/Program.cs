namespace JogoDeAdivinhacao.ConsoleApp
{
    internal class Program
    {
        // Versão 1: Estrutura Básica e Entrada do Usuário
        static void Main(string[] args)
        {
            Console.WriteLine("-------------------------------------------------------------");
            Console.WriteLine("Jogo de Adivinhação");
            Console.WriteLine("-------------------------------------------------------------");

            // Lógica do Jogo
            Console.Write("Digite Para Chutar: ");
            int numerodigitado = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Você Digitou o Número: " + numerodigitado);


            Console.ReadLine();
        }
    }
}
