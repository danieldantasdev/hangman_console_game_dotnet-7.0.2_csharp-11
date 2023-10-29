using Models.Forca;

internal static class Program
{
    public static void Main(string[] args)
    {
        ConstruirBanner();
        Console.Write("Digite a palavra correta: ");
        string palavraCorretaInputModel = Console.ReadLine() ?? string.Empty;

        Forca jogo = new Forca(palavraCorretaInputModel);
        jogo.Jogar();
    }

    static void ConstruirBanner()
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.Write("-------------------------------\n" +
                      "| ESSE É UM MINI JOGO DE FORCA |\n" +
                      "--------------------------------\n"
        );

        Console.ResetColor();
    }
}