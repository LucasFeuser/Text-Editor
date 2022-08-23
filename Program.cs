using System;
using System.IO;
using System.Threading;

namespace TextEditor
{
    class Program
    {
        static void Main(string[] args)
        {
            Menu();
        }

        static void Menu()
        {
            Console.Clear();
            Console.WriteLine("O que você deseja fazer?");
            Console.WriteLine("1 - Open Archive");
            Console.WriteLine("2 - Create new Archive");
            Console.WriteLine("0 - Exit");
            short option = short.Parse(Console.ReadLine()); //Converse Readline String to Short;

            switch (option)
            {
                case 0: System.Environment.Exit(0); break;
                case 1: Open(); break;
                case 2: Edit(); break;
                default: Menu(); break;
            }            
            

        }

        static void Open()
        {
            Console.Clear();
            Console.WriteLine("Qual caminho do arquivo?");
            string path = Console.ReadLine();

            using (var file = new StreamReader(path))
            {
                string text = file.ReadToEnd(); //Read to end = Lear até o fim
                Console.Clear();
                Console.WriteLine("Carregando.");
                Thread.Sleep(1000);
                Console.Clear();
                Console.WriteLine("Carregando..");
                Thread.Sleep(1000);
                Console.Clear();
                Console.WriteLine("Carregando...");  
                Thread.Sleep(1000);
                Console.Clear();
                Console.WriteLine($"Conteudo : \n {text}");
                
            }
            Console.WriteLine("");
            Console.ReadLine();
            Menu();
        }

        static void Edit()
        {
            Console.Clear();
            Console.WriteLine("Digite o seu texto a baixo: (ESC to exit)");
            Console.WriteLine("- - - - - - - - - - - - - - - - ");
            string text = "";

            do
            {
                text += Console.ReadLine();
                text += Environment.NewLine; //Insert new line;

            } while (Console.ReadKey().Key != ConsoleKey.Escape);
            
            
            Save(text);
        }

        static void Save(string text)
        {
            Console.Clear();
            Console.WriteLine("Qual caminho para salvar o arquivo?");
            var path = Console.ReadLine();

            using (var file = new StreamWriter(path))//Open and close object, best mode;
            {
                file.Write(text); 
            }
            Console.WriteLine($"Achive {path} sucess saved");
            Console.ReadLine();
            Menu();
        }
    }
}
