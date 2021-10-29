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
            if (cnpj.Length == 14 && cnpj.Substring(cnpj.Length - 4) == "0001") // substring retorna um pedaço do texto string original, o startIndex pega uma posição especifica da string (nesse caso, os 4 ultimos)
            { // o comando && só retorna verdadeiro se as duas condições forem cumpridas
                return true;
            }
            return false;
        } 

    }
}