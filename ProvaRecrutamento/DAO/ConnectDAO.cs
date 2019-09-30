using ProvaRecrutamento.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;

namespace ProvaRecrutamento.DAO
{
    public class ConnectDAO
    {
        private String _createPessoa = "INSERT INTO PessoaFisica (PessoaFisicaID, Nome, CPF, Sexo,DataNascimento, EstadoCivilID, CargoID, Endereco, Numero, Complemento, Bairro, Cidade, Estado, CEP)" +
                                      " VALUES (@id, @nome, @cpf, @sexo, @nascimento, @e_civilId, @cargoId, @endereco, @numero, @complemento, @bairro, @cidade, @estado, @cep)";
        private static String _queryPessoas = "SELECT * FROM PessoaFisica ORDER BY Nome ASC";
        private String _queryPessoa = "SELECT * FROM PessoaFisica WHERE PessoaFisicaID = @id";
        private String _updatePessoa = "UPDATE PessoaFisica SET Nome = @nome, CPF = @cpf, Sexo = @sexo, DataNascimento = @nascimento, EstadoCivilID = @e_civilId, CargoID = @cargoId, Endereco = @endereco, Numero = @numero, Complemento = @complemento, Bairro = @bairro, Cidade = @cidade, Estado = @estado, CEP = @cep) WHERE PessoaFisicaID = @id";
        private String _deletePessoa = "DELETE FROM PessoaFisica WHERE PessoaFisicaID = @id";

        public void create(PessoaViewModel pessoa)
        {
            SQLConnection.conectar();

            using (SqlCommand command = new SqlCommand())
            {
                command.Connection = SQLConnection.statusConexao();
                command.CommandType = CommandType.Text;
                command.CommandText = _createPessoa;
                command.Parameters.AddWithValue("@id", pessoa.pessoaId);
                command.Parameters.AddWithValue("@nome", pessoa.nome);
                command.Parameters.AddWithValue("@cpf", pessoa.cpf);
                command.Parameters.AddWithValue("@sexo", pessoa.sexo);
                command.Parameters.AddWithValue("@nascimento", pessoa.dataNasc);
                command.Parameters.AddWithValue("@e_civilId", pessoa.estadoId);
                command.Parameters.AddWithValue("@cargoId", pessoa.cargoId);
                command.Parameters.AddWithValue("@endereco", pessoa.endereco.ToString());
                command.Parameters.AddWithValue("@numero", pessoa.endereco.numero);
                command.Parameters.AddWithValue("@complemento", pessoa.endereco.complemento);
                command.Parameters.AddWithValue("@bairro", pessoa.endereco.bairro);
                command.Parameters.AddWithValue("@cidade", pessoa.endereco.cidade);
                command.Parameters.AddWithValue("@estado", pessoa.endereco.estado);
                command.Parameters.AddWithValue("@cep", pessoa.endereco.cep);

                SQLConnection.desconectar();

                try
                {
                    SQLConnection.conectar();
                    command.ExecuteNonQuery();
                }
                catch (SqlException ex)
                {
                    throw ex;
                }
            }

        }

        public static List<PessoaViewModel> AllPessoas()
        {
            SQLConnection.conectar();

            var list = new List<PessoaViewModel>();

            using (SqlCommand command = new SqlCommand())
            {
                command.Connection = SQLConnection.statusConexao();
                command.CommandText = _queryPessoas;
                SqlDataReader dr = command.ExecuteReader();

                    while (dr.Read())
                    {
                
                        EnderecoModel e = new EnderecoModel();
                        e.endereco = dr.GetString(dr.GetOrdinal("Endereco"));
                        e.numero = dr.GetString(dr.GetOrdinal("Numero"));
                        e.complemento = dr.GetString(dr.GetOrdinal("Complemento"));
                        e.bairro = dr.GetString(dr.GetOrdinal("Bairro"));
                        e.cidade = dr.GetString(dr.GetOrdinal("Cidade"));
                        e.estado = dr.GetString(dr.GetOrdinal("Estado"));
                        e.cep = dr.GetString(dr.GetOrdinal("CEP"));

                        PessoaViewModel p = new PessoaViewModel();
                        p.pessoaId = dr.GetInt32(dr.GetOrdinal("PessoaFisicaID"));
                        p.cargoId = dr.GetInt32(dr.GetOrdinal("CargoID"));
                        p.nome = dr.GetString(dr.GetOrdinal("Nome"));
                        p.cpf = dr.GetString(dr.GetOrdinal("CPF"));
                        p.endereco = e;
                        p.sexo = dr.GetString(dr.GetOrdinal("Sexo"));
                        p.dataNasc = dr.GetDateTime(dr.GetOrdinal("DataNascimento"));
                        p.estadoId = dr.GetByte(dr.GetOrdinal("EstadoCivilID"));
                        
                        list.Add(p);
                    }
       
                dr.Close();
            }


            return list;
        }

