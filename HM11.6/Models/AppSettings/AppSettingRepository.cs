using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HM11._6.Models.AppSettings
{
    public class AppSettingRepository : IAppSetting
    {
        private readonly string _path;
        public AppSettingRepository()
        {
            _path = @"file-settings.json";
        }

        public AppSettingRepository(string path)
        {
            _path = path;
        }

        /// <summary>
        /// Загрузка клиентов из файла настроек
        /// </summary>
        /// <returns></returns>
        public AppSetting Load()
        {
            if (!File.Exists(_path))
            {
                return new AppSetting();
            }

            string data = File.ReadAllText(_path);
            return JsonConvert.DeserializeObject<AppSetting>(data) ?? new AppSetting();
        }

        /// <summary>
        /// Сохранение файла с настройками
        /// </summary>
        /// <param name="appSetting"></param>
        public void Save(AppSetting appSetting)
        {
            string json = JsonConvert.SerializeObject(appSetting);
            File.WriteAllText(_path, json, Encoding.UTF8);
        }
    }
}
