using System;
using System.IO;

namespace Tombola
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Benvenuto in questo gioco interattivo!\n" +
                "\nPotrai scegliere se giocare a Tombola o Bingo!");

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\nCome ti chiami?");
            string nome = Console.ReadLine();

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine($"Ciao {nome}, iniziamo a giocare!");
            Console.ForegroundColor = ConsoleColor.White;

            char continua;  //carattere che utilizzo nel do-while per chiedere all'utente se vuole continuare a giocare
            do
            {
                int n = ScegliGioco();

                int[] cartella = new int[n];

                cartella = ScegliNumeri(ref cartella, ref n);

                Array.Sort(cartella);  //utilizzo questa funzione per stampare a video i numeri scelti in ordine crescente

                Console.WriteLine($"\nOk {nome}, hai scelto i seguenti numeri: ");
                Console.WriteLine("\n--------------------------------------------------------------------------------------------------------------------");

                for (int i = 0; i < cartella.Length; i++)
                {
                    Console.Write($"{cartella[i]} \t");
                }
                Console.WriteLine("\n--------------------------------------------------------------------------------------------------------------------");

                int diff = SelezionaDiff();  //metodo per la selezione della difficoltà

                int[] tabellone = Estrazione(ref diff);  //creo l'array tabellone che, con il metodo Estrazione, vado a riempire con i valori estratti random dal pc
                Array.Sort(tabellone);   //ordino i valori estratti in maniera crescente

                Console.WriteLine("\nI numeri estratti sono:");
                Console.WriteLine("\n--------------------------------------------------------------------------------------------------------------------------------------------------------------");

                for (int i = 0; i < tabellone.Length; i++)
                {
                    Console.Write($"{tabellone[i]}\t");
                }
                Console.WriteLine("\n--------------------------------------------------------------------------------------------------------------------------------------------------------------");

                if (n == 15)
                {
                    VerificaVittoriaTombola(ref cartella, ref tabellone, ref nome);  //metodo per la verifica della vittoria
                }

                if (n == 5)
                {
                    VerificaVittoriaLotto(ref cartella, ref tabellone, ref nome);  //metodo per la verifica della vittoria
                }


                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\n\nVuoi continuare a giocare? Se sì, digita 's'\n");
                continua = Console.ReadKey().KeyChar;
                Console.ForegroundColor = ConsoleColor.White;

            } while (continua == 's' || continua == 'S');
        }



        private static void VerificaVittoriaLotto(ref int[] cartella, ref int[] tabellone, ref string nome)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            int cont = 0;

            int[] check = new int[cartella.Length];    //array in cui andrò a salvare i numeri "indovinati" dall'utente
            for (int i = 0; i < cartella.Length; i++)   //scorro l'array dei numeri scelti dall'utente
            {
                for (int j = 0; j < tabellone.Length; j++)    //scorro l'array dei numeri generati dal pc
                {
                    if (cartella[i] == tabellone[j])         //se trovo una corrispondenza incremento contatore
                    {
                        cont++;
                        check[i] = cartella[i];   //salvo il numero indovinato nell'array check

                    }
                }
            }


            if (cont == 2)    //ho deciso di usare una cascata di else if, avrei potuto usare anche switch mettendogli in ingresso il contatore cont
            {
                Console.WriteLine($"\nComplimenti {nome}, hai fatto AMBO!");
                Console.WriteLine("\nI numeri vincenti sono:");
                for (int i = 0; i < check.Length; i++)
                {
                    if (check[i] != 0)
                    {
                        Console.Write($"{check[i]}\t");
                    }
                }
            }
            else if (cont == 3)
            {
                Console.WriteLine($"\nComplimenti {nome}, hai fatto TERNO!");
                Console.WriteLine("\nI numeri vincenti sono:");
                for (int i = 0; i < check.Length; i++)
                {
                    if (check[i] != 0)
                    {
                        Console.Write($"{check[i]}\t");
                    }
                }
            }
            else if (cont == 4)
            {
                Console.WriteLine($"\nComplimenti {nome}, hai fatto QUATERNA!");
                Console.WriteLine("\nI numeri vincenti sono:");
                for (int i = 0; i < check.Length; i++)
                {
                    if (check[i] != 0)
                    {
                        Console.Write($"{check[i]}\t");
                    }
                }
            }
            else if (cont == 5)
            {
                Console.WriteLine($"\nComplimenti {nome}, hai fatto CINQUINA!");
                Console.WriteLine("\nI numeri vincenti sono:");
                for (int i = 0; i < check.Length; i++)
                {
                    if (check[i] != 0)
                    {
                        Console.Write($"{check[i]}\t");
                    }
                }
            }

            else if (cont < 2)
            {
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine($"\nMi dispiace {nome}, hai perso!\nHai indovinato solo {cont} numeri:");


                for (int i = 0; i < check.Length; i++)
                {
                    if (check[i] != 0)
                    {
                        Console.Write($"{check[i]}\t");
                    }
                }

            }
            else if (cont == 0)
            {
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine($"\nMi dispiace {nome}, hai perso!\nNon hai indovinato nessun numero.");

            }
            Console.ForegroundColor = ConsoleColor.White;
        }

        private static void VerificaVittoriaTombola(ref int[] cartella, ref int[] tabellone, ref string nome)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            int cont = 0;

            int[] check = new int[cartella.Length];    //array in cui andrò a salvare i numeri "indovinati" dall'utente
            for (int i = 0; i < cartella.Length; i++)   //scorro l'array dei numeri scelti dall'utente
            {
                for (int j = 0; j < tabellone.Length; j++)    //scorro l'array dei numeri generati dal pc
                {
                    if (cartella[i] == tabellone[j])         //se trovo una corrispondenza incremento contatore
                    {
                        cont++;
                        check[i] = cartella[i];   //salvo il numero indovinato nell'array check

                    }
                }
            }

            if (cont == 2)    //ho deciso di usare una cascata di else if, avrei potuto usare anche switch mettendogli in ingresso il contatore cont
            {
                Console.WriteLine($"\nComplimenti {nome}, hai fatto AMBO!");
                Console.WriteLine("\nI numeri vincenti sono:");
                for (int i = 0; i < check.Length; i++)
                {
                    if (check[i] != 0)
                    {
                        Console.Write($"{check[i]}\t");
                    }
                }
            }
            else if (cont == 3)
            {
                Console.WriteLine($"\nComplimenti {nome}, hai fatto TERNO!");
                Console.WriteLine("\nI numeri vincenti sono:");
                for (int i = 0; i < check.Length; i++)
                {
                    if (check[i] != 0)
                    {
                        Console.Write($"{check[i]}\t");
                    }
                }
            }
            else if (cont == 4)
            {
                Console.WriteLine($"\nComplimenti {nome}, hai fatto QUATERNA!");
                Console.WriteLine("\nI numeri vincenti sono:");
                for (int i = 0; i < check.Length; i++)
                {
                    if (check[i] != 0)
                    {
                        Console.Write($"{check[i]}\t");
                    }
                }
            }
            else if (cont >= 5 && cont <= 14)
            {
                Console.WriteLine($"\nComplimenti {nome}, hai fatto CINQUINA!");
                Console.WriteLine("\nI numeri vincenti sono:");
                for (int i = 0; i < check.Length; i++)
                {
                    if (check[i] != 0)
                    {
                        Console.Write($"{check[i]}\t");
                    }
                }
            }
            else if (cont == 15)
            {

                Console.WriteLine($"\nComplimenti {nome}, hai fatto TOMBOLA!");
                Console.WriteLine("\nI numeri vincenti sono:");
                for (int i = 0; i < check.Length; i++)
                {
                    if (check[i] != 0)
                    {
                        Console.Write($"{check[i]}\t");
                    }
                }
            }
            else if (cont < 2)
            {
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine($"\nMi dispiace {nome}, hai perso!\nHai indovinato solo {cont} numeri:");


                for (int i = 0; i < check.Length; i++)
                {
                    if (check[i] != 0)
                    {
                        Console.Write($"{check[i]}\t");
                    }
                }

            }

            else if (cont == 0)
            {
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine($"\nMi dispiace {nome}, hai perso!\nNon hai indovinato nessun numero.");

            }
            Console.ForegroundColor = ConsoleColor.White;

        }

        private static int[] Estrazione(ref int diff)
        {
            StreamWriter sw = new StreamWriter(@"numeriEstratti.txt");  //uso questo oggetto per provare a salvare la i numeri estratti in un file

            int[] estratti = new int[diff];   //creo l'array dei numeri estratti che avrà dimensione 'diff', ovvero varia in base al livello di difficoltà scelto dall'utente

            Random random = new Random();

            for (int i = 0; i < diff; i++)
            {
                int tab = random.Next(1, 91);  //generazione del tabellone

                int found = -1; //flag utilizzato per controllare che il numero scelto dall'utente non sia stato già inserito
                found = Array.IndexOf(estratti, tab);   //assegno a found il valore ottenuto grazie alla funzione IndexOf
                if (found > -1)   //se IndexOf restituisce -1, allora l'elemento non è presente già nell'array. Quindi se found è maggiore di -1, l'elemento inserito è già nell'array
                {
                    i--;   //quindi decremento
                }
                else
                {
                    estratti[i] = tab;
                    sw.Write($" {estratti[i]} ");
                }

            }
            sw.Close();
            return estratti;
        }

        private static int SelezionaDiff()   //utilizzo uno switch per far scegliere all'utente la difficoltà
        {

            int difficoltà = 0;

            Console.WriteLine("\nScegli il livello di difficolta:");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n1) Facile");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\n2) Medio");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\n3) Difficile");
            Console.ForegroundColor = ConsoleColor.White;


            int num;
            while (!int.TryParse(Console.ReadLine(), out num) || num < 1 || num > 3)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Puoi inserire solo inserire 1, 2 o 3! Riprova:");
                Console.ForegroundColor = ConsoleColor.White;
            }

            switch (num)
            {
                case 1:
                    difficoltà = 70;
                    Console.WriteLine("\nHai scelto: \nLivello FACILE!\nVerranno estratti 70 numeri!");
                    break;
                case 2:
                    difficoltà = 40;
                    Console.WriteLine("\nHai scelto: \nLivello MEDIO!\nVerranno estratti 40 numeri!");
                    break;
                case 3:
                    difficoltà = 20;
                    Console.WriteLine("\nHai scelto: \nLivello DIFFICILE!\nVerranno estratti 20 numeri!");
                    break;
                default:
                    break;

            }
            return difficoltà;
        }



        private static int[] ScegliNumeri(ref int[] cartella, ref int n)
        {
     
            StreamWriter sw = new StreamWriter(@"numeriGiocati.txt");  //uso questo oggetto per provare a salvare la "cartella" in un file


            Console.WriteLine($"\nScegli {n} numeri diversi fra loro:\n");
            int numScelto; //numero scelto dall'utente 

            for (int i = 0; i < cartella.Length; i++)

            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine($"Inserisci il {i + 1}° numero: ");
                Console.ForegroundColor = ConsoleColor.White;


                while (!int.TryParse(Console.ReadLine(), out numScelto) || numScelto < 1 || numScelto > 90)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nPuoi inserire solo numeri interi compresi tra 1 e 90");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                int found = -1;              //controllo che il numero scelto dall'utente non sia già inserito
                found = Array.IndexOf(cartella, numScelto);
                if (found > -1)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"\nIl numero {numScelto} è già presente nella cartella! Riprova!");
                    Console.ForegroundColor = ConsoleColor.White;
                    i--;
                }
                else
                {

                    cartella[i] = numScelto;
                    sw.Write($" {cartella[i]} ");
                  
                }
            }
            sw.Close();
            return cartella;

        }

        private static int ScegliGioco()
        {
            int n;

            Console.WriteLine("\nScegli a quale gioco giocare:");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n1) Lotto ---> Sceglierai 5 numeri");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\n2) Tombola ---> Sceglierai 15 numeri");
            Console.ForegroundColor = ConsoleColor.White;

            while (!int.TryParse(Console.ReadLine(), out n) || n < 1 || n > 2)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Puoi inserire solo inserire 1 o 2. Riprova:");
                Console.ForegroundColor = ConsoleColor.White;
            }


            switch (n)
            {
                case 1:
                    n = 5;
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("\nHai scelto di giocare al LOTTO!");
                    break;

                case 2:
                    n = 15;
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("\nHai scelto di giocare a TOMBOLA!");
                    break;
            }
            Console.ForegroundColor = ConsoleColor.White;
            return n;
        }
    }
}


