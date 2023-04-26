using System;
using System.Diagnostics;
using static System.Console;
using System.Text;
using System.IO;

namespace ConsoleCRUD
{
    class MainClass
    {
        public static void status()
        {
            for (int i = 0; i < nomes.Count; i++)
            {
                medias[i] = Convert.ToDouble(medias[i]);
                if (medias[i] > 7)
                {
                    statusR.Add("Aprovado");
                }
                else if (medias[i] > 5)
                {
                    statusR.Add("Recuperação");
                }
                else if (medias[i] >= 0)
                {
                    statusR.Add("Reprovado");
                } 
            }
        }
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
            WriteLine(">>>> CADASTRO DE PESSOAS <<<<");
            String[] options = { "1-Cadastrar",
                                 "2-Editar",
                                 "3-Excluir",
                                 "4-Listar",
                                 "5-Gravar",
                                 "6-Ler",
                                 "7-Média",
                                 "8-Sair"};
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
                        Media();
                        break;
                    case 8:
                        Environment.Exit(0);
                        break;
                    default:
                        WriteLine("Por favor, didite uma opção entre 1 e " + options.Length);
                        break;
                }
            }
        }

        static List<string> nomes = new List<string>();
        static List<double> notas1 = new List<double>();
        static List<double> notas2 = new List<double>();
        static List<double> notas3 = new List<double>();
        static List<double> notas4 = new List<double>();
        static List<string> reprovados = new List<string>();
        static List<string> recuperacao = new List<string>();
        static List<string> aprovados = new List<string>();
        static List<double> medias = new List<double>();
        static List<string> statusR = new List<string>();
        private static void Cadastrar()
        {
            Clear();
            ForegroundColor = ConsoleColor.Green;
            WriteLine(">>>> CADASTRO DE PESSOA <<<<\n");
            ResetColor();
            string nome = "";
            for (int i = 0; i < 2; i++)
            {
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
                    WriteLine("Dígite a 1º nota do aluno:");
                    notas1.Add(Convert.ToInt32(ReadLine()));
                    WriteLine("Dígite a 2º nota do aluno:");
                    notas2.Add(Convert.ToInt32(ReadLine()));
                    WriteLine("Dígite a 3º nota do aluno:");
                    notas3.Add(Convert.ToInt32(ReadLine()));
                    WriteLine("Dígite a 4º nota do aluno:");
                    notas4.Add(Convert.ToInt32(ReadLine()));
                }
            }
        }
        private static void Editar()
        {
            Clear();
            ForegroundColor = ConsoleColor.Green;
            WriteLine(">>>> EDIÇÃO DE PESSOA <<<<\n");
            ResetColor();
            string nome = "";
            foreach (var item in nomes)
            {
                Console.WriteLine(item);
            }
            WriteLine("Escreva o nome que você deseja editar:");
            nome = ReadLine();
            int index = nomes.IndexOf(nome);
            if (index >= 0)
            {
                WriteLine(">>>> Regitro que será editado <<<<");
                WriteLine($"Nome: {nomes[index]}");
                WriteLine($"1º nota: {notas1[index]}\n");
                WriteLine($"2º nota: {notas2[index]}\n");
                WriteLine($"3º nota: {notas3[index]}\n");
                WriteLine($"4º nota: {notas4[index]}\n");
                WriteLine("Digite o novo nome:");
                nome = ReadLine();
                index = nomes.IndexOf(nome);
                if (index >= 0)
                {
                    nomes[index] = nome;
                    WriteLine("Digite a 1º nota:");
                    notas1[index] = Convert.ToDouble(ReadLine());
                    WriteLine("Digite a 2º nota:");
                    notas2[index] = Convert.ToDouble(ReadLine());
                    WriteLine("Digite a 3º nota:");
                    notas3[index] = Convert.ToDouble(ReadLine());
                    WriteLine("Digite a 4º nota:");
                    notas4[index] = Convert.ToDouble(ReadLine());

                }
                else
                {
                    WriteLine("Pessoa editada com sucesso!!");
                    ForegroundColor = ConsoleColor.Red;
                    WriteLine("Nome nâo existente");
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
                WriteLine($"1 nota: {notas1[index]}");
                WriteLine($"2 nota: {notas2[index]}");
                WriteLine($"3 nota: {notas3[index]}");
                WriteLine($"4 nota: {notas4[index]}");
                WriteLine("Continuar?");
                WriteLine("1-Sim");
                WriteLine("2-Não");
                soun = Convert.ToInt32(ReadLine());
                if (soun == 1)
                {
                    nomes.RemoveAt(index);
                    notas1.RemoveAt(index);
                    notas2.RemoveAt(index);
                    notas3.RemoveAt(index);
                    notas4.RemoveAt(index);
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
                WriteLine($"Nome: {item}, 1º Nota: {notas1[pos]}, 2º Nota: {notas2[pos]}, 3º Nota: {notas3[pos]}, 4º Nota: {notas4[pos]}, Média: {medias[pos]}, Status: {statusR[pos]} \n");
                pos++;
            }
        }
        public static void Media()
        {
            for (int i = 0; i < nomes.Count; i++)
            {
                double n1 = 0;
                double n2 = 0;
                double n3 = 0;
                double n4 = 0;
                int index = nomes.IndexOf(nomes[i]);
                n1 = Convert.ToDouble(notas1[index]);
                n2 = Convert.ToDouble(notas2[index]);
                n3 = Convert.ToDouble(notas3[index]);
                n4 = Convert.ToDouble(notas4[index]);
                double media = (n1 + n2 + n3 + n4) / 4;
                medias.Add(media);
                WriteLine($"A média do aluno {nomes[i]} foi de {Convert.ToDouble(medias[i])}");
                status();

            }
        }
        private static void Gravar()
        {
            WriteLine("\n>>>> GRAVANDO OS DADOS <<<<");
            try
            {
                StreamWriter dados;
                string arquivo = @"C:\Users\user\source\repos\ProjetosPessoais\nomes.txt";
                dados = File.CreateText(arquivo);
                foreach (var item in nomes)
                {
                    dados.WriteLine($"{item}");
                }
                dados.Close();
                StreamWriter dados1;
                string arquivo1 = @"C:\Users\user\source\repos\ProjetosPessoais\notas1.txt";
                dados1 = File.CreateText(arquivo1);
                foreach (var item1 in notas1)
                {
                    dados1.WriteLine($"{item1}");
                }
                dados1.Close();
                StreamWriter dados2;
                string arquivo2 = @"C:\Users\user\source\repos\ProjetosPessoais\notas2.txt";
                dados2 = File.CreateText(arquivo2);
                foreach (var item2 in notas2)
                {
                    dados2.WriteLine($"{item2}");
                }
                dados2.Close();
                StreamWriter dados3;
                string arquivo3 = @"C:\Users\user\source\repos\ProjetosPessoais\notas3.txt";
                dados3 = File.CreateText(arquivo3);
                foreach (var item3 in notas3)
                {
                    dados3.WriteLine($"{item3}");
                }
                dados3.Close();
                StreamWriter dados4;
                string arquivo4 = @"C:\Users\user\source\repos\ProjetosPessoais\notas4.txt";
                dados4 = File.CreateText(arquivo4);
                foreach (var item4 in notas4)
                {
                    dados4.WriteLine($"{item4}");
                }
                dados4.Close();
                StreamWriter Media;
                string arquivo5 = @"C:\Users\user\source\repos\ProjetosPessoais\medias.txt";
                Media = File.CreateText(arquivo5);
                foreach (var media in medias)
                {
                    Media.WriteLine($"{media}");
                }
                Media.Close();
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
            WriteLine(">>>> LENDO AQUIVO <<<<\n");
            var nome = File.ReadAllLines(@"C:\Users\user\source\repos\ProjetosPessoais\nomes.txt");
            for (int i = 0; i < nome.Length; i++)
            {
                nomes.Add(nome[i]);
            }
            var nota1 = File.ReadAllLines(@"C:\Users\user\source\repos\ProjetosPessoais\notas1.txt");
            for (int x = 0; x < nota1.Length; x++)
            {
                notas1.Add(Convert.ToInt32(nota1[x]));
            }
            var nota2 = File.ReadAllLines(@"C:\Users\user\source\repos\ProjetosPessoais\notas2.txt");
            for (int x = 0; x < nota2.Length; x++)
            {
                notas2.Add(Convert.ToInt32(nota2[x]));
            }
            var nota3 = File.ReadAllLines(@"C:\Users\user\source\repos\ProjetosPessoais\notas3.txt");
            for (int x = 0; x < nota3.Length; x++)
            {
                notas3.Add(Convert.ToInt32(nota3[x]));
            }
            var nota4 = File.ReadAllLines(@"C:\Users\user\source\repos\ProjetosPessoais\notas4.txt");
            for (int x = 0; x < nota4.Length; x++)
            {
                notas4.Add(Convert.ToInt32(nota4[x]));
            }
            var media = File.ReadAllLines(@"C:\Users\user\source\repos\ProjetosPessoais\medias.txt");
            for (int x = 0; x < media.Length; x++)
            {
                medias.Add(Convert.ToDouble(media[x]));
            }
            WriteLine("\nLeitura de dados concuída!!");
        }
    }
}