using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Level3 : MonoBehaviour, ILevel
{
    // UI
    [Header("UI")]
    [SerializeField] private GameObject _fanchantPanel;
    [SerializeField] private TextMeshProUGUI _fanchantText;
    [SerializeField] private TMP_InputField _inputText;
    
    private const float TIME_FOR_LEVEL = 30f;

    private float defaultFontSize = 40f;
    private float fontSizeWhenKeyboardOpen = 25f;

    void Awake() {
        EventManager.OnLevelStart();
        _fanchantPanel.SetActive(false);
    }

    void Update() {
        #if UNITY_ANDROID

        if (TouchScreenKeyboard.visible) {
            _fanchantText.fontSize = fontSizeWhenKeyboardOpen;
        }
        else {
            _fanchantText.fontSize = defaultFontSize;
        }

        #endif
    }

    public void PlayGame()
    {
        _fanchantPanel.SetActive(true);
        _inputText.Select();
    }

    public void EndGame()
    {
        _fanchantPanel.SetActive(false);
    }

    public bool IsSuccessful()
    {
        // Compare user input to fanchant
        string fanchant1 = _fanchantText.text.ToLower();
        string fanchant2 = _inputText.text.ToLower();
        return fanchant1.Equals(fanchant2);
    }

    public float GetTimeForLevel()
    {
        return TIME_FOR_LEVEL;
    }
}