        public static PessoaViewModel PessoasById(int id)
        {
            SQLConnection.conectar();

            var p = new PessoaViewModel();

            using (SqlCommand command = new SqlCommand())
            {
                command.Connection = SQLConnection.statusConexao();
                command.CommandText = _queryPessoas;
                SqlDataReader dr = command.ExecuteReader();

                while (dr.Read())
                {
                    EnderecoModel e = new EnderecoModel();
                    e.endereco = dr.GetString(dr.GetOrdinal("Endereco"));
                    e.numero = dr.GetString(dr.GetOrdinal("Numero"));
                    e.complemento = dr.GetString(dr.GetOrdinal("Complemento"));
                    e.bairro = dr.GetString(dr.GetOrdinal("Bairro"));
                    e.cidade = dr.GetString(dr.GetOrdinal("Cidade"));
                    e.estado = dr.GetString(dr.GetOrdinal("Estado"));
                    e.cep = dr.GetString(dr.GetOrdinal("CEP"));


                    p.pessoaId = dr.GetInt32(dr.GetOrdinal("PessoaFisicaID"));
                    p.cargoId = dr.GetInt32(dr.GetOrdinal("CargoID"));
                    p.nome = dr.GetString(dr.GetOrdinal("Nome"));
                    p.cpf = dr.GetString(dr.GetOrdinal("CPF"));
                    p.endereco = e;
                    p.sexo = dr.GetString(dr.GetOrdinal("Sexo"));
                    p.dataNasc = dr.GetDateTime(dr.GetOrdinal("DataNascimento"));
                    p.estadoId = dr.GetByte(dr.GetOrdinal("EstadoCivilID"));
                }
        
                dr.Close();
            }

            return p;
        }


        public void AtualizarPessoa(PessoaViewModel pessoa)
        {
            SQLConnection.conectar();

            ///var command = new SqlCommand(createPessoa);
            using (SqlCommand command = new SqlCommand())
            {
                command.Connection = SQLConnection.statusConexao();
                command.CommandType = CommandType.Text;
                command.CommandText = _updatePessoa;
                command.Parameters.AddWithValue("@id", pessoa.pessoaId);
                command.Parameters.AddWithValue("@nome", pessoa.nome);
                command.Parameters.AddWithValue("@cpf", pessoa.cpf);
                command.Parameters.AddWithValue("@sexo", pessoa.sexo);
                command.Parameters.AddWithValue("@nascimento", pessoa.dataNasc);
                command.Parameters.AddWithValue("@e_civilId", pessoa.estadoId);
                command.Parameters.AddWithValue("@cargoId", pessoa.cargoId);
                command.Parameters.AddWithValue("@endereco", pessoa.endereco.ToString());
                command.Parameters.AddWithValue("@numero", pessoa.endereco.numero);
                command.Parameters.AddWithValue("@complemento", pessoa.endereco.complemento);
                command.Parameters.AddWithValue("@bairro", pessoa.endereco.bairro);
                command.Parameters.AddWithValue("@cidade", pessoa.endereco.cidade);
                command.Parameters.AddWithValue("@estado", pessoa.endereco.estado);
                command.Parameters.AddWithValue("@cep", pessoa.endereco.cep);

                SQLConnection.desconectar();

                try
                {
                    SQLConnection.conectar();
                    command.ExecuteNonQuery();
                }
                catch (SqlException ex)
                {
                    throw ex;
                }

            }
        }

        public void ExcluirPessoa(int id)
        {
            SQLConnection.conectar();

            using (SqlCommand command = new SqlCommand())
            {
                command.Connection = SQLConnection.statusConexao();
                command.CommandType = CommandType.Text;
                command.CommandText = _deletePessoa;


                SQLConnection.desconectar();

                try
                {
                    SQLConnection.conectar();
                    command.ExecuteNonQuery();
                }
                catch (SqlException ex)
                {
                    throw ex;
                }

            }

        }
    }
}