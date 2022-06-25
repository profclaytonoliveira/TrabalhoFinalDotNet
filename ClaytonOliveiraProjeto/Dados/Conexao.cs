using System.Data.SqlClient;
namespace ClaytonOliveiraProjeto.Dados
{
    public class Conexao
    {
        private string anotacaoSQL = string.Empty;
        public Conexao() // construtor
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();
            anotacaoSQL = builder.GetSection("ConnectionStrings:AnotacaoSQL").Value;
        }
        public string getAnotacaoSQL()
        {
            return anotacaoSQL;
        }
    }
}
