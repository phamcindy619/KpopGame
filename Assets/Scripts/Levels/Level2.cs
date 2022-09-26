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

    // Update is called once per frame
    void Update()
    {
        
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

    public override bool isSuccessful() {
        foreach (Song song in _playlist.songs) {
            if (song.correct) {
                if (!_playlist.addedToPlaylist.Contains(song)) {
                    return false;
                }
            }
            else {
                if (_playlist.addedToPlaylist.Contains(song)) {
                    return false;
                }
            }
        }
        return true;
    }
}
