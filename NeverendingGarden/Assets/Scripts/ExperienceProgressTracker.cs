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
    void Start()
    {
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
    void Update()
    {
        float time = Time.time;
        Debug.Log(time);
        if (totalWatered >= flowers.Count)
        {
            if (trig2 == false)
            {
                trig2 = true;
                StartCoroutine(AllDone());
            }
            
        }
        if (time >= 540)
        {
           
            if (trig == false)
            {
                StartCoroutine(AlmostOver());

                foreach (var item in flowers)
                {
                    item.growing = true; 
                    item.trig = false;

                } 
                trig = true;
            }
        }
        if (time >= 600)
        {
            if (trig3 == false)
            {
                ExperienceApp.End();
                trig3 = true;
            }
            
        }
    }

    IEnumerator AlmostOver()
    {
        almostOverText.SetActive(true);
        yield return new WaitForSeconds(3);
        almostOverText.SetActive(false);
    }
    IEnumerator AllDone()
    {
        allDoneText.SetActive(true);
        yield return new WaitForSeconds(3);
        allDoneText.SetActive(false);
    }
}
