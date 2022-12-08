using System.Security.Principal;

namespace Forca
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //cria array com as partes do desenho do nome do jogo
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

            //cria array com as partes do desenho do enforcado
            string[] desenhoEnforcado = { "  +---+\r\n  |   |\r\n      |\r\n      |\r\n      |\r\n      |",
            "  +---+\r\n  |   |\r\n  O   |\r\n      |\r\n      |\r\n      |",
            "  +---+\r\n  |   |\r\n  O   |\r\n  |   |\r\n      |\r\n      |",
            "  +---+\r\n  |   |\r\n  O   |\r\n /|   |\r\n      |\r\n      |",
            "  +---+\r\n  |   |\r\n  O   |\r\n /|\\  |\r\n      |\r\n      |",
            "  +---+\r\n  |   |\r\n  O   |\r\n /|\\  |\r\n /    |\r\n      |",
            "  +---+\r\n  |   |\r\n  O   |\r\n /|\\  |\r\n / \\  |\r\n      |"
            };

            //cria array de palavras chave
            string[] arrayPalavraChave = { "nanotecnologo" , "escaravelho" , "ampulheta" , "bergamota"};
            //cria array de temas de acordo com as palavras chave
            string[] arrayTema = { "profissão" , "animal" , "objeto" , "fruta"};

            //cria um número aleatório
            Random aleatorio = new Random();
            //cria um inteiro de índice e armazena um número aleatório nele de acordo com o
            //tamanho do array de palavras chave
            int indice = aleatorio.Next(arrayPalavraChave.Length);

            //cria e atribui uma palavra chave aleatória à variável
            string palavraChave = arrayPalavraChave[indice].ToUpper();
            //cria e atribui um tema de acordo com a palavra chave escolhida
            string tema = arrayTema[indice];

            //cria um array de char com a palavra oculta
            char[] oculta = new char[palavraChave.Length];

            //cria as variáveis que serão usadas para controlar o jogo
            int acertos = 0;
            int erros = 0;
            int chances = 6;

            //cria um booleano de continuação
            bool continua = true;

            //coloca '-' (traços) no array de char 'oculta'
            for (int i = 0; i < palavraChave.Length; i++)
            {
                oculta[i] = '-';
            }

            //cria a variável para controle das letras que serão digitadas
            int indiceLetra = 0;
            //cria array das letras que serão digitadas
            char[] letrasDigitadas = new char[26];

            //estrutura de repetição principal do jogo
            while ((erros < chances) && continua)
            {
                //imprime o desenho do nome do jogo
                foreach (string parte in desenhoJogoDaForca)
                {
                    Console.WriteLine(parte);
                }

                //imprime infos do grupo
                Console.WriteLine("Grupo 7 - Bruno, Sylmara e Eder\n");

                //imprime o desenho do enforcado de acordo com o numero de erros
                Console.WriteLine(desenhoEnforcado[erros]);

                //imprime quantidade de erros e chances totais
                Console.WriteLine($"\nErros / Chances: {erros} / {chances}\n");

                //imprime o tema
                Console.WriteLine($"Tema: {tema.ToUpper()}\n");

                //imprime a palavra com traços
                Console.WriteLine(oculta);

                //organiza array de letras digitadas em ordem alfabética
                Array.Sort(letrasDigitadas);

                //imprime letras digitadas
                Console.WriteLine("\nLetras digitadas:\n");
                foreach (char letraDigitada in letrasDigitadas)
                {
                    if (letraDigitada != 0)
                    {
                        Console.Write($"{letraDigitada} ");
                    }
                }

                Console.WriteLine();

                //cria variável para armazenar a letra que será digitada
                char letra;

                //cria booleano para verificar se o caractere digitado é uma letra
                bool verificaLetra;

                //espera a entrada de uma letra
                do
                {
                    Console.WriteLine("\nDigite uma letra:");
                    char.TryParse(Console.ReadLine().ToUpper(), out letra);
                    verificaLetra = char.IsLetter(letra);
                } while (!verificaLetra);

                //verifica se a letra digitada já foi digitada anteriormente
                if (Array.IndexOf(letrasDigitadas, letra) == -1)
                {
                    //se ainda não foi, guarda a letra no array de letras digitadas
                    letrasDigitadas[indiceLetra] = letra;
                    indiceLetra++;

                    //verifica se a palavra chave contém a letra
                    if (palavraChave.Contains(letra))
                    {
                        //mostra a letra digitada na posição na palavra chave
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
                        Console.WriteLine($"\nA letra '{letra}' não existe na palavra chave.");
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

                //verifica se o número de acertos é o mesmo do tamanho da palavra
                //vitória
                if (acertos == palavraChave.Length)
                {
                    Console.Clear();
                    Console.WriteLine($"\nA palavra chave é: {palavraChave.ToUpper()}");
                    Console.WriteLine("\nParabéns! Você venceu!");
                    continua = false;
                    Console.WriteLine("\nPressione qualquer tecla para continuar.");
                    Console.ReadKey();
                }
                //verifica se o número de erros é igual ao número de chances
                //derrota
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