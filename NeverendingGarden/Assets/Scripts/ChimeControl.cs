using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChimeControl : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip chime;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(PlaySound());
    }

    IEnumerator PlaySound()
    {   yield return new WaitForSeconds(Random.Range(47, 107));    
        audioSource.PlayOneShot(chime, 1f);
                   
        StartCoroutine(PlaySound());
    }
}
