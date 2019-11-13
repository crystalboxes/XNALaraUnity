using System;
using System.Runtime.InteropServices;
using System.Text;
using UnityEngine;

public static class XPSImporter
{

  public class StringHandle : SafeHandle
  {
    public StringHandle() : base(IntPtr.Zero, true) { }

    public override bool IsInvalid
    {
      get { return false; }
    }

    public string AsString()
    {
      int len = 0;
      while (Marshal.ReadByte(handle, len) != 0) { ++len; }
      byte[] buffer = new byte[len];
      Marshal.Copy(handle, buffer, 0, buffer.Length);
      return Encoding.UTF8.GetString(buffer);
    }

    protected override bool ReleaseHandle()
    {
      return true;
    }
  }

  public enum BoneNaming
  {
    Default,
    Mecanim,
  }

  [DllImport("xpsimport", EntryPoint = "xps_load_model")]
  public static extern IntPtr LoadModel(string filename, BoneNaming boneNaming, int flipUv, int ReverseWinding);

  [DllImport("xpsimport", EntryPoint = "xps_delete_model")]
  public static extern void DeleteModel(IntPtr model);

  [DllImport("xpsimport", EntryPoint = "xps_get_error")]
  public static extern byte GetError(IntPtr model);

  [DllImport("xpsimport", EntryPoint = "xps_get_mesh_count")]
  public static extern int GetMeshCount(IntPtr model);

  [DllImport("xpsimport", EntryPoint = "xps_get_mesh_index_count")]
  public static extern int GetMeshIndexCount(IntPtr model, int meshIndex);

  [DllImport("xpsimport", EntryPoint = "xps_get_mesh_index")]
  public static extern int GetMeshIndex(IntPtr model, int meshIndex, int indexNum);

  [DllImport("xpsimport", EntryPoint = "xps_get_bone_count")]
  public static extern int GetBoneCount(IntPtr model);

  [DllImport("xpsimport", EntryPoint = "xps_get_bone_name")]
  public static extern StringHandle GetBoneName(IntPtr model, int index);

  [DllImport("xpsimport", EntryPoint = "xps_get_bone_parent_id")]
  public static extern int GetBoneParentId(IntPtr model, int index);

  [DllImport("xpsimport", EntryPoint = "xps_get_bone_position")]
  public static extern Vector3 GetBonePosition(IntPtr model, int index);

  [DllImport("xpsimport", EntryPoint = "xps_get_mesh_name")]
  public static extern StringHandle GetMeshName(IntPtr model, int meshIndex);

  [DllImport("xpsimport", EntryPoint = "xps_get_uv_layers")]
  public static extern int GetUvLayers(IntPtr model, int meshIndex);

  [DllImport("xpsimport", EntryPoint = "xps_get_vertex_count")]
  public static extern int GetVertexCount(IntPtr model, int meshIndex);

  [DllImport("xpsimport", EntryPoint = "xps_get_texture_count")]
  public static extern int GetTextureCount(IntPtr model, int meshIndex);
  [DllImport("xpsimport", EntryPoint = "xps_get_texture_id")]
  public static extern int GetTextureId(IntPtr model, int meshIndex, int textureIndex);
  [DllImport("xpsimport", EntryPoint = "xps_get_texture_filename")]
  public static extern StringHandle GetTextureFilename(IntPtr model, int meshIndex, int textureIndex);
  [DllImport("xpsimport", EntryPoint = "xps_get_texture_uv_layer")]
  public static extern int GetTextureUvLayer(IntPtr model, int meshIndex, int textureIndex);

  [DllImport("xpsimport", EntryPoint = "xps_get_vertex_id")]
  public static extern int GetVertexId(IntPtr model, int meshIndex, int vertexIndex);

  [DllImport("xpsimport", EntryPoint = "xps_get_vertex_position")]
  public static extern Vector3 GetVertexPosition(IntPtr model, int meshIndex, int vertexIndex);

  [DllImport("xpsimport", EntryPoint = "xps_get_vertex_normal")]
  public static extern Vector3 GetVertexNormal(IntPtr model, int meshIndex, int vertexIndex);

  [DllImport("xpsimport", EntryPoint = "xps_get_vertex_color")]
  public static extern Color GetVertexColor(IntPtr model, int meshIndex, int vertexIndex);

  [DllImport("xpsimport", EntryPoint = "xps_get_vertex_uv")]
  public static extern Vector2 GetVertexUv(IntPtr model, int meshIndex, int vertexIndex, int layerId);

  [DllImport("xpsimport", EntryPoint = "xps_get_vertex_bone_index")]
  public static extern int GetVertexBoneIndex(IntPtr model, int meshIndex, int vertexIndex, int weightId);

  [DllImport("xpsimport", EntryPoint = "xps_get_vertex_bone_weight")]
  public static extern float GetVertexBoneWeight(IntPtr model, int meshIndex, int vertexIndex, int weightId);

  [DllImport("xpsimport", EntryPoint = "xps_get_render_group_alpha")]
  public static extern int GetRenderGroupAlpha(IntPtr model, int meshIndex);

  [DllImport("xpsimport", EntryPoint = "xps_get_render_group_posable")]
  public static extern int GetRenderGroupPosable(IntPtr model, int meshIndex);

  [DllImport("xpsimport", EntryPoint = "xps_get_render_group_bump1_rep")]
  public static extern int GetRenderGroupBump1Rep(IntPtr model, int meshIndex);

  [DllImport("xpsimport", EntryPoint = "xps_get_render_group_bump2_rep")]
  public static extern int GetRenderGroupBump2Rep(IntPtr model, int meshIndex);

  [DllImport("xpsimport", EntryPoint = "xps_get_render_group_spec1_rep")]
  public static extern int GetRenderGroupSpec1Rep(IntPtr model, int meshIndex);

  [DllImport("xpsimport", EntryPoint = "xps_get_render_group_texture_count")]
  public static extern int GetRenderGroupTextureCount(IntPtr model, int meshIndex);

  [DllImport("xpsimport", EntryPoint = "xps_get_render_group_texture_type")]
  public static extern StringHandle GetRenderGroupTextureType(IntPtr model, int meshIndex, int textureTypeIndex);
}
