namespace RedVentures.Host.Models
{
    public class UserModel
    {
        public string Name { get; set; }
        public int Id { get; set; }
        public string Gravatar { get; set; }

        public static UserModel ParseDetailed(UserModelDetailed detailed)
        {
            return new UserModel
            {
                Id = detailed.Id,
                Name = detailed.Name,
                Gravatar = detailed.Gravatar
            };
        }
    }
}