using System;
using System.Diagnostics;
using static System.Console;
using System.Text;
using System.IO;

namespace ConsoleCRUD
{
    class MainClass
    {
        public static void printMenu(string[] options)
        {
            foreach (string option in options)
            {
                WriteLine(option);
            }
            WriteLine("\nEscolha a sua opção:");
        }
        public static void Main(String[] args)
        {
            Ler();
            WriteLine(">>>> CADASTRO DE PESSOAS <<<<");
            String[] options = { "1-Cadastrar",
                                 "2-Editar",
                                 "3-Excluir",
                                 "4-Listar",
                                 "5-Gravar",
                                 "6-Ler",
                                 "7-Sair"};
            int option = 0;
            while (true)
            {
                printMenu(options);
                try
                {
                    option = Convert.ToInt32(ReadLine());
                }
                catch (System.FormatException)
                {
                    WriteLine("Por favor, didite uma opção entre 1 e " + options.Length);
                    continue;
                }
                catch (Exception)
                {
                    WriteLine("Um erro aconteceu!!");
                    continue;
                }
                switch (option)
                {
                    case 1:
                        Cadastrar();
                        break;
                    case 2:
                        Editar();
                        break;
                    case 3:
                        Excluir();
                        break;
                    case 4:
                        Listar();
                        break;
                    case 5:
                        Gravar();
                        break;
                    case 6:
                        Ler();
                        break;
                    case 7:
                        Environment.Exit(0);
                        break;
                    default:
                        WriteLine("Por favor, didite uma opção entre 1 e " + options.Length);
                        break;
                }
            }
        }

        static List<string> nomes = new List<string>();
        static List<int> idades = new List<int>();
        private static void Cadastrar()
        {
            Clear();
            ForegroundColor = ConsoleColor.Green;
            WriteLine(">>>> CADASTRO DE PESSOA <<<<\n");
            ResetColor();
            string nome = "";
            WriteLine("Dígite o nome da pessoa:");
            nome = ReadLine();
            int index = nomes.IndexOf(nome);
            if (index >= 0)
            {
                ForegroundColor = ConsoleColor.Red;
                WriteLine("Nome já existente");
                ResetColor();
            }
            else
            {
                nomes.Add(nome);
                WriteLine("Dígite a idade da pessoa:");
                idades.Add(Convert.ToInt32(ReadLine()));
            }
        }
        private static void Editar()
        {
            Clear();
            ForegroundColor = ConsoleColor.Green;
            WriteLine(">>>> EDIÇÃO DE PESSOA <<<<\n");
            ResetColor();
            string nome = "";
            WriteLine("Escreva o nome que você deseja editar:");
            nome = ReadLine();
            int index = nomes.IndexOf(nome);
            if (index >= 0)
            {
                WriteLine(">>>> Regitro que será editado <<<<");
                WriteLine($"Nome: {nomes[index]}");
                WriteLine($"Nome: {idades[index]}\n");
                WriteLine("Digite o nome:");
                nome = ReadLine();
                index = nomes.IndexOf(nome);
                if (index >= 0)
                {
                    ForegroundColor = ConsoleColor.Red;
                    WriteLine("Nome já existente");
                    ResetColor();
                }
                else
                {
                    nomes[index] = nome;
                    WriteLine("Digite a idade:");
                    idades[index] = Convert.ToInt32(ReadLine());
                    WriteLine("Pessoa editada com sucesso!!");
                }
            }
            else
            {
                ForegroundColor = ConsoleColor.Red;
                WriteLine("Registro não encontrado!!!");
                ResetColor();
            }
        }
        private static void Excluir()
        {
            Clear();
            ForegroundColor = ConsoleColor.Green;
            WriteLine(">>>> EXCLUSÃO DE PESSOA <<<<\n");
            ResetColor();
            string nome = "";
            WriteLine("Escreva o nome que você deseja excluir:");
            nome = ReadLine();
            int index = nomes.IndexOf(nome);
            int soun;
            if (index >= 0)
            {
                ForegroundColor = ConsoleColor.Green;
                WriteLine(">>>> Regitro que será excluido <<<<");
                ResetColor();
                WriteLine($"Nome: {nomes[index]}");
                WriteLine($"Idade: {idades[index]}");
                WriteLine("Continuar?");
                WriteLine("1-Sim");
                WriteLine("2-Não");
                soun = Convert.ToInt32(ReadLine());
                if (soun == 1)
                {
                    nomes.RemoveAt(index);
                    idades.RemoveAt(index);
                    WriteLine("Pessoa excluida com sucesso!!");
                }
                else
                {
                    ForegroundColor = ConsoleColor.Blue;
                    WriteLine("Exclusão de pessoa cancelada!!");
                    ResetColor();
                }
            }
            else
            {
                ForegroundColor = ConsoleColor.Red;
                WriteLine("Registro não encontrado!!!");
                ResetColor();
            }
        }
        private static void Listar()
        {
            Clear();
            ForegroundColor = ConsoleColor.Green;
            WriteLine(">>>> LISTAGEM DE PESSOA <<<<\n");
            ResetColor();
            int pos = 0;
            foreach (var item in nomes)
            {
                WriteLine($"Nome: {item}, Idade: {idades[pos]}");
                pos++;
            }
        }
        private static void Gravar()
        {
            WriteLine("\n>>>> GRAVANDO OS DADOS <<<<");
            try
            {
                StreamWriter dados;
                string arquivo = @"C:\Users\Aluno\source\repos\ContinuaProjeto\\dados.txt";
                dados = File.CreateText(arquivo);
                foreach (var item in nomes)
                {
                    dados.WriteLine($"{item}");
                }
                dados.Close();
                StreamWriter dados2;
                string arquivo2 = @"C:\Users\Aluno\source\repos\ContinuaProjeto\\dados2.txt";
                dados2 = File.CreateText(arquivo2);
                foreach (var item2 in idades)
                {
                    dados2.WriteLine($"{item2}");
                }
                dados2.Close();
                WriteLine();
            }
            catch (Exception e)
            {
                WriteLine("Erro: ", e.Message);
            }
            finally
            {
                WriteLine("Dados gravados com sucesso!!");
            }
        }
        private static void Ler()
        {
            Clear();
            WriteLine(">>>> LENDO AQUIVO <<<<");
            Console.WriteLine();
            var nome = File.ReadAllLines(@"C:\Users\Aluno\source\repos\CRUD-PARTE2\Dados1.txt");
            for (int i = 0; i < nome.Length; i++)
            {
                nomes.Add(nome[i]);
            }
            var idade = File.ReadAllLines(@"C:\Users\Aluno\source\repos\CRUD-PARTE2\Dados2.txt");
            for (int x = 0; x < idade.Length; x++)
            {
                idades.Add(Convert.ToInt32(idade[x]));
            }
            WriteLine("\nLeitura de dados concuída!!");
        }
    }
}