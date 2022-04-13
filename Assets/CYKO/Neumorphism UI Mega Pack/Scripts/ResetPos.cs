using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetPos : MonoBehaviour
{
    private void OnEnable()
    {
        gameObject.transform.localPosition = new Vector3(0, 0, 0);
    }
}
