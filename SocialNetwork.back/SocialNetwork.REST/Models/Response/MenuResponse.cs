using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocialNetwork.Rest.Models.Response
{
    public class MenuResponse
    {
        public List<MenuTop> MenuTop { get; set; }
        public List<MenuLeft> MenuLeft { get; set; }

        public MenuResponse()
        {
            MenuTop = new List<MenuTop>()
            {
                new MenuTop { name = "Inicio", path = "/home" },
                new MenuTop { name = "Fotos", path = "/photos" },
                new MenuTop { name = "Amigos", path = "/friends" },
                new MenuTop { name = "Configuración", path = "/settings" }
            };

            MenuLeft = new List<MenuLeft>()
            {
                new MenuLeft { name = "Inicio", icon = "assets/svg-icons/sprites/icons.svg#olymp-newsfeed-icon", path = "/home" },
                new MenuLeft { name = "Mensajes", icon = "assets/svg-icons/sprites/icons.svg#olymp-little-delete", path = "/messages" },
                new MenuLeft { name = "Amigos", icon = "assets/svg-icons/sprites/icons.svg#olymp-happy-faces-icon", path = "/friends" },
                new MenuLeft { name = "Grupos", icon = "assets/svg-icons/sprites/icons.svg#olymp-happy-faces-icon", path = "/groups" },
            };
        }
    }

    public class MenuLeft
    {
        public String name { get; set; }
        public String icon { get; set; }
        public String path { get; set; }
    }

    public class MenuTop
    {
        public String name { get; set; }
        public String path { get; set; }
    }
}
