using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level2 : Level
{
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
    }

    public override void PlayGame() {
        
    }

    public override void EndGame() {
        
    }

    public override bool isSuccessful() {
        return false;
    }
}
