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
            Debug.Log("grow");
            if (other.gameObject.GetComponent<VRTags>().tags[0] == "Plant")
            {
                other.gameObject.GetComponent<PlantGrowthControllable>().growing = true; 
                other.gameObject.GetComponent<PlantGrowthControllable>().trig = false;

            }
        }

    }
    public void OnTriggerExit(Collider other)
    {

        if ((other.GetComponent<VRTags>() != null))
        {
            Debug.Log("stop grow");
            if (other.gameObject.GetComponent<VRTags>().tags[0] == "Plant")
            {
                other.gameObject.GetComponent<PlantGrowthControllable>().growing = false; 
                other.gameObject.GetComponent<PlantGrowthControllable>().trig = true;

            }
        }
    }
}
