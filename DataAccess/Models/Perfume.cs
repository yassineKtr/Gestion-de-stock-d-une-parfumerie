namespace DataAccess.Models
{
    public class Perfume
    {
        public Guid id { get; set; } = Guid.NewGuid();
        public string name { get; set; }
        public string brand { get; set; }
        public double promo { get; set; } = 0;
        public double price { get; set; }
    }
}
