using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ConsoleApp9
{
    public class XmlProcessor<T> : IDataProcessor<T>
    {
        public List<T> LoadData(string filePath)
        {
            try
            {
                var serializer = new XmlSerializer(typeof(List<T>));
                using (var reader = new StreamReader(filePath))
                {
                    return (List<T>)serializer.Deserialize(reader);
                }
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Ошибка загрузки XML-данных.", ex);
            }
        }

        public void SaveData(List<T> data, string filePath)
        {
            try
            {
                var serializer = new XmlSerializer(typeof(List<T>));
                using (var writer = new StreamWriter(filePath))
                {
                    serializer.Serialize(writer, data);
                }
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Ошибка сохранения XML-данных.", ex);
            }
        }
    }
}
