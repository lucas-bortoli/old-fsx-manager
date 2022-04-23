namespace fsxGUI
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();

            var settings = Properties.Settings.Default;

            if (string.IsNullOrWhiteSpace(settings.DataFileLocation))
            {
                settings.DataFileLocation = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "fsx.dat");
            }

            if (string.IsNullOrWhiteSpace(settings.DownloadsFolder))
            {
                settings.DownloadsFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "Fsx Downloads");
                Directory.CreateDirectory(settings.DownloadsFolder);
            }

            Application.Run(new MainWindow());
        }
    }
}