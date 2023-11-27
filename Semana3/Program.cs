using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    // Definição da tupla Produto
    public record Produto(int Codigo, string Nome, int QuantidadeEmEstoque, double PrecoUnitario);

    static List<Produto> estoque = new List<Produto>(); // Lista para armazenar os produtos

    static void Main(string[] args)
    {
        while (true)
        {
            Console.WriteLine("1. Cadastrar Produto");
            Console.WriteLine("2. Consultar Produto por Código");
            Console.WriteLine("3. Atualizar Estoque");
            Console.WriteLine("4. Gerar Relatórios");
            Console.WriteLine("5. Sair");
            Console.Write("Escolha uma opção: ");

            int opcao;
            if (!int.TryParse(Console.ReadLine(), out opcao))
            {
                Console.WriteLine("Opção inválida. Tente novamente.");
                continue;
            }

            switch (opcao)
            {
                case 1:
                    CadastrarProduto();
                    break;
                case 2:
                    ConsultarProdutoPorCodigo();
                    break;
                case 3:
                    AtualizarEstoque();
                    break;
                case 4:
                    GerarRelatorios();
                    break;
                case 5:
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Opção inválida. Tente novamente.");
                    break;
            }
        }
    }

    static void CadastrarProduto()
    {
        try
        {
            Console.Write("Digite o código do produto: ");
            int codigo = int.Parse(Console.ReadLine());

            Console.Write("Digite o nome do produto: ");
            string nome = Console.ReadLine();

            Console.Write("Digite a quantidade em estoque: ");
            int quantidade = int.Parse(Console.ReadLine());

            Console.Write("Digite o preço unitário: ");
            double preco = double.Parse(Console.ReadLine());

            Produto novoProduto = new Produto(codigo, nome, quantidade, preco);
            estoque.Add(novoProduto);

            Console.WriteLine("Produto cadastrado com sucesso!");
        }
        catch (FormatException)
        {
            Console.WriteLine("Erro: formato inválido. Certifique-se de inserir os dados corretamente.");
        }
    }

    static void ConsultarProdutoPorCodigo()
    {
        try
        {
            Console.Write("Digite o código do produto: ");
            int codigo = int.Parse(Console.ReadLine());

            Produto produto = estoque.FirstOrDefault(p => p.Codigo == codigo);

            if (produto == null)
            {
                throw new Exception("Produto não encontrado.");
            }

            Console.WriteLine($"Produto encontrado: {produto.Nome}, Quantidade: {produto.QuantidadeEmEstoque}, Preço: {produto.PrecoUnitario}");
        }
        catch (FormatException)
        {
            Console.WriteLine("Erro: formato inválido. Insira um código válido.");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    static void AtualizarEstoque()
    {
        try
        {
            Console.Write("Digite o código do produto: ");
            int codigo = int.Parse(Console.ReadLine());

            Produto produto = estoque.FirstOrDefault(p => p.Codigo == codigo);

            if (produto == null)
            {
                throw new Exception("Produto não encontrado.");
            }

            Console.WriteLine($"Produto: {produto.Nome}, Quantidade atual: {produto.QuantidadeEmEstoque}");

            Console.Write("Digite a quantidade a ser adicionada (use valor negativo para saída): ");
            int quantidade = int.Parse(Console.ReadLine());

            if (produto.QuantidadeEmEstoque + quantidade < 0)
            {
                throw new Exception("Quantidade insuficiente para essa saída.");
            }

            produto = produto with { QuantidadeEmEstoque = produto.QuantidadeEmEstoque + quantidade };
            estoque[estoque.FindIndex(p => p.Codigo == codigo)] = produto;

            Console.WriteLine("Estoque atualizado com sucesso!");
        }
        catch (FormatException)
        {
            Console.WriteLine("Erro: formato inválido. Insira um valor numérico.");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    static void GerarRelatorios()
    {
        try
        {
            Console.WriteLine("1. Lista de produtos com quantidade em estoque abaixo de um limite");
            Console.WriteLine("2. Lista de produtos com valor entre um mínimo e um máximo");
            Console.WriteLine("3. Valor total do estoque e de cada produto");

            Console.Write("Escolha uma opção de relatório: ");
            int opcao = int.Parse(Console.ReadLine());

            switch (opcao)
            {
                case 1:
                    Console.Write("Digite o limite de quantidade: ");
                    int limite = int.Parse(Console.ReadLine());

                    var produtosAbaixoDoLimite = estoque.Where(p => p.QuantidadeEmEstoque < limite);
                    Console.WriteLine("Produtos abaixo do limite de quantidade:");
                    foreach (var produto in produtosAbaixoDoLimite)
                    {
                        Console.WriteLine($"{produto.Nome} - Quantidade: {produto.QuantidadeEmEstoque}");
                    }
                    break;
                case 2:
                    Console.Write("Digite o valor mínimo: ");
                    double minimo = double.Parse(Console.ReadLine());

                    Console.Write("Digite o valor máximo: ");
                    double maximo = double.Parse(Console.ReadLine());

                    var produtosEntreValores = estoque.Where(p => p.PrecoUnitario >= minimo && p.PrecoUnitario <= maximo);
                    Console.WriteLine("Produtos com preço entre os valores informados:");
                    foreach (var produto in produtosEntreValores)
                    {
                        Console.WriteLine($"{produto.Nome} - Preço: {produto.PrecoUnitario}");
                    }
                    break;
                case 3:
                    double valorTotalEstoque = estoque.Sum(p => p.QuantidadeEmEstoque * p.PrecoUnitario);
                    Console.WriteLine($"Valor total do estoque: {valorTotalEstoque}");

                    Console.WriteLine("Valor total de cada produto:");
                    foreach (var produto in estoque)
                    {
                        double valorProduto = produto.QuantidadeEmEstoque * produto.PrecoUnitario;
                        Console.WriteLine($"{produto.Nome} - Valor Total: {valorProduto}");
                    }
                    break;
                default:
                    Console.WriteLine("Opção inválida. Tente novamente.");
                    break;
            }
        }
        catch (FormatException)
        {
            Console.WriteLine("Erro: formato inválido. Insira um valor numérico.");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}
