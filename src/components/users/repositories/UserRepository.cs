using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.healthy.src.components.users.dtos;
using api.healthy.src.components.utils;
using api.healthy.src.context;
using Microsoft.EntityFrameworkCore;

namespace api.healthy.src.components.users.repositories
{
    public class UserRepository(ApiContext db) : IUserRepository
    {
        private readonly ApiContext _db = db;

        public async Task<UserModel> CreateUser(NewUser request)
        {

            UserModel newUser = request.ToModel() ?? throw new Exception("Error parsing new user");
            _db.Users.Add(newUser);
            DatabaseUtils.CheckRowsDb(await _db.SaveChangesAsync());

            return newUser;
        }

        public async Task<UserModel> DeleteUser(long userCpf)
        {
            var user = await _db.Users.FindAsync(userCpf) ?? throw new Exception("User was not found. Unable to delete");
            _db.Users.Remove(user);
            DatabaseUtils.CheckRowsDb(await _db.SaveChangesAsync());
            return user;
        }

        public async Task<UserModel> GetUserByCpfAsync(long userCpf) {
            return await _db.Users.FindAsync(userCpf) ?? throw new Exception("User was not found.");
        }

        public async Task<List<UserModel>> GetUserAsync(string? fname, string? email, char? sex)
        {
            var query = _db.Users.AsQueryable();
            if (fname is not null)
                query = query.Where(user => user.FullName.ToLower().Contains(fname.ToLower()));
            
            if (email is not null)
                query = query.Where(user => user.Email.ToLower().Contains(email.ToLower()));

            if (sex is not null)
                query = query.Where(user => user.Sex.Equals(sex));
            
            var users = await query.ToListAsync() ?? throw new Exception("User was not found.");
            return users;
        }

        public async Task<List<UserModel>> GetUsersAsync()
        {
            return await _db.Users.ToListAsync();
        }

        public async Task<UserModel> UpdateUser(long userCpf, EditUser request)
        {
            var user = await _db.Users.FindAsync(userCpf) ?? throw new Exception("User was not found.");
            user = request.Edit(user) ?? throw new Exception($"Unable to edit the user: ${user.Cpf}");
            DatabaseUtils.CheckRowsDb(await _db.SaveChangesAsync());
            return user;
        }
    }
}