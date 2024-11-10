using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.healthy.src.components.diet;
using api.healthy.src.components.utils;

namespace api.healthy.src.components.users
{
    public class UserModel
    {
        public required long Cpf { get; set; }
        public required string FullName { get; set; }
        public required string Email { get; set; }
        public required char Sex { get; set; }
        public DateTime BirthDate { get; set; }

        public UserModel() { }


        public List<DietModel> Diets { get; set; }

        public int GetAge()
        {
            DateTime today = DateTime.Today;
            int age = today.Year - BirthDate.Year;

            if (BirthDate > today.AddYears(-age))
            {
                age--;
            }

            return age;
        }
    }
}