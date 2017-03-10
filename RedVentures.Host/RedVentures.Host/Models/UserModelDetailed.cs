using System.Collections.Generic;

namespace RedVentures.Host.Models
{
    public class UserModelDetailed
    {
        public string Name { get; set; }
        public int Id { get; set; }
        public string Gravatar { get; set; }
        public List<WidgetModel> Widgets { get; set; }

        public UserModelDetailed()
        {
            Widgets = new List<WidgetModel>();
        }

        public static UserModelDetailed Create(int id, string name, string gravatar)
        {
            return new UserModelDetailed
            {
                Id = id,
                Name = name,
                Gravatar = gravatar
            };
        }
    }
}
