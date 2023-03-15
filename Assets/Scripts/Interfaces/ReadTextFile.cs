using UnityEngine;
using UnityEngine.SceneManagement;

/*
    Text files should follow the format with empty lines in between:
    Line 1

    Line 2

    Line 3
*/

public class ReadTextFile
{
    public string ReadAll(string filePath) {
        TextAsset textFile = Resources.Load<TextAsset>(filePath) as TextAsset;
        return textFile.text;
    }

    public string ReadLine(string filePath) {
        TextAsset textFile = Resources.Load<TextAsset>(filePath) as TextAsset;
        string[] lines = textFile.text.Split('\n');
        int levelNum = int.Parse(SceneManager.GetActiveScene().name.Substring(5));
        return lines[(levelNum - 1) * 2];
    }
}
