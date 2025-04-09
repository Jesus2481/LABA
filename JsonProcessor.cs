using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp9
{
    public class JsonProcessor<T> : IDataProcessor<T>
    {
        public List<T> LoadData(string filePath)
        {
            try
            {
                var json = File.ReadAllText(filePath);
                return System.Text.Json.JsonSerializer.Deserialize<List<T>>(json);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Ошибка загрузки JSON-данных.", ex);
            }
        }

        public void SaveData(List<T> data, string filePath)
        {
            try
            {
                var json = System.Text.Json.JsonSerializer.Serialize(data);
                File.WriteAllText(filePath, json);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Ошибка сохранения JSON-данных.", ex);
            }
        }
    }
}
