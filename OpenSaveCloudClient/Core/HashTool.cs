using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace OpenSaveCloudClient.Core
{
    internal class HashTool
    {

        /// <summary>
        /// method <c>HashDirectory</c> walk through a directory and make a hash of all the files
        /// </summary>
        /// <param name="path">The path to the folder</param>
        /// <returns>The hash of the folder</returns>
        /// <exception cref="InvalidOperationException"></exception>
        public static byte[]? HashDirectory(string path)
        {
            DirectoryInfo dir = new(path);
            using HashAlgorithm? sha = HashAlgorithm.Create("SHA-512");
            if (sha == null)
            {
                throw new InvalidOperationException("HashDirectory: SHA-512 algorithm does not exist");
            }
            using (var stream = new CryptoStream(Stream.Null, sha, CryptoStreamMode.Write))
            {
                using var writer = new BinaryWriter(stream);
                FileSystemInfo[] infos = dir.GetFileSystemInfos();
                Array.Sort(infos, (a, b) => string.Compare(a.Name, b.Name, StringComparison.Ordinal));
                foreach (FileSystemInfo info in infos)
                {
                    writer.Write(info.Name);
                    if ((info.Attributes & FileAttributes.Directory) == 0)
                    {
                        byte[]? hash = HashFile(info as FileInfo);
                        if (hash == null)
                        {
                            throw new InvalidOperationException("HashDirectory: hash of the file is null");
                        }
                        writer.Write((byte)'F');
                        writer.Write(hash);
                    }
                    else
                    {
                        byte[]? hash = HashDirectory(info.FullName);
                        if (hash == null)
                        {
                            throw new InvalidOperationException("HashDirectory: hash of the directory is null");
                        }
                        writer.Write((byte)'D');
                        writer.Write(hash);
                    }
                }
            }
            return sha.Hash;
        }

        /// <summary>
        /// method <c>HashFile</c> make a hash SHA-512 of a file
        /// </summary>
        /// <param name="fileInfo">The file information</param>
        /// <returns>The file's hash</returns>
        /// <exception cref="Exception"></exception>
        /// <exception cref="InvalidOperationException"></exception>
        private static byte[]? HashFile(FileInfo? fileInfo)
        {
            if (fileInfo == null)
            {
                throw new Exception("HashFile: invalid file information");
            }
            using HashAlgorithm? sha = HashAlgorithm.Create("SHA-512");
            if (sha == null)
            {
                throw new InvalidOperationException("HashFile: SHA-512 algorithm does not exist");
            }
            using var inputStream = fileInfo.OpenRead();
            return sha.ComputeHash(inputStream);
        }

        public static string? HashFile(string path)
        {
            FileInfo fileInfo = new(path);
            byte[]? hash = HashFile(fileInfo);
            if (hash == null)
            {
                throw new InvalidOperationException("HashFile: file to get hash");
            }
            return BitConverter.ToString(hash).Replace("-", "");
        }

    }
}
