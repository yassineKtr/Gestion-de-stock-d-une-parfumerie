using DataAccess.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ParfumerieServices.Tests
{
    public static class TestMethodes
    {
        public static async Task<IEnumerable<Perfume>> GetPerfumes()
        {
            IEnumerable<Perfume> perfumes = new List<Perfume>()
            {
                new Perfume()
                {
                    name = "name1",
                    brand = "brand1",
                    price = 100,

                },
                new Perfume()
                {
                    name = "name2",
                    brand = "brand2",
                    price = 200,

                },
                new Perfume()
                {
                    name = "name3",
                    brand = "brand3",
                    price = 300,

                },
                new Perfume()
                {
                    name = "name4",
                    brand = "brand4",
                    price = 400,

                }
            };
            return perfumes;
        }

        public static async Task<Perfume?> GetPerfumeById()
        {
            var perfume= new Perfume()
            {
                name = "name3",
                brand = "brand3",
                price = 100,
            };

            return perfume;
        }

        public static async Task<IEnumerable<string>> GetBrands()
        {
            
            return new List<string>()
            {
                "brand1",
                "brand2",
                "brand3",
                "brand4",
            };
        }

        public static async Task<IEnumerable<Perfume>> GetPerfumesOfASingleBrand()
        {
            IEnumerable<Perfume> perfumes = new List<Perfume>()
            {
                new Perfume()
                {
                    name = "name1",
                    brand = "brand1",
                    price = 100,

                },
                new Perfume()
                {
                    name = "name2",
                    brand = "brand1",
                    price = 200,

                },
                new Perfume()
                {
                    name = "name3",
                    brand = "brand1",
                    price = 300,

                },
                new Perfume()
                {
                    name = "name4",
                    brand = "brand1",
                    price = 400,

                }
            };
            return perfumes;

        }
    }
}
