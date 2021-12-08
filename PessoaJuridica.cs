using System.Collections.Generic;
using System.IO;

namespace cadastroPessoa
{
    public class PessoaJuridica : Pessoa
    {
        public string cnpj { get; set; }

        public string RazaoSocial { get; set; }

        public string caminho { get; private set; } = "Database/PessoaJuridica.csv";

        public override double PagarImposto(float rendimento)
        { // aqui temos o polimorfismo, metodos herdados de uma classe (Pessoa) que tem comportamentos diferentes nas suas subclasses (PessoaFisica, PessoaJuridica)
            if (rendimento <= 5000)
            {
                return rendimento * .06;
            } // lembrando que, quando se quer repetir um retorno de forma diferente dentro da mesma função, se utiliza o "&&"
            else if (rendimento > 5000 && rendimento <= 10000)
            { // calculo de desconto com o rentimento informado
                return rendimento * .08;
            }
            else
            {
                return rendimento * .15;
            }

        }
        // Validação se o cnpj virá com 14 digitos
        public bool ValidarCNPJ(string cnpj)
        {
            // se quiser que avalie duas condições, deve-se colocar dois && (avaliar uma "&" outra)
            if (cnpj.Length == 14 && cnpj.Substring(cnpj.Length - 6, 4) == "0001") // substring retorna um pedaço do texto string original, o startIndex pega uma posição especifica da string (nesse caso, os 4 ultimos), o que queremos comparar é o 00001, então é necessario informar onde irá começar a comparação, e quantos numeros irá pegar, nesse caso, começar na 8º posição, e pegar 4 numeros a partir dali.
            { // o comando && só retorna verdadeiro se as duas condições forem cumpridas
                return true;
            }
            return false;
        }
        // para salvar os objetos no arquivo, é necessario transformar ele em string, preparar ele pra entrar no arquivo, para isso, utiliza-se um método
        public string PrepararLinhasCsv(PessoaJuridica pj){

            return $"{pj.cnpj};{pj.nome};{pj.RazaoSocial}"; // para isso, utiliza-se o return, como string, o metodo de preparar linhas define a ordem que será salvo para assim poder ser lido

        }
        // é necessario também um método que insere as linhas no arquivo
        public void Inserir(PessoaJuridica pj){ // dentro do método inserir, coloca-se qual objeto desejado para colocar no arquivo

            string[] linhas = {PrepararLinhasCsv(pj)}; // é necessario criar um aray de string para que o arquivo receba o objeto, pois ele trabalha com aray de string
        // o nome do aray é linhas, o método de preparação de linhas está dentro do aray, e o pj são os objetos que irão para o arquivo
            File.AppendAllLines(caminho, linhas); // o metodo utilizado pede o caminho e o conteúdo (aray) que ele tem q salvar lá dentro do arquivo (File)
        }
        // o metodo que lê o arquivo, deve ter um tipo de retorno, se estramos trabalhando com objeto, a melhor forma de retornar é uma lista
        public List<PessoaJuridica> Ler(){

            List<PessoaJuridica> listaPj = new List<PessoaJuridica>(); // deve-se instanciar a lista

            string[] linhas = File.ReadAllLines(caminho); // deve-se criar o aray, não tem problema usar o mesmo nome pois está em aray diferente
        
            foreach (var cadaLinha in linhas) // para ler items de uma lista, se usa o foreach
            {
                string[] atributos = cadaLinha.Split(";"); // aqui utilizamos a mesma forma de criação de aray, mas escolhemos o separador de ponto e virgula para o split
            
                PessoaJuridica cadaPj = new PessoaJuridica(); // este objeto servirá para receber os atributos

                cadaPj.cnpj = atributos[0];
                cadaPj.nome = atributos[1];
                cadaPj.RazaoSocial = atributos[2];

                listaPj.Add(cadaPj); // aqui adicionamos o objeto na lista, que no caso é o cadaPj (cada pj registrada)
            }
        
            return listaPj; // o retorno deve ser colocado despois da chave dos métodos, funcionando como um break
        }
    }
}