using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.healthy.src.components.users;

namespace api.healthy.src.components.diet
{
    public class DietModel
    {
        public Guid Id { get; set; }
        public ExerciseLevel ExerciseLevel { get; set; }
        public double Weigth { get; set; }

        public double BMR { get; set; }
        public double MedianKcalLose { get; set; }
        public double RecomendedKcalToEat { get; set; }
        public Macros? Macros { get; set; }


        public UserModel User { get; set; }

        public DietModel(double weigth, ExerciseLevel exerciseLevel)
        {
            this.Id = Guid.NewGuid();
            this.Weigth = weigth;
            this.ExerciseLevel = exerciseLevel;
        }

        public DietModel() { }




        public void FillBMR()
        {
            bool isMen = User.Sex == 'M';
            double heigth = User.Heigth;
            double weigth = this.Weigth;
            int age = this.User.GetAge();

            if (isMen)
            {
                // Fórmula corrigida para homens
                this.BMR = 88.362 + (13.397 * weigth) + (4.799 * heigth) - (5.677 * age);
            }
            else
            {
                // Fórmula para mulheres
                this.BMR = 447.593 + (9.247 * weigth) + (3.098 * heigth) - (4.330 * age);
            }
        }
    }
}


// TMB (homens) = 88,362 + (13,397 x peso em kg) + (4,799 x altura em cm) - (5,677 x idade em anos). Exemplificando: um homem de 80 kg, 1,75m e 40 anos teria, portanto, por volta de: 88, 362 + (13,397 x 80) + (4,799 x 175) - (5,677 x 40). Ou seja, 88,362 + 1.071,76 + 839,825 - 227,08, que é igual a 1.772,867 calorias.
// TMB (mulheres) = 447,593 + (9,247 x peso em kg) + (3,098 x altura em cm) - (4,330 x idade em anos)


