namespace ProjetoAula04.Settings
{
    public class SqlServerSettings
    {
        //método para obter a connectionstring do banco de dados
        public static string GetConnectionString()
        {
            return @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=BDAula04;Integrated Security=True;Connect Timeout=30;Encrypt=False;";
        }
    }
}