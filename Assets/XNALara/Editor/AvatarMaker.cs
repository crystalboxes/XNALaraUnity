using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace XNALara
{
    public class AvatarMaker
    {
        readonly GameObject _root;
        readonly List<GameObject> _bones;
        readonly Dictionary<Naming.BoneType, GameObject> _boneMapping = new Dictionary<Naming.BoneType, GameObject>();
        
        public AvatarMaker(GameObject root, GameObject skeleton, List<GameObject> bones, bool checkLeftRight=true)
        {
            _root = root;
            _bones = bones;
            // _bones is used for the array of SkeletonBones and it requires all parent transforms which may not be, in
            // fact the actual bones
            _bones.Add(root);
            _bones.Add(skeleton);
            // First make a dictionary bonetype -> transform
            foreach (var bone in bones)
            {
                // Get bone type
                if (!Naming.BoneDictionary.ContainsKey(bone.name)) continue;
                var boneType = Naming.BoneDictionary[bone.name];
                if (boneType != Naming.BoneType.Generic)
                    _boneMapping[boneType] = bone;
            }

            if (!checkLeftRight) return;
            // Make sure Left/Right bones aren't swapped.
            var boneMapping = new Dictionary<Naming.BoneType, GameObject>(_boneMapping);
            foreach (var mapping in boneMapping)
            {
                var boneType = mapping.Key;
                var boneTypeString = boneType.ToString();
                
                if (!boneTypeString.Contains("Left")) continue;
                if (!(Vector3.Dot(mapping.Value.transform.position, Vector3.left) < .0f)) continue;
                // Swap left right
                var otherBoneType = (Naming.BoneType)Enum.Parse(typeof(Naming.BoneType), boneTypeString.Replace("Left", "Right"));
                var otherGo = _boneMapping[otherBoneType];
                var go = _boneMapping[boneType];
                _boneMapping[boneType] = otherGo;
                _boneMapping[otherBoneType] = go;
                //Debug.LogFormat("Swapped {0} with {1}", go.name, otherGo.name);
            }
        }

        Dictionary<Naming.BoneType, Quaternion> GetTPoseRotationMap()
        { 
            const float hipAngle = 4.725841f;
            const float armAngle = 86.44605f;
            
            var hipLeft = _boneMapping[Naming.BoneType.HipLeft].transform;
            var hipRight = _boneMapping[Naming.BoneType.HipRight].transform;
            var kneeLeft = _boneMapping[Naming.BoneType.KneeLeft].transform;
            var kneeRight = _boneMapping[Naming.BoneType.KneeRight].transform;
            var armLeft = _boneMapping[Naming.BoneType.ShoulderLeft].transform;
            var armRight = _boneMapping[Naming.BoneType.ShoulderRight].transform;
            var elbowLeft = _boneMapping[Naming.BoneType.ElbowLeft].transform;
            var elbowRight = _boneMapping[Naming.BoneType.ElbowRight].transform;
            
            var hipLeftRotation = hipLeft.rotation;
            var hipRightRotation = hipRight.rotation;
            var shoulderLeftRotation = armLeft.rotation;
            var shoulderRightRotation = armRight.rotation;
            
            var armAngleLeft = Vector3.Angle(elbowLeft.position - armLeft.position,
                new Vector3(armLeft.position.x, 0f, armLeft.position.z) - armLeft.position);
            var armAngleRight = Vector3.Angle(elbowRight.position - armRight.position,
                new Vector3(armRight.position.x, 0f, armRight.position.z) - armRight.position);
            
            var hipAngleLeft = Vector3.Angle(kneeLeft.position - hipLeft.position,
                new Vector3(hipLeft.position.x, 0f, hipLeft.position.z) - hipLeft.position);
            var hipAngleRight = Vector3.Angle(kneeRight.position - hipRight.position,
                new Vector3(hipRight.position.x, 0f, hipRight.position.z) - hipRight.position);

            armLeft.rotation = Quaternion.Euler(
                new Vector3(armLeft.rotation.x, armLeft.rotation.y, armLeft.rotation.z + armAngle - armAngleLeft )
            );
            armRight.rotation = Quaternion.Euler(
                new Vector3(armRight.rotation.x, armRight.rotation.y, armRight.rotation.z + armAngleRight - armAngle  )
            );
            
            hipLeft.rotation = Quaternion.Euler(
                new Vector3(hipLeft.rotation.x, hipLeft.rotation.y, hipLeft.rotation.z + hipAngle - hipAngleLeft )
            );
            hipRight.rotation = Quaternion.Euler(
                new Vector3(hipRight.rotation.x, hipRight.rotation.y, hipRight.rotation.z + hipAngleRight - hipAngle  )
            );
            
            var rotationMap = new Dictionary<Naming.BoneType, Quaternion>()
            {
                {Naming.BoneType.HipLeft, hipLeft.localRotation},
                {Naming.BoneType.HipRight, hipRight.localRotation},
                {Naming.BoneType.ShoulderLeft, armLeft.localRotation},
                {Naming.BoneType.ShoulderRight, armRight.localRotation}
            };

            hipLeft.rotation = hipLeftRotation;
            hipRight.rotation = hipRightRotation;
            armLeft.rotation = shoulderLeftRotation;
            armRight.rotation = shoulderRightRotation;
            return rotationMap;
            
        }
        
        SkeletonBone[] GetSkeletonBones()
        {
            var skeletonBones = new SkeletonBone[_bones.Count];
            var rotationMap = GetTPoseRotationMap();
            for (var x = 0; x < _bones.Count; x++)
            {
                var go = _bones[x];
                var boneType = Naming.BoneDictionary.ContainsKey(go.name) 
                    ? Naming.BoneDictionary[go.name] 
                    : Naming.BoneType.Generic;
                
                skeletonBones[x] = new SkeletonBone()
                {
                    name = go.name,
                    position = go.transform.localPosition,
                    rotation = rotationMap.ContainsKey(boneType)
                        ? rotationMap[boneType]
                        : go.transform.localRotation,
                    scale = go.transform.localScale
                    
                };
            }
            return skeletonBones;
        }

        public Avatar Create()
        {
            // check if it's a valid mecanim avatar
            var boneName = HumanTrait.BoneName;
            for (var x = 0; x < boneName.Length; x++)
            {
                if (!HumanTrait.RequiredBone(x)) continue;
                var requiredBoneType = Naming.MecanimNameToBoneType(boneName[x]);
                if (!_boneMapping.ContainsKey(requiredBoneType))
                    return AvatarBuilder.BuildGenericAvatar(_root, "");
            }
            
            var humanBones = new HumanBone[_boneMapping.Count];
            var skeletonBones = GetSkeletonBones();
            for (var x = 0; x < _boneMapping.Count; x++)
            {
                var item = _boneMapping.ElementAt(x);
                var boneType = item.Key;
                var go = item.Value;
                var mecanimBoneName = Naming.BoneTypeToMecanimName(boneType);
                if (mecanimBoneName == "default") 
                    mecanimBoneName = go.name;

                var humanBone = new HumanBone
                {
                    humanName = mecanimBoneName,
                    boneName = go.name,
                    limit = {useDefaultValues = true}
                };
                humanBones[x] = humanBone;
            }

            var humanDescription = new HumanDescription()
            {
                skeleton = skeletonBones,
                human = humanBones
            };
            
            return AvatarBuilder.BuildHumanAvatar(_root, humanDescription);
        }
    }
}
