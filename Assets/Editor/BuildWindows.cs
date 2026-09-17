#if UNITY_EDITOR
using System.IO;
using UnityEditor;
using UnityEditor.Build.Reporting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor.SceneManagement;

public static class BuildWindows
{
    public static void PerformBuild()
    {
        const string sceneFolder = "Assets/Scenes";
        const string scenePath = sceneFolder + "/Main.unity";
        const string output = "build/Windows/ChunkWars.exe";

        if (!AssetDatabase.IsValidFolder(sceneFolder))
            AssetDatabase.CreateFolder("Assets", "Scenes");

        if (!File.Exists(scenePath))
        {
            Scene scene = EditorSceneManager.NewScene(NewSceneSetup.EmptyScene, NewSceneMode.Single);
            EditorSceneManager.SaveScene(scene, scenePath);
        }

        Directory.CreateDirectory(Path.GetDirectoryName(output));
        var options = new BuildPlayerOptions
        {
            scenes = new[] { scenePath },
            locationPathName = output,
            target = BuildTarget.StandaloneWindows64,
            options = BuildOptions.None
        };

        BuildReport report = BuildPipeline.BuildPlayer(options);
        if (report.summary.result != BuildResult.Succeeded)
            throw new System.Exception("Windows build failed: " + report.summary.result);

        Debug.Log("Windows build created: " + output);
    }
}
#endif
