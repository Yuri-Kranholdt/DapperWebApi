using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using AutoMapper;
using Azure;
using Dapper;
using DapperWebApi.Dto;
using DapperWebApi.Models;
using Microsoft.Data.SqlClient;

namespace DapperWebApi.Services
{
    public class UserService : UserInterface
    {

        private readonly IConfiguration _config;
        private readonly IMapper _mapper;

        public UserService(IConfiguration configuration, IMapper mapper) 
        { 
            _config = configuration;
            _mapper = mapper;
        }


        public async Task<ResponseModel<UserlistDto>> FindUser(int id)
        {
            ResponseModel<UserlistDto> response = new ResponseModel<UserlistDto>();

            string query = "select * from Users where Id = @Id";

            using (var connection = new SqlConnection(_config.GetConnectionString("DefaultConnection")))
            {
                var user = await connection.QueryFirstOrDefaultAsync<User>(query, new {Id = id });

                if (user == null)
                {
                    response.mensagem = "Nenhum usuário encontrado";
                    response.status = false; return response;
                }

                var mappeduser = _mapper.Map<UserlistDto>(user);
                response.dados = mappeduser;
                response.mensagem = "usuário encontrado";
            }

            return response;
        }

        public async Task<ResponseModel<List<UserlistDto>>> DeleteUser(int id)
        {
            ResponseModel<List<UserlistDto>> response = new ResponseModel<List<UserlistDto>>();

            string delquery = "delete from Users where Id = @Id";

            using (var connection = new SqlConnection(_config.GetConnectionString("DefaultConnection")))
            {

                var rowsAffected = await connection.ExecuteAsync(delquery, new { Id = id });

                if (rowsAffected == 0)
                {
                    response.mensagem = "nenhum usuário localizado";
                    response.status = false;
                    return response;
                }

                var users = await ListUsers(connection);

                var mappeduser = _mapper.Map<List<UserlistDto>>(users);
                response.dados = mappeduser;
                response.mensagem = "usuário deletado com sucesso";
            }

            return response;
        }


        public async Task<ResponseModel<List<UserlistDto>>> GetUsers()
        {

            ResponseModel<List<UserlistDto>> response = new ResponseModel<List<UserlistDto>>();

            using (var connection = new SqlConnection(_config.GetConnectionString("DefaultConnection")))
            {
                var users = await ListUsers(connection);

                if (users.Count() == 0)
                {
                    response.mensagem = "nenhum usuário localizado";
                    response.status = false;
                    return response;
                }

                var mappedusers = _mapper.Map<List<UserlistDto>>(users); // users list to userlistdto list

                response.dados = mappedusers;
                response.mensagem = "usuários";
            }

            return response;
        }

        public async Task<ResponseModel<List<UserlistDto>>> CreateUser(UserCreateDto userCreateDto)
        {
            ResponseModel<List<UserlistDto>> response = new ResponseModel<List<UserlistDto>>();

            string query = "insert into Users(Nome, Email, Cargo, Salario, CPF, Situacao, Senha) " +
                            "values (@Nome, @Email, @Cargo, @Salario, @CPF, @Situacao, @Senha)";

            using (var connection = new SqlConnection(_config.GetConnectionString("DefaultConnection")))
            {
                var new_user = new
                {
                    Nome = userCreateDto.Nome,
                    Email = userCreateDto.Email,
                    Cargo = userCreateDto.Cargo,
                    Salario = userCreateDto.Salario,
                    CPF = userCreateDto.CPF,
                    Situacao = userCreateDto.Situacao,
                    Senha = userCreateDto.Senha,
                };

                var rowsAffected = await connection.ExecuteAsync(query, new_user);

                if (rowsAffected == 0)
                {
                    response.mensagem = "ops!";
                    response.status = false;
                    return response;
                }

                var users = await ListUsers(connection);
                var mappeduser = _mapper.Map<List<UserlistDto>>(users);

                response.dados = mappeduser;
                response.mensagem = "usuário criado com sucesso";
            }

            return response;
        }

        public async Task<ResponseModel<List<UserlistDto>>> UpdateUser(UserUpdateDto userUpdateDto)
        {
            ResponseModel<List<UserlistDto>> response = new ResponseModel<List<UserlistDto>>();

            var query = @"UPDATE Users 
                          SET Nome = @Nome, 
                          Email = @Email, 
                          Cargo = @Cargo, 
                          Salario = @Salario, 
                          CPF = @CPF, 
                          Situacao = @Situacao, 
                          Senha = @Senha 
                          WHERE Id = @Id";

            using (var connection = new SqlConnection(_config.GetConnectionString("DefaultConnection")))
            {

                var updated_user = new
                {
                    Id = userUpdateDto.Id,
                    Nome = userUpdateDto.Nome,
                    Email = userUpdateDto.Email,
                    Cargo = userUpdateDto.Cargo,
                    Salario = userUpdateDto.Salario,
                    CPF = userUpdateDto.CPF,
                    Situacao = userUpdateDto.Situacao,
                    Senha = userUpdateDto.Senha,
                };

                var rowsAffected = await connection.ExecuteAsync(query, updated_user);

                if (rowsAffected == 0) 
                {
                    response.mensagem = "Usuário não encontrado!";
                    response.status = false;
                    return response;
                }

                var users = await ListUsers(connection);
                var mappeduser = _mapper.Map<List<UserlistDto>>(users);

                response.dados = mappeduser;
                response.mensagem = "usuário atualizado com sucesso";

            }

            return response;

        }

        private static async Task<IEnumerable<User>> ListUsers(SqlConnection connection)
        {
            return await connection.QueryAsync<User>("select * from Users");
        }
    }
}
