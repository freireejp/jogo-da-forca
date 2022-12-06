namespace Forca
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] desenhoJogoDaForca = { "\r\n" +
                    "       _                         _         ______                  \r\n" +
                    "      | |                       | |       |  ____|                 \r\n" +
                    "      | | ___   __ _  ___     __| | __ _  | |__ ___  _ __ ___ __ _ \r\n" +
                    "  _   | |/ _ \\ / _` |/ _ \\   / _` |/ _` | |  __/ _ \\| '__/ __/ _` |\r\n" +
                    " | |__| | (_) | (_| | (_) | | (_| | (_| | | | | (_) | | | (_| (_| |\r\n" +
                    "  \\____/ \\___/ \\__, |\\___/   \\__,_|\\__,_| |_|  \\___/|_|  \\___\\__,_|\r\n" +
                    "                __/ |                                              \r\n" +
                    "               |___/                                               \r\n"
            };

            string[] desenhoEnforcado = { "  +---+\r\n  |   |\r\n      |\r\n      |\r\n      |\r\n      |",
            "  +---+\r\n  |   |\r\n  O   |\r\n      |\r\n      |\r\n      |",
            "  +---+\r\n  |   |\r\n  O   |\r\n  |   |\r\n      |\r\n      |",
            "  +---+\r\n  |   |\r\n  O   |\r\n /|   |\r\n      |\r\n      |",
            "  +---+\r\n  |   |\r\n  O   |\r\n /|\\  |\r\n      |\r\n      |",
            "  +---+\r\n  |   |\r\n  O   |\r\n /|\\  |\r\n /    |\r\n      |",
            "  +---+\r\n  |   |\r\n  O   |\r\n /|\\  |\r\n / \\  |\r\n      |"
            };

            string[] arrayPalavraChave = { "nanotecnologo" , "escaravelho" , "ampulheta" , "bergamota"};
            string[] arrayTema = { "profissão" , "animal" , "objeto" , "fruta"};

            Random aleatorio = new Random();
            int indice = aleatorio.Next(arrayPalavraChave.Length);

            string palavraChave = arrayPalavraChave[indice];
            string tema = arrayTema[indice];

            char[] oculta = new char[palavraChave.Length];

            int acertos = 0;
            int erros = 0;
            int chances = 6;

            bool continua = true;

            for (int i = 0; i < palavraChave.Length; i++)
            {
                oculta[i] = '-';
            }

            int indiceLetra = 0;

            char[] letrasDigitadas = new char[26];

            while ((erros < chances) && continua)
            {
                foreach (string parte in desenhoJogoDaForca)
                {
                    Console.WriteLine(parte);
                }

                Console.WriteLine("Grupo 7 - Bruno, Sylmara e Eder\n");

                Console.WriteLine(desenhoEnforcado[erros]);

                Console.WriteLine($"\nErros / Chances: {erros} / {chances}\n");

                Console.WriteLine($"Tema: {tema.ToUpper()}\n");

                Console.WriteLine(oculta);

                Array.Sort(letrasDigitadas);

                Console.WriteLine("\nLetras digitadas:\n");
                foreach (char letraDigitada in letrasDigitadas)
                {
                    if (letraDigitada != 0)
                    {
                        Console.Write($"{letraDigitada} ");
                    }
                }

                Console.WriteLine();

                char letra;

                bool verificaConversao;

                bool verificaLetra;

                do
                {
                    Console.WriteLine("\nDigite uma letra:");
                    verificaConversao = char.TryParse(Console.ReadLine().ToLower(), out letra);
                    verificaLetra = char.IsLetter(letra);
                } while (!(verificaConversao && verificaLetra));

                if (Array.IndexOf(letrasDigitadas, letra) == -1)
                {
                    letrasDigitadas[indiceLetra] = letra;
                    indiceLetra++;

                    if (palavraChave.Contains(letra))
                    {
                        for (int i = 0; i < palavraChave.Length; i++)
                        {
                            if (letra == palavraChave[i])
                            {
                                oculta[i] = palavraChave[i];
                                acertos++;
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine($"\nA letra '{letra.ToString().ToUpper()}' não existe na palavra chave.");
                        erros++;
                        Console.WriteLine("\nPressione qualquer tecla para continuar.");
                        Console.ReadKey();
                    }
                }
                else
                {
                    Console.WriteLine("\nLetra já informada. Tente uma nova letra.");
                    Console.WriteLine("\nPressione qualquer tecla para continuar.");
                    Console.ReadKey();
                }

                if (acertos == palavraChave.Length)
                {
                    Console.Clear();
                    Console.WriteLine($"\nA palavra chave é: {palavraChave.ToUpper()}");
                    Console.WriteLine("\nParabéns! Você venceu!");
                    continua = false;
                    Console.WriteLine("\nPressione qualquer tecla para continuar.");
                    Console.ReadKey();
                }
                else if(erros == chances)
                {
                    Console.Clear();                    
                    Console.WriteLine("\nQue pena. Você perdeu.\n");
                    Console.WriteLine(desenhoEnforcado[erros]);
                    Console.WriteLine("\nPressione qualquer tecla para continuar.");
                    Console.ReadKey();
                }

                Console.Clear();
            }
        }
    }
}