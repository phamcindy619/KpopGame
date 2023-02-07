using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using TMPro;
using UnityEngine.SceneManagement;

/*
    Text files should follow the format with empty lines in between:
    Line 1

    Line 2

    Line 3
*/

public class ReadTextFile : MonoBehaviour
{
    private StreamReader _sr;

    public string ReadText(string filePath) {
        _sr = new StreamReader(filePath);
        string text = "";
        int levelNum = int.Parse(SceneManager.GetActiveScene().name.Substring(5));

        for (int i = 0; i < levelNum; i++) {
            text = _sr.ReadLine();
            _sr.ReadLine();
        }
        return text;
    }
}
