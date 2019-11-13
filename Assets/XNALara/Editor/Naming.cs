using System.Collections.Generic;
using XNALara.Data;

namespace XNALara
{
    public static class Naming
    {
        public enum BoneType
        {
            Generic,
            Ground,
            Hips,
            SpineLower,
            SpineMiddle,
            SpineUpper,
            Neck,
            Head,
            CollarLeft,
            ShoulderLeft,
            ElbowLeft,
            HandLeft,
            ThumbLeft0,
            ThumbLeft1,
            ThumbLeft2,
            IndexLeft0,
            IndexLeft1,
            IndexLeft2,
            MiddleLeft0,
            MiddleLeft1,
            MiddleLeft2,
            RingLeft0,
            RingLeft1,
            RingLeft2,
            PinkyLeft0,
            PinkyLeft1,
            PinkyLeft2,
            CollarRight,
            ShoulderRight,
            ElbowRight,
            HandRight,
            ThumbRight0,
            ThumbRight1,
            ThumbRight2,
            IndexRight0,
            IndexRight1,
            IndexRight2,
            MiddleRight0,
            MiddleRight1,
            MiddleRight2,
            RingRight0,
            RingRight1,
            RingRight2,
            PinkyRight0,
            PinkyRight1,
            PinkyRight2,
            HipLeft,
            KneeLeft,
            FootLeft,
            ToeLeft,
            HipRight,
            KneeRight,
            FootRight,
            ToeRight,
            Jaw,
            EyelidLowerLeft,
            EyelidUpperLeft,
            EyeballLeft,
            MouthCornerLeft,
            EyebrowLeft0,
            EyebrowLeft1,
            EyebrowLeft2,
            EyelidLowerRight,
            EyelidUpperRight,
            EyeballRight,
            MouthCornerRight,
            EyebrowRight0,
            EyebrowRight1,
            EyebrowRight2,
            Pelvis
        }

