using RedVentures.Host.Models;
using System.Collections.Generic;
using System.Linq;

namespace RedVentures.Host.Extensions
{
    public static class DictionaryExtensions
    {
        public static bool TryGetUser(this Dictionary<int, UserModelDetailed> users, string id, out UserModelDetailed user)
        {
            int idParsed;
            user = null;
            return int.TryParse(id, out idParsed) && users.TryGetValue(idParsed, out user);
        }

        public static bool TryGetWidget(this Dictionary<int, WidgetModel> widgets, string id, out WidgetModel widget)
        {
            int idParsed;
            widget = null;
            return int.TryParse(id, out idParsed) && widgets.TryGetValue(idParsed, out widget);
        }

        public static Dictionary<int, UserModel> ToBasicUser(this Dictionary<int, UserModelDetailed> users)
        {
            return users.ToDictionary(dic => dic.Key, dic => UserModel.ParseDetailed(dic.Value));
        }        
    }
}
