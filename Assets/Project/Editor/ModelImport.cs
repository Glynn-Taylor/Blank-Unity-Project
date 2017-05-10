using UnityEngine;
using UnityEditor;
using System;

public class ModelImport : AssetPostprocessor
{
     public void OnPreprocessModel()
    {
        // Apple settings to all atlases
        
        ModelImporter importer = assetImporter as ModelImporter;
        String name = importer.assetPath.ToLower();
        if (assetPath.Contains(".blend") || assetPath.Contains(".fbx"))
        {
			Debug.Log("Processing model");
            importer.globalScale = 1.0F;
            //importer.importAnimation = false;
            //importer.animationType = ModelImporterAnimationType.None;
            //importer.importBlendShapes = false;
            importer.generateSecondaryUV = true;
            //importer.importNormals = ModelImporterNormals.Calculate;
            //importer.normalSmoothingAngle = 30;
            
            importer.importMaterials = false;
            //importer.materialName = ModelImporterMaterialName.BasedOnMaterialName;
            //importer.materialSearch = ModelImporterMaterialSearch.Everywhere;
        }
    }
    /*public Material OnAssignMaterialModel(Material material, Renderer renderer)  {
        string materialPath = "Assets/Foxtree/Materials/Mat.ShaderTest.VertexColor.mat";

        // Find if there is a material at the material path
        // Turn this off to always regeneration materials
        if (AssetDatabase.LoadAssetAtPath(materialPath, typeof(Material)))
            return AssetDatabase.LoadAssetAtPath(materialPath, typeof(Material)) as Material;

        Debug.LogError("[ModelImport] Could not find default material!!!");
        // Create a new material asset using the specular shader
        // but otherwise the default values from the model
        //material.shader = Shader.Find("Unlit/FoxtreeToon");
        //AssetDatabase.CreateAsset(material, "Assets/" + material.name + ".mat");
        return material;
    }*/
}