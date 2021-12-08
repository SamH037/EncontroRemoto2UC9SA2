using System.IO;

namespace cadastroPessoa
{
    public abstract class Pessoa
    {
        public string nome { get; set; }

        public Endereco endereco { get; set; }

        public float rendimento { get; set; }

        public abstract double PagarImposto(float salario);

        public void VerificarArquivo(string caminho){ // esse metodo é um metodo que será herdado pela Pf e Pj para não ciar arquivos soltos, nisso, será utilizado o metodo de exemplo no Program, parte de registro Pj, que é para arquivos .csv
        // verifica-se se a pasta existe e se o arquivo existe
            string pasta = caminho.Split("/")[0]; // o metodo split separa uma string e transforma em um aray, separando o caminho do arquivo
        // o colchete representa a posição da barra que eu quero pegar, sendo que irá ler a string até a barra (0) e pegar o primeiro elemento, substring funcionaria, mas caso tenha que mudar o nome da pasta, vai dar problema
            if (!Directory.Exists(pasta)) // toda vez que eu chamar meu método para criar um aquivo, ele vai criar um diretório, dará problema se criar um diretorio igual e sobreescrever, então é necessario fazer uma verificação
            {
                Directory.CreateDirectory(pasta); // esse é o comando para criar a pasta, caso ela não exista
            }

            if (!File.Exists(caminho)) // aqui faz-se a mesma coisa que se faz com a pasta, verificando o caminho do arquivo
            {
                File.Create(caminho);
            }

        }

    }
}