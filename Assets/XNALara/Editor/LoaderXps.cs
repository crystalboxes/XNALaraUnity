using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

namespace XNALara
{
    public class LoaderXps : ScriptableObject
    {

        struct BoneWeightTemp
        {
            public int Id;
            public float Weight;
        }
        [MenuItem("IO/XNALara")]
        static void OpenXpsModel()
        {
            var filePath = EditorUtility.OpenFilePanelWithFilters("Open XNALara mesh", "", new[] { "FileType", "mesh,xps,ascii" });

            if (filePath.Length == 0)
            {
                return;
            }


            Data.Model xpsData;


            var model = XPSImporter.LoadModel(filePath, XPSImporter.BoneNaming.Default, 1, 1);
            var origin = Directory.GetParent(filePath).FullName;

            int boneCount = (int)XPSImporter.GetBoneCount(model);
            Data.Bone[] Bones = new Data.Bone[boneCount];
            for (int x = 0; x < boneCount; x++)
            {
                string bn = XPSImporter.GetBoneName(model, x).AsString();
                Bones[x] = new Data.Bone(bn, XPSImporter.GetBonePosition(model, x), XPSImporter.GetBoneParentId(model, x));
            }

            var meshes = new List<Data.Geometry>();
            for (var meshNumber = 0; meshNumber < XPSImporter.GetMeshCount(model); meshNumber++)
            {
                int indexCount = XPSImporter.GetMeshIndexCount(model, meshNumber);
                int vertexCount = XPSImporter.GetVertexCount(model, meshNumber);
                int uvLayersCount = XPSImporter.GetUvLayers(model, meshNumber);
                int textureCount = XPSImporter.GetTextureCount(model, meshNumber);

                string meshName = XPSImporter.GetMeshName(model, meshNumber).AsString();
                int[] meshFaces = new int[indexCount];
                Vector3[] positions = new Vector3[vertexCount];
                Vector3[] normals = new Vector3[vertexCount];
                Vector2[][] uv = new Vector2[uvLayersCount][];
                for (int x = 0; x < uvLayersCount; x++)
                {
                    uv[x] = new Vector2[vertexCount];
                }
                Data.Texture[] textures = new Data.Texture[textureCount];

                for (int x = 0; x < textureCount; x++)
                {
                    var pth = XPSImporter.GetTextureFilename(model, meshNumber, x).AsString();
                    textures[x] = new Data.Texture(pth, origin);
                }

                for (int y = 0; y < indexCount; y++)
                {
                    meshFaces[y] = XPSImporter.GetMeshIndex(model, meshNumber, y);
                }

                var activeBones = new Dictionary<int, string>();
                var boneList = new List<string>();
                BoneWeight[] weights = new BoneWeight[vertexCount];

                for (int vdx = 0; vdx < vertexCount; vdx++)
                {
                    positions[vdx] = XPSImporter.GetVertexPosition(model, meshNumber, vdx);
                    normals[vdx] = XPSImporter.GetVertexNormal(model, meshNumber, vdx);
                    for (int uvx = 0; uvx < uvLayersCount; uvx++)
                    {
                        uv[uvx][vdx] = XPSImporter.GetVertexUv(model, meshNumber, vdx, uvx);
                    }
                    BoneWeightTemp[] boneWeightsTemp = new BoneWeightTemp[4];
                    for (int x = 0; x < 4; x++)
                    {
                        boneWeightsTemp[x].Id = XPSImporter.GetVertexBoneIndex(model, meshNumber, vdx, x);
                        boneWeightsTemp[x].Weight = XPSImporter.GetVertexBoneWeight(model, meshNumber, vdx, x);
                    }
                    foreach (var boneWeight in boneWeightsTemp)
                    {
                        if (activeBones.ContainsKey(boneWeight.Id)) continue;
                        activeBones[boneWeight.Id] = Bones[boneWeight.Id].Name;
                        boneList.Add(Bones[boneWeight.Id].Name);
                    }

                    for (var z = 0; z < boneWeightsTemp.Length; z++)
                    {
                        var boneId = boneList.IndexOf(activeBones[boneWeightsTemp[z].Id]);
                        var weight = boneWeightsTemp[z].Weight;
                        switch (z)
                        {
                            case 0:
                                weights[vdx].boneIndex0 = boneId;
                                weights[vdx].weight0 = weight;
                                break;
                            case 1:
                                weights[vdx].boneIndex1 = boneId;
                                weights[vdx].weight1 = weight;
                                break;
                            case 2:
                                weights[vdx].boneIndex2 = boneId;
                                weights[vdx].weight2 = weight;
                                break;
                            case 3:
                                weights[vdx].boneIndex3 = boneId;
                                weights[vdx].weight3 = weight;
                                break;
                        }
                    }
                }

                var renderGroup = new RenderGroup();
                renderGroup.Alpha = XPSImporter.GetRenderGroupAlpha(model, meshNumber) != 0;
                renderGroup.Posable = XPSImporter.GetRenderGroupPosable(model, meshNumber) != 0;
                renderGroup.Spec1Rep = XPSImporter.GetRenderGroupSpec1Rep(model, meshNumber) != 0;
                renderGroup.Bump1Rep = XPSImporter.GetRenderGroupBump1Rep(model, meshNumber) != 0;
                renderGroup.Bump2Rep = XPSImporter.GetRenderGroupBump2Rep(model, meshNumber) != 0;
                renderGroup.TexCount = XPSImporter.GetRenderGroupTextureCount(model, meshNumber);
                renderGroup.TextureTypes = new string[renderGroup.TexCount];

                for (int x = 0; x < renderGroup.TextureTypes.Length; x++)
                {
                    renderGroup.TextureTypes[x] = XPSImporter.GetRenderGroupTextureType(model, meshNumber, x).AsString();
                }
                meshes.Add(new Data.Geometry(meshName, meshFaces, positions, normals,
                    uv, textures, boneList.ToArray(), weights, renderGroup));
            }

            xpsData = new Data.Model(origin, meshes.ToArray(), Bones);
            XPSImporter.DeleteModel(model);


            var pm = new PrefabMaker(xpsData);
            pm.CreateHierarchy();
        }
    }
}
