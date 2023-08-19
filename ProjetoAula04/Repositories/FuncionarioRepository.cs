using Dapper;
using ProjetoAula04.Entities;
using ProjetoAula04.Settings;
using System.Data.SqlClient;

namespace ProjetoAula04.Repositories
{
    public class FuncionarioRepository
    {
        //método para gravar um registro de funcionario
        //na tabela do banco de dados

        public void Create(Funcionario funcionario)
        {
            //acessar o banco de dados (abrir conexão com o banco de dados)
            using (var connection = new SqlConnection(SqlServerSettings.GetConnectionString()))
            {
                //escrever uma query para executar um insert na tabela de funcionãrio
                var query = @"
                INSERT INTO FUNCIONARIO(ID, NOME, CPF, MATRICULA, DATAADMISSAO, TIPOCONTRATACAO)
                VALUES(@Id, @Nome, @Cpf, @Matricula, @DataAdmissao, @TipoContratacao)
            ";

                connection.Execute(query, new
                {
                    @Id = funcionario.Id,
                    @Nome = funcionario.Nome,
                    @Cpf = funcionario.Cpf,
                    @Matricula = funcionario.Matricula,
                    @DataAdmissao = funcionario.DataAdmissao,
                    @TipoContratacao = (int)funcionario.TipoContratacao,
                });
            }
        }

        public void Update(Funcionario funcionario)
        {
            var query = @"
            UPDATE FUNCIONARIO
            SET
                NOME = @Nome,
                CPF = @Cpf,
                MATRICULA = @Matricula,
                DATAADMISSAO = @DataAdmissao,
                TIPOCONTRATACAO = @TipoContratacao
            WHERE
                ID = @Id
            ";

            using (var connection = new SqlConnection(SqlServerSettings.GetConnectionString()))
            {
                connection.Execute(query, new
                {
                    @Nome = funcionario.Nome,
                    @Cpf = funcionario.Cpf,
                    @Matricula = funcionario.Matricula,
                    @DataAdmissao = funcionario.DataAdmissao,
                    @TipoContratacao = funcionario.TipoContratacao,
                    @Id = funcionario.Id,
                });
            }
        }

        public void Delete(Funcionario funcionario)
        {
            var query = @"
            DELETE FROM FUNCIONARIO WHERE ID = @Id

            ";
            using (var connection = new SqlConnection(SqlServerSettings.GetConnectionString()))
            {
                connection.Execute(query, new
                {
                    @Id = funcionario.Id,
                });
            }
        }

        public List<Funcionario> GetAll()
        {
            var query = @"
            SELECT ID, NOME, CPF, MATRICULA, DATAADMISSAO, TIPOCONTRATACAO
            FROM FUNCIONARIO
            ORDER BY NOME ASC
            ";

            using (var connection = new SqlConnection(SqlServerSettings.GetConnectionString()))
            {
                return connection.Query<Funcionario>(query).ToList();
            }
        }

        public Funcionario? GetById(Guid id)
        {
            var query = @"
            SELECT ID, NOME, CPF, MATRICULA, DATAADMISSAO, TIPOCONTRATACAO
            FROM FUNCIONARIO
            WHERE ID = @Id
            ";

            using (var connection = new SqlConnection(SqlServerSettings.GetConnectionString()))
            {
                return connection.Query<Funcionario>(query, new { @Id = id }).FirstOrDefault();
            }
        }
    }
}