using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using OpenSaveCloudClient.Models;

namespace OpenSaveCloudClient.Core
{
    public class SaveManager
    {
        private static SaveManager? instance;
        private List<GameSave> saves;

        public List<GameSave> Saves { get { return saves; } }

        private SaveManager()
        {
            saves = new List<GameSave>();
            Load();
            new Thread(() => CleanArchiveFolder()).Start();
        }

        public static SaveManager GetInstance()
        {
            if (instance == null)
            {
                instance = new SaveManager();
            }
            return instance;
        }

        public GameSave Create(string name, string path, string coverHash)
        {

            GameSave gameSave = new GameSave(name, "", path, "", 0);
            return gameSave;
        }

        public void DetectChanges()
        {
            foreach (GameSave gameSave in saves)
            {
                gameSave.DetectChanges();
            }
        }

        private void Load()
        {
            string appdata = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "osc");
            string path = Path.Combine(appdata, "games.json");
            if (!File.Exists(appdata))
            {
                Directory.CreateDirectory(appdata);
            }
            if (File.Exists(path))
            {
                string json = File.ReadAllText(path);
                var res = JsonSerializer.Deserialize<List<GameSave>>(json);
                if (res != null)
                {
                    saves = res;
                }
            }
        }

        public void Save()
        {
            string appdata = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "osc");
            string path = Path.Combine(appdata, "games.json");
            if (!File.Exists(appdata))
            {
                Directory.CreateDirectory(appdata);
            }
            string json = JsonSerializer.Serialize(saves);
            File.WriteAllText(path, json);
        }

        private void CleanArchiveFolder()
        {
            string appdata = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "osc");
            string cachePath = Path.Combine(appdata, "cache");
            if (Directory.Exists(cachePath))
            {
                string[] files = Directory.GetFiles(cachePath);
                foreach (string file in files)
                {
                    bool exist = false;
                    foreach (GameSave save in saves)
                    {
                        if (save.Uuid == Path.GetFileNameWithoutExtension(file))
                        {
                            exist = true;
                            break;
                        }
                    }
                    if (!exist)
                    {
                        File.Delete(Path.Combine(cachePath, file));
                    }
                }
            }
        }

    }
}
