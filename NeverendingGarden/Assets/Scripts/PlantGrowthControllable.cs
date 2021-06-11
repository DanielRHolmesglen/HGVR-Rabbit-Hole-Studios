using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CapsuleCollider))]
[RequireComponent(typeof(VRTags))]
public class PlantGrowthControllable : MonoBehaviour 
{
    public Animator animatorController;
    public float delay;
    public float growthAmount;
    public bool growing;
    public bool stemsGrown;
    public bool trig = true;
    bool trig2;
    public bool sparkling = false;
    public bool routine;
    public ExperienceProgressTracker experienceProgress;
    CapsuleCollider capsuleCollider;

  
    // Start is called before the first frame update
    void Start()
    {
        
        animatorController.speed = 0;
       


       
        
     
        capsuleCollider = GetComponent<CapsuleCollider>();
        capsuleCollider.isTrigger = true;       
    }
    
    // Update is called once per frame
    void Update()
    {       
        if (growing == true && trig == false)
        {                       
            if (routine == false)
            {  
                StartCoroutine(Grow());
            }           
        }
    }

    private IEnumerator Grow()
    {               
        routine = true;
        if (growing == true)
        {
            animatorController.speed = 1;
           
            if (animatorController.playbackTime >= 10)
            {
                experienceProgress.totalWatered += 1;
                trig2 = true;
            }  
        }
        else
        {
            animatorController.speed = 0;
            routine = false;
            yield break;
        }
        yield return null;
        StartCoroutine(Grow());        
    }  
}
















