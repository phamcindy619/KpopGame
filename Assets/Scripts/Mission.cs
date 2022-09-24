using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Mission : MonoBehaviour
{
    [HideInInspector]
    public string missionsFilePath;
    private StreamReader _sr;

    // Mission
    public int missionNum;
    public TextMeshProUGUI missionsText;
    public Button startButton;

    // Start is called before the first frame update
    void Start()
    {
        missionsFilePath = Application.streamingAssetsPath + "/Missions.txt";
        _sr = new StreamReader(missionsFilePath);

        // Get the current level and display the mission
        missionNum = int.Parse(SceneManager.GetActiveScene().name.Substring(5));
        DisplayMission(missionNum);

        startButton.onClick.AddListener(GameManager.instance.CloseMission);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Display the text for current mission from the missions file
    private void DisplayMission(int currLevel) {
        for (int i = 0; i < currLevel; i++) {
            missionsText.text = _sr.ReadLine();
            _sr.ReadLine();
        }
    }
}
