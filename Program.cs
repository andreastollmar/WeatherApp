using WeatherApp.Methods;

namespace WeatherApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //string[] test = new string[3];
            //var mainMenuEnums = (Enum.GetNames(typeof(Enums.OutDoorMenu))); // returnar en array med allt innehåll. Funkar utmärkt för detta
            //List <string> data = Helpers.FetchData("Ute");
            //Helpers.DisplayDataForDay("2016-06-18", "Inne");
            Helpers.SortByTemp("Ute");
            Helpers.DisplayMainMenu();
            Console.WriteLine();
            
            //int choice = Helpers.MultipleChoice(true, mainMenuEnums);
            //Console.WriteLine(choice);
        }
    }
}