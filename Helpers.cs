using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherApp
{
    internal class Helpers
    {
        public static int MultipleChoice(bool canCancel, params string[] options) // menuval kolla hur det funkar
        {
            const int startX = 0;
            const int startY = 0;
            const int optionsPerLine = 1;
            const int spacingPerLine = 15;

            int currentSelection = 0;

            ConsoleKey key;

            Console.CursorVisible = false;

            do
            {
                Console.Clear();

                for (int i = 0; i < options.Length; i++)
                {
                    Console.SetCursorPosition(startX + (i % optionsPerLine) * spacingPerLine, startY + i / optionsPerLine);

                    if (i == currentSelection)
                        Console.ForegroundColor = ConsoleColor.Red;

                    Console.Write(options[i].Replace("_", " "));

                    Console.ResetColor();
                }

                key = Console.ReadKey(true).Key;

                switch (key)
                {
                    case ConsoleKey.LeftArrow:
                        {
                            if (currentSelection % optionsPerLine > 0)
                                currentSelection--;
                            break;
                        }
                    case ConsoleKey.RightArrow:
                        {
                            if (currentSelection % optionsPerLine < optionsPerLine - 1)
                                currentSelection++;
                            break;
                        }
                    case ConsoleKey.UpArrow:
                        {
                            if (currentSelection >= optionsPerLine)
                                currentSelection -= optionsPerLine;
                            break;
                        }
                    case ConsoleKey.DownArrow:
                        {
                            if (currentSelection + optionsPerLine < options.Length)
                                currentSelection += optionsPerLine;
                            break;
                        }
                    case ConsoleKey.Escape:
                        {
                            if (canCancel)
                                return -1;
                            break;
                        }
                }
            } while (key != ConsoleKey.Enter);

            Console.CursorVisible = true;

            return currentSelection;
        }


        public static void DisplayMainMenu()
        {
            var mainMenuArray = Enum.GetNames(typeof(Enums.MainMenu));
            int choice = MultipleChoice(false, mainMenuArray);
            switch (choice)
            {
                case 0:
                    DisplayIndoorMenu();
                    break;
                case 1:
                    DisplayOutdoorMenu();
                    break;
                case 2:
                    Console.WriteLine("Press any key to exit");
                    Console.ReadLine();
                    break;

            }
        }
        public static void DisplayIndoorMenu()
        {
            var indoorMenuArray = (Enum.GetNames(typeof(Enums.IndoorMenu)));
            int choice = MultipleChoice(false, indoorMenuArray);
            switch (choice)
            {
                case 0:
                    Console.WriteLine("SearchFor");
                    break;
                case 1:
                    Console.WriteLine("Sort by temp");
                    break;
                case 2:
                    Console.WriteLine("Sort by humidity");
                    break;
                case 3:
                    Console.WriteLine("Sort by risk for mold");
                    break;
                case 4:
                    DisplayMainMenu();
                    break;

            }
        }
        public static void DisplayOutdoorMenu()
        {
            var outdoorMenuArray = (Enum.GetNames(typeof(Enums.OutDoorMenu)));
            int choice = MultipleChoice(false, outdoorMenuArray);

            switch (choice)
            {
                case 0:
                    Console.WriteLine("SearchFor");
                    break;
                case 1:
                    Console.WriteLine("Sort by temp");
                    break;
                case 2:
                    Console.WriteLine("Sort by humidity");
                    break;
                case 3:
                    Console.WriteLine("Sort by risk for mold");
                    break;
                case 4:
                    Console.WriteLine("Show Meterological Fall");
                    break;
                case 5:
                    Console.WriteLine("Show meterological Winter");
                    break;
                case 6:
                    DisplayMainMenu();
                    break;

            }
        }

    }
}

