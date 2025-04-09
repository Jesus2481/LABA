namespace ConsoleApp9
{
    class Program
    {
        static void Main()
        {
            var manager = new ShopManager();

            // Загрузка данных
            var antiqueProcessor = new XmlProcessor<AntiqueArtifact>();
            var modernProcessor = new JsonProcessor<ModernArtifact>();
            var legendaryProcessor = new LegendaryProcessor();

            manager.LoadAllData(antiqueProcessor, "antique.xml");
            manager.LoadAllData(modernProcessor, "modern.json");
            manager.LoadAllData(legendaryProcessor, "legends.txt");

            // Генерация отчета
            manager.GenerateReport("report.txt");

            // Поиск проклятых артефактов
            var cursedArtifacts = manager.FindCursedArtifacts();
            Console.WriteLine("Проклятые артефакты:");
            foreach (var artifact in cursedArtifacts)
            {
                Console.WriteLine($"{artifact.Name} (Power: {artifact.PowerLevel})");
            }

            // Топ-3 артефакта по силе
            var topArtifacts = manager.TopByPower(3);
            Console.WriteLine("\nТоп-3 артефакта по силе:");
            foreach (var artifact in topArtifacts)
            {
                Console.WriteLine($"{artifact.Name} (Power: {artifact.PowerLevel})");
            }
        }
    }
}