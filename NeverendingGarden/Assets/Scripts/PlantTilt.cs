using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
 * This Script is a tool to auto rotate and scale plant sizes
 * so they look more realistic. After use you must check for clipping.
 * by Will C
 */

public class PlantTilt : MonoBehaviour
{
    public List<GameObject> objects; 
    public List<PlantGrowthControllable> plants;
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
       
        if (Input.GetKeyDown(KeyCode.H))
        {
            var x = FindObjectsOfType<Bit>();
            foreach (var item in x)
            {
                objects.Add(item.gameObject);
            }
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            foreach (var item in objects)
            {
                item.transform.Rotate(new Vector3(Random.Range(-5f, 5f), Random.Range(-360f, 360f), Random.Range(-5f, 5f)), Space.Self);
                var x = item.transform.localScale;
                item.transform.localScale *= Random.Range(.9f, 1.1f);
            }
        }
    }
}
//make so that plants shrink to orig size