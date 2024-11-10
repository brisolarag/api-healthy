using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.healthy.src.components.users.dtos;
using api.healthy.src.components.users.repositories;

namespace api.healthy.src.components.users.services
{
    public class UserService(IUserRepository rep) : IUserService
    {
        private readonly IUserRepository _rep = rep;

        public async Task<UserModel> CreateUser(NewUser request)
        {
            return await _rep.CreateUser(request);
        }

        public async Task<UserModel> DeleteUser(long userCpf)
        {
            return await _rep.DeleteUser(userCpf);
        }

        public async Task<List<UserModel>> GetUserAsync(string? fname, string? email, char? sex)
        {
            return await _rep.GetUserAsync(fname, email, sex);
        }

        public async Task<UserModel> GetUserByCpfAsync(long userCpf)
        {
            return await _rep.GetUserByCpfAsync(userCpf);
        }

        public async Task<List<UserModel>> GetUsersAsync()
        {
            return await _rep.GetUsersAsync();
        }

        public async Task<UserModel> UpdateUser(long userCpf, EditUser request)
        {
            return await _rep.UpdateUser(userCpf, request);
        }
    }
}