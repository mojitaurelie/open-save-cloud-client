using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.IO.Compression;
using System.Security.Cryptography;
using OpenSaveCloudClient.Core;

namespace OpenSaveCloudClient.Models
{
    public class GameSave
    {

        private long id;
        private string uuid;
        private readonly string name;
        private readonly string folderPath;
        private readonly string description;
        private string hash;
        private string currentHash;
        private readonly string? coverPath;
        private long revision;
        private bool synced;

        public long Id { get { return id; } set { id = value; } }
        public string Uuid { get { return uuid; } }
        public string Name { get { return name; } }
        public string Description { get { return description; } }
        public string FolderPath { get { return folderPath; } }
        public string Hash { get { return hash; } }
        public string CurrentHash { get { return currentHash; } }
        public string? CoverPath { get { return coverPath; } }   
        public long Revision { get { return revision; } set { revision = value; } }
        public bool Synced { get { return synced; } set { synced = value; } }

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
        }

        [JsonConstructor]
        public GameSave(long id, string uuid, string name, string folderPath, string description, string hash, string currentHash, string? coverPath, long revision, bool synced)
        {
            this.id = id;
            this.uuid = uuid;
            this.name = name;
            this.folderPath = folderPath;
            this.description = description;
            this.hash = hash;
            this.currentHash = currentHash;
            this.coverPath = coverPath;
            this.revision = revision;
            this.synced = synced;
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
            if (File.Exists(archivePath))
            {
                File.Delete(archivePath);
            }
            ZipFile.CreateFromDirectory(folderPath, archivePath, CompressionLevel.SmallestSize, false);
            using (var md5 = MD5.Create())
            {
                using (FileStream stream = File.OpenRead(archivePath))
                {
                    var h = md5.ComputeHash(stream);
                    hash = BitConverter.ToString(h).Replace("-", "").ToLowerInvariant();
                }
            }
        }

        public bool DetectChanges()
        {
            byte[]? hashBytes = HashTool.HashDirectory(FolderPath);
            if (hashBytes == null)
            {
                throw new Exception(String.Format("failed to get hash of directory '{0}'", FolderPath));
            }
            currentHash = BitConverter.ToString(hashBytes).Replace("-", "");
            if (currentHash != hash)
            {
                synced = false;
            }
            return (currentHash != hash);
        }

        public void UpdateHash()
        {
            hash = currentHash;
        }
    }
}
