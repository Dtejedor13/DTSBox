namespace DTSBox_WPF
{
    static class StartUp
    {
        public static string GetStartUpURI()
        {
            // change filename as startUp View
            string file = "MainWindow.xaml";

            string test = MainWindow.NameProperty + ".xaml";

            return $"Views/{file}";
        }
    }
}
