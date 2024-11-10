using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.healthy.src.components.users.dtos
{
    public class EditUser
    {
        public string? FullName { get; set; }
        public string? Email { get; set; }
        public char?  Sex { get; set; }
        public DateTime? BirthDate { get; set; }

        public UserModel Edit(UserModel model) {
            if (this.FullName is not null)
                model.FullName = this.FullName;
            
            if (this.Email is not null)
                model.Email = this.Email;

            if (this.BirthDate.HasValue)
                model.BirthDate = this.BirthDate.Value;
            
            if (this.Sex.HasValue)
                model.Sex = this.Sex.Value;

            
            return model;
        }
    }
}