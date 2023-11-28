/ avaliacao 28-11

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
