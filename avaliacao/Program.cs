// avaliacao 28-11

using System;
using System.Collections.Generic;
using System.Linq;

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
    public double CalcularIMC()
    {
        // Cálculo do IMC usando altura e peso
        return Peso / (Altura * Altura);
    }
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

    public void RelatorioTreinadoresPorIdade(int idadeMinima, int idadeMaxima) {
        DateTime dataAtual = DateTime.Now;
        var treinadoresFiltrados = treinadores.Where(t => (dataAtual.Year - t.DataNascimento.Year) >= idadeMinima &&
                                                    (dataAtual.Year - t.DataNascimento.Year) <= idadeMaxima);
        Console.WriteLine("Treinadores por idade:");
        foreach (var treinador in treinadoresFiltrados) {
            Console.WriteLine($"Nome: {treinador.Nome}, Idade: {dataAtual.Year - treinador.DataNascimento.Year}");
        }
    }

    public void RelatorioClientesPorIdade(int idadeMinima, int idadeMaxima) {
        DateTime dataAtual = DateTime.Now;
        var clientesFiltrados = clientes.Where(c => (dataAtual.Year - c.DataNascimento.Year) >= idadeMinima &&
                                                (dataAtual.Year - c.DataNascimento.Year) <= idadeMaxima);
        Console.WriteLine("Clientes por idade:");
        foreach (var cliente in clientesFiltrados) {
            Console.WriteLine($"Nome: {cliente.Nome}, Idade: {dataAtual.Year - cliente.DataNascimento.Year}");
        }
    }

    public void RelatorioClientesPorIMC(double valorIMC) {
        var clientesFiltrados = clientes.Where(c => c.CalcularIMC() > valorIMC)
                                         .OrderBy(c => c.CalcularIMC());
        Console.WriteLine($"Clientes com IMC > {valorIMC} em ordem crescente:");
        foreach (var cliente in clientesFiltrados) {
            Console.WriteLine($"Nome: {cliente.Nome}, IMC: {cliente.CalcularIMC()}");
        }
    }

    public void RelatorioClientesOrdemAlfabetica() {
        var clientesOrdenados = clientes.OrderBy(c => c.Nome);
        Console.WriteLine("Clientes em ordem alfabética:");
        foreach (var cliente in clientesOrdenados) {
            Console.WriteLine($"Nome: {cliente.Nome}");
        }
    }

    public void RelatorioClientesMaisVelhoParaMaisNovo() {
        var clientesOrdenadosIdade = clientes.OrderByDescending(c => c.DataNascimento);
        Console.WriteLine("Clientes do mais novo para o mais velho:");
        foreach (var cliente in clientesOrdenadosIdade) {
            Console.WriteLine($"Nome: {cliente.Nome}, Idade: {DateTime.Now.Year - cliente.DataNascimento.Year}");
        }
    }

    public void RelatorioAniversariantesDoMes(int mes) {
        
        List<Pessoa> pessoas = new List<Pessoa>();
        pessoas.AddRange(treinadores);
        pessoas.AddRange(clientes);

        var aniversariantes = pessoas.Where(p => p.DataNascimento.Month == mes);
        Console.WriteLine($"Aniversariantes do mês {mes}:");
        foreach (var pessoa in aniversariantes) {
            Console.WriteLine($"Nome: {pessoa.Nome}, Data de Nascimento: {pessoa.DataNascimento:d}");
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
            DataNascimento = new DateTime(1990, 6, 25),
            CPF = "98765432109",
            Altura = 1.65,
            Peso = 60
        };
        Cliente cliente2 = new Cliente
{
    Nome = "João Silva",
    DataNascimento = new DateTime(1985, 6, 12),
    CPF = "12345678901",
    Altura = 1.75,
    Peso = 80
};

// Cliente 3
Cliente cliente3 = new Cliente
{
    Nome = "Ana Oliveira",
    DataNascimento = new DateTime(2000, 11, 30),
    CPF = "13579246801",
    Altura = 1.60,
    Peso = 55
};

// Cliente 4
Cliente cliente4 = new Cliente
{
    Nome = "Pedro Souza",
    DataNascimento = new DateTime(1976, 6, 18),
    CPF = "24680135790",
    Altura = 1.80,
    Peso = 85
};

// Cliente 5
Cliente cliente5 = new Cliente
{
    Nome = "Carla Ferreira",
    DataNascimento = new DateTime(1995, 6, 8),
    CPF = "11223344556",
    Altura = 1.70,
    Peso = 70
};

        academia.AdicionarTreinador(treinador1);
        academia.AdicionarCliente(cliente1);
        academia.AdicionarCliente(cliente2);
        academia.AdicionarCliente(cliente3);
        academia.AdicionarCliente(cliente4);
        academia.AdicionarCliente(cliente5);

        academia.RelatorioTreinadoresPorIdade(30, 50);
        academia.RelatorioClientesPorIdade(0, 100);
        academia.RelatorioClientesOrdemAlfabetica();
        academia.RelatorioClientesMaisVelhoParaMaisNovo();
        academia.RelatorioAniversariantesDoMes(6);
        academia.RelatorioClientesPorIMC(10);
    }
}