using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantGrowth : MonoBehaviour
{
    public List<Transform> objectsToGrow;
    public float delay;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Grow());
    }
    
    // Update is called once per frame
    // void Update()
    // {
        
    // }

    private IEnumerator Grow()
    {
        while (objectsToGrow[0].localScale != Vector3.one)
        {
            foreach (var growthTransform in objectsToGrow)
            {
                growthTransform.localScale += new Vector3(.01f, .01f, .01f);
            }
            yield return new WaitForSeconds(delay);
        }

        yield return null;
    }
}
