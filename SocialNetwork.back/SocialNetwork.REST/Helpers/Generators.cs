using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocialNetwork.Rest.Helpers
{
    public class Generators
    {
        public static String getNickname(String name, String lastname)
        {
            String nickname = String.Empty;
            Random rnd = new Random();
            if(name.Length > 0)
            {
                int to = rnd.Next(2, name.Length);
                nickname += name.Substring(0, to - 1);
            }
            
            if(lastname.Length > 0)
            {
                string[] surnames = lastname.Split(" ");
                for(int i = 0; i < surnames.Length; i++)
                {
                    int to = rnd.Next(2, surnames[i].Length);
                    nickname += surnames[i].Substring(0, to - 1);
                }
            }

            string anyCode = DateTime.Now.Ticks.ToString();
            int maxTick = anyCode.Length;
            nickname += $".{anyCode.Substring(0, 2)}";
            if (maxTick % 2 == 0)
            {
                nickname += anyCode.Substring((maxTick / 2) - 1, 2);
            }
            else
            {
                nickname += anyCode.Substring((maxTick - 1) / 2, 1);
            }
            nickname += anyCode.Substring(anyCode.Length - 2, 2);

            return nickname.ToLower();
        }
    }
}
