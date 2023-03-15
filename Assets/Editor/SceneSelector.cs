using System.IO;
using System.Linq;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;

public class SceneSelector : Editor
{
    //TODO: Paste your favorite Scene Folder here!
    private const string scenePath = "Assets/Scenes";

    [MenuItem("Window/Scene Selector/Enable")]
    public static void Enable()
    {
        SceneView.duringSceneGui += OnScene;
    }

    [MenuItem("Window/Scene Selector/Disable")]
    public static void Disable()
    {
        SceneView.duringSceneGui -= OnScene;
    }

    private static void OnScene(SceneView sceneview)
    {
        Handles.BeginGUI();
        if (GUI.Button(new Rect(10, 10, 80, 25), "Scenes"))
        {
            var guids = AssetDatabase.FindAssets("t:scene", new[] { scenePath });
            var scenes = guids.Select(x => AssetDatabase.GUIDToAssetPath(x));
            scenes.OrderBy(x => x);

            GenericMenu menu = new GenericMenu();
            var currentPath = "";
            foreach (var scene in scenes)
            {
                var sceneDir = Path.GetDirectoryName(scene);

                if (currentPath != sceneDir)
                {
                    menu.AddSeparator("");
                    currentPath = sceneDir;
                }

                var sceneName = Path.GetFileNameWithoutExtension(scene);
                menu.AddItem(new GUIContent(sceneName), false, OnSceneSelect, scene);
            }
            menu.ShowAsContext();
        }
        Handles.EndGUI();
    }

    private static void OnSceneSelect(object scenePath)
    {
        var path = (string)scenePath;
        if (Application.isPlaying)
            EditorSceneManager.LoadScene(path);
        else
            EditorSceneManager.OpenScene(path, OpenSceneMode.Single);
    }
}