using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;

namespace cadastroPessoa
{
    class Program
    {
        static void Main(string[] args)
        {
            string opcao;
            // lista criada de pessoas fisicas, que irão receber os valores registrados pelo usuário, pode ser criada dentro do switch, mas nesta situação, em varios momentos, outras funções precisarão de acesso a essa mesma lista
            List<PessoaFisica> listaPf = new List<PessoaFisica>();
            List<PessoaJuridica> listaPj = new List<PessoaJuridica>();

            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.BackgroundColor = ConsoleColor.Red;
            Console.WriteLine(
@$"=================================================
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

                        // Console.WriteLine($"Digite seu logradouro");
                        // endPf.logradouro = Console.ReadLine(); // aqui recebemos o comando que o usuário coloca, assim como os outros readlines
                        
                        // Console.WriteLine($"Digite seu numero");
                        // endPf.numero = int.Parse(Console.ReadLine()); // o metodo Parse, é necessario para converter a informação string para int, ou double, float, etc

                        // Console.WriteLine($"Digite um complemento (aperte ENTER para vazio)");
                        // endPf.complemento = Console.ReadLine();
                        // // é necessario perguntar pro usuário se o endereço é comercial ou não, pra isso é preciso que deixe as informações pedidas de forma clara
                        // Console.WriteLine($"Seu endereço é Comercial? S/N");
                        // // string endComercial = Console.ReadLine().ToUpper(); // este é o comando para ler a verificação

                        // if (endComercial == "S") // o if veririca se é true ou false a depender da resposta do usuário
                        // {
                        //     endPf.enderecoComercial = true;
                        // }
                        // else
                        // {
                        //     endPf.enderecoComercial = false;
                        // }


                        // novaPf.endereco = endPf;

                        // Console.WriteLine($"Digite seu CPF (Somente numeros)");
                        // novaPf.cpf = Console.ReadLine();

                        Console.WriteLine($"Digite seu Nome completo");
                        novaPf.nome = Console.ReadLine();

                        // Console.WriteLine($"Digite seu rendimento mensal (Somente numeros)");
                        // novaPf.rendimento = float.Parse(Console.ReadLine()); // aqui também é necessario a conversão, nesse caso utiliza-se o float para o rendimento

                        // Console.WriteLine($"Digite sua Data de Nascimento (AAAA-MM-DD)");
                        // novaPf.dataNascimento = DateTime.Parse(Console.ReadLine());

                        // bool idadeValida = pf.ValidarDataNascimento(novaPf.dataNascimento); // aqui nós temos o sistema pegando a data de nascimento colocada, e retornando com o bool

                        // if (idadeValida == true) // só permite o cadastro se a data for valida
                        // { // temos q salvar o cadastro dentro de uma lista, então criamos a lista fora do switch, e aqui precisamos chama-la com o método
                        //     Console.WriteLine($"Cadastro Aprovado!");
                        //     listaPf.Add(novaPf); // aqui informamos o objeto que queremos adicionar na lista criada anteriormente
                        //     Console.WriteLine(pf.PagarImposto(novaPf.rendimento));
                        // }
                        // else
                        // {
                        //     Console.WriteLine($"Cadastro Reprovado!");
                        // }
                        // a biblioteca/classe StreamWriter é uma forma de criar um arquivo para um tipo de dado registrado
                        // using (StreamWriter sw = new StreamWriter($"{novaPf.nome}.txt")) // nesse caso, criamos a Pf, o usuário vai entrar com o nome dela, devemos também informar o tipo do arquivo
                        // {
                        //     sw.Write($"{novaPf.nome}"); // para eliminar a utilização do close, por precisar de fechar o arquivo, se utiliza esse tipo de processo
                        // }

                        using (StreamReader sr = new StreamReader($"{novaPf.nome}.txt")) // esse comando é feito para ler o arquivo
                        { // é necessario criar uma estrutura de repetição, nela, seria bom colocar uma forma de validar se a primeira linha tem algo escrito para assim poder ler o arquivo ou não, se cria sempre uma variavel antes do while, nesse caso linha
                            string linha;
                            
                            while ((linha = sr.ReadLine()) != null) // esse comando diz para ler a linha do arquivo antes para depois comparar se é diferente de nulo, note o comando inicial entre parentese
                            {
                                Console.WriteLine($"{linha}");
                            }
                        }

                        break;

                    case "2": // para conseguir listar os cadastros, é necessario de uma estrutura de repetição, que utiliza o comando foreach, in (para cada item, em(lista))
                        // é cirado uma variavel para salvar um item, nesse caso, os items da lista, e o collection que é a lista
                        foreach (var cadaItem in listaPf)
                        {
                            Console.WriteLine($"Nome: {cadaItem.nome}");
                            Console.WriteLine($"CPF: {cadaItem.cpf}");
                            Console.WriteLine($"Logradouro: {cadaItem.endereco.logradouro}");
                            Console.WriteLine($"Numero: {cadaItem.endereco.numero}");
                            Console.WriteLine($"Rendimento: {cadaItem.rendimento}");
                        }

                        break;

                    case "3": // aqui utilizamos o metodo para remover cadastros
                        // precisamos chamar o objeto cadastrado na lista, assim precisamos de um parametro, que poderia ser um Id, ou o CPF como um numero único
                        Console.WriteLine($"Digite o CPF que deseja remover");
                        string cpfProcurado = Console.ReadLine(); // devemos instanciar o item que procuramos, referenciando o item procurado
                        // precisamos incluir um objeto a ser encontrado, dessa forma, chamamos a classe, que esta sendo salvo na lista (PessoaFisica), e instanciamos um objeto dessa classe no método
                        PessoaFisica pessoaEncontrada = listaPf.Find(cadaItem => cadaItem.cpf == cpfProcurado); // utilizamos o Find, que é um método parecido com o Foreach com o if, lendo item por item, procurando o parametros que você quer, dessa forma, cada item q ele percorre, vai pegar um item que combine com o que você procura, instanciando os items como "cadaItem", e o cpf como "cpfProcurado"
                        // precisamos colocar uma validação para encontrar a pessoa encontrada antes
                        if (pessoaEncontrada != null) // aqui, caso não encontre a pessoa, irá armazenar nulo (null)
                        {
                            listaPf.Remove(pessoaEncontrada); // com esse comando, removemos a pessoa que o método encontrou
                            Console.WriteLine($"Cadastro Removido!");
                        }
                        else
                        { // caso seja igual a nulo, irá mostrar que não encontrou
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
                        // como ja fizemos o metodo na subclasse, apenas colocamos estes dois métodos aqui no program
                        pj.VerificarArquivo(pj.caminho);
                        pj.Inserir(novaPj);
                            
                            foreach (var item in novaPj.Ler())
                            {
                                Console.WriteLine($"Nome: {item.nome} - Razão Social:{item.RazaoSocial} - CNPJ: {item.cnpj}");   
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