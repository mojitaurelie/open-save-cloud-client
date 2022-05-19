using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.IO.Compression;
using System.Security.Cryptography;

namespace OpenSaveCloudClient.Models
{
    public class GameSave
    {

        private int id;
        private string uuid;
        private readonly string name;
        private readonly string folderPath;
        private readonly string description;
        private string hash;
        private readonly string? coverPath;
        private readonly int revision;
        private bool synced;
        private bool localOnly;

        public int Id { get { return id; } set { id = value; } }
        public string Uuid { get { return uuid; } }
        public string Name { get { return name; } }
        public string Description { get { return description; } }
        public string FolderPath { get { return folderPath; } }
        public string Hash { get { return hash; } }
        public string? CoverPath { get { return coverPath; } }   
        public int Revision { get { return revision; } }
        public bool Synced { get { return synced; } set { synced = value; } }
        public bool LocalOnly { get { return localOnly; } set { localOnly = value; } }

        public GameSave(string name, string description, string folderPath, string? coverPath, int revision)
        {
            Guid guid = Guid.NewGuid();
            this.name = name;
            this.uuid = guid.ToString();
            this.description = description;
            this.hash = "";
            this.folderPath = folderPath;
            this.coverPath = coverPath;
            this.revision = revision;
            synced = false;
            localOnly = true;
        }

        [JsonConstructor]
        public GameSave(int id, string uuid, string name, string folderPath, string description, string hash, string? coverPath, int revision, bool synced, bool localOnly)
        {
            this.id = id;
            this.uuid = uuid;
            this.name = name;
            this.folderPath = folderPath;
            this.description = description;
            this.hash = hash;
            this.coverPath = coverPath;
            this.revision = revision;
            this.synced = synced;
            this.localOnly = localOnly;
        }

        public void Archive()
        {
            string appdata = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "osc");
            string cachePath = Path.Combine(appdata, "cache");
            string archivePath = Path.Combine(cachePath, uuid + ".bin");
            if (!File.Exists(appdata))
            {
                Directory.CreateDirectory(appdata);
            }
            if (!File.Exists(cachePath))
            {
                Directory.CreateDirectory(cachePath);
            }
            ZipFile.CreateFromDirectory(folderPath, archivePath, CompressionLevel.SmallestSize, true);
            using (var md5 = MD5.Create())
            {
                using (var stream = File.OpenRead(archivePath))
                {
                    var h = md5.ComputeHash(stream);
                    hash = BitConverter.ToString(h).Replace("-", "").ToLowerInvariant();
                }
            }
        }
    }
}
