/*
 *  Written by James Leahy. (c) 2018 DeFunc Art.
 *  https://github.com/defuncart/
 */
#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;

namespace AssetImport2
{
    /// <summary>An editor script which listens to import events.</summary>
    public class MyAssetPostprocessor : AssetPostprocessor
    {
        /// <summary>Callback after a texture of sprites has completed importing.</summary>
        /// <param name="texture">The texture.</param>
        /// <param name="sprites">The array of sprites.</param>
        private void OnPostprocessSprites(Texture2D texture, Sprite[] sprites)
        {
            if(System.IO.Path.GetDirectoryName(assetPath) == "Assets/Sprites/UI")
            {
                TextureImporter textureImporter = assetImporter as TextureImporter;
                textureImporter.textureCompression = TextureImporterCompression.CompressedHQ;
                textureImporter.crunchedCompression = true;
                textureImporter.compressionQuality = 100;
            }
        }
    }
}
#endif