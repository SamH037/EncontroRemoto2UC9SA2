using System;

namespace cadastroPessoa
{
    public class PessoaFisica : Pessoa
    {
        public string cpf { get; set; }

        public DateTime dataNascimento { get; set; }

        public override double PagarImposto(float rendimento)

        { // implementando desconto condicional no imposto
            if (rendimento <= 1500)
            {
                return 0;
            } // lembrando que, quando se quer repetir um retorno de forma diferente dentro da mesma função, se utiliza o "&&"
            else if (rendimento > 1500 && rendimento <= 5000)
            { // calculo de desconto com o rentimento informado
                return rendimento * .03;
            }
            else
            {
                return rendimento * .05;
            }
        }

        public bool ValidarDataNascimento(DateTime dataNasc)
        {

            DateTime dataAtual = DateTime.Today;

            double anos = (dataAtual - dataNasc).TotalDays / 365;

            if (anos >= 18)
            {

                return true;

            }

            return false;
        }
    }
}