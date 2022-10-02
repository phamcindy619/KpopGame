using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Level3 : Level
{
    public GameObject fanchantPanel;

    [SerializeField]
    private TextMeshProUGUI fanchantText;
    [SerializeField]
    private TMP_InputField inputText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Awake() {
        GameManager.instance.OpenMission();
        fanchantPanel.SetActive(false);
    }

    public override void PlayGame()
    {
        fanchantPanel.SetActive(true);
        inputText.Select();
    }

    public override void EndGame()
    {
        fanchantPanel.SetActive(false);
    }

    public override bool IsSuccessful()
    {
        // Compare user input to fanchant
        string fanchant1 = fanchantText.text.ToLower();
        string fanchant2 = inputText.text.ToLower();
        return fanchant1.Equals(fanchant2);
    }

}
