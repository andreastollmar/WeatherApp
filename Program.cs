namespace WeatherApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] test = new string[3];
            var mainMenuEnums = (Enum.GetNames(typeof(Enums.OutDoorMenu))); // returnar en array med allt innehåll. Funkar utmärkt för detta
            int j = 0;
            //foreach (int i in Enum.GetValues(typeof(Enums.FirstMenu)))
            //{
            //    string mainMenu = Enum.GetName(typeof(Enums.FirstMenu), i);
            //    test[j] = mainMenu;
            //    j++;
            //}

            
            bool cancel = true;
            int choice = Helpers.MultipleChoice(cancel, mainMenuEnums);
            Console.WriteLine(choice);
        }
    }
}