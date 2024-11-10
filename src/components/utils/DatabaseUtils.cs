using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.healthy.src.context;

namespace api.healthy.src.components.utils
{
    public class DatabaseUtils
    {
        public static void CheckRowsDb(int rowsAffected) {
            if (rowsAffected == 0)
                throw new Exception("Error saving to the database");
        }
    }
}