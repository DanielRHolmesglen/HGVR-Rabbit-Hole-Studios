using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WateringCollider : MonoBehaviour
{
   

    public void OnTriggerStay(Collider other)
    {
        Debug.Log(other.gameObject.name);
        if ((other.GetComponent<VRTags>() != null))
        {
            other.gameObject.GetComponent<PlantGrowthControllable>().animatorController.speed = 1;//.growing = true; 
        
            Debug.Log("grow");
           
        }

    }
    public void OnTriggerExit(Collider other)
    {

        if ((other.GetComponent<VRTags>() != null))
        {
            other.gameObject.GetComponent<PlantGrowthControllable>().animatorController.speed = 0;//growing = false; 

            Debug.Log("stop grow");
            
        }
    }
}
