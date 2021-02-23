using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolumeValue : MonoBehaviour
{ 
    private AudioSource audioSrc;
    private float VolumeMusic = 1f;
    // Start is called before the first frame update
    void Start()
    {
         audioSrc = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        audioSrc.volume = VolumeMusic;
    }
        public void SetVolume(float vol){
        VolumeMusic = vol;
    }
}
