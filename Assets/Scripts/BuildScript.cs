using UnityEditor;
using UnityEditor.Build.Reporting;
using UnityEngine;
using System;

public class BuildScript
{
    public static string[] levels = new string[] {
        "Assets/Scenes/MainMenu.unity", 
        "Assets/Scenes/Levels/Level1.unity", 
        "Assets/Scenes/Levels/Level2.unity", 
        "Assets/Scenes/Levels/Level3.unity", 
        "Assets/Scenes/Ending.unity"
    };

    [MenuItem("Build/Windows")]
    public static void BuildWindows() {
        //string path = EditorUtility.SaveFolderPanel("Choose Location of Built Game", "", "");
        BuildReport report = BuildPipeline.BuildPlayer(
            levels, 
            "Builds/Windows/K-PopSimulator.exe", 
            BuildTarget.StandaloneWindows, 
            BuildOptions.None
        );
        Debug.Log(report.summary.result + " " + report.summary.totalErrors);
        // DirectoryInfo newDataFolder = Directory.CreateDirectory(path);
        // DirectoryInfo newEdgeFolder = Directory.CreateDirectory(path);
        // FileUtil.MoveFileOrDirectory(path + "/K-PopSimulator_Data", newDataFolder.FullName);
        // FileUtil.MoveFileOrDirectory(path + "/MonoBleedingEdge", newEdgeFolder.FullName);
    }

    [MenuItem("Build/MacOS")]
    public static void BuildMacOS() {
        BuildReport report = BuildPipeline.BuildPlayer(
            levels,
            "Builds/Mac/K-PopSimulator.app",
            BuildTarget.StandaloneOSX,
            BuildOptions.None
        );
        Debug.Log(report.summary.result + " " + report.summary.totalErrors);
    }
}
