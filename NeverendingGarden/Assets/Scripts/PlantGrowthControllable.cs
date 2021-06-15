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
  

    
    bool done;
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
        
        if (done == false)
        { 
            if (growing == true)
            {                       
            
             
                StartCoroutine(Grow());
                     
            }  
        }

    }
    
    public IEnumerator Grow()
    {
        Debug.Log("running coroutine");
        if (animatorController.playbackTime >= 10)
        {
            experienceProgress.totalWatered += 1;
            done = true;
            yield break;
        }          

        

        if (growing == true)
        {   
            
            
                animatorController.speed = 1;
               
            
            
           
           
        }
        else if (growing == false)
        {
            Debug.Log("no grow");
           
            animatorController.speed = 0;
          
            yield break;
        }  
        yield return null;
      
    }  
}
















