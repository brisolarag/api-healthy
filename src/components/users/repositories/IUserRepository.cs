using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.healthy.src.components.users.dtos;
using api.healthy.src.context;

namespace api.healthy.src.components.users.repositories
{
    public interface IUserRepository
    {
        Task<List<UserModel>> GetUsersAsync();
        Task<UserModel> GetUserByCpfAsync(long userCpf);
        Task<List<UserModel>> GetUserAsync(string? fname, string? email, char? sex);
        Task<UserModel> CreateUser(NewUser request);
        Task<UserModel> UpdateUser(long userCpf, EditUser request);
        Task<UserModel> DeleteUser(long userCpf);
    }
}