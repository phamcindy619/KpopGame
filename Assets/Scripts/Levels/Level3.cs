using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Level3 : MonoBehaviour, ILevel
{
    public GameObject fanchantPanel;

    [SerializeField]
    private TextMeshProUGUI fanchantText;
    [SerializeField]
    private TMP_InputField inputText;
    private const float TIME_FOR_LEVEL = 20f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Awake() {
        EventManager.OnLevelStart();
        fanchantPanel.SetActive(false);
    }

    public void PlayGame()
    {
        fanchantPanel.SetActive(true);
        inputText.Select();
    }

    public void EndGame()
    {
        fanchantPanel.SetActive(false);
    }

    public bool IsSuccessful()
    {
        // Compare user input to fanchant
        string fanchant1 = fanchantText.text.ToLower();
        string fanchant2 = inputText.text.ToLower();
        return fanchant1.Equals(fanchant2);
    }

    public float GetTimeForLevel()
    {
        return TIME_FOR_LEVEL;
    }

}
