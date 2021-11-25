using System;
using System.Collections.Generic;
using System.Threading;

namespace cadastroPessoa
{
    class Program
    {
        static void Main(string[] args)
        {
            string opcao;
            // lista criada de pessoas fisicas, que irão receber os valores registrados pelo usuário
            List<PessoaFisica> listaPf = new List<PessoaFisica>();
            List<PessoaJuridica> listaPj = new List<PessoaJuridica>();

            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.BackgroundColor = ConsoleColor.Red;
            Console.WriteLine(@$"
=================================================
│       Bem vindo ao Sistema de cadastro de     │
│           pessoas Fisica e Juridica           │
================================================="
);
            // aqui chamamos a função de load que criamos fora da main no final do código, e atribuimos um valor para o texto que foi declarado na função original
            LoadBar("Iniciando");
            // o "do" e "while" são a estrutura de repetição, tudo que eu quero q se repita, estará dentro deste laço
            do
            {
                Console.Clear();
                Console.WriteLine(@$"
=================================================
│            Escolha uma das Opções abaixo      │
│-----------------------------------------------│
│                 PESSOA FÍSICA                 │
│           1 - Cadastrar Pessoa Física         │
│           2 - Listar Pessoa Física            │
│           3 - Remover Pessoa Física           │
│                                               │
│                 PESSOA JURÍDICA               │
│           4 - Cadastrar Pessoa Jurídica       │
│           5 - Listar Pessoa Jurídica          │
│           6 - Remover Pessoa Jurídica         │
│                                               │
│           0 - Sair                            │
================================================="
);     // aqui a opcao recebe o valor que o usuário escreveu
                opcao = Console.ReadLine(); // comando usado para ler a opção que foi digitada pelo usuário
                // switch case avalia as opções selecionadas pelo usuário
                switch (opcao)
                {
                    case "1":

                        Console.ResetColor();

                        PessoaFisica pf = new PessoaFisica();
                        PessoaFisica novaPf = new PessoaFisica();
                        Endereco endPf = new Endereco();

                        Console.WriteLine($"Digite seu logradouro");
                        endPf.logradouro = Console.ReadLine();

                        Console.WriteLine($"Digite seu numero");
                        endPf.numero = int.Parse(Console.ReadLine());

                        Console.WriteLine($"Digite um complemento (aperte ENTER para vazio)");
                        endPf.complemento = Console.ReadLine();

                        Console.WriteLine($"Seu endereço é Comercial? S/N");
                        string endComercial = Console.ReadLine().ToUpper();

                        if (endComercial == "S")
                        {
                            endPf.enderecoComercial = true;
                        }
                        else
                        {
                            endPf.enderecoComercial = false;
                        }


                        novaPf.endereco = endPf;

                        Console.WriteLine($"Digite seu CPF (Somente numeros)");
                        novaPf.cpf = Console.ReadLine();

                        Console.WriteLine($"Digite seu Nome completo");
                        novaPf.nome = Console.ReadLine();

                        Console.WriteLine($"Digite seu rendimento mensal (Somente numeros)");
                        novaPf.rendimento = float.Parse(Console.ReadLine());

                        Console.WriteLine($"Digite sua Data de Nascimento (AAAA-MM-DD)");
                        novaPf.dataNascimento = DateTime.Parse(Console.ReadLine());

                        bool idadeValida = pf.ValidarDataNascimento(novaPf.dataNascimento);

                        if (idadeValida == true)
                        {
                            Console.WriteLine($"Cadastro Aprovado!");
                            listaPf.Add(novaPf);
                            Console.WriteLine($"O valor do Desconto do imposto é de: {pf.PagarImposto(novaPf.rendimento).ToString("N2")} reais");
                        }
                        else
                        {
                            Console.WriteLine($"Cadastro Reprovado!");
                        }

                        break;

                    case "2":

                        foreach (var cadaItem in listaPf)
                        {
                            Console.WriteLine($"Nome: {cadaItem.nome}");
                            Console.WriteLine($"CPF: {cadaItem.cpf}");
                            Console.WriteLine($"Logradouro: {cadaItem.endereco.logradouro}");
                            Console.WriteLine($"Numero: {cadaItem.endereco.numero}");
                            Console.WriteLine($"Rendimento: {cadaItem.rendimento}");
                        }

                        break;

                    case "3":

                        Console.WriteLine($"Digite o CPF que deseja remover");
                        string cpfProcurado = Console.ReadLine();

                        PessoaFisica pessoaEncontrada = listaPf.Find(cadaItem => cadaItem.cpf == cpfProcurado);

                        if (pessoaEncontrada != null)
                        {
                            listaPf.Remove(pessoaEncontrada);
                            Console.WriteLine($"Cadastro Removido!");
                        }
                        else
                        {
                            Console.WriteLine($"CPF não encontrado!");

                        }

                        break;

                    case "4":

                        Console.ResetColor();
                        PessoaJuridica pj = new PessoaJuridica();
                        PessoaJuridica novaPj = new PessoaJuridica();
                        Endereco endPj = new Endereco();

                        Console.WriteLine($"Digite seu logradouro");
                        endPj.logradouro = Console.ReadLine();

                        Console.WriteLine($"Digite seu numero");
                        endPj.numero = int.Parse(Console.ReadLine());

                        Console.WriteLine($"Digite seu complemento (aperte ENTER para vazio)");
                        endPj.complemento = Console.ReadLine();

                        Console.WriteLine($"Seu endereço é Comercial? S/N");
                        string endComercialPj = Console.ReadLine().ToUpper();

                        if (endComercialPj == "S")
                        {
                            endPj.enderecoComercial = true;
                        }
                        else
                        {
                            endPj.enderecoComercial = false;
                        }

                        novaPj.endereco = endPj;

                        Console.WriteLine($"Digite seu CNPJ (Somente numeros)");
                        novaPj.cnpj = Console.ReadLine();

                        Console.WriteLine($"Digite sua Razao Social");
                        novaPj.RazaoSocial = Console.ReadLine();

                        Console.WriteLine($"Digite seu rendimento mensal (Somente numeros)");
                        novaPj.rendimento = float.Parse(Console.ReadLine());


                        if (pj.ValidarCNPJ(novaPj.cnpj))
                        {
                            Console.WriteLine($"CNPJ Valido!");
                            listaPj.Add(novaPj);
                            Console.WriteLine($"O valor do Desconto do imposto é de: {pj.PagarImposto(novaPj.rendimento).ToString("N2")} reais");

                        }
                        else
                        {
                            Console.WriteLine($"CNPJ Invalido!");
                        }

                        break;

                    case "5":

                        foreach (var cadaItem in listaPj)
                        {
                            Console.WriteLine($"Razao Social: {cadaItem.RazaoSocial}");
                            Console.WriteLine($"CNPJ: {cadaItem.cnpj}");
                            Console.WriteLine($"Logradouro: {cadaItem.endereco.logradouro}");
                            Console.WriteLine($"Numero: {cadaItem.endereco.numero}");
                            Console.WriteLine($"Rendimento: {cadaItem.rendimento}");
                        }

                        break;

                    case "6":

                        Console.WriteLine($"Digite o CNPJ que deseja remover");
                        string cnpjProcurado = Console.ReadLine();

                        PessoaJuridica pessoaJEncontrada = listaPj.Find(cadaItem => cadaItem.cnpj == cnpjProcurado);

                        if (pessoaJEncontrada != null)
                        {
                            listaPj.Remove(pessoaJEncontrada);
                            Console.WriteLine($"Cadastro Removido!");
                        }
                        else
                        {
                            Console.WriteLine($"CNPJ não encontrado!");

                        }

                        break;

                    case "0":
                        Console.ResetColor();
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine($"Obrigado por utilizar o sistema");

                        LoadBar("Finalizando");

                        Console.ResetColor();
                        break;

                    default:
                        Console.WriteLine($"Opção inválida, por favor, digite uma opção válida");
                        break;
                }
            } while (opcao != "0");
            // while está avaliando a string opcao criada fora dele
        }
        // Função criada para barras de carregamento no código. Para que ela seja valida para todos os escopos, deve ser criada fora da main, e depois do escopo main, não antes
        // para chamar uma função que não precisa ser instaciada, que é criada fora da main, necessita colocar o comando "static"
        static void LoadBar(string textoLoad)
        // o argumento criado "textoLoad" dentro do método LoadBar, passa o valor que vier nele para o método de carregamento criado, asism não precisarei criar um método para Iniciar e outro para Finalizar
        {

            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.DarkRed;
            // console write diferente de writeline não pula linha na hora de mostrar
            Console.Write(textoLoad);
            Thread.Sleep(300);
            // Estrutura de repetição simples pelo laço for
            for (var contador = 0; contador < 5; contador++)
            {
                Console.Write($".");
                Thread.Sleep(250);
            }
            Console.ResetColor();
            // onde eu chamar o nome da função "loadbar", vai chamar esta função
        }
    }
}