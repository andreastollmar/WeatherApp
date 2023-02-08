using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using WeatherApp.Models;

namespace WeatherApp.Methods
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
                    Console.SetCursorPosition(startX + i % optionsPerLine * spacingPerLine, startY + i / optionsPerLine);

                    if (i == currentSelection)
                        Console.ForegroundColor = ConsoleColor.Red;

                    Console.Write(options[i].Replace("_", " "));

                    Console.ResetColor();
                }

                key = Console.ReadKey().Key;

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
            bool runMenu = true;
            while (runMenu)
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
                        runMenu = false;
                        break;

                }
            }
        }
        public static void DisplayIndoorMenu()
        {
            bool indoorMenu = true;
            List<Day> days = SortData("Inne");
            while (indoorMenu)
            {
                var indoorMenuArray = Enum.GetNames(typeof(Enums.IndoorMenu));
                int choice = MultipleChoice(false, indoorMenuArray);
                switch (choice)
                {
                    case 0:
                        string input = ValidateData.ValidateDate("Enter Date to search: ");
                        DisplayDataForDay(input, "Inne");
                        break;
                    case 1:
                        Console.Clear();
                        DisplayTemp(days);
                        break;
                    case 2:
                        DisplayHumidity(days);
                        break;
                    case 3:
                        DisplayMoldRisk(days);
                        break;
                    case 4:
                        indoorMenu = false;
                        break;

                }
            }
        }
        public static void DisplayOutdoorMenu()
        {
            bool outdoorMenu = true;
            List<Day> days = SortData("Ute");
            while (outdoorMenu)
            {
                var outdoorMenuArray = Enum.GetNames(typeof(Enums.OutDoorMenu));
                int choice = MultipleChoice(false, outdoorMenuArray);
                switch (choice)
                {
                    case 0:
                        string input = ValidateData.ValidateDate("Enter Date to search: ");
                        DisplayDataForDay(input, "Ute");
                        break;
                    case 1:
                        DisplayTemp(days);
                        break;
                    case 2:
                        DisplayHumidity(days);
                        break;
                    case 3:
                        DisplayMoldRisk(days);
                        break;
                    case 4:
                        Console.WriteLine("Show Meterological Fall");
                        break;
                    case 5:
                        Console.WriteLine("Show meterological Winter");
                        break;
                    case 6:
                        outdoorMenu = false;
                        break;
                }
            }
        }
        public static List<string> FetchData(string inOrOut)
        {
            string path = "../../../tempdata5-med fel/tempdata5-med fel.txt";
            string pattern = @"^(?<date>[0-9]{4}-[0-1][0-9]-[0-3][0-9])\s([0-2][0-9]:[0-5][0-9]:[0-5][0-9])," + inOrOut + ",(?<temp>[0-9][0-9]*.[0-9]),(?<humidity>[0-9][0-9]*)$";
            Regex regex = new Regex(pattern);
            var allData = File.ReadAllLines(path);

            List<string> tempData = new List<string>();

            foreach (string line in allData)
            {
                Match match = regex.Match(line);

                if (match.Success)
                {
                    int dayCheck = int.Parse(match.Groups["date"].Value.Substring(8, 2));
                    int monthCheck = int.Parse(match.Groups["date"].Value.Substring(5, 2));
                    int yearCheck = int.Parse(match.Groups["date"].Value.Substring(0, 4));
                    if (dayCheck < 32 && monthCheck > 5 && monthCheck < 13 && yearCheck == 2016)
                    {
                        tempData.Add(match.Value);
                    }

                }
            }
            return tempData;
        }
        public static List<Day> SortData(string inOrOut)
        {
            List<string> tempData = FetchData(inOrOut);

            string pattern = @"^(?<date>[0-9]{4}-[0-1][0-9]-[0-3][0-9])\s([0-2][0-9]:[0-5][0-9]:[0-5][0-9])," + inOrOut + ",(?<temp>[0-9][0-9]*.[0-9]),(?<humidity>[0-9][0-9]*)$";
            Regex regex = new Regex(pattern);
            int i = 0;
            int matchCount = 0;
            double avgTemp = 0;
            double avgHumidity = 0;
            Month month = new Month();
            foreach (string line in tempData)
            {
                Match match = regex.Match(line);
                if (match.Success)
                {

                    string dateOne = match.Groups["date"].Value;
                    string dateTwo = "";

                    try { dateTwo = regex.Match(tempData[i + 1]).Groups["date"].Value; }
                    catch
                    {
                        string nr = regex.Match(tempData[i]).Groups["temp"].Value.Replace(".", ",");
                        string humidity = regex.Match(tempData[i]).Groups["humidity"].Value;
                        avgTemp += double.Parse(nr, CultureInfo.GetCultureInfo("sv-SE"));
                        avgHumidity += double.Parse(humidity);
                        matchCount++;
                    }
                    if (dateOne == dateTwo)
                    {
                        string nr = regex.Match(tempData[i]).Groups["temp"].Value.Replace(".", ",");
                        string humidity = regex.Match(tempData[i]).Groups["humidity"].Value;
                        avgTemp += double.Parse(nr, CultureInfo.GetCultureInfo("sv-SE"));
                        avgHumidity += double.Parse(humidity);
                        matchCount++;
                    }
                    else
                    {
                        //Console.WriteLine(regex.Match(tempData[i]).Groups["date"] + " " + Math.Round(avgTemp / matchCount, 2).ToString());
                        month.Days.Add(new Day { AvgTemp = Math.Round(avgTemp / matchCount, 1), AvgHumidity = Math.Round((avgHumidity / matchCount), 2), Date = match.Groups["date"].Value });
                        matchCount = 0;
                        avgTemp = 0;
                        avgHumidity = 0;
                    }
                }
                i++;
            }

            Console.ReadKey();
            return month.Days;
        }

        public static void DisplayDataForDay(string date, string prefix)
        {
            string path = "../../../tempdata5-med fel/tempdata5-med fel.txt";
            string pattern = @"" + date + " ([0-2][0-9]:[0-5][0-9]:[0-5][0-9])," + prefix + ",(?<temp>[0-9][0-9]*.[0-9]),(?<humidity>[0-9][0-9]*)$";
            Regex regex = new Regex(pattern);
            var allData = File.ReadAllLines(path);
            double avgTemp = 0;
            double avgHumidity = 0;
            int counter = 0;
            bool success = false;

            foreach (string line in allData)
            {
                Match match = regex.Match(line);

                if (match.Success)
                {
                    string temp = match.Groups["temp"].Value.Replace(".", ",");
                    avgTemp += double.Parse(temp);
                    avgHumidity += double.Parse(match.Groups["humidity"].Value);
                    counter++;
                    success = true;
                }
            }
            if (success)
            {
                Console.WriteLine(date + " Average temp: " + Math.Round((avgTemp / counter), 2) + " Average humidity: " + Math.Round((avgHumidity / counter), 2));
            }
            else
            {
                Console.WriteLine("No data for that date");
            }
        }

        private static void DisplayHumidity(List<Day> days)
        {
            foreach (var m in days.OrderByDescending(x => x.AvgHumidity))
            {
                Console.WriteLine($"{m.Date} {m.AvgHumidity}");
            }
        }
        private static void DisplayTemp(List<Day> days)
        {
            foreach (var m in days.OrderByDescending(x => x.AvgTemp))
            {
                Console.WriteLine($"{m.Date} {m.AvgTemp}");
            }
        }
        private static void DisplayMoldRisk(List<Day> days)
        {
            foreach (var m in days)
            {
                m.CalculateMoldRisk();
            }
            foreach (var m in days.OrderByDescending(x => x.HumidityIndex).Take(20))
            {
                Console.WriteLine($"Date: {m.Date}\tTemperature: {m.AvgTemp}   \tHumidity: {m.AvgHumidity}\t\tMold risk index: {m.HumidityIndex}");
            }
        }
        private static void MetrologicalWinter()
        {

        }
        private static void MetrologicalFall()
        {

        }

    }
}

