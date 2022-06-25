using System;
using System.Collections.Generic;

namespace SimpleMenu
{
    public class Menu
    {
        private string Title;
        private List<MenuOption> options;

        public Menu(string title, List<MenuOption> options)
        {
            this.Title = title;
            this.options = options;
        }

        public void show()
        {
            Console.Clear();
            Console.WriteLine(Title);
            Dictionary<int, MenuOption> optionsNumbered = new Dictionary<int, MenuOption>();
            for (int i = 0; i < options.Count; i++)
            {
                optionsNumbered.Add(i, options[i]);
                Console.WriteLine("\t[" + i + "]: " + options[i].Title);
            }
            int choice = -1;
            while (choice < 0 || choice >= options.Count)
            {
                Console.Write("\tEnter your choice: ");
                string input = Console.ReadLine();
                if (int.TryParse(input, out choice))
                {
                    if (choice < 0 || choice >= options.Count)
                    {
                        Console.WriteLine("\tInvalid choice");
                    }
                    else
                    {
                        optionsNumbered[choice].action();
                    }
                }
                else
                {
                    Console.WriteLine("\tInvalid choice");
                }
            }
        }
    }

    public class MenuOption
    {
        public string Title;
        public Action action;
        public MenuOption(string title, Action action)
        {
            this.Title = title;
            this.action = action;
        }
        
        public static MenuOption SubMenu(string title, Menu subMenu)
        {
            return new MenuOption(title, () =>
            {
                subMenu.show();
            });
        }
        
        public void run()
        {
            action();
        }
    }
}
