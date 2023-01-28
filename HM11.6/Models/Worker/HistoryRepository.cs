using Microsoft.Win32;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HM11._6.Models.Worker
{
    public class HistoryRepository : IFileRepository<HistoryArgs>
    {
        private static int Id;
        static HistoryRepository()
        {
            Id = 0;
        }

        private static int NextId() => ++Id;

        private List<HistoryArgs> _history;
        public List<HistoryArgs> History => _history;

        public int Count => History.Count();
        private readonly string _path;

        public HistoryRepository(string path)
        {
            if (string.IsNullOrEmpty(path) || string.IsNullOrWhiteSpace(path))
            {
                throw new ArgumentNullException(nameof(path));
            }
            _path = path;

            if (File.Exists(_path))
            {
                Load();
                return;

            }

            File.Create(_path);
            NoHistoryForLoad();
        }

        private void NoHistoryForLoad()
        {
            _history = new List<HistoryArgs>();
            Id = 0;
        }

        private void Load()
        {
            string data = File.ReadAllText(_path);

            if (string.IsNullOrEmpty(data))
            {
                NoHistoryForLoad();
                return;
            }

            _history = JsonConvert.DeserializeObject<List<HistoryArgs>>(data);
        }

        public void AddFileRepository(HistoryArgs item)
        {
            if (item is null)
            {
                return;
            }

            item.Id = NextId();
            _history.Add(item);
            Save();
        }

        private void Save()
        {
            string json = JsonConvert.SerializeObject(_history);
            File.WriteAllText(_path, json);
        }

        public void ClearRepository()
        {
            if (History is null)
            {
                return;
            }
            History.Clear();
        }

        public void DeleteFileRepository(int itemId)
        {
            if (_history.Any(c => c.Id == itemId))
            {
                _history.Remove(_history.FirstOrDefault(c => c.Id == itemId));
            }
            else
                Debug.WriteLine("Данного элемента нет");

            Save();
        }

        public void EditFileRepository(HistoryArgs item)
        {
            if (!_history.Any(c => c.Id == item.Id))
            {
                throw new ArgumentOutOfRangeException(nameof(item), "Такой истории нет");
            }

            _history[_history.IndexOf(_history.First(c => c.Id == item.Id))] = item;
            Save();
        }

        public IEnumerable<HistoryArgs> GetAllItemsRepository() => History;

        public IEnumerator<HistoryArgs> GetEnumerator()
        {
            for (int i = 0; i < History.Count(); i++)
            {
                yield return History[i];
            }
        }

        public HistoryArgs GetItemById(int itemId)
        {
            if (_history.Any(c=>c.Id == itemId))
            {
                return _history.FirstOrDefault(c => c.Id == itemId);
            }

            return null;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
