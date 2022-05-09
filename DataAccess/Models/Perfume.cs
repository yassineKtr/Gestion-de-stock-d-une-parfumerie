namespace DataAccess.Models
{
    public class Perfume
    {
        public Guid Id { get; set; } 
        public string Name { get; set; }
        public string Brand { get; set; }
        public double Promo { get; set; } = 0;
        public double Price { get; set; }
    }
}
