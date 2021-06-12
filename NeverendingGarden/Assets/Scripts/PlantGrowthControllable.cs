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
    public bool trig2; 
    public bool trig3;
    bool done;
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
       // InvokeRepeating("NewUpdate", 0, 1f);
    }
    
    // Update is called once per frame
    void Update()
    {       
        if (done == true)
        {
            StopAllCoroutines();
        }
        if (growing == true && trig == false)
        {                       
            if (routine == false && done == false)
            {  
                StartCoroutine(Grow());
            }           
        }
    }

    void NewUpdate()
    {
        
    }
        

    private IEnumerator Grow()
    {
        Debug.Log("running coroutine");
        if (animatorController.playbackTime >= 10)
        {
            experienceProgress.totalWatered += 1;
            done = true;
            yield break;
        }          

        routine = true;
        if (growing == true)
        {
            if (trig3 == false)
            {
                animatorController.speed = 1;
                trig3 = true;
            }
            
           
           
        }
        else
        {
            trig3 = false;
            animatorController.speed = 0;
            routine = false;
            yield break;
        }
        yield return null;
      
    }  
}
















