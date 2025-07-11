using DapperWebApi.Dto;
using DapperWebApi.Models;

namespace DapperWebApi.Services
{
    public interface UserInterface
    {
        Task<ResponseModel<List<UserlistDto>>> GetUsers();
        Task<ResponseModel<UserlistDto>> FindUser(int id);
        Task<ResponseModel<List<UserlistDto>>> DeleteUser(int id);
        Task<ResponseModel<List<UserlistDto>>> CreateUser(UserCreateDto userCreateDto);
        Task<ResponseModel<List<UserlistDto>>> UpdateUser(UserUpdateDto userUpdateDto);
    }
}
