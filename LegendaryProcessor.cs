using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp9
{
    public class LegendaryProcessor : IDataProcessor<LegendaryArtifact>
    {
        public List<LegendaryArtifact> LoadData(string filePath)
        {
            try
            {
                var lines = File.ReadAllLines(filePath);
                var artifacts = new List<LegendaryArtifact>();

                foreach (var line in lines)
                {
                    var parts = line.Split('|');
                    if (parts.Length == 5)
                    {
                        artifacts.Add(new LegendaryArtifact
                        {
                            Name = parts[0],
                            PowerLevel = int.Parse(parts[1]),
                            Rarity = Enum.Parse<Rarity>(parts[2]),
                            CurseDescription = parts[3],
                            IsCursed = bool.Parse(parts[4])
                        });
                    }
                }

                return artifacts;
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Ошибка загрузки текстовых данных.", ex);
            }
        }

        public void SaveData(List<LegendaryArtifact> data, string filePath)
        {
            try
            {
                var lines = new List<string>();
                foreach (var artifact in data)
                {
                    lines.Add($"{artifact.Name}|{artifact.PowerLevel}|{artifact.Rarity}|{artifact.CurseDescription}|{artifact.IsCursed}");
                }
                File.WriteAllLines(filePath, lines);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Ошибка сохранения текстовых данных.", ex);
            }
        }
    }
}
