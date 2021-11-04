namespace cadastroPessoa
{
    public class PessoaJuridica : Pessoa
    {
        public string cnpj { get; set; }
        
        public string RazaoSocial { get; set; }

        public override void PagarImposto(float salario){
        
        }
        // Validação se o cnpj virá com 14 digitos
        public bool ValidarCNPJ(string cnpj){
        // se quiser que avalie duas condições, deve-se colocar dois && (avaliar uma "&" outra)
            if (cnpj.Length == 14 && cnpj.Substring(cnpj.Length - 6, 4) == "0001") // substring retorna um pedaço do texto string original, o startIndex pega uma posição especifica da string (nesse caso, os 4 ultimos), o que queremos comparar é o 00001, então é necessario informar onde irá começar a comparação, e quantos numeros irá pegar, nesse caso, começar na 8º posição, e pegar 4 numeros a partir dali.
            { // o comando && só retorna verdadeiro se as duas condições forem cumpridas
                return true;
            }
            return false;
        } 

    }
}