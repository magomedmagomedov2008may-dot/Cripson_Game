#if UNITY_EDITOR
using UnityEditor;using UnityEditor.SceneManagement;using UnityEngine;using UnityEngine.SceneManagement;
[InitializeOnLoad]public static class AutoSceneSetup{static AutoSceneSetup(){EditorApplication.delayCall+=Run;}static void Run(){const string f="Assets/Scenes",p=f+"/Main.unity";if(!AssetDatabase.IsValidFolder(f))AssetDatabase.CreateFolder("Assets","Scenes");if(AssetDatabase.LoadAssetAtPath<SceneAsset>(p)==null){var s=EditorSceneManager.NewScene(NewSceneSetup.EmptyScene,NewSceneMode.Single);EditorSceneManager.SaveScene(s,p);}EditorBuildSettings.scenes=new[]{new EditorBuildSettingsScene(p,true)};}}
#endif