        public static Dictionary<string, BoneType> BoneDictionary
        {
            get
            {
                var boneDictionary = new Dictionary<string, BoneType>();
                boneDictionary["root ground"] = BoneType.Ground;
                boneDictionary["root hips"] = BoneType.Hips;
                boneDictionary["pelvis"] = BoneType.Pelvis;
                boneDictionary["leg left thigh"] = BoneType.HipLeft;
                boneDictionary["leg left knee"] = BoneType.KneeLeft;
                boneDictionary["leg left ankle"] = BoneType.FootLeft;
                boneDictionary["leg left toes"] = BoneType.ToeLeft;
                boneDictionary["leg right thigh"] = BoneType.HipRight;
                boneDictionary["leg right knee"] = BoneType.KneeRight;
                boneDictionary["leg right ankle"] = BoneType.FootRight;
                boneDictionary["leg right toes"] = BoneType.ToeRight;
                boneDictionary["spine lower"] = BoneType.SpineLower;
                boneDictionary["spine middle"] = BoneType.SpineMiddle;
                boneDictionary["spine upper"] = BoneType.SpineUpper;
                boneDictionary["head neck lower"] = BoneType.Neck;
                boneDictionary["head neck upper"] = BoneType.Head;
                boneDictionary["head jaw"] = BoneType.Jaw;
                boneDictionary["head eyeball left"] = BoneType.EyeballLeft;
                boneDictionary["head eyeball right"] = BoneType.EyeballRight;
                boneDictionary["head eyelid upper right"] = BoneType.EyelidUpperRight;
                boneDictionary["head eyelid lower right"] = BoneType.EyelidLowerRight;
                boneDictionary["head eyelid upper left"] = BoneType.EyelidUpperLeft;
                boneDictionary["head eyelid lower left"] = BoneType.EyelidLowerLeft;
                boneDictionary["head eyelid right upper"] = BoneType.EyelidUpperRight;
                boneDictionary["head eyelid right lower"] = BoneType.EyelidLowerRight;
                boneDictionary["head eyelid left upper"] = BoneType.EyelidUpperLeft;
                boneDictionary["head eyelid left lower"] = BoneType.EyelidLowerLeft;
                boneDictionary["head eyebrow right a"] = BoneType.EyebrowRight0;
                boneDictionary["head eyebrow right b"] = BoneType.EyebrowRight1;
                boneDictionary["head eyebrow right c"] = BoneType.EyebrowRight2;
                boneDictionary["head eyebrow left a"] = BoneType.EyebrowLeft0;
                boneDictionary["head eyebrow left b"] = BoneType.EyebrowLeft1;
                boneDictionary["head eyebrow left c"] = BoneType.EyebrowLeft2;
                boneDictionary["head eyebrow right 1"] = BoneType.EyebrowRight0;
                boneDictionary["head eyebrow right 2"] = BoneType.EyebrowRight1;
                boneDictionary["head eyebrow right 3"] = BoneType.EyebrowRight2;
                boneDictionary["head eyebrow left 1"] = BoneType.EyebrowLeft0;
                boneDictionary["head eyebrow left 2"] = BoneType.EyebrowLeft1;
                boneDictionary["head eyebrow left 3"] = BoneType.EyebrowLeft2;
                boneDictionary["head mouth corner right"] = BoneType.MouthCornerRight;
                boneDictionary["head mouth corner left"] = BoneType.MouthCornerLeft;
                boneDictionary["arm left shoulder 1"] = BoneType.CollarLeft;
                boneDictionary["arm left shoulder 2"] = BoneType.ShoulderLeft;
                boneDictionary["arm left shoulder a"] = BoneType.CollarLeft;
                boneDictionary["arm left shoulder b"] = BoneType.ShoulderLeft;
                boneDictionary["arm left elbow"] = BoneType.ElbowLeft;
                boneDictionary["arm left wrist"] = BoneType.HandLeft;
                boneDictionary["arm left wirst"] = BoneType.HandLeft;
                boneDictionary["arm left finger 1a"] = BoneType.ThumbLeft0;
                boneDictionary["arm left finger 1b"] = BoneType.ThumbLeft1;
                boneDictionary["arm left finger 1c"] = BoneType.ThumbLeft2;
                boneDictionary["arm left finger 2a"] = BoneType.IndexLeft0;
                boneDictionary["arm left finger 2b"] = BoneType.IndexLeft1;
                boneDictionary["arm left finger 2c"] = BoneType.IndexLeft2;
                boneDictionary["arm left finger 3a"] = BoneType.MiddleLeft0;
                boneDictionary["arm left finger 3b"] = BoneType.MiddleLeft1;
                boneDictionary["arm left finger 3c"] = BoneType.MiddleLeft2;
                boneDictionary["arm left finger 4a"] = BoneType.RingLeft0;
                boneDictionary["arm left finger 4b"] = BoneType.RingLeft1;
                boneDictionary["arm left finger 4c"] = BoneType.RingLeft2;
                boneDictionary["arm left finger 5a"] = BoneType.PinkyLeft0;
                boneDictionary["arm left finger 5b"] = BoneType.PinkyLeft1;
                boneDictionary["arm left finger 5c"] = BoneType.PinkyLeft2;
                boneDictionary["arm right shoulder 1"] = BoneType.CollarRight;
                boneDictionary["arm right shoulder 2"] = BoneType.ShoulderRight;
                boneDictionary["arm right shoulder a"] = BoneType.CollarRight;
                boneDictionary["arm right shoulder b"] = BoneType.ShoulderRight;
                boneDictionary["arm right elbow"] = BoneType.ElbowRight;
                boneDictionary["arm right wrist"] = BoneType.HandRight;
                boneDictionary["arm right wirst"] = BoneType.HandRight;
                boneDictionary["arm right finger 1a"] = BoneType.ThumbRight0;
                boneDictionary["arm right finger 1b"] = BoneType.ThumbRight1;
                boneDictionary["arm right finger 1c"] = BoneType.ThumbRight2;
                boneDictionary["arm right finger 2a"] = BoneType.IndexRight0;
                boneDictionary["arm right finger 2b"] = BoneType.IndexRight1;
                boneDictionary["arm right finger 2c"] = BoneType.IndexRight2;
                boneDictionary["arm right finger 3a"] = BoneType.MiddleRight0;
                boneDictionary["arm right finger 3b"] = BoneType.MiddleRight1;
                boneDictionary["arm right finger 3c"] = BoneType.MiddleRight2;
                boneDictionary["arm right finger 4a"] = BoneType.RingRight0;
                boneDictionary["arm right finger 4b"] = BoneType.RingRight1;
                boneDictionary["arm right finger 4c"] = BoneType.RingRight2;
                boneDictionary["arm right finger 5a"] = BoneType.PinkyRight0;
                boneDictionary["arm right finger 5b"] = BoneType.PinkyRight1;
                boneDictionary["arm right finger 5c"] = BoneType.PinkyRight2;
                boneDictionary["mixamorig_Hips"] = BoneType.Hips;
                boneDictionary["mixamorig_Spine"] = BoneType.SpineLower;
                boneDictionary["mixamorig_Spine1"] = BoneType.SpineMiddle;
                boneDictionary["mixamorig_Spine2"] = BoneType.SpineUpper;
                boneDictionary["mixamorig_Neck"] = BoneType.Neck;
                boneDictionary["mixamorig_Head"] = BoneType.Head;
                boneDictionary["mixamorig_LeftShoulder"] = BoneType.CollarLeft;
                boneDictionary["mixamorig_LeftArm"] = BoneType.ShoulderLeft;
                boneDictionary["mixamorig_LeftForeArm"] = BoneType.ElbowLeft;
                boneDictionary["mixamorig_LeftHand"] = BoneType.HandLeft;
                boneDictionary["mixamorig_LeftHandThumb1"] = BoneType.ThumbLeft0;
                boneDictionary["mixamorig_LeftHandThumb2"] = BoneType.ThumbLeft1;
                boneDictionary["mixamorig_LeftHandThumb3"] = BoneType.ThumbLeft2;
                boneDictionary["mixamorig_LeftHandIndex1"] = BoneType.IndexLeft0;
                boneDictionary["mixamorig_LeftHandIndex2"] = BoneType.IndexLeft1;
                boneDictionary["mixamorig_LeftHandIndex3"] = BoneType.IndexLeft2;
                boneDictionary["mixamorig_LeftHandMiddle1"] = BoneType.MiddleLeft0;
                boneDictionary["mixamorig_LeftHandMiddle2"] = BoneType.MiddleLeft1;
                boneDictionary["mixamorig_LeftHandMiddle3"] = BoneType.MiddleLeft2;
                boneDictionary["mixamorig_LeftHandRing1"] = BoneType.RingLeft0;
                boneDictionary["mixamorig_LeftHandRing2"] = BoneType.RingLeft1;
                boneDictionary["mixamorig_LeftHandRing3"] = BoneType.RingLeft2;
                boneDictionary["mixamorig_LeftHandPinky1"] = BoneType.PinkyLeft0;
                boneDictionary["mixamorig_LeftHandPinky2"] = BoneType.PinkyLeft1;
                boneDictionary["mixamorig_LeftHandPinky3"] = BoneType.PinkyLeft2;
                boneDictionary["mixamorig_RightShoulder"] = BoneType.CollarRight;
                boneDictionary["mixamorig_RightArm"] = BoneType.ShoulderRight;
                boneDictionary["mixamorig_RightForeArm"] = BoneType.ElbowRight;
                boneDictionary["mixamorig_RightHand"] = BoneType.HandRight;
                boneDictionary["mixamorig_RightHandThumb1"] = BoneType.ThumbRight0;
                boneDictionary["mixamorig_RightHandThumb2"] = BoneType.ThumbRight1;
                boneDictionary["mixamorig_RightHandThumb3"] = BoneType.ThumbRight2;
                boneDictionary["mixamorig_RightHandIndex1"] = BoneType.IndexRight0;
                boneDictionary["mixamorig_RightHandIndex2"] = BoneType.IndexRight1;
                boneDictionary["mixamorig_RightHandIndex3"] = BoneType.IndexRight2;
                boneDictionary["mixamorig_RightHandMiddle1"] = BoneType.MiddleRight0;
                boneDictionary["mixamorig_RightHandMiddle2"] = BoneType.MiddleRight1;
                boneDictionary["mixamorig_RightHandMiddle3"] = BoneType.MiddleRight2;
                boneDictionary["mixamorig_RightHandRing1"] = BoneType.RingRight0;
                boneDictionary["mixamorig_RightHandRing2"] = BoneType.RingRight1;
                boneDictionary["mixamorig_RightHandRing3"] = BoneType.RingRight2;
                boneDictionary["mixamorig_RightHandPinky1"] = BoneType.PinkyRight0;
                boneDictionary["mixamorig_RightHandPinky2"] = BoneType.PinkyRight1;
                boneDictionary["mixamorig_RightHandPinky3"] = BoneType.PinkyRight2;
                boneDictionary["mixamorig_LeftUpLeg"] = BoneType.HipLeft;
                boneDictionary["mixamorig_LeftLeg"] = BoneType.KneeLeft;
                boneDictionary["mixamorig_LeftFoot"] = BoneType.FootLeft;
                boneDictionary["mixamorig_LeftToeBase"] = BoneType.ToeLeft;
                boneDictionary["mixamorig_RightUpLeg"] = BoneType.HipRight;
                boneDictionary["mixamorig_RightLeg"] = BoneType.KneeRight;
                boneDictionary["mixamorig_RightFoot"] = BoneType.FootRight;
                boneDictionary["mixamorig_RightToeBase"] = BoneType.ToeRight;
                boneDictionary["Genesis"] = BoneType.Ground;
                boneDictionary["hip"] = BoneType.Hips;
                boneDictionary["lThigh"] = BoneType.HipLeft;
                boneDictionary["lShin"] = BoneType.KneeLeft;
                boneDictionary["lFoot"] = BoneType.FootLeft;
                boneDictionary["lToe"] = BoneType.ToeLeft;
                boneDictionary["rThigh"] = BoneType.HipRight;
                boneDictionary["rShin"] = BoneType.KneeRight;
                boneDictionary["rFoot"] = BoneType.FootRight;
                boneDictionary["rToe"] = BoneType.ToeRight;
                boneDictionary["abdomen"] = BoneType.SpineLower;
                boneDictionary["abdomen2"] = BoneType.SpineMiddle;
                boneDictionary["chest"] = BoneType.SpineUpper;
                boneDictionary["neck"] = BoneType.Neck;
                boneDictionary["head"] = BoneType.Head;
                boneDictionary["rEye"] = BoneType.EyeballRight;
                boneDictionary["lEye"] = BoneType.EyeballRight;
                boneDictionary["upperJaw"] = BoneType.Jaw;
                boneDictionary["rCollar"] = BoneType.CollarRight;
                boneDictionary["rShldr"] = BoneType.ShoulderRight;
                boneDictionary["rForeArm"] = BoneType.ElbowRight;
                boneDictionary["rHand"] = BoneType.HandRight;
                boneDictionary["rThumb1"] = BoneType.ThumbRight0;
                boneDictionary["rThumb2"] = BoneType.ThumbRight1;
                boneDictionary["rThumb3"] = BoneType.ThumbRight2;
                boneDictionary["rIndex1"] = BoneType.IndexRight0;
                boneDictionary["rIndex2"] = BoneType.IndexRight1;
                boneDictionary["rIndex3"] = BoneType.IndexRight2;
                boneDictionary["rMid1"] = BoneType.MiddleRight0;
                boneDictionary["rMid2"] = BoneType.MiddleRight1;
                boneDictionary["rMid3"] = BoneType.MiddleRight2;
                boneDictionary["rRing1"] = BoneType.RingRight0;
                boneDictionary["rRing2"] = BoneType.RingRight1;
                boneDictionary["rRing3"] = BoneType.RingRight2;
                boneDictionary["rPinky1"] = BoneType.PinkyRight0;
                boneDictionary["rPinky2"] = BoneType.PinkyRight1;
                boneDictionary["rPinky3"] = BoneType.PinkyRight2;
                boneDictionary["lCollar"] = BoneType.CollarLeft;
                boneDictionary["lShldr"] = BoneType.ShoulderLeft;
                boneDictionary["lForeArm"] = BoneType.ElbowLeft;
                boneDictionary["lHand"] = BoneType.HandLeft;
                boneDictionary["lThumb1"] = BoneType.ThumbLeft0;
                boneDictionary["lThumb2"] = BoneType.ThumbLeft1;
                boneDictionary["lThumb3"] = BoneType.ThumbLeft2;
                boneDictionary["lIndex1"] = BoneType.IndexLeft0;
                boneDictionary["lIndex2"] = BoneType.IndexLeft1;
                boneDictionary["lIndex3"] = BoneType.IndexLeft2;
                boneDictionary["lMid1"] = BoneType.MiddleLeft0;
                boneDictionary["lMid2"] = BoneType.MiddleLeft1;
                boneDictionary["lMid3"] = BoneType.MiddleLeft2;
                boneDictionary["lRing1"] = BoneType.RingLeft0;
                boneDictionary["lRing2"] = BoneType.RingLeft1;
                boneDictionary["lRing3"] = BoneType.RingLeft2;
                boneDictionary["lPinky1"] = BoneType.PinkyLeft0;
                boneDictionary["lPinky2"] = BoneType.PinkyLeft1;
                boneDictionary["lPinky3"] = BoneType.PinkyLeft2;
                boneDictionary["rShldrBend"] = BoneType.ShoulderRight;
                boneDictionary["rForearmBend"] = BoneType.ElbowRight;
                boneDictionary["rThighBend"] = BoneType.HipRight;
                boneDictionary["lShldrBend"] = BoneType.ShoulderLeft;
                boneDictionary["lForearmBend"] = BoneType.ElbowLeft;
                boneDictionary["lThighBend"] = BoneType.HipLeft;
                boneDictionary["abdomenLower"] = BoneType.SpineLower;
                boneDictionary["abdomenUpper"] = BoneType.SpineMiddle;
                boneDictionary["chestLower"] = BoneType.SpineUpper;
                boneDictionary["neckLower"] = BoneType.Neck;
                boneDictionary["Hips"] = BoneType.Hips;
                boneDictionary["Chest"] = BoneType.SpineLower;
                boneDictionary["Chest2"] = BoneType.SpineMiddle;
                boneDictionary["Chest3"] = BoneType.SpineUpper;
                boneDictionary["Neck"] = BoneType.Neck;
                boneDictionary["Head"] = BoneType.Head;
                boneDictionary["LeftCollar"] = BoneType.CollarLeft;
                boneDictionary["LeftShoulder"] = BoneType.ShoulderLeft;
                boneDictionary["LeftElbow"] = BoneType.ElbowLeft;
                boneDictionary["LeftHand"] = BoneType.HandLeft;
                boneDictionary["LeftFinger0"] = BoneType.ThumbLeft0;
                boneDictionary["LeftFinger01"] = BoneType.ThumbLeft1;
                boneDictionary["LeftFinger1"] = BoneType.IndexLeft0;
                boneDictionary["LeftFinger11"] = BoneType.IndexLeft1;
                boneDictionary["RightCollar"] = BoneType.CollarRight;
                boneDictionary["RightShoulder"] = BoneType.ShoulderRight;
                boneDictionary["RightElbow"] = BoneType.ElbowRight;
                boneDictionary["RightHand"] = BoneType.HandRight;
                boneDictionary["RightFinger0"] = BoneType.ThumbRight0;
                boneDictionary["RightFinger01"] = BoneType.ThumbRight1;
                boneDictionary["RightFinger1"] = BoneType.IndexRight0;
                boneDictionary["RightFinger11"] = BoneType.IndexRight1;
                boneDictionary["LeftHip"] = BoneType.HipLeft;
                boneDictionary["LeftKnee"] = BoneType.KneeLeft;
                boneDictionary["LeftAnkle"] = BoneType.FootLeft;
                boneDictionary["LeftToe"] = BoneType.ToeLeft;
                boneDictionary["RightHip"] = BoneType.HipRight;
                boneDictionary["RightKnee"] = BoneType.KneeRight;
                boneDictionary["RightAnkle"] = BoneType.FootRight;
                boneDictionary["RightToe"] = BoneType.ToeRight;
                return boneDictionary;
            }
        }
        
