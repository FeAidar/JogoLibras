using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SomJingles : MonoBehaviour
{
    public AudioClip StartClip;
    public AudioClip LoopClip;
    public AudioSource audioSource;

    void Start()
    {
        StartCoroutine(playSound());
    }

    IEnumerator playSound()
    {
        audioSource.clip = StartClip;
        audioSource.Play();
        yield return new WaitUntil(() => audioSource.isPlaying == false);
        audioSource.clip = LoopClip;
        audioSource.Play();
        audioSource.loop = true;
    }
}