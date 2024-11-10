using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.healthy.src.components.diet
{
    public class Macros(double calories, double protein, double fat, double carbs)
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public double Calories { get; set; } = calories;
        public double Protein { get; set; } = protein;
        public double Fat { get; set; } = fat;
        public double Carbs { get; set; } = carbs;
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