        public static BoneType MecanimNameToBoneType(string mecanimName)
        {
            switch (mecanimName)
            {
                case "Hips": return BoneType.Hips;
                case "LeftUpperLeg": return BoneType.HipLeft;
                case "LeftLowerLeg": return BoneType.KneeLeft;
                case "LeftFoot": return BoneType.FootLeft;
                case "LeftToes": return BoneType.ToeLeft;
                case "RightUpperLeg": return BoneType.HipRight;
                case "RightLowerLeg": return BoneType.KneeRight;
                case "RightFoot": return BoneType.FootRight;
                case "RightToes": return BoneType.ToeRight;
                case "Spine": return BoneType.SpineLower;
                case "Chest": return BoneType.SpineMiddle;
                case "UpperChest": return BoneType.SpineUpper;
                case "Neck": return BoneType.Neck;
                case "Head": return BoneType.Head;
                case "Jaw": return BoneType.Jaw;
                case "LeftEye": return BoneType.EyeballLeft;
                case "RightEye": return BoneType.EyeballRight;
                case "LeftShoulder": return BoneType.CollarLeft;
                case "LeftUpperArm": return BoneType.ShoulderLeft;
                case "LeftLowerArm": return BoneType.ElbowLeft;
                case "LeftHand": return BoneType.HandLeft;
                case "Left Thumb Proximal": return BoneType.ThumbLeft0;
                case "Left Thumb Intermediate": return BoneType.ThumbLeft1;
                case "Left Thumb Distal": return BoneType.ThumbLeft2;
                case "Left Index Proximal": return BoneType.IndexLeft0;
                case "Left Index Intermediate": return BoneType.IndexLeft1;
                case "Left Index Distal": return BoneType.IndexLeft2;
                case "Left Middle Proximal": return BoneType.MiddleLeft0;
                case "Left Middle Intermediate": return BoneType.MiddleLeft1;
                case "Left Middle Distal": return BoneType.MiddleLeft2;
                case "Left Ring Proximal": return BoneType.RingLeft0;
                case "Left Ring Intermediate": return BoneType.RingLeft1;
                case "Left Ring Distal": return BoneType.RingLeft2;
                case "Left Little Proximal": return BoneType.PinkyLeft0;
                case "Left Little Intermediate": return BoneType.PinkyLeft1;
                case "Left Little Distal": return BoneType.PinkyLeft2;
                case "RightShoulder": return BoneType.CollarRight;
                case "RightUpperArm": return BoneType.ShoulderRight;
                case "RightLowerArm": return BoneType.ElbowRight;
                case "RightHand": return BoneType.HandRight;
                case "Right Thumb Proximal": return BoneType.ThumbRight0;
                case "Right Thumb Intermediate": return BoneType.ThumbRight1;
                case "Right Thumb Distal": return BoneType.ThumbRight2;
                case "Right Index Proximal": return BoneType.IndexRight0;
                case "Right Index Intermediate": return BoneType.IndexRight1;
                case "Right Index Distal": return BoneType.IndexRight2;
                case "Right Middle Proximal": return BoneType.MiddleRight0;
                case "Right Middle Intermediate": return BoneType.MiddleRight1;
                case "Right Middle Distal": return BoneType.MiddleRight2;
                case "Right Ring Proximal": return BoneType.RingRight0;
                case "Right Ring Intermediate": return BoneType.RingRight1;
                case "Right Ring Distal": return BoneType.RingRight2;
                case "Right Little Proximal": return BoneType.PinkyRight0;
                case "Right Little Intermediate": return BoneType.PinkyRight1;
                case "Right Little Distal": return BoneType.PinkyRight2;
                default: return BoneType.Generic;
            }
        }

