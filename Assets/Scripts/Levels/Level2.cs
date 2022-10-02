using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level2 : Level
{
    public GameObject playlistPanel;

    private Playlist _playlist;

    // Start is called before the first frame update
    void Start()
    {
        _playlist = playlistPanel.GetComponent<Playlist>();
    }

    void Awake() {
        GameManager.instance.OpenMission();
        playlistPanel.SetActive(false);
    }

    public override void PlayGame() {
        playlistPanel.SetActive(true);
    }

    public override void EndGame() {
        playlistPanel.SetActive(false);
    }

    public override bool IsSuccessful() {
        #if UNITY_EDITOR
            return true;
        #endif
        
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
}
