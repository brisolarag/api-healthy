using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.healthy.src.components.diet.dtos;
using api.healthy.src.components.diet.repositories;
using Microsoft.EntityFrameworkCore.Query;

namespace api.healthy.src.components.diet.services
{
    public class DietService(IDietRespository rep) : IDietService
    {
        private readonly IDietRespository _rep = rep;

        public Task<DietModel> FillBMR(Guid dietId)
        {
            return _rep.FillBMR(dietId);
        }

        public Task<List<DietModel>> GetAllAppDiets()
        {
            return _rep.GetAllAppDiets();
        }

        public Task<List<DietModel>> GetDietByCpf(long userCpf)
        {
            return _rep.GetDietByCpf(userCpf);
        }

        public Task<DietModel> InsertNewDiet(long userCpf, CreateDiet request)
        {
            return _rep.InsertNewDiet(userCpf, request);
        }
    }
}