namespace RedVentures.Host.Models
{
    public class WidgetModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Color { get; set; }
        public double Price { get; set; }
        public int Inventory { get; set; }
        public bool Melts { get; set; }

        public static WidgetModel Create(int id, string name, string color, double price, int inventory, bool melts)
        {
            return new WidgetModel
            {
                Id = id,
                Name = name,
                Color = color,
                Price = price,
                Inventory = inventory,
                Melts = melts
            };
        }
    }
}