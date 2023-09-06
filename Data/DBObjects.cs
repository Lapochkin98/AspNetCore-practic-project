using TestAspCore.Data.Models;

namespace TestAspCore.Data
{
    public class DBObjects
    {
        public static void Initial(AppDbContent content)
        {     
            if(!content.Category.Any())
                content.Category.AddRange(Categories.Select(c => c.Value));

            if (!content.Game.Any())
            {
                content.AddRange
                    (
                        new Game
                        {
                            Name = "CallOfDutyMW2",
                            ShortDesc = "Action-packed first-person shooter",
                            LongDesc = "Call of Duty: Modern Warfare 2 is a popular first-person shooter game developed by Infinity Ward. It features an intense single-player campaign and a multiplayer mode with various game modes and maps.",
                            Img = "" +
                      " /img/CallOfDutyMW2.png",
                            Price = 19.99,
                            IsFavourite = true,
                            Available = true,
                            Category = Categories["Action"]
                        },
                        new Game
                        {
                            Name = "AssassinsCreedValhalla",
                            ShortDesc = "Open-world action-adventure",
                            LongDesc = "Assassin's Creed Valhalla is the latest installment in the Assassin's Creed series developed by Ubisoft. Set in the Viking Age, players take on the role of Eivor, a Viking raider, as they explore a vast open world, engage in combat, and build their settlement.",
                            Img = "/img/AssasinsCreedValhalla.jpg",
                            Price = 49.99,
                            IsFavourite = true,
                            Available = true,
                            Category = Categories["Action"]
                        },
                        new Game
                        {
                            Name = "The Witcher 3: Wild Hunt",
                            ShortDesc = "Epic fantasy RPG",
                            LongDesc = "The Witcher 3: Wild Hunt is an award-winning role-playing game developed by CD Projekt Red. Players control Geralt of Rivia, a monster hunter known as a Witcher, as he embarks on a quest-filled adventure in a richly detailed open world.",
                            Img = "/img/TheWitcher3WildHunt.jpg",
                            Price = 29.99,
                            IsFavourite = true,
                            Available = true,
                            Category = Categories["Action"]
                        },
                        new Game
                        {
                            Name = "FIFA 22",
                            ShortDesc = "Popular soccer simulation",
                            LongDesc = "FIFA 22 is the latest installment in the long-running FIFA series developed by EA Sports. It features realistic soccer gameplay, various game modes including career mode and ultimate team, and updated player rosters and teams.",
                            Img = "/img/FIFA_22_Cover.jpg",
                            Price = 59.99,
                            IsFavourite = true,
                            Available = true,
                            Category = Categories["Action"]
                        },
                        new Game
                        {
                            Name = "Minecraft",
                            ShortDesc = "Sandbox survival game",
                            LongDesc = "Minecraft is a hugely popular sandbox survival game developed by Mojang Studios. Players can explore a procedurally generated 3D world, gather resources, build structures, and engage in various activities such as crafting, mining, and combat.",
                            Img = "/img/Minecraft.jpeg",
                            Price = 26.99,
                            IsFavourite = true,
                            Available = true,
                            Category = Categories["Action"]
                        }
                    );
            }

            content.SaveChanges();
        }

        private static Dictionary<string, Category>? category;

        public static Dictionary<string, Category> Categories
        {
            get
            {
                if(category == null)
                {
                    var list = new Category[]
                    {
                        new Category { CategoryName = "Action", Desc = "Category for action-packed games" },
                        new Category { CategoryName = "Adventure", Desc = "Category for immersive adventure games" }
                    };

                    category = new Dictionary<string, Category>();

                    foreach(var c in list)
                    {
                        category.Add(c.CategoryName, c);
                    }
                }

                return category;
            }
        }
    }
}
