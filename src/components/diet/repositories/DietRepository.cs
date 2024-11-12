using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.healthy.src.components.diet.dtos;
using api.healthy.src.context;
using Microsoft.EntityFrameworkCore;

namespace api.healthy.src.components.diet.repositories
{
    public class DietRepository(ApiContext db): IDietRespository
    {
        private readonly ApiContext _db = db;

        public async Task<List<DietModel>> GetDietByCpf(long userCpf)
        {
            var user = await _db.Users.Include(u => u.Diets).SingleOrDefaultAsync(u => u.Cpf == userCpf) ?? 
                    throw new Exception("User was not found.");
            
            return user.Diets;
        }

        public Task<List<DietModel>> GetAllAppDiets()
        {
            return _db.Diets.ToListAsync();
        }

        public async Task<DietModel> InsertNewDiet(long userCpf, CreateDiet request)
        {
            var user = await _db.Users.Include(u => u.Diets).SingleOrDefaultAsync(u => u.Cpf == userCpf) ?? 
                    throw new Exception("User was not found.");
            
            var diet = new DietModel(request.weigth, (ExerciseLevel) 2);
            user.Diets ??= new List<DietModel>();
            user.Diets.Add(diet);
            diet.User = user;

            _db.Diets.Add(diet);

            await _db.SaveChangesAsync();
            return diet;
        }

        public async Task<DietModel> FillBMR(Guid dietId) 
        {
            var diet = await _db.Diets.Include(d => d.User).SingleOrDefaultAsync(d => d.Id == dietId) ?? throw new Exception ("Diet was not found.");
            diet.FillBMR();
            await _db.SaveChangesAsync();
            return diet;
        }
    }
}