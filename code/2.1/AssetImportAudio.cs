/*
 *  Written by James Leahy. (c) 2018 DeFunc Art.
 *  https://github.com/defuncart/
 */
#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;

namespace AssetImport1
{
    /// <summary>An editor script which listens to import events.</summary>
    public class MyAssetPostprocessor : AssetPostprocessor
    {
        /// <summary>Callback before an audio clip is imported.</summary>
        private void OnPreprocessAudio()
        {
            AudioImporter audioImporter = assetImporter as AudioImporter;
            audioImporter.forceToMono = true;
            audioImporter.preloadAudioData = false;
            AudioImporterSampleSettings settings = new AudioImporterSampleSettings()
            {
                loadType = AudioClipLoadType.DecompressOnLoad,
                compressionFormat = AudioCompressionFormat.Vorbis,
                quality = 0,
                sampleRateSetting = AudioSampleRateSetting.OverrideSampleRate,
                sampleRateOverride = 22050
            };
            audioImporter.defaultSampleSettings = settings;
        }
    }
}
#endif