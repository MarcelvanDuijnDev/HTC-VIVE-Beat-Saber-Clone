using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEditor;

public class FileConvertor : EditorWindow
{

    [MenuItem("Window/FileConvertor")]
    static void Init()
    {
        // Get existing open window or if none, make a new one:
        FileConvertor window = (FileConvertor)EditorWindow.GetWindow(typeof(FileConvertor));
        window.Show();
    }

    void OnGUI()
    {
        GUILayout.Label("Covert", EditorStyles.boldLabel);

        if (GUILayout.Button("Covert Object"))
        {
            ConvertTest();
        }
    }

    void ConvertTest()
    {
        string path = EditorUtility.SaveFilePanel("Save saber file", "", "Plasma_Katana" + ".saber", "saber");
        Debug.Log(path);

        
        if (path != "")
        {
            string fileName = Path.GetFileName(path);
            string folderPath = Path.GetDirectoryName(path);

            PrefabUtility.CreatePrefab("Assets/_CustomSaber.prefab", Selection.activeObject as GameObject);
            AssetBundleBuild assetBundleBuild = default(AssetBundleBuild);
            assetBundleBuild.assetNames = new string[] {
                            "Assets/_CustomSaber.prefab"
                        };

            assetBundleBuild.assetBundleName = fileName;

            BuildTargetGroup selectedBuildTargetGroup = EditorUserBuildSettings.selectedBuildTargetGroup;
            BuildTarget activeBuildTarget = EditorUserBuildSettings.activeBuildTarget;

            BuildPipeline.BuildAssetBundles(Application.temporaryCachePath, new AssetBundleBuild[] { assetBundleBuild }, 0, EditorUserBuildSettings.activeBuildTarget);
            EditorPrefs.SetString("currentBuildingAssetBundlePath", folderPath);
            EditorUserBuildSettings.SwitchActiveBuildTarget(selectedBuildTargetGroup, activeBuildTarget);
            AssetDatabase.DeleteAsset("Assets/_CustomSaber.prefab");
            File.Move(Application.temporaryCachePath + "/" + fileName, path);
            AssetDatabase.Refresh();
            EditorUtility.DisplayDialog("Exportation Successful!", "Exportation Successful!", "OK");
        }
        else
        {
            EditorUtility.DisplayDialog("Exportation Failed!", "Path is invalid.", "OK");
        }
        
    }

    /*
    void Testload()
    {
        string path = EditorUtility.SaveFilePanel("Save saber file", "", "Plasma_Katana" + ".saber", "saber");

        var newOb = AssetBundle.LoadFromFile(path);
        AssetBundle b;
        b.LoadAsset(path, newOb);
    }
    */
}
