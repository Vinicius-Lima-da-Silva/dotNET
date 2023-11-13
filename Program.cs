using System;

class Programa
{
    static void Main()
    {

        // 4. Operadores Aritméticos
         int x = 10;
        int y = 3;

        // Adição
        int adicao = x + y;
        Console.WriteLine($"Adição: {adicao}");

        // Subtração
        int subtracao = x - y;
        Console.WriteLine($"Subtração: {subtracao}");

        // Multiplicação
        int multiplicacao = x * y;
        Console.WriteLine($"Multiplicação: {multiplicacao}");

        // Divisão
        int divisao = x / y;
        Console.WriteLine($"Divisão: {divisao}");

        // Divisão com decimal
        double resultadoDivisaoDecimal = (double)x / y;

        Console.WriteLine($"Divisão com decimal: {resultadoDivisaoDecimal}");

        // 5. Operadores de Comparação
        int a = 5;
        int b = 8;

        
        if (a > b)
        {
            Console.WriteLine("a é maior que b.");
        }
        else
        {
            Console.WriteLine("a não é maior que b.");
        }

       
        
        // 6. Operadores de Igualdade
        string str1 = "Hello";
        string str2 = "World";

        
        if (str1 == str2)
        {
            Console.WriteLine("As strings são iguais.");
        }
        else
        {
            Console.WriteLine("As strings são diferentes.");
        }

        // 7. Operadores Lógicos
        bool condicao1 = true;
        bool condicao2 = false;

        
        if (condicao1 && condicao2)
        {
            Console.WriteLine("Ambas as condições são verdadeiras.");
        }
        else
        {
            Console.WriteLine("Pelo menos uma das condições não é verdadeira.");
        }

        // 8. Desafio de Mistura de Operadores
        int num1 = 7;
        int num2 = 3;
        int num3 = 10;

        if (num1 > num2 && num3 == num1 + num2)
        {
            Console.WriteLine("A condição 1 (num1 > num2) é verdadeira.");
            Console.WriteLine("A condição 2 (num3 == num1 + num2) também é verdadeira.");
        }
        else
        {
            Console.WriteLine("Pelo menos uma das condições não é verdadeira.");
        }
    }
}
