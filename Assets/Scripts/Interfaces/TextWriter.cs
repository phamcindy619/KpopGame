using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextWriter : MonoBehaviour
{
    private TextMeshProUGUI _uiText;
    private string _textToWrite;
    private int _charIndex;
    private float _timePerChar;
    private float _timer;

    public void AddWriter(TextMeshProUGUI uiText, string textToWrite, float timePerChar) {
        _uiText = uiText;
        _textToWrite = textToWrite;
        _timePerChar = timePerChar;
        _charIndex = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (_uiText != null) {
            _timer -= Time.deltaTime;
            if (_timer <= 0f) {
                _timer += _timePerChar;
                _charIndex++;
                _uiText.text = _textToWrite.Substring(0, _charIndex);

                // Entire string displayed
                if (_charIndex >= _textToWrite.Length) {
                    _uiText = null;
                }
            }
        }
    }
}
