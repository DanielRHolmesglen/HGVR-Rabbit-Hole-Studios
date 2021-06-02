using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(CapsuleCollider))]
[RequireComponent(typeof(VRTags))]
public class PlantGrowthControllableTestDisplay : MonoBehaviour
{

    public List<Transform> leavesAndStems;
    public List<Transform> flowers;
    public float delay;
    public float growthAmount;
    public bool growing;
    public bool stemsGrown;
    public bool trig = true;
    public bool sparkling = false;
    public bool routine;
    CapsuleCollider capsuleCollider;
    public ParticleSystem[] sparkles = new ParticleSystem[2];
    public Text worldPos; 
    public Text scale; 
    public Text delayDisplay; 
    public Text growthAmountDisplay; 
    public Text growingDisplay; 
    public Text stemsGrownDisplay; 
    public Text trigDisplay; 
    public Text sparklingDisplay; 
    public Text routineDisplay; 
    
    // Start is called before the first frame update
    void Start()
    {
        foreach (var item in sparkles)
        {
            item.Stop();
        }

        foreach (var item in leavesAndStems)
        {
            item.localScale = new Vector3(.1f, .1f, .1f);
        }

        foreach (var item in flowers)
        {
            item.localScale = new Vector3(.1f, .1f, .1f);
        }
        capsuleCollider = GetComponent<CapsuleCollider>();
        capsuleCollider.isTrigger = true;

    }

    // Update is called once per frame
    void Update()
    {
        worldPos.text = "Pos: " + gameObject.transform.position.ToString();
        scale.text = "Scale: " + gameObject.transform.localScale.ToString();
        delayDisplay.text = "Delay: " + delay.ToString();
        growthAmountDisplay.text = "Growth Amount: " + growthAmount.ToString();
        growingDisplay.text = "Growing: " + growing.ToString();
        stemsGrownDisplay.text = "Stems Grown: " + stemsGrown.ToString();
        trigDisplay.text = "Trig: " + trig.ToString();
        sparklingDisplay.text = "Sparkling: " + sparkling.ToString();
        routineDisplay.text = "Routine: " + routine.ToString();
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
            if (sparkling == false)
            {
                sparkling = true;
                foreach (var item in sparkles)
                {
                    item.Play();
                }
            }

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
            sparkling = false;
            foreach (var item in sparkles)
            {
                item.Stop();
            }
            routine = false;
            yield break;
        }
        yield return null;
        StartCoroutine(Grow());

    }


}