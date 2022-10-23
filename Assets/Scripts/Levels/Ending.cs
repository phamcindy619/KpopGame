using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ending : MonoBehaviour
{
    public AudioClip endingSong;
    public AudioClip cheeringClip;

    // Start is called before the first frame update
    void Start()
    {
        SoundManager.instance.PlayMusic(endingSong);
        SoundManager.instance.PlaySingle(cheeringClip);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
