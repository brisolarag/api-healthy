using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.healthy.src.components.diet
{
    public class BodyInformation(double weigth, double heigth)
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public double Weigth { get; set; } = weigth;
        public double Heigth { get; set; } = heigth;
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}