using System.IO;
using UnityEngine;

namespace XNALara.Data
{
    public class Model
    {

        public string Name
        {
            get { return new DirectoryInfo(_originDirectory).Name; }
        }

        public Geometry[] Geometries { get; }
        public string OriginPath { get { return _originDirectory; } }
        readonly string _originDirectory;
        public readonly Bone[] Bones;

        public Model(string originPath, Geometry[] geometries, Bone[] bones)
        {
            Geometries = geometries;
            _originDirectory = originPath;
            Bones = bones;
        }
    }
    
    public class Geometry
    {
        public string Name { get; }
        
        public readonly int[] Indices;
        public readonly Vector3[] Positions;
        public readonly Vector3[] Normals;
        public readonly Vector2[][] Uv;
        public readonly Texture[] Textures;
        public readonly string[] Bones;

        public readonly BoneWeight[] BoneWeights;
        
        public readonly RenderGroup RenderGroup;

        public Geometry(string meshName, int[] meshFaces, Vector3[] positions, Vector3[] normals, Vector2[][] uv, 
            Texture[] textures, string[] bones, BoneWeight[] boneBoneWeights, RenderGroup renderGroup)
        {
            Name = meshName;
            Indices = meshFaces;
            Positions = positions;
            Normals = normals;
            Uv = uv;
            Textures = textures;
            Bones = bones;
            BoneWeights = boneBoneWeights;
            RenderGroup = renderGroup;
        }
    }

    public class Texture
    {
        readonly string _fileName;
        readonly string _baseDir;
        Texture2D _unityTexture;

        public Texture(string file, string baseDir)
        {
            if (file != "")
            {
                _fileName = new DirectoryInfo(file).Name;
            } else
            {
                _fileName = file;
            }
            _baseDir = baseDir;
        }

        public Texture2D Texture2D
        {
            get
            {
                if (_unityTexture == null)
                {
                    
                    var dm = new DirectoryMaker(_baseDir);
                    if (File.Exists(Path.Combine(_baseDir, _fileName)))
                        _unityTexture = dm.LoadTexture(_fileName);
                    else
                        return null;
                }
                return _unityTexture;
            }
        }

    }

    public class Bone
    {
        public string Name { get; }

        public Vector3 Position { get; }
        public int ParentId { get; }

        public Bone( string name, Vector3 position, int parentId)
        {
            Name = name;
            Position = position;
            ParentId = parentId;
        }
    }
}
