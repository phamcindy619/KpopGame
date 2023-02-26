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
    public string image;
    public bool correct;
}

[System.Serializable]
public class SongList {
    public List<Song> songs;
}

public class Playlist : MonoBehaviour
{
    public List<Song> songs;
    public List<Song> addedToPlaylist;
    private string _songsFilePath;
    private string _albumsFilePath;
    private int _currSongIndex;

    // UI
    [Header("UI")]
    [SerializeField] private Image _albumImage;
    [SerializeField] private Button _prevButton;
    [SerializeField] private Button _nextButton;
    [SerializeField] private Button _addRemoveButton;
    [SerializeField] private TextMeshProUGUI _songText;
    [SerializeField] private Sprite _addSprite;
    [SerializeField] private Sprite _removeSprite;

    // Start is called before the first frame update
    void Start()
    {
        _songsFilePath = Application.streamingAssetsPath + "/JSON/Songs.json";
        _albumsFilePath = Application.streamingAssetsPath + "/AlbumImages/";
        songs = new List<Song>();
        addedToPlaylist = new List<Song>();
        _currSongIndex = 0;

        // Listeners
        _prevButton.onClick.AddListener(PrevSong);
        _prevButton.onClick.AddListener(EventManager.ButtonClicked);
        _nextButton.onClick.AddListener(NextSong);
        _nextButton.onClick.AddListener(EventManager.ButtonClicked);
        _addRemoveButton.onClick.AddListener(AddRemoveSong);
        _addRemoveButton.onClick.AddListener(EventManager.ButtonClicked);

        // Get songs
        LoadSongs();
        DisplaySong(songs[0]);
    }

    private void LoadSongs() {
        string jsonStr = File.ReadAllText(_songsFilePath);
        SongList songList = JsonUtility.FromJson<SongList>(jsonStr);
        foreach (Song song in songList.songs) {
            songs.Add(song);
        }
    }

    private void NextSong() {
        // Increment index
        _currSongIndex++;
        if (_currSongIndex >= songs.Count) {
            _currSongIndex = 0;
        }

        DisplaySong(songs[_currSongIndex]);
    }

    private void PrevSong() {
        _currSongIndex--;
        if (_currSongIndex < 0) {
            _currSongIndex = songs.Count - 1;
        }

        DisplaySong(songs[_currSongIndex]);
    }

    private void AddRemoveSong() {
        Song currSong = songs[_currSongIndex];
        // Remove the song from playlist
        if (addedToPlaylist.Contains(currSong)) {
            addedToPlaylist.Remove(currSong);
            _addRemoveButton.GetComponent<Image>().sprite = _addSprite;
        }
        else {
            addedToPlaylist.Add(currSong);
            _addRemoveButton.GetComponent<Image>().sprite = _removeSprite;
        }
    }

    private void DisplaySong(Song currSong) {
        _songText.text = currSong.name + " - " + currSong.artist;
        
        // Check if song is in playlist and display the add/remove button
        if (addedToPlaylist.Contains(currSong)) {
            _addRemoveButton.GetComponent<Image>().sprite = _removeSprite;
        }
        else {
            _addRemoveButton.GetComponent<Image>().sprite = _addSprite;
        }

        // Display album image
        _albumImage.sprite = GetAlbumImage(currSong);
    }

    private Sprite GetAlbumImage(Song song) {
        byte[] pngBytes = File.ReadAllBytes(_albumsFilePath + song.image);

        Texture2D tex = new Texture2D(2, 2);
        tex.LoadImage(pngBytes);
        return Sprite.Create(tex, new Rect(0f, 0f, tex.width, tex.height), new Vector2(0.5f, 0.5f), 100f);
    }
}
