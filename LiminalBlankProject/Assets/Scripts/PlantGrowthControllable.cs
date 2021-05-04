using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshCollider))]
[RequireComponent(typeof(VRTags))]
public class PlantGrowthControllable : MonoBehaviour 
{
   
    public List<Transform> objectsToGrow;
    public float delay;
    public float growthAmount;
    public bool growing;
    MeshCollider meshCollider;
    // Start is called before the first frame update
    void Start()
    {
        meshCollider = GetComponent<MeshCollider>();
        meshCollider.isTrigger = true;
        StartCoroutine(Grow());
    }
    
    // Update is called once per frame
    void FixedUpdate()
    {
        
    }

    private IEnumerator Grow()
    {
        if (growing == true)
        {
            if (objectsToGrow[0].localScale.y < 1)
            {
                foreach (var growthTransform in objectsToGrow)
            {
                growthTransform.localScale += new Vector3(growthAmount, growthAmount, growthAmount);
            }
                yield return new WaitForSeconds(delay);
            }
            
        }
        yield return null;
        StartCoroutine(Grow());
        
    }

  
}
















