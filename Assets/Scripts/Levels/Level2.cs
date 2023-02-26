using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level2 : MonoBehaviour, ILevel
{
    public GameObject playlistPanel;

    private Playlist _playlist;
    private const float TIME_FOR_LEVEL = 30f;

    // Start is called before the first frame update
    void Start()
    {
        _playlist = playlistPanel.GetComponent<Playlist>();
    }

    void Awake() {
        EventManager.OnLevelOpen();
        playlistPanel.SetActive(false);
    }

    public void PlayGame() {
        playlistPanel.SetActive(true);
    }

    public void EndGame() {
        playlistPanel.SetActive(false);
    }

    public bool IsSuccessful() {
        foreach (Song song in _playlist.songs) {
            if (song.correct && !_playlist.addedToPlaylist.Contains(song)) {
                return false;
            }
            else if (!song.correct && _playlist.addedToPlaylist.Contains(song)) {
                return false;
            }
        }
        return true;
    }

    public float GetTimeForLevel()
    {
        return TIME_FOR_LEVEL;
    }
}
