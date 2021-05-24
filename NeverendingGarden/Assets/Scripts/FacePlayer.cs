using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FacePlayer : MonoBehaviour
{
    public GameObject playerHead;
    void Start()
    {
        
        gameObject.transform.rotation = playerHead.transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.rotation = playerHead.transform.rotation;
    }
}
