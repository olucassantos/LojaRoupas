Console.WriteLine("Qual o valor da compra?");

decimal valorCompra;
// Tenta converter o texto para decimal, e da erro caso não de certo
if(!decimal.TryParse(Console.ReadLine(), out valorCompra))
{
    Console.WriteLine("Valor inválido!");
    return;
}

Console.WriteLine("Qual a forma de pagamento? (vista/prazo)");
string formaPagamento = Console.ReadLine();

// Verifica se a forma de pagamento está correta
if(formaPagamento != "vista" && formaPagamento != "prazo")
{
    Console.WriteLine("Forma de pagamento inválida!");
    return; // Para a execução do programa.
}

// Verifica a forma de pagamento
decimal valorFinal = 0;

if(formaPagamento == "vista")
{
    // Calcula o valor de desconto
    if(valorCompra > 1000)
        valorFinal = valorCompra * 0.8m;
    else if (valorCompra > 500)
        valorFinal = valorCompra * 0.85m;
    else
        valorFinal = valorCompra * 0.90m;

    Console.WriteLine($"O valor final da compra é de: {valorFinal.ToString("C")}");
} 
else
{
    Console.WriteLine("Qual a quantidade de parcelas desejadas?");
    int parcelas;

    // Se não conseguir converter o valor de entrada da erro.
    if (!int.TryParse(Console.ReadLine(), out parcelas))
    {
        Console.WriteLine("Numero de parcelas inválidas!");
        return; // Para a execução do programa.
    }

    if (parcelas == 0)
    {
        Console.WriteLine("Parcelas não podem ficar zeradas.");
        Console.WriteLine("Se quiser, pague a vista!");
        return; // Para a execução do programa.
    }

    decimal valorParcela;
    // Até 5 parcelas para compras abaixo de 800 reais.
    if (valorCompra < 800 && parcelas > 5)
    {
        Console.WriteLine("Numero de parcelas inválidas!");
        return; // Para a execução do programa.
    } 
    else if (parcelas > 18)
    {
        Console.WriteLine("Numero de parcelas inválidas!");
        return; // Para a execução do programa.
    } 
    else if (parcelas > 10)
    {
        decimal juros = 0;
        // Aplicar o juros
        if (parcelas == 11)
            juros = 5;
        else if(parcelas == 12)
            juros = 6.5m;
        else if(parcelas == 13)
            juros = 7;
        else if (parcelas == 14)
            juros = 7;
        else if (parcelas == 15)
            juros = 9.5m;
        else if (parcelas == 16)
            juros = 10;
        else if (parcelas == 17)
            juros = 11.3m;
        else if (parcelas == 18)
            juros = 12;

        // Calcula o juros nas parcelas
        valorFinal = (parcelas * (juros / 100)) * valorCompra;
        valorParcela = valorFinal / parcelas;
    }
    else
    {
        // Mostra o valor final parcelado, sem juros
        valorFinal = valorCompra;
        valorParcela = valorCompra / parcelas;
    }

    Console.WriteLine($"O valor total é de {valorFinal.ToString("c")}");
    Console.WriteLine($"Serão {parcelas} de {valorParcela.ToString("c")}");
}