        public static string BoneTypeToMecanimName(BoneType boneType)
        {
            switch (boneType)
            {
                case BoneType.Hips: return "Hips";
                case BoneType.HipLeft: return "LeftUpperLeg";
                case BoneType.KneeLeft: return "LeftLowerLeg";
                case BoneType.FootLeft: return "LeftFoot";
                case BoneType.ToeLeft: return "LeftToes";
                
                case BoneType.HipRight: return "RightUpperLeg";
                case BoneType.KneeRight: return "RightLowerLeg";
                case BoneType.FootRight: return "RightFoot";
                case BoneType.ToeRight: return "RightToes";
                
                case BoneType.SpineLower: return "Spine";
                case BoneType.SpineMiddle: return "Chest";
                case BoneType.SpineUpper: return "UpperChest";
                
                case BoneType.Neck: return "Neck";
                case BoneType.Head: return "Head";
                case BoneType.Jaw: return "Jaw";
                
                case BoneType.EyeballLeft: return "LeftEye";
                case BoneType.EyeballRight: return "RightEye";
                
                case BoneType.CollarLeft: return "LeftShoulder";
                case BoneType.ShoulderLeft: return "LeftUpperArm";
                case BoneType.ElbowLeft: return "LeftLowerArm";
                case BoneType.HandLeft: return "LeftHand";
                
                case BoneType.ThumbLeft0: return "Left Thumb Proximal";
                case BoneType.ThumbLeft1: return "Left Thumb Intermediate";
                case BoneType.ThumbLeft2: return "Left Thumb Distal";
                case BoneType.IndexLeft0: return "Left Index Proximal";
                case BoneType.IndexLeft1: return "Left Index Intermediate";
                case BoneType.IndexLeft2: return "Left Index Distal";
                case BoneType.MiddleLeft0: return "Left Middle Proximal";
                case BoneType.MiddleLeft1: return "Left Middle Intermediate";
                case BoneType.MiddleLeft2: return "Left Middle Distal";
                case BoneType.RingLeft0: return "Left Ring Proximal";
                case BoneType.RingLeft1: return "Left Ring Intermediate";
                case BoneType.RingLeft2: return "Left Ring Distal";
                case BoneType.PinkyLeft0: return "Left Little Proximal";
                case BoneType.PinkyLeft1: return "Left Little Intermediate";
                case BoneType.PinkyLeft2: return "Left Little Distal";
                
                case BoneType.CollarRight: return "RightShoulder";
                case BoneType.ShoulderRight: return "RightUpperArm";
                case BoneType.ElbowRight: return "RightLowerArm";
                case BoneType.HandRight: return "RightHand";
                
                case BoneType.ThumbRight0: return "Right Thumb Proximal";
                case BoneType.ThumbRight1: return "Right Thumb Intermediate";
                case BoneType.ThumbRight2: return "Right Thumb Distal";
                case BoneType.IndexRight0: return "Right Index Proximal";
                case BoneType.IndexRight1: return "Right Index Intermediate";
                case BoneType.IndexRight2: return "Right Index Distal";
                case BoneType.MiddleRight0: return "Right Middle Proximal";
                case BoneType.MiddleRight1: return "Right Middle Intermediate";
                case BoneType.MiddleRight2: return "Right Middle Distal";
                case BoneType.RingRight0: return "Right Ring Proximal";
                case BoneType.RingRight1: return "Right Ring Intermediate";
                case BoneType.RingRight2: return "Right Ring Distal";
                case BoneType.PinkyRight0: return "Right Little Proximal";
                case BoneType.PinkyRight1: return "Right Little Intermediate";
                case BoneType.PinkyRight2: return "Right Little Distal";
                
                default: return "default";
            }
        }

    }
}