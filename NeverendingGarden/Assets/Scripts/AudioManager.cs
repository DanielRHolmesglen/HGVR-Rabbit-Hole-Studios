using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip[] stings;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(PlaySound());
    }

    IEnumerator PlaySound()
    {
        yield return new WaitForSeconds(Random.Range(15, 35));
        int x = Random.Range(0, stings.Length);
        audioSource.PlayOneShot(stings[x], .1f);
        StartCoroutine(PlaySound());
    }
}
