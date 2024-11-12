using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.healthy.src.components.diet.dtos;

namespace api.healthy.src.components.diet.services
{
    public interface IDietService
    {
        Task<DietModel> InsertNewDiet(long userCpf, CreateDiet request);
        Task<List<DietModel>> GetAllAppDiets();
        Task<List<DietModel>> GetDietByCpf(long userCpf);
        Task<DietModel> FillBMR(Guid dietId);
    }
}