using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound : MonoBehaviour
{
    private AudioSource source;

    private void Awake() {
        source = GetComponent<AudioSource>();
    }

    public void Play(AudioClip sound){
        source.PlayOneShot(sound);
    }
}
