using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Liminal.SDK.Input;
using Liminal.Core.Fader;

public class TeleportPoint : MonoBehaviour
{
    public Transform point;
    public Vector3 scale;
    // Start is called before the first frame update
    void Start()
    {
        scale = gameObject.transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void OnLookAt()
    {
        StartCoroutine(Teleport());
    }
   
    public IEnumerator Teleport()
    {
        

        

        var fader = ScreenFader.Instance;

        fader.FadeTo(Color.black, 3);
        yield return new WaitForSeconds(3);
        GameObject.Find("VRAvatar").transform.position = point.position;
        var x = FindObjectsOfType<TeleportPoint>();
        foreach (var item in x)
        {


            item.gameObject.transform.localScale = scale;


        }
        
        fader.FadeTo(Color.clear, 3);
        gameObject.transform.localScale = Vector3.zero;
        yield return null;

    }
}
