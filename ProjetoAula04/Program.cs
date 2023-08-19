using ProjetoAula04.Controllers;

namespace ProjetoAula04
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("(1) CADASTRAR FUNCIONÁRIOS");
            Console.WriteLine("(2) ATUALIZAR FUNCIONÁRIOS");
            Console.WriteLine("(3) EXCLUIR FUNCIONÁRIOS");
            Console.WriteLine("(4) CONSULTAR FUNCIONÁRIOS");

            Console.WriteLine("\nINFORME A OPÇÃO DESEJADA: ");
            var opcao = int.Parse(Console.ReadLine());

            var funcionarioController = new FuncionarioController();

            switch (opcao)
            {
                case 1: funcionarioController.CadastrarFuncionário(); break;
                case 2: funcionarioController.UpdateFuncionario(); break;
                case 3: funcionarioController.DeleteFuncionario(); break;
                case 4: funcionarioController.ConsultarFuncionarios(); break;
            }

            Console.WriteLine("DESEJA CONTINUAR ? (S,N): ");
            var continuar = Console.ReadLine();

            if (continuar.Equals("S", StringComparison.OrdinalIgnoreCase))
            {
                //limpar a tela do prompt
                Console.Clear();
                Main(args);
            }
            else
            {
                Console.WriteLine("\nFIM DO PROGRAMA!");
            }
        }
    }
}