namespace WeatherApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //string[] test = new string[3];
            //var mainMenuEnums = (Enum.GetNames(typeof(Enums.OutDoorMenu))); // returnar en array med allt innehåll. Funkar utmärkt för detta
            Helpers.FetchData();
            //Helpers.DisplayMainMenu();
            
            //int choice = Helpers.MultipleChoice(true, mainMenuEnums);
            //Console.WriteLine(choice);
        }
    }
}