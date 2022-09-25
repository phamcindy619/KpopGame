using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using TMPro;

[System.Serializable]
public class Song {
    public string name;
    public string artist;
    public string album;
}

[System.Serializable]
public class SongList {
    public List<Song> songs;
}

public class Playlist : MonoBehaviour
{
    private List<Song> _songs;
    private string _songsFilePath;
    private int _currSongIndex;

    // UI
    public Image albumImage;
    public Button prevButton;
    public Button nextButton;
    public Button addRemoveButton;
    public TextMeshProUGUI songText;

    // Start is called before the first frame update
    void Start()
    {
        _songsFilePath = Application.streamingAssetsPath + "/Songs.json";
        _songs = new List<Song>();
        _currSongIndex = 0;

        // Listeners
        prevButton.onClick.AddListener(PrevSong);
        nextButton.onClick.AddListener(NextSong);
        addRemoveButton.onClick.AddListener(AddRemoveSong);

        // Get songs
        LoadSongs();
        DisplaySong(_songs[0]);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void LoadSongs() {
        string jsonStr = File.ReadAllText(_songsFilePath);
        SongList songList = JsonUtility.FromJson<SongList>(jsonStr);
        foreach (Song song in songList.songs) {
            _songs.Add(song);
        }
    }

    private void NextSong() {
        // Increment index
        _currSongIndex++;
        if (_currSongIndex >= _songs.Count) {
            _currSongIndex = 0;
        }

        DisplaySong(_songs[_currSongIndex]);
    }

    private void PrevSong() {
        _currSongIndex--;
        if (_currSongIndex < 0) {
            _currSongIndex = _songs.Count - 1;
        }

        DisplaySong(_songs[_currSongIndex]);
    }

    private void AddRemoveSong() {

    }

    private void DisplaySong(Song currSong) {
        songText.text = currSong.name + " - " + currSong.artist;

        // Display album image
    }


}
