using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.healthy.src.components.diet.dtos
{
    public class CreateDiet
    {
        public required int exerciseLevel { get; set; }
        public required double weigth { get; set; }
    }
}