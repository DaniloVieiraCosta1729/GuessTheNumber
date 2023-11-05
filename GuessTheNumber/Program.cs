Menu();
void Menu()
{
    restart:
    Console.Clear();
    Console.WriteLine(@"

░██████╗░██╗░░░██╗███████╗░██████╗░██████╗  ████████╗██╗░░██╗███████╗
██╔════╝░██║░░░██║██╔════╝██╔════╝██╔════╝  ╚══██╔══╝██║░░██║██╔════╝
██║░░██╗░██║░░░██║█████╗░░╚█████╗░╚█████╗░  ░░░██║░░░███████║█████╗░░
██║░░╚██╗██║░░░██║██╔══╝░░░╚═══██╗░╚═══██╗  ░░░██║░░░██╔══██║██╔══╝░░
╚██████╔╝╚██████╔╝███████╗██████╔╝██████╔╝  ░░░██║░░░██║░░██║███████╗
░╚═════╝░░╚═════╝░╚══════╝╚═════╝░╚═════╝░  ░░░╚═╝░░░╚═╝░░╚═╝╚══════╝

███╗░░██╗██╗░░░██╗███╗░░░███╗██████╗░███████╗██████╗░
████╗░██║██║░░░██║████╗░████║██╔══██╗██╔════╝██╔══██╗
██╔██╗██║██║░░░██║██╔████╔██║██████╦╝█████╗░░██████╔╝
██║╚████║██║░░░██║██║╚██╔╝██║██╔══██╗██╔══╝░░██╔══██╗
██║░╚███║╚██████╔╝██║░╚═╝░██║██████╦╝███████╗██║░░██║
╚═╝░░╚══╝░╚═════╝░╚═╝░░░░░╚═╝╚═════╝░╚══════╝╚═╝░░╚═╝
");
    string boasVindas = "\nBem-vindo(a) ao Guess The Number\nNeste jogo eu pensarei em um número entre 1 e 100 e você deve tentar adivinhar que número é este.";
    string textoDinamico = "";
    foreach (char item in boasVindas)
    {
        Console.Clear();
        Console.WriteLine(@"

░██████╗░██╗░░░██╗███████╗░██████╗░██████╗  ████████╗██╗░░██╗███████╗
██╔════╝░██║░░░██║██╔════╝██╔════╝██╔════╝  ╚══██╔══╝██║░░██║██╔════╝
██║░░██╗░██║░░░██║█████╗░░╚█████╗░╚█████╗░  ░░░██║░░░███████║█████╗░░
██║░░╚██╗██║░░░██║██╔══╝░░░╚═══██╗░╚═══██╗  ░░░██║░░░██╔══██║██╔══╝░░
╚██████╔╝╚██████╔╝███████╗██████╔╝██████╔╝  ░░░██║░░░██║░░██║███████╗
░╚═════╝░░╚═════╝░╚══════╝╚═════╝░╚═════╝░  ░░░╚═╝░░░╚═╝░░╚═╝╚══════╝

███╗░░██╗██╗░░░██╗███╗░░░███╗██████╗░███████╗██████╗░
████╗░██║██║░░░██║████╗░████║██╔══██╗██╔════╝██╔══██╗
██╔██╗██║██║░░░██║██╔████╔██║██████╦╝█████╗░░██████╔╝
██║╚████║██║░░░██║██║╚██╔╝██║██╔══██╗██╔══╝░░██╔══██╗
██║░╚███║╚██████╔╝██║░╚═╝░██║██████╦╝███████╗██║░░██║
╚═╝░░╚══╝░╚═════╝░╚═╝░░░░░╚═╝╚═════╝░╚══════╝╚═╝░░╚═╝
");
        textoDinamico = textoDinamico + item.ToString();
        Console.Write($"{textoDinamico}\r");
        Thread.Sleep( 20 );
    }
    Thread.Sleep(1000);
    digitarNovamente:
    Console.Write("\nPreparado(a)? \nPressione [y] para começar ou [n] para fechar o jogo: ");
    
    char inicializador;

    try
    {
        inicializador = char.Parse(Console.ReadLine()!);
    }
    catch (Exception)
    {
        Console.WriteLine("O valor digitado não é válido, por favor, tente novamente...");
        goto digitarNovamente;
    }

    switch (inicializador)
    {
        case 'y': GuessTheNumber();
            goto restart;

        case 'n': Console.WriteLine("Fechar");
            break;

        default: Console.WriteLine("O valor digitado não é válido, por favor, tente novamente...");
            Thread.Sleep(2000);
            goto restart;
    }
}
int NumeroDoComputador()
{
    Random aleatorio = new Random();
    int escolhido = aleatorio.Next(1, 101);
    return escolhido;
}
void GuessTheNumber()
{
    int computador = NumeroDoComputador();
    Console.WriteLine("Pronto, tente adivinhar qual número eu pensei!");
    int contador = 0;
    while (contador < 5)
    {
        Console.Write("Palpite: ");
        int palpite = int.Parse(Console.ReadLine()!);
        if (palpite == computador)
        {
            Console.WriteLine($"Parabéns!! Você acertou, a resposta correta é {palpite}.");
            goto venceu;
        }
        else if (palpite > computador)
        {
            Console.WriteLine($"Hum... Não, o número que eu pensei é menor que {palpite}.");
        }
        else
        {
            Console.WriteLine($"Hum... Não, o número que eu pensei é maior que {palpite}.");
        }
        contador++;
    }
    Console.WriteLine($"Não foi dessa vez... O número que eu pensei foi {computador}");
    venceu:
    Console.Write("Pressione qualquer tecla para voltar ao Menu principal: ");
    Console.ReadKey();
}
