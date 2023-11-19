using System;
using System.Collections.Generic;

class Tarefa
{
    public string Nome { get; set; }
    public DateTime Data { get; set; }
    public bool Concluida { get; set; }
}

class GerenciadorTarefas
{
    private List<Tarefa> tarefas;

    public GerenciadorTarefas()
    {
        tarefas = new List<Tarefa>();
    }

    public void AdicionarTarefa(string nome, DateTime data)
    {
        Tarefa novaTarefa = new Tarefa
        {
            Nome = nome,
            Data = data,
            Concluida = false
        };
        tarefas.Add(novaTarefa);
        Console.WriteLine("Tarefa adicionada com sucesso!");
    }

    public void ExibirTarefas()
    {
        Console.WriteLine("Lista de Tarefas:");
        foreach (var tarefa in tarefas)
        {
            Console.WriteLine($"Nome: {tarefa.Nome} - Data: {tarefa.Data.ToShortDateString()} - Concluída: {(tarefa.Concluida ? "Sim" : "Não")}");
        }
    }

    public void MarcarComoConcluida(int indice)
    {
        if (indice >= 0 && indice < tarefas.Count)
        {
            tarefas[indice].Concluida = true;
            Console.WriteLine("Tarefa marcada como concluída!");
        }
        else
        {
            Console.WriteLine("Índice inválido!");
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        GerenciadorTarefas gerenciador = new GerenciadorTarefas();

        bool executando = true;
        while (executando)
        {
            Console.WriteLine("Escolha uma opção:");
            Console.WriteLine("1 - Adicionar Tarefa");
            Console.WriteLine("2 - Exibir Tarefas");
            Console.WriteLine("3 - Marcar Tarefa como Concluída");
            Console.WriteLine("4 - Sair");

            int opcao;
            if (int.TryParse(Console.ReadLine(), out opcao))
            {
                switch (opcao)
                {
                    case 1:
                        Console.WriteLine("Digite o nome da tarefa:");
                        string nomeTarefa = Console.ReadLine();
                        Console.WriteLine("Digite a data da tarefa (dd/mm/aaaa):");
                        DateTime dataTarefa;
                        if (DateTime.TryParse(Console.ReadLine(), out dataTarefa))
                        {
                            gerenciador.AdicionarTarefa(nomeTarefa, dataTarefa);
                        }
                        else
                        {
                            Console.WriteLine("Data inválida!");
                        }
                        break;
                    case 2:
                        gerenciador.ExibirTarefas();
                        break;
                    case 3:
                        Console.WriteLine("Digite o índice da tarefa a ser marcada como concluída:");
                        int indiceTarefa;
                        if (int.TryParse(Console.ReadLine(), out indiceTarefa))
                        {
                            gerenciador.MarcarComoConcluida(indiceTarefa);
                        }
                        else
                        {
                            Console.WriteLine("Índice inválido!");
                        }
                        break;
                    case 4:
                        executando = false;
                        break;
                    default:
                        Console.WriteLine("Opção inválida!");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Opção inválida!");
            }
        }
    }
}
