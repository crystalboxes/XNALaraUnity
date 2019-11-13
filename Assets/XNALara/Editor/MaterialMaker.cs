using UnityEngine;

namespace XNALara
{
    public class MaterialMaker
    {
        enum Pipeline { Default, Legacy, LWRP, HDRP }
        enum TextureType { Diffuse, Normal, Specular, Emission, Unsupported }
        
        public Material Material { get; private set; }
        bool _alpha;
        readonly Data.Texture[] _textures;
        readonly TextureType[] _textureTypes;
        Pipeline _pipeline = Pipeline.Default;

        public MaterialMaker(Data.Texture[] textures, RenderGroup renderGroup)
        {
            _textures = textures;
            _alpha = renderGroup.Alpha;
            _textureTypes = new TextureType[renderGroup.TextureTypes.Length];
            for (var x = 0; x < _textureTypes.Length; x++)
            {
                switch (renderGroup.TextureTypes[x])
                {
                    case "diffuse": _textureTypes[x] = TextureType.Diffuse;
                        break;
                    case "bumpmap": _textureTypes[x] = TextureType.Normal;
                        break;
                    case "specular": _textureTypes[x] = TextureType.Specular;
                        break;
                    case "emission": _textureTypes[x] = TextureType.Emission;
                        break;
                    default: _textureTypes[x] = TextureType.Unsupported;
                        break;
                }
            }

            CheckRenderPipeline();
            Material = new Material(GetShader());
            HandleAlpha();
            SetTextures();
            // Stupid unity editor limitation. 
            SetKeywords();
        }

        void SetKeywords()
        {
            if (_pipeline == Pipeline.Legacy)
                MaterialKeywords.StandardShader.SetMaterialKeywords(Material, MaterialKeywords.WorkflowMode.Specular);
            else if (_pipeline == Pipeline.LWRP)
                MaterialKeywords.LWRP.SetMaterialKeywords(Material);
        }

        void SetTextures()
        {
            Material.SetFloat("_Glossiness", .5f);
            Material.SetFloat("_GlossMapScale", .5f);
            switch (_pipeline)
            {
                case Pipeline.LWRP:
                    Material.SetFloat("_WorkflowMode", 1f);
                    break;
                case Pipeline.HDRP:
                    Material.SetFloat("_MaterialID", 4f);
                    break;
            }

            for (var x = 0; x < Mathf.Min(_textures.Length, _textureTypes.Length); x++)
            {
                var texture = _textures[x];
                switch (_textureTypes[x])
                {
                    /*
                     * LWRP / Legacy
                     * _MainTex
                     * _BumpMap
                     * _SpecGlossMap
                     * _EmissionMap
                     */
                    
                    /*
                     * HDRP
                     * _BaseColor
                     * _NormalMap
                     * _SpecularColorMap
                     * _EmissiveColorMap
                     */
                    
                    case TextureType.Diffuse:
                        Material.SetTexture(_pipeline == Pipeline.HDRP ? 
                            "_BaseColor" : "_MainTex", texture.Texture2D);
                        break;
                    case TextureType.Normal:
                        Material.SetTexture(_pipeline == Pipeline.HDRP ? 
                            "_NormalMap" : "_BumpMap", texture.Texture2D);
                        break;
                    case TextureType.Specular:
                        Material.SetTexture(_pipeline == Pipeline.HDRP ? 
                            "_SpecularColorMap" : "_SpecGlossMap", texture.Texture2D);
                        break;
                    case TextureType.Emission:
                        Material.SetTexture(_pipeline == Pipeline.HDRP ? 
                            "_EmissiveColorMap" : "_EmissionMap", texture.Texture2D);
                        break;
                }
            }
        }

        void HandleAlpha()
        {
            switch (_pipeline)
            {
                case Pipeline.HDRP:
                    Material.SetFloat("_SurfaceType", _alpha ? 1f : 0f);
                    break;
                case Pipeline.LWRP:
                    Material.SetFloat("_Surface", _alpha ? 1f : 0f);
                    break;
                case Pipeline.Legacy:
                    Material.SetFloat("_Mode", _alpha ? 2f : 0f);
                    break;
            }
        }

        void CheckRenderPipeline()
        {
            if (GetShader(Pipeline.LWRP) != null)
                _pipeline = Pipeline.LWRP;
            else if (GetShader(Pipeline.HDRP) != null)
                _pipeline = Pipeline.HDRP;
            else
                _pipeline = Pipeline.Legacy;
        }

        Shader GetShader(Pipeline pipeline = Pipeline.Default)
        {
            string shaderName;
            if (pipeline == Pipeline.Default) 
                pipeline = _pipeline;
            
            switch (pipeline)
            {
                case Pipeline.HDRP:
                    shaderName = "HDRenderPipeline/Lit";
                    break;
                case Pipeline.LWRP:
                    shaderName = "LightweightPipeline/Standard (Physically Based)";
                    break;
                default:
                    shaderName = "Standard (Specular setup)";
                    break;
            }
            return Shader.Find(shaderName);
        }
    }
}