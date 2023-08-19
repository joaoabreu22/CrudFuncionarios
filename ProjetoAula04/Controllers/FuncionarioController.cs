using ProjetoAula04.Entities;
using ProjetoAula04.Enums;
using ProjetoAula04.Repositories;

namespace ProjetoAula04.Controllers
{
    public class FuncionarioController
    {
        // metodo para executar o cadastro do funcionario
        public void CadastrarFuncionário()
        {
            try
            {
                Console.WriteLine("\nCADASTRO DE FUNCIONÁRIO:\n");

                var funcionario = new Funcionario();
                funcionario.Id = Guid.NewGuid();

                Console.Write("NOME DO FUNCIONÁRIO:");
                funcionario.Nome = Console.ReadLine();

                Console.Write("CPF DO FUNCIONÁRIO:");
                funcionario.Cpf = Console.ReadLine();

                Console.Write("MATRICULA:");
                funcionario.Matricula = Console.ReadLine();

                Console.Write("DATA DE ADMISSÃO:");
                funcionario.DataAdmissao = DateTime.Parse(Console.ReadLine());

                Console.WriteLine("(1) ESTÁGIO");
                Console.WriteLine("(2) CLT");
                Console.WriteLine("(3) TERCEIRIZADO");
                funcionario.TipoContratacao = (TipoContratacao)int.Parse(Console.ReadLine());

                //gravando no banco de dados
                var funcionarioRepository = new FuncionarioRepository();
                funcionarioRepository.Create(funcionario);

                Console.WriteLine("FUNCIONARIO CADASTRADO COM SUCESSO");
            }
            catch (ArgumentException e)
            {
                Console.WriteLine("\nErro de validação de dados: ");
                Console.WriteLine(e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine("\nFalha ao cadastrar: ");
                Console.WriteLine(e.Message);
            }
        }

        public void UpdateFuncionario()
        {
            try
            {
                Console.WriteLine("\nATUALIZAÇÃO DE FUNCIONÁRIO:\n");

                Console.WriteLine("ID DO FUNCIONÁRIO.......: ");
                var id = Guid.Parse(Console.ReadLine());

                var funcionarioRepository = new FuncionarioRepository();
                var funcionario = funcionarioRepository.GetById(id);

                if (funcionario != null)
                {
                    Console.Write("NOME DO FUNCIONÁRIO:");
                    funcionario.Nome = Console.ReadLine();

                    Console.Write("CPF DO FUNCIONÁRIO:");
                    funcionario.Cpf = Console.ReadLine();

                    Console.Write("MATRICULA:");
                    funcionario.Matricula = Console.ReadLine();

                    Console.Write("DATA DE ADMISSÃO:");
                    funcionario.DataAdmissao = DateTime.Parse(Console.ReadLine());

                    Console.WriteLine("(1) ESTÁGIO");
                    Console.WriteLine("(2) CLT");
                    Console.WriteLine("(3) TERCEIRIZADO");
                    funcionario.TipoContratacao = (TipoContratacao)int.Parse(Console.ReadLine());

                    funcionarioRepository.Update(funcionario);
                    Console.WriteLine("FUNCIONARIO ATUALIZADO COM SUCESSO");
                }
                else
                {
                    Console.WriteLine("Funcionário não encontrado!");
                }
            }
            catch (ArgumentException e)
            {
                Console.WriteLine("\nErro de validação de dados: ");
                Console.WriteLine(e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine("\nFalha ao atualizar: ");
                Console.WriteLine(e.Message);
            }
        }

        public void DeleteFuncionario()
        {
            try
            {
                Console.WriteLine("\nATUALIZAÇÃO DE FUNCIONÁRIO:\n");

                Console.WriteLine("ID DO FUNCIONÁRIO.......: ");
                var id = Guid.Parse(Console.ReadLine());

                var funcionarioRepository = new FuncionarioRepository();
                var funcionario = funcionarioRepository.GetById(id);

                if (funcionario != null)
                {
                    funcionarioRepository.Delete(funcionario);
                    Console.WriteLine("FUNCIONARIO EXCLUIDO COM SUCESSO");
                }
                else
                {
                    Console.WriteLine("Funcionário não encontrado!");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("\nFalha ao excluir: ");
                Console.WriteLine(e.Message);
            }
        }

        public void ConsultarFuncionarios()
        {
            try
            {
                Console.WriteLine("\nCONSULTA DE FUNCIONÁRIO:\n");

                var funcionarioRepository = new FuncionarioRepository();
                var funcionarios = funcionarioRepository.GetAll();

                foreach (var item in funcionarios)
                {
                    Console.WriteLine("ID DO FUNCIONÁRIO.....: " + item.Id);
                    Console.WriteLine("NOME..................: " + item.Nome);
                    Console.WriteLine("CPF...................: " + item.Cpf);
                    Console.WriteLine("MATRICULA.............: " + item.Matricula);
                    Console.WriteLine("TIPO DE CONTRATAÇÃO...: " + item.TipoContratacao);
                    Console.WriteLine("DATA DE ADMISSÃO......: " + item.DataAdmissao);
                    Console.WriteLine("...");
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}