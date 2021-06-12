using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Liminal.SDK.Core;


public class ExperienceProgressTracker : MonoBehaviour
{
    public List<PlantGrowthControllable> flowers;
    public int totalWatered;
    bool trig; 
    bool trig2;
    bool trig3;
    public GameObject almostOverText;
    public GameObject allDoneText;
    public float time;
    public ParticleSystem winParticles;
    void Start()
    {
        time = 0;
        InvokeRepeating("Increment", 0, 1);
        almostOverText.SetActive(false);
        allDoneText.SetActive(false);
        var x = FindObjectsOfType<PlantGrowthControllable>();
        foreach (var item in x)
        {
            item.experienceProgress = this;
            flowers.Add(item);
        }
    }

    // Update is called once per frame
    

    public void Increment()
    {
        time += 1;
        if (totalWatered >= flowers.Count)
        {
            if (trig2 == false)
            {
                trig2 = true;
                StartCoroutine(AllDone());
            }
            
        }
        if (time >= 240)
        {
            
            if (trig == false)
            {
                StartCoroutine(AlmostOver()); 
                StartCoroutine(GrowIn());

                trig = true;
            }
        }
        if (time >= 300)
        {
            if (trig3 == false)
            {
                ExperienceApp.End();
                trig3 = true;
            }
            
        }
    }

    IEnumerator GrowIn()
    {
        foreach (var item in flowers)
        {
            item.growing = true; 
            item.trig = false;
            yield return new WaitForEndOfFrame();
        } 
                
    }
    IEnumerator AlmostOver()
    {
        winParticles.Play();
        almostOverText.SetActive(true);
        yield return new WaitForSeconds(3);
        almostOverText.SetActive(false);
    }
    IEnumerator AllDone()
    {
        winParticles.Play();
        allDoneText.SetActive(true);
        yield return new WaitForSeconds(3);
        allDoneText.SetActive(false);
    }
}
