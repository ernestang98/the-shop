using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseAfter10Secs : MonoBehaviour
{
    public GameObject panel;
    // Start is called before the first frame update
    void Start()
    {
        CloseAfter10S();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void CloseAfter10S()
    {
        StartCoroutine(RemoveAfterSeconds(3, panel));
    }

    IEnumerator RemoveAfterSeconds(int seconds, GameObject obj)
    {
        yield return new WaitForSeconds(5);
        obj.SetActive(false);
    }

}
