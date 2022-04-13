using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Custom1Script : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        int C1Trait1 = PlayerPrefs.GetInt("C1Trait1");
        int C2Trait1 = PlayerPrefs.GetInt("C2Trait1");
        int C2Trait2 = PlayerPrefs.GetInt("C2Trait2");
        int C3Trait1 = PlayerPrefs.GetInt("C3Trait1");


        Debug.Log("C1TRAIT1 = " + C1Trait1.ToString());
        Debug.Log("C2TRAIT1 = " + C2Trait1.ToString());
        Debug.Log("C2TRAIT2 = " + C2Trait2.ToString());
        Debug.Log("C3TRAIT1 = " + C3Trait1.ToString());
        Debug.Log("setting traits");

        if (C1Trait1 > 0)
        { transform.Find("Logo1").GetComponent<MeshRenderer>().enabled = true; }
        else
        {
            transform.Find("Logo1").GetComponent<MeshRenderer>().enabled = false;
        }

        if (C2Trait1 > 0)
        { transform.Find("Logo2Left").GetComponent<MeshRenderer>().enabled = true; }
        else
        {
            transform.Find("Logo2Left").GetComponent<MeshRenderer>().enabled = false;
        }

        if (C2Trait2 > 0)
        { transform.Find("Logo2Right").GetComponent<MeshRenderer>().enabled = true; }
        else
        {
            transform.Find("Logo2Right").GetComponent<MeshRenderer>().enabled = false;
        }

        if (C3Trait1 > 0)
        { transform.Find("Logo3").GetComponent<MeshRenderer>().enabled = true; }
        else
        {
            transform.Find("Logo3").GetComponent<MeshRenderer>().enabled = false;
        }



        //transform.Find("Frame1").GetComponent<MeshRenderer>().enabled = false;
    }



    // Update is called once per frame
    void Update()
    {

    }
}

