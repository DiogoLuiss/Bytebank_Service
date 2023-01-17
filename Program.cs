using Csharp_avançado.Bill;
using Csharp_avançado.Bytebank.Util;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using static System.Net.Mime.MediaTypeNames;

namespace CsharpAvançado
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region: ArraysTeste

            void NumericArrayTest()

            {

                int[] Idade = { 10, 20, 30, 40 }; //Tambem serve

                int[] Idades = new int[5];

                Idades[0] = 18;

                Idades[1] = 15;

                Idades[2] = 20;

                Idades[3] = 38;

                Idades[4] = 28;


                Console.WriteLine($"O tamnho do array é {Idades.Length}");

                int IdadesTotal = 0;

                for (int i = 0; i < Idades.Length; i++)
                {
                    IdadesTotal += Idades[i];

                }

                Console.WriteLine($" A idade total é {IdadesTotal} e sua media é {IdadesTotal / Idades.Length} ");
                Console.ReadKey(true);
            }


            void StringArrayTest()
            {
                string[] ArrayWords = new string[5];

                for (int i = 0; i < ArrayWords.Length; i++)
                {

                    Console.Write($"Digite {i + 1}º Palavra: ");
                    ArrayWords[i] = Console.ReadLine();
                }

                Console.WriteLine("Digite palavra a ser encontrada: ");
                string Busca = Console.ReadLine();

                bool FindValue = false;
                foreach (string word in ArrayWords)
                {

                    if (word.Equals(Busca))
                    {
                        Console.WriteLine($" A palavra {word} foi encontrada");
                        FindValue = true;
                    }

                }

                if (!FindValue)
                {
                    Console.WriteLine($"Nenhuma palavra encontrada");
                }

                Console.ReadKey(true);
            }



            double[] ArrayTeste = { 1, 7, 5, 9, 10, 7.5 };




            //MedianTest(ArrayTeste);


            void MedianTest(Array sample)
            {
                if ((sample == null) || (sample.Length == 0))
                {

                    Console.WriteLine("Valor de array invalidos");

                }
                double[] OrderedNumbers = (double[])sample.Clone();

                Array.Sort(OrderedNumbers);

                int Size = OrderedNumbers.Length;
                int Mid = Size / 2;

                double Median = (Size % 2 != 0) ? OrderedNumbers[Mid] : (OrderedNumbers[Mid] + OrderedNumbers[Mid - 1]) / 2;

                for (int i = 0; i < OrderedNumbers.Length; i++)
                {
                    Console.WriteLine(OrderedNumbers[i]);
                }

                Console.WriteLine($"Com base na amostra a mediana é = {Median}");


            }


            void TesteArrayCurrentAccount()
            {

                ListCurrentsAccounts ListCurrentsAccounts = new ListCurrentsAccounts();

                ListCurrentsAccounts.Add(new CurrentAccount("Antonio", 51, 10));
                ListCurrentsAccounts.Add(new CurrentAccount("Gui", 19, 100));
                ListCurrentsAccounts.Add(new CurrentAccount("Marcella", 58, 50));
                ListCurrentsAccounts.Add(new CurrentAccount("João", 21, 100));
                ListCurrentsAccounts.Add(new CurrentAccount("Rafa", 31, 80));
                ListCurrentsAccounts.Add(new CurrentAccount("Gustavo", 31, 10));

                ListCurrentsAccounts.Add(new CurrentAccount("Antonio", 51, 500));
                var Diogo = new CurrentAccount("Diogo", 19, 754);
                ListCurrentsAccounts.Add(Diogo);
                ListCurrentsAccounts.Add(new CurrentAccount("Marcella", 58, 120));
                ListCurrentsAccounts.Add(new CurrentAccount("João", 21, 146));
                ListCurrentsAccounts.Add(new CurrentAccount("Jairo", 31, 10));
                ListCurrentsAccounts.Add(new CurrentAccount("Igor", 31, 124));


                //GetHigherBalanceAmount(ListCurrentsAccounts);

                ListCurrentsAccounts.ShowAccounts();
                ListCurrentsAccounts.RemoveAccount(Diogo);
                Console.WriteLine("==================================");
                ListCurrentsAccounts.ShowAccounts();

            }
            ////TesteArrayCurrentAccount();

            void GetHigherBalanceAmount(ListCurrentsAccounts ListCurrentsAccounts)

            {
                var AllAccounts = ListCurrentsAccounts._itens;
                CurrentAccount AccountHighestBalance = AllAccounts[0];

                double HighestValue = 0;
                foreach (var Account in AllAccounts)
                {


                    if (Account.BalanceAccount > HighestValue)
                    {


                        HighestValue = Account.BalanceAccount;
                        AccountHighestBalance = Account;
                    }

                }

                Console.WriteLine($"A conta do {AccountHighestBalance.Name} ganhou com o valor de {AccountHighestBalance.BalanceAccount} ");

            }

            //Console.ReadKey(true);
            #endregion


            #region:BytebankService

            List<CurrentAccount> ListAccounts = new List<CurrentAccount>() { new CurrentAccount("João", 21, 100),
            new CurrentAccount("Rafa", 31, 80), new CurrentAccount("Gustavo", 31, 10)};

            void ServiceBytebank()

            {
                try
                {

                    char option = '0';

                    while (option != '6')
                    {
                        Console.Clear();

                        Console.WriteLine("===========================================");
                        Console.WriteLine("====            Atendimento            ====");
                        Console.WriteLine("===========================================");
                        Console.WriteLine();

                        Console.WriteLine("====       Opções de Atentimento        ===");
                        Console.WriteLine();
                        Console.WriteLine("==== 1 -      Cadastrar Conta          ====");
                        Console.WriteLine("==== 2 -      Listar Contas            ====");
                        Console.WriteLine("==== 3 -      Remover Conta            ====");
                        Console.WriteLine("==== 4 -      Ordenar Conta            ====");
                        Console.WriteLine("==== 5 -      Pesquisar Conta          ====");
                        Console.WriteLine("==== 6 -      Sair do Sistema          ====");
                        Console.WriteLine("");
                        Console.Write("Digite a opção desejada: ");
                        try

                        {
                            option = char.Parse(Console.ReadLine());
                        }
                        catch (Exception)
                        {
                            throw new Exception("Erro: A opção não pode ser vazio");
                        }


                        switch (option)
                        {
                            case '1':
                                RegisterClient();
                                break;

                            case '2':
                                ShowAccounts();
                                break;
                            case '3':
                                DeleteAccounts();
                                break;
                            case '4':
                                SortAccounts();
                                break;
                            case '5':
                                FindAccounts();
                                break;

                            default:
                                break;
                        }
                    }

                }

                catch (Exception Error)
                {
                    Console.WriteLine("");
                    Console.WriteLine(Error.Message);
                    Console.ReadKey();
                    ServiceBytebank();
                }


            }
            ServiceBytebank();


            void RegisterClient()
            {

                Console.Clear();
                Console.WriteLine("=========================================");
                Console.WriteLine("========== Registro de Cliente ==========");
                Console.WriteLine("=========================================");
                Console.WriteLine("");

                string Name;
                int NumberAccount;
                double BalanceValue;
                try
                {
                    Console.Write("Digite o nome da conta: ");
                    Name = Console.ReadLine();

                    Console.Write("Digite o numero da conta: ");
                    NumberAccount = int.Parse(Console.ReadLine());

                    Console.Write("Digite o saldo da conta: ");
                    BalanceValue = double.Parse(Console.ReadLine());

                    ListAccounts.Add(new CurrentAccount(Name, NumberAccount, BalanceValue));

                    Console.WriteLine("...Conta criada com Sucesso...");

                    Console.ReadKey();
                }
                catch (Exception Error)
                {
                    Console.WriteLine("Erro: Dados estão invalidos");

                    Console.ReadKey();
                    //throw new Exception(Error.Message);
                }

            }



            void ShowAccounts()
            {
                Console.Clear();
                Console.WriteLine("=======================================");
                Console.WriteLine("========== Lista de Cliente ===========");
                Console.WriteLine("=======================================");
                Console.WriteLine("");

                if (ListAccounts.Count == 0)
                {
                    Console.WriteLine("...Nenhuma conta cadastrada!!....");
                }

                foreach (CurrentAccount item in ListAccounts)
                {
                    Console.WriteLine(item.ToString()); ;
                }
                Console.ReadKey();
            }


            void DeleteAccounts()
            {
                Console.Clear();
                Console.WriteLine("=======================================");
                Console.WriteLine("=========== Deletar Cliente ===========");
                Console.WriteLine("=======================================");
                Console.WriteLine("");

                Console.WriteLine("Escreva o nome da conta que deseja deletar: ");

                string NameAccount = Console.ReadLine();

                if (NameAccount == "")
                {
                    Console.WriteLine("Erro: você precisa digitar algo");
                    Console.ReadKey();
                    return;
                }
                var Account = ListAccounts.Find(Account => Account.Name.Contains(NameAccount));

                if (Account != null)
                {
                    ListAccounts.Remove(Account);
                    Console.WriteLine("...Conta deletada com sucesso!!...");
                    Console.ReadKey();
                }
                else
                {
                    Console.WriteLine("Erro: Conta não encontrada, falha ao tentar excluir!!");
                    Console.ReadKey();
                }

            }


            void SortAccounts()
            {
                ListAccounts.Sort();
                Console.WriteLine("...Lista ordenada com sucesso...");
                Console.ReadKey();
            }

            void FindAccounts()
            {
                Console.Clear();
                Console.WriteLine("=========================================");
                Console.WriteLine("=========== Pesquisar Cliente ===========");
                Console.WriteLine("=========================================");
                Console.WriteLine("");

                Console.WriteLine("Escreva o nome, numero ou saldo da conta que deseja achar: ");

                string InfoAccount = Console.ReadLine();

                if (InfoAccount == "")
                {
                    Console.WriteLine();
                    Console.WriteLine("Erro: você precisa digitar algo");
                    Console.ReadKey();
                    return;
                }
                var Account = ListAccounts.Where(Account => Account.Name == InfoAccount).FirstOrDefault();
             
                if (Account != null)
                {
                    Console.WriteLine();
                    Console.WriteLine("...Conta encontrada com sucesso!!...");
                    Console.WriteLine();
                    Console.WriteLine(Account.ToString());
                    Console.ReadKey();
                }
                else
                {
                    double InfoAccountDouble;

                    try
                    {
                       InfoAccountDouble = int.Parse(InfoAccount);
                    }
                    catch (Exception)
                    {

                        throw new Exception("Erro: Conta não encontrada, falha ao tentar achar!!");
                    }


                    var Account2 = ListAccounts.Where(Account => Account.NumberAccount == InfoAccountDouble).FirstOrDefault();
                        
                  

                    if (Account2 != null)
                    {
                        Console.WriteLine("...Conta encontrada com sucesso!!...");
                        Console.WriteLine(Account2.ToString()); ;
                        Console.ReadKey();
                    }
                    else
                    {

                        var Account3 = ListAccounts.Where(Account => Account.BalanceAccount == InfoAccountDouble).FirstOrDefault();
                        if (Account3 != null)
                        {
                            Console.WriteLine();
                            Console.WriteLine("...Conta encontrada com sucesso!!...");
                            Console.WriteLine();
                            Console.WriteLine(Account3.ToString()); ;
                            Console.ReadKey();
                        }
                        else
                        {
                            Console.WriteLine();
                            Console.WriteLine("Erro: Conta não encontrada, falha ao tentar achar!!");
                            Console.ReadKey();
                        }

                    }


                }

            }


            #endregion

            #region: ChallengeFindNames

            void ChallengeFindNames()
            {

                List<string> NamesFromChoices = new List<string>()
            {
             "Bruce Wayne",
             "Carlos Vilagran",
            "Richard Grayson",
            "Bob Kane",
            "Will Farrel",
            "Lois Lane",
            "General Welling",
            "Perla Letícia",
            "Uxas",
            "Diana Prince",
            "Elisabeth Romanova",
            "Anakin Wayne"
            };


                Console.WriteLine("===Digite o Nome===");
                var Name = Console.ReadLine();
             
                var NameFind = NamesFromChoices.Find(x => x.Contains(Name));

                if (NameFind != null)
                {
                    Console.WriteLine($"Nome encontrado com sucesso");
                    Console.WriteLine(NameFind);

                }
                else
                {
                    Console.WriteLine($"Nome não encontrado");
                }


            }


            //ChallengeFindNames();

            #endregion
        }

    
    }
}




