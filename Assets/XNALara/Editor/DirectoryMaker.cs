using UnityEngine;
using UnityEditor;
using System.IO;

namespace XNALara
{
    public class DirectoryMaker
    {
        const string AssetsPath = "Assets";
        const string BaseDir = "XNALaraImport";
        readonly string _meshName;
        readonly string _originDirectory;
        string MeshFolder
        {
            get { return AssetsPath + "/" + BaseDir + "/" + _meshName; }
        }
        
        public DirectoryMaker(string originDirectory)
        {
            _meshName = new DirectoryInfo(originDirectory).Name;
            _originDirectory = originDirectory;
            MakeDirectory(MakePath());
        }

        public Texture2D LoadTexture(string filename)
        {
            var assetPath = MakePath("", filename);
            if (!File.Exists(FullPath(assetPath)))
            {
                File.Copy(Path.Combine(_originDirectory, filename), FullPath(assetPath));
                AssetDatabase.Refresh();
            }
                
            return AssetDatabase.LoadAssetAtPath<Texture2D>(assetPath);
        }

        public static string FullPath(string assetPath)
        {
            if (assetPath.StartsWith(AssetsPath))
                assetPath = assetPath.Substring((AssetsPath + "/").Length);

            return Application.dataPath + "/" + assetPath;
        }

        public string MakePath(string subdirectory="", string filename="")
        {
            var currentDir = MeshFolder;
            if (subdirectory.Length > 0)
                currentDir += "/" + subdirectory;

            if (filename.Length > 0)
                currentDir += "/" + filename;

            return currentDir;
        }
        
        static void MakeDirectory(string path, bool deleteIfExists=false) 
        {
            if (deleteIfExists)
            {
                var materialsFullPath = FullPath(path);
                if (Directory.Exists(materialsFullPath))
                    Directory.Delete(materialsFullPath, true);
                AssetDatabase.Refresh();
            }
            
            const string assetsBasePath = "Assets";
            path = path.TrimStart('/');

            if (path.StartsWith(assetsBasePath))
                path = path.Substring((assetsBasePath + "/").Length);
            
            var folders = path.Split('/');
            var currentPath = assetsBasePath;
            foreach (var folder in folders)
            {
                if (!AssetDatabase.IsValidFolder(currentPath + "/" + folder))
                    AssetDatabase.CreateFolder(currentPath, folder);
                currentPath += "/" + folder;
            }
        }
    }
}
