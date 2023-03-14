using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;
using System.Threading.Tasks;

/*
    Text files should follow the format with empty lines in between:
    Line 1

    Line 2

    Line 3
*/

public class ReadTextFile
{
    private  UnityWebRequest _webRequest;
    private void LoadFile(string uri) {
        _webRequest = UnityWebRequest.Get(uri);
        UnityWebRequestAsyncOperation op = _webRequest.SendWebRequest();
        while (!op.isDone) {
        }
        if (_webRequest.result != UnityWebRequest.Result.Success) {
            Debug.Log(_webRequest.result);
        }
    }

    public string ReadAll(string filePath) {
        LoadFile(filePath);
        return _webRequest.downloadHandler.text;
    }

    public string ReadLine(string filePath) {
        LoadFile(filePath);
        string text = _webRequest.downloadHandler.text;
        string[] lines = text.Split('\n');
        int levelNum = int.Parse(SceneManager.GetActiveScene().name.Substring(5));
        return lines[(levelNum - 1) * 2];
    }
}
