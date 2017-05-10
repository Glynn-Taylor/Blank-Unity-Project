using UnityEngine;
using UnityEditor;
using System;

public class TextureImport: AssetPostprocessor
{
    void OnPreprocessTexture()
    {
        
        TextureImporter importer = assetImporter as TextureImporter;
        String name = importer.assetPath.ToLower();
        Debug.Log("Importing texture: '"+name+"'");
        if (assetPath.ToLower().Contains("icon.") || assetPath.ToLower().Contains("ui."))
        {
            importer.textureType = TextureImporterType.Sprite;
        }
    }
}