using System;

namespace cadastroPessoa
{
    class Program
    {
        static void Main(string[] args)
        { // Cria-se um objeto para poder validar o outro objeto, um objeto recebe os valores, e um para chamar o método
            PessoaFisica pFisica = new PessoaFisica();

            PessoaFisica novapFisica = new PessoaFisica();
            Endereco end = new Endereco();
            
            end.logradouro = "Serra Azul, Q35";
            end.numero = 1;
            end.complemento = "Sobradinho/DF";
            end.enderecoComercial = false;
          // repare que este recebeu os valores
            novapFisica.endereco = end;
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
        }
    }
}