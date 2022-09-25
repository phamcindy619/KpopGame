using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level2 : Level
{
    public GameObject playlist;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Awake() {
        GameManager.instance.OpenMission();
        playlist.SetActive(false);
    }

    public override void PlayGame() {
        playlist.SetActive(true);
    }

    public override void EndGame() {
        playlist.SetActive(false);
    }

    public override bool isSuccessful() {
        return false;
    }
}
