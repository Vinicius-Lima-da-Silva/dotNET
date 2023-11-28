// avaliacao 28-11

using System;
using System.Collections.Generic;

public class Pessoa
{
    public string Nome { get; set; }
    public DateTime DataNascimento { get; set; }
    public string CPF { get; set; }
}

public class Treinador : Pessoa
{
    public string CREF { get; set; }
}

public class Cliente : Pessoa
{
    public double Altura { get; set; }
    public double Peso { get; set; }
}

public class Academia
{
    private List<Treinador> treinadores;
    private List<Cliente> clientes;

    public Academia()
    {
        treinadores = new List<Treinador>();
        clientes = new List<Cliente>();
    }
    public void AdicionarTreinador(Treinador treinador)
    {
        if (!treinadores.Exists(t => t.CPF == treinador.CPF || t.CREF == treinador.CREF))
        {
            treinadores.Add(treinador);
            Console.WriteLine("Treinador adicionado com sucesso!");
        }
        else
        {
            Console.WriteLine("CPF ou CREF já existente para outro treinador!");
        }
    }

    public void AdicionarCliente(Cliente cliente)
    {
        if (!clientes.Exists(c => c.CPF == cliente.CPF))
        {
            clientes.Add(cliente);
            Console.WriteLine("Cliente adicionado com sucesso!");
        }
        else
        {
            Console.WriteLine("CPF já existente para outro cliente!");
        }
    }

    public void GerarRelatorioTreinadores()
    {
        Console.WriteLine("Relatório de Treinadores:");
        foreach (var treinador in treinadores)
        {
            Console.WriteLine($"Nome: {treinador.Nome}, CPF: {treinador.CPF}, CREF: {treinador.CREF}");
        }
    }

    public void GerarRelatorioClientes()
    {
        Console.WriteLine("Relatório de Clientes:");
        foreach (var cliente in clientes)
        {
            Console.WriteLine($"Nome: {cliente.Nome}, CPF: {cliente.CPF}, Altura: {cliente.Altura}, Peso: {cliente.Peso}");
        }
    }
}


class Program
{
    static void Main(string[] args)
    {
        Academia academia = new Academia();

        Treinador treinador1 = new Treinador
        {
            Nome = "João Silva",
            DataNascimento = new DateTime(1985, 5, 15),
            CPF = "12345678901",
            CREF = "ABC123"
        };

        Cliente cliente1 = new Cliente
        {
            Nome = "Maria Santos",
            DataNascimento = new DateTime(1990, 8, 25),
            CPF = "98765432109",
            Altura = 1.65,
            Peso = 60
        };

        academia.AdicionarTreinador(treinador1);
        academia.AdicionarCliente(cliente1);

        academia.GerarRelatorioTreinadores();
        academia.GerarRelatorioClientes();
    }
}

