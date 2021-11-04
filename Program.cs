using System;
using System.IO;
using System.Threading;

namespace cadastroPessoa
{
    class Program
    {
        static void Main(string[] args)
        {
            string opcao;

            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.BackgroundColor = ConsoleColor.Red;
            Console.WriteLine(@$"
=================================================
│       Bem vindo ao Sistema de cadastro de     │
│           pessoas Fisica e Juridica           │
=================================================
");
            // aqui chamamos a função de load que criamos fora da main no final do código, e atribuimos um valor para o texto que foi declarado na função original
            LoadBar("Iniciando");
            // o "do" e "while" são a estrutura de repetição, tudo que eu quero q se repita, estará dentro deste laço
            do
            {
                Console.WriteLine(@$"
=================================================
│            Escolha uma das Opções abaixo      │
│-----------------------------------------------│
│           1 - Pessoa Fisica                   │
│           2 - Pessoa Juridica                 │
│                                               │
│           0 - Sair                            │
=================================================
");     // aqui a opcao recebe o valor que o usuário escreveu
                opcao = Console.ReadLine();
                // switch case avalia as opções selecionadas pelo usuário
                switch (opcao)
                {
                    case "1":
                        // Cria-se um objeto para poder validar o outro objeto, um objeto recebe os valores, e um para chamar o método
                        PessoaFisica pFisica = new PessoaFisica();

                        PessoaFisica novapFisica = new PessoaFisica();

                        Endereco endPf = new Endereco();

                        endPf.logradouro = "Serra Azul, Q35";
                        endPf.numero = 1;
                        endPf.complemento = "Sobradinho/DF";
                        endPf.enderecoComercial = false;
                        // repare que este recebeu os valores
                        novapFisica.endereco = endPf;
                        novapFisica.cpf = "123456789";
                        novapFisica.nome = "João";
                        novapFisica.dataNascimento = new DateTime(1992, 01, 25);
                        // aqui acontece a consulta dos valores recebidos da pessoa cadastrada
                        Console.WriteLine($"Rua: {novapFisica.endereco.logradouro}, casa {novapFisica.endereco.numero}, {novapFisica.endereco.complemento}");
                        // e aqui veja que o outro objeto está chamando a validação referente ao método
                        bool idadeValida = pFisica.ValidarDataNascimento(pFisica.dataNascimento);

                        if (idadeValida == true)
                        {

                            Console.WriteLine("Cadastro aprovado!");

                        }
                        else
                        {

                            Console.WriteLine("Cadastro reprovado, idade inválida!");

                        }
                        break;

                    case "2":
                        PessoaJuridica pJuridica = new PessoaJuridica();

                        PessoaJuridica novaPjuridica = new PessoaJuridica();

                        Endereco endPj = new Endereco();

                        endPj.logradouro = "Q Central";
                        endPj.numero = 5;
                        endPj.complemento = "Banco do Brasil";
                        endPj.enderecoComercial = true;

                        novaPjuridica.endereco = endPj;
                        novaPjuridica.cnpj = "34567890000199";
                        novaPjuridica.RazaoSocial = "pessoajuridica";
                        // por padrão, quando se coloca um "if", ele já valida se é true. se colocar "!", ele valida se é falso
                        if (!pJuridica.ValidarCNPJ(novaPjuridica.cnpj))
                        {
                            Console.WriteLine($"CNPJ Inválido");
                        }
                        else
                        {
                            Console.WriteLine("CNPJ Válido");
                        }
                        break;

                    case "0":

                        Console.WriteLine($"Obrigado por utilizar nosso sistema");

                        LoadBar("Finalizando");

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