using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp9
{
    public class ShopManager
    {
        private List<Artifact> _artifacts = new();

        public void LoadAllData<T>(IDataProcessor<T> processor, string filePath) where T : Artifact
        {
            var loadedArtifacts = processor.LoadData(filePath).Cast<Artifact>().ToList();
            _artifacts.AddRange(loadedArtifacts);
        }

        public void GenerateReport(string filePath)
        {
            var report = $"Общее количество артефактов: {_artifacts.Count}\n";
            report += "Статистика по редкости:\n";

            var groupedByRarity = _artifacts.GroupBy(a => a.Rarity)
                                            .Select(g => new { Rarity = g.Key, Count = g.Count() });

            foreach (var group in groupedByRarity)
            {
                report += $"{group.Rarity}: {group.Count} шт.\n";
            }

            File.WriteAllText(filePath, report);
        }

        public IEnumerable<Artifact> FindCursedArtifacts()
        {
            return _artifacts.OfType<LegendaryArtifact>()
                             .Where(a => a.IsCursed && a.PowerLevel > 50);
        }

        public IEnumerable<IGrouping<Rarity, Artifact>> GroupByRarity()
        {
            return _artifacts.GroupBy(a => a.Rarity);
        }

        public IEnumerable<Artifact> TopByPower(int count)
        {
            return _artifacts.OrderByDescending(a => a.PowerLevel).Take(count);
        }
    }
}
