using RedVentures.Host.Models;
using System;
using System.Collections.Generic;

namespace RedVentures.Host.Repository
{
    public static class DataRepository
    {
        private static readonly Dictionary<string, string> Logins = new Dictionary<string, string>
        {
            {"redVentures", "redVentures!1" },
            {"administrator", "admin!@10" },
        };

        private static readonly Dictionary<int, WidgetModel> Widgets = new Dictionary<int, WidgetModel>
        {
            {1, WidgetModel.Create(1, "update success", "black", 1111.00, 122, true) },
            {2, WidgetModel.Create(2, "Vice President", "magenta", 3.80, 23, true) }
        };

        private static readonly Dictionary<int, UserModelDetailed> Users = new Dictionary<int, UserModelDetailed>
        {
            {1, UserModelDetailed.Create(1, "Colin", "http://www.gravatar.com/avatar/a51972ea936bc3b841350caef34ea47e?s=64&d=monsterid")},
            {2, UserModelDetailed.Create(2,"Kyle","http://www.gravatar.com/avatar/432f3e353c689fc37af86ae861d934f9?s=64&d=monsterid")},
            {3, UserModelDetailed.Create(3,"Thomas", "http://www.gravatar.com/avatar/48009c6a27d25ef0ea03f985d1f186b0?s=64&d=monsterid") }
        };

        public static Dictionary<string, string> GetLogins()
        {
            return Logins;
        }

        public static Dictionary<int, UserModelDetailed> GetUsers()
        {
            return Users;
        }

        public static Dictionary<int, WidgetModel> GetWidgets()
        {
            return Widgets;
        }

        public static void AddWidget(int widgetId, WidgetModel widget)
        {
            Widgets.Add(widgetId, widget);
        }

        public static void LinkWidgetToUser(int userId, int widgetId)
        {
            UserModelDetailed user;
            if (!Users.TryGetValue(userId, out user))
                throw new ArgumentException($"User with id '{userId}' was not found.");

            WidgetModel widget;
            if (!Widgets.TryGetValue(widgetId, out widget))
                throw new ArgumentException($"Widget with id '{widgetId}' was not found.");

            user.Widgets.Add(widget);
        }
    }
}