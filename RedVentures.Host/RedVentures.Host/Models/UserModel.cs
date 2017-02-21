namespace RedVentures.Host.Models
{
    public class UserModel
    {
        public string Name { get; set; }
        public int Id { get; set; }
        public string Gravatar { get; set; }

        public static UserModel Create(int id, string name, string gravatar)
        {
            return new UserModel
            {
                Id = id,
                Name = name,
                Gravatar = gravatar
            };
        }
    }
}