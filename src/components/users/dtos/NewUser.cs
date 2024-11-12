using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.healthy.src.components.utils;

namespace api.healthy.src.components.users.dtos
{
    public class NewUser
    {
        public required long Cpf {get;set;}
        public required string FullName {get;set;}
        public required string Email { get; set; }
        public required char Sex { get; set; }
        public required int Heigth { get; set; }
        public required DateTime BirthDate { get; set; }



        public void Validate()
        {
            if (!CpfValidator.IsValidCPF(this.Cpf))
            {
                throw new ArgumentException("Invalid CPF", nameof(Cpf));
            }
        }

        public UserModel ToModel() {
            // Validate();
            return new UserModel() {
                Cpf = this.Cpf,
                FullName = this.FullName,
                Email = this.Email,
                Sex = this.Sex,
                BirthDate = this.BirthDate,
                Heigth = this.Heigth
            };
        }
    }
}