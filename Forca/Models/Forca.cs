namespace Models.Forca;

class Forca
{
    public string PalavraCorreta { get; private set; } = string.Empty;
    public List<char> LetrasCorretas { get; private set; } = new List<char>();
    public List<char> Tracos { get; private set; } = new List<char>();
    public uint QuantidadeAcertos { get; private set; } = uint.MinValue;

    public Forca(string palavraCorreta)
    {
        PalavraCorreta = palavraCorreta;
        ConstruirForca();
    }

    public void Jogar()
    {
        while (QuantidadeAcertos < PalavraCorreta.Length)
        {
            Console.Write("\nDigite uma letra: ");
            string letraInputModel = Console.ReadLine()?.ToLower();

            if (LetraEhValida(letraInputModel))
            {
                if (PalavraCorreta.Contains(letraInputModel[0]))
                {
                    Console.WriteLine("Letra correta!");
                    if (!LetrasCorretas.Contains(letraInputModel[0]))
                    {
                        LetrasCorretas.Add(letraInputModel[0]);
                        QuantidadeAcertos++;
                    }
                }
                else
                {
                    Console.WriteLine("Letra incorreta. Tente novamente.");
                }

                AtualizarTracos();
                ExibirForca();
            }
            else
            {
                Console.WriteLine("Digite uma letra válida.");
            }
        }

        Console.WriteLine("Parabéns! Você adivinhou a palavra correta: " + PalavraCorreta);
    }

    private bool LetraEhValida(string letraInput)
    {
        return letraInput.Length == 1 && char.IsLetter(letraInput[0]);
    }

    private void ConstruirForca()
    {
        for (int i = 0; i < PalavraCorreta.Length; i++)
        {
            Tracos.Add('-');
        }
    }

    private void AtualizarTracos()
    {
        Tracos.Clear();

        foreach (char letra in PalavraCorreta)
        {
            if (LetrasCorretas.Contains(letra))
            {
                Tracos.Add(letra);
            }
            else
            {
                Tracos.Add('-');
            }
        }
    }

    private void ExibirForca()
    {
        string traco = new string('-', PalavraCorreta.Length);
        string forca =
            " ______" + "\n" +
            "|      |" + $" Quantidade de acertos = {QuantidadeAcertos}" + "\n" +
            "|" + $" Letras corretas = [ {string.Join(", ", LetrasCorretas)} ]" + "\n" +
            "|" + "\n" +
            "|" + "\n" +
            "|" + "\n " + $"{string.Join(" ", Tracos)}";

        Console.Write(forca);
    }
}