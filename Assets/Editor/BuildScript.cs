using UnityEditor;
using UnityEngine;
using System.IO;
using System.IO.Compression;
using System.Diagnostics;

public class BuildScript
{
    public static string[] levels = new string[] {
        "Assets/Scenes/MainMenu.unity", 
        "Assets/Scenes/Levels/Level1.unity", 
        "Assets/Scenes/Levels/Level2.unity", 
        "Assets/Scenes/Levels/Level3.unity", 
        "Assets/Scenes/Ending.unity"
    };

    [MenuItem("Build/Build All")]
    public static void BuildAll() {
        BuildWindows();
        BuildMacOS();
        BuildWebGL();
    }

    [MenuItem("Build/Windows")]
    public static void BuildWindows() {
        string path = "Builds/Windows";

        // Clean up
        FileUtil.DeleteFileOrDirectory(path + "/K-PopSimulator_Data");
        FileUtil.DeleteFileOrDirectory(path + "/MonoBleedingEdge");
        
        BuildPipeline.BuildPlayer(
            levels, 
            path + "/K-PopSimulator.exe", 
            BuildTarget.StandaloneWindows, 
            BuildOptions.None
        );
        // Set up directory structure for InnoSetup
        DirectoryInfo newDataFolder = Directory.CreateDirectory(path + "/Data");
        DirectoryInfo newEdgeFolder = Directory.CreateDirectory(path + "/Edge");
        FileUtil.MoveFileOrDirectory(path + "/K-PopSimulator_Data", newDataFolder.FullName + "/K-PopSimulator_Data");
        FileUtil.MoveFileOrDirectory(path + "/MonoBleedingEdge", newEdgeFolder.FullName + "/MonoBleedingEdge");
        Directory.Move(newDataFolder.FullName, path + "/K-PopSimulator_Data");
        Directory.Move(newEdgeFolder.FullName, path + "/MonoBleedingEdge");

        FileUtil.DeleteFileOrDirectory(path + "/K-PopSimulator_BurstDebugInformation_DoNotShip");

        Process proc = new Process();
        proc.StartInfo.FileName = EditorUtility.OpenFilePanel("Choose Location of InnoSetup File", "", "iss");;
        proc.Start();
    }

    [MenuItem("Build/MacOS")]
    public static void BuildMacOS() {
        string path = "Builds/MacOS";

        BuildPipeline.BuildPlayer(
            levels,
            path + "/K-PopSimulator.app",
            BuildTarget.StandaloneOSX,
            BuildOptions.None
        );
        FileUtil.DeleteFileOrDirectory(path + "/K-PopSimulator_BurstDebugInformation_DoNotShip");

        FileUtil.DeleteFileOrDirectory(path + "/K-PopSimulatorOSX.zip");
        ZipFile.CreateFromDirectory(path + "/K-PopSimulator.app", path + "/K-PopSimulatorOSX.zip", System.IO.Compression.CompressionLevel.Fastest, true);
    }

    [MenuItem("Build/WebGL")]
    public static void BuildWebGL() {
        string path = "Builds/WebGL";

        BuildPipeline.BuildPlayer(
            levels,
            path + "/Player",
            BuildTarget.WebGL,
            BuildOptions.None
        );

        FileUtil.DeleteFileOrDirectory(path + "/K-PopSimulatorWeb.zip");
        ZipFile.CreateFromDirectory(path + "/Player", path + "/K-PopSimulatorWeb.zip");
    }

    [MenuItem("Build/Android")]
    public static void BuildAndroid() {
        string path = "Builds/Android";
        BuildPipeline.BuildPlayer(
            levels,
            path + "/K-PopSimulator.aab",
            BuildTarget.Android,
            BuildOptions.None
        );
        
        FileUtil.DeleteFileOrDirectory(path + "/K-PopSimulator_BurstDebugInformation_DoNotShip");
    }
}
