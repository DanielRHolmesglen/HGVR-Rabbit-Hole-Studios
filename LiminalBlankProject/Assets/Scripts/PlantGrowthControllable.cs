using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CapsuleCollider))]
[RequireComponent(typeof(VRTags))]
public class PlantGrowthControllable : MonoBehaviour 
{

    public List<Transform> leavesAndStems; 
    public List<Transform> flowers;
    public float delay;
    public float growthAmount;
    public bool growing;
    public bool stemsGrown;
    public bool trig = true;
    public bool routine;
    CapsuleCollider capsuleCollider;

    private void Awake()
    {
        foreach (var item in leavesAndStems)
        {
            item.localScale = new Vector3(.1f, .1f, .1f);
        }

        foreach (var item in flowers)
        {
            item.localScale = new Vector3(.1f, .1f, .1f);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
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
            if (stemsGrown == false)
            {
                if (leavesAndStems[0].localScale.y < 1)
                {
                    foreach (var growthTransform in leavesAndStems)
                    {
                        growthTransform.localScale += new Vector3(growthAmount, growthAmount, growthAmount);
                    }
                    yield return new WaitForSeconds(delay);
                }
                else
                {
                    stemsGrown = true;
                }
            }
            else
            {
                if (flowers[0].localScale.y < 1)
                {
                    foreach (var growthTransform in flowers)
                    {
                        growthTransform.localScale += new Vector3(growthAmount, growthAmount, growthAmount);
                    }
                    yield return new WaitForSeconds(delay);
                }
            }
            
        }
        else
        {
            routine = false;
            yield break;
        }
        yield return null;
        StartCoroutine(Grow());
        
    }

  
}
















