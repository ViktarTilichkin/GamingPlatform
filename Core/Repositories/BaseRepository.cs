using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Core.Repositories
{
    public abstract class BaseRepository<T>
    {
        protected abstract string path { get; }
        protected IEnumerable<T> GetAll()
        {
            var serializeoptions = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            };
            using StreamReader sr1 = new StreamReader(path);
            for (string line = sr1.ReadLine(); line != null; line = sr1.ReadLine())
            {
                yield return JsonSerializer.Deserialize<T>(line, serializeoptions);

            }
            sr1.Close();
        }
        protected void UpdateFile(List<T> dataList)
        {
            try
            {
                var serializeoptions = new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                };
                StreamWriter sw1 = new StreamWriter(path);
                for (int i = 0; i < dataList.Count; i++)
                {
                    if (dataList[i] != null)
                    {
                        string json = JsonSerializer.Serialize(dataList[i], serializeoptions);
                        sw1.WriteLine(json);
                    }
                }
                sw1.Close();
            }


            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
