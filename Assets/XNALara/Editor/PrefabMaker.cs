using System.Collections.Generic;
using System.IO;
using NUnit.Framework;
using UnityEditor;
using UnityEngine;

namespace XNALara
{
    public class PrefabMaker
    {
        readonly Data.Model _model;
        readonly Dictionary<string, GameObject> _bones = new Dictionary<string, GameObject>();
        
        public PrefabMaker(Data.Model model)
        {
            _model = model;
        }
	    
	    string AssetDirectory
	    {
		    get { return new DirectoryMaker(_model.OriginPath).MakePath();  }
	    }

        public void CreateHierarchy()
        {
            var root = new GameObject(_model.Name);
	        var prefabAssetPath = AssetDirectory + "/" + _model.Name + ".prefab";
	        root = PrefabUtility.ConnectGameObjectToPrefab(root, PrefabUtility.CreatePrefab(prefabAssetPath, root));
	        
            var skeletonRoot = new GameObject("Skeleton");
            skeletonRoot.transform.SetParent(root.transform);
            // add bones
            var addedBones = new List<GameObject>();
            foreach (var bone in _model.Bones)
            {
                _bones[bone.Name] = new GameObject(bone.Name);
                _bones[bone.Name].transform.position = bone.Position;
                addedBones.Add(_bones[bone.Name]);
            }
            // parent nodes
            for (var x = 0; x < addedBones.Count; x++)
            {
                var parentId = _model.Bones[x].ParentId;
                var parentTransform = skeletonRoot.transform;
                try
                {
                    if (parentId != -1) parentTransform = addedBones[parentId].transform;

                } catch (System.Exception ign)
                {
                    Debug.Log(ign.ToString());
                } 
                addedBones[x].transform.SetParent(parentTransform);
            }
            
            // add meshes
	        //var meshes = new List<Mesh>();
	        //var materials = new List<Material>();
	        var assetObjects = new List<Object>();
            
			foreach (var geo in _model.Geometries)
			{
				var go = new GameObject(geo.Name);
				go.transform.SetParent(root.transform);

				var mesh = new Mesh()
				{
					name = geo.Name + " mesh",
					vertices = geo.Positions,
					normals = geo.Normals,
					uv = geo.Uv[0],
					triangles = geo.Indices
				};

				var material = new MaterialMaker(geo.Textures, geo.RenderGroup).Material;
				material.name = geo.Name;

				if (geo.BoneWeights.Length == 0)
				{
					
					var sc = go.AddComponent(typeof(MeshFilter)) as MeshFilter;
					var mr = go.AddComponent(typeof(MeshRenderer)) as MeshRenderer;
					if (sc != null) sc.sharedMesh = mesh;
					if (mr != null) mr.sharedMaterial = material;
				}
				else
				{
					var rend = go.AddComponent(typeof(SkinnedMeshRenderer)) as SkinnedMeshRenderer;
				
					var transformBones = new Transform[geo.Bones.Length];
					var bindPoses  = new Matrix4x4[geo.Bones.Length];
				
					for (var x = 0; x < transformBones.Length; x++)
					{
						transformBones[x] = _bones[geo.Bones[x]].transform;
						bindPoses[x] = transformBones[x].worldToLocalMatrix * go.transform.localToWorldMatrix;
					}

					mesh.boneWeights = geo.BoneWeights;
					mesh.bindposes = bindPoses;				

					if (rend == null) continue;
					rend.bones = transformBones;
					rend.sharedMesh = mesh;
					rend.sharedMaterial = material;
				}
				assetObjects.Add(mesh);
				assetObjects.Add(material);
			}
	        
	        // create avatar and the other components
	        // addedBones
	        // set model to the T-pose
	        
	        if (addedBones.Count > 2)
	        {
		        var avatarMaker = new AvatarMaker(root, skeletonRoot, addedBones);
		        var avatar = avatarMaker.Create();
		        avatar.name = root.name + " Avatar";
		        Debug.LogFormat("Imported avatar: \"{0}\" . Valid: \"{1}\"", avatar.isHuman ? "Mecanim" : "Generic", 
			        avatar.isValid ? "Yes" : "No");
		        assetObjects.Add(avatar);

		        var animator = root.AddComponent<Animator>();
		        animator.applyRootMotion = true;
		        animator.avatar = avatar;
		        animator.updateMode = AnimatorUpdateMode.Normal;
		        animator.cullingMode = AnimatorCullingMode.CullUpdateTransforms;
	        }
	        
	        foreach(var assetObject in assetObjects)
				AssetDatabase.AddObjectToAsset(assetObject, prefabAssetPath);
	        AssetDatabase.SaveAssets();
	        
	        var prefabParent = PrefabUtility.GetCorrespondingObjectFromSource(root);
	        var gameObject = PrefabUtility.FindValidUploadPrefabInstanceRoot(root);
	        PrefabUtility.ReplacePrefab(gameObject, prefabParent, ReplacePrefabOptions.ConnectToPrefab);
			AssetDatabase.Refresh();

        }
    }
}
