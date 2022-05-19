using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;

namespace OpenSaveCloudClient.Models
{
    public class Configuration
    {
        private static Configuration? instance;
        private Dictionary<string, string> _values;

        private Configuration()
        {
            _values = new Dictionary<string, string>();
            Load();
        }

        public static Configuration GetInstance()
        {
            if (instance == null)
            {
                instance = new Configuration();
            }
            return instance;
        }

        private void Load()
        {
            string appdata = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "osc");
            string path = Path.Combine(appdata, "settings.json");
            if (!File.Exists(appdata))
            {
                Directory.CreateDirectory(appdata);
            }
            if (File.Exists(path))
            {
                string json = File.ReadAllText(path);
                var res = JsonSerializer.Deserialize<Dictionary<string, string>>(json);
                if (res != null)
                {
                    _values = res;
                }
            }
        }

        private void Save()
        {
            string appdata = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "osc");
            string path = Path.Combine(appdata, "settings.json");
            if (!File.Exists(appdata))
            {
                Directory.CreateDirectory(appdata);
            }
            string json = JsonSerializer.Serialize<Dictionary<string, string>>(_values);
            File.WriteAllText(path, json);
        }

        public string GetString(string key, string defaultValue)
        {
            try
            {
                return _values[key];
            }
            catch (KeyNotFoundException)
            {
                return defaultValue;
            }
        }

        public int GetInt(string key, int defaultValue)
        {
            try
            {
                string value = _values[key];
                if (!Int32.TryParse(value, out int result))
                {
                    throw new Exception("This value is not an Int32");
                }
                return result;
            }
            catch (KeyNotFoundException)
            {
                return defaultValue;
            }
        }

        public Boolean GetBoolean(string key, bool defaultValue)
        {
            try
            {
                string value = _values[key];
                if (!Boolean.TryParse(value, out bool result))
                {
                    throw new Exception("This value is not a Boolean");
                }
                return result;
            } catch (KeyNotFoundException)
            {
                return defaultValue;
            }
        }

        public void SetValue(string key, object? value, bool autoFlush = false)
        {
            if (value == null)
            {
                _values.Remove(key);
            } 
            else
            {
                _values[key] = value.ToString();
            }
            if (autoFlush)
            {
                Save();
            }
        }

        public void Flush()
        {
            Save();
        }

    }
}
