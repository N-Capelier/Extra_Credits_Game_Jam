#if UNITY_EDITOR

using UnityEditor;
using UnityEngine;

namespace UTPI.BuildPacks
{
    [CreateAssetMenu(fileName = "new Build Pack", menuName ="Build Pack", order = 201)]
    public class BuildPack : ScriptableObject
    {
        [System.Serializable]
        public struct SceneToBuild
        {
            public SceneAsset sceneAsset;
            public bool enabled;
        }

        public SceneToBuild[] scenesToBuild;

        public void SetToBuildSettings()
        {
            EditorBuildSettingsScene[] newScenes = new EditorBuildSettingsScene[scenesToBuild.Length];

            for (int i = 0; i < scenesToBuild.Length; i++)
            {
                string scenePath = AssetDatabase.GetAssetPath(scenesToBuild[i].sceneAsset);
                newScenes[i] = new EditorBuildSettingsScene(scenePath, scenesToBuild[i].enabled);
            }

            EditorBuildSettings.scenes = newScenes;
        }

        public void GetBuildSettingsScenes()
        {
            scenesToBuild = new SceneToBuild[EditorBuildSettings.scenes.Length];

            for (int i = 0; i < scenesToBuild.Length; i++)
            {
                scenesToBuild[i] = new SceneToBuild();
                scenesToBuild[i].sceneAsset = AssetDatabase.LoadAssetAtPath<SceneAsset>(EditorBuildSettings.scenes[i].path);
                scenesToBuild[i].enabled = EditorBuildSettings.scenes[i].enabled;
            }
        }

        public void SetEnabling(bool enabling)
        {
            for (int i = 0; i < scenesToBuild.Length; i++)
            {
                scenesToBuild[i].enabled = enabling;
            }
        }
    }
}
#endif