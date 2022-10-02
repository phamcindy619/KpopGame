using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Level4 : Level
{
    public GameObject posterPanel;
    public GameObject drawing;
    
    [SerializeField]
    private TextMeshProUGUI _tracingText;
    

    // Start is called before the first frame update
    void Start()
    {
       
    }

    void Awake() {
        GameManager.instance.OpenMission();
        posterPanel.SetActive(false);
        drawing.SetActive(false);
    }

    public override void PlayGame()
    {
        posterPanel.SetActive(true);
        drawing.SetActive(true);
    }

    public override void EndGame()
    {
        posterPanel.SetActive(false);
        drawing.SetActive(false);
    }

    public override bool IsSuccessful()
    {
        return false;
    }


}
