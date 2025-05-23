using System;
using System.Collections.Generic;

namespace CatalogoFilmes
{
    // Classe que representa um filme com suas propriedades
    public class Filme
    {
        public string Titulo { get; }
        public string Diretor { get; }
        public int AnoLancamento { get; }
        public string Genero { get; }
        public int DuracaoMinutos { get; }

        public Filme(string titulo, string diretor, int anoLancamento, string genero, int duracaoMinutos)
        {
            if (string.IsNullOrWhiteSpace(titulo)) throw new ArgumentException("Título não pode ser vazio.");
            if (string.IsNullOrWhiteSpace(diretor)) throw new ArgumentException("Diretor não pode ser vazio.");
            if (anoLancamento <= 1800 || anoLancamento > DateTime.Now.Year) throw new ArgumentOutOfRangeException(nameof(anoLancamento), "Ano inválido.");
            if (string.IsNullOrWhiteSpace(genero)) throw new ArgumentException("Gênero não pode ser vazio.");
            if (duracaoMinutos <= 0) throw new ArgumentOutOfRangeException(nameof(duracaoMinutos), "Duração deve ser maior que zero.");

            Titulo = titulo;
            Diretor = diretor;
            AnoLancamento = anoLancamento;
            Genero = genero;
            DuracaoMinutos = duracaoMinutos;
        }

        public void ExibirDetalhes()
        {
            Console.WriteLine($"Título: {Titulo}");
            Console.WriteLine($"Diretor: {Diretor}");
            Console.WriteLine($"Ano de Lançamento: {AnoLancamento}");
            Console.WriteLine($"Gênero: {Genero}");
            Console.WriteLine($"Duração: {DuracaoMinutos} minutos");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Criação da lista de filmes
            List<Filme> filmes = new List<Filme>
            {
                new Filme("Rei Arthur: A Lenda da Espada", "Guy Ritchie", 2017, "Fantasia, aventura e ação inspirado nas lendas arturianas", 178),
                new Filme("Velozes e Furiosos 5: Operação Rio", "Justin Lin", 2011, "Ação", 136),
                new Filme("Barbie e as doze princesas bailarina", "Terry Klassen, Greg Richardson", 2006, "Infantil", 139)
            };

            bool executar = true;

            while (executar)
            {
                try
                {
                    Console.Clear();
                    Console.WriteLine("==== Catálogo de Filmes ====");
                    Console.WriteLine("Selecione um filme para ver detalhes:");
                    for (int i = 0; i < filmes.Count; i++)
                    {
                        Console.WriteLine($"{i + 1} - {filmes[i].Titulo}");
                    }
                    Console.WriteLine("0 - Sair");
                    Console.Write("Digite a opção desejada: ");

                    string entrada = Console.ReadLine();

                    if (!int.TryParse(entrada, out int opcao))
                    {
                        Console.WriteLine("Entrada inválida. Por favor, digite um número válido.");
                        Pausar();
                        continue;
                    }

                    if (opcao == 0)
                    {
                        executar = false;
                        Console.WriteLine("Encerrando o programa. Obrigado por usar!");
                        Pausar();
                        continue;
                    }

                    if (opcao < 1 || opcao > filmes.Count)
                    {
                        Console.WriteLine("Opção fora do intervalo válido. Tente novamente.");
                        Pausar();
                        continue;
                    }

                    Console.Clear();
                    filmes[opcao - 1].ExibirDetalhes();
                    Pausar();
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Ocorreu um erro: {ex.Message}");
                    Pausar();
                }
            }
        }

        // Método para pausar e esperar que o usuário pressione uma tecla para continuar
        private static void Pausar()
        {
            Console.WriteLine("\nPressione qualquer tecla para continuar...");
            Console.ReadKey();
        }
    }
}





