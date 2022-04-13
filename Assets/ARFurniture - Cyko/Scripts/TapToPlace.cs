using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using TMPro;


[RequireComponent(typeof(ARRaycastManager))]
public class TapToPlace : MonoBehaviour
{
    [SerializeField] ARSession m_Session;
    public GameObject[] objectToPlace;
    private GameObject spawnedObject;
    private Vector2 touchPosition;
    private ARRaycastManager arRaycastManager;
    public GameObject Cam;
    public GameObject Canvas;
    public GameObject sun;
    public Slider slider;
    bool isSunRotating = false;
    public TMP_Text text;
    public Color r, g, b;

    static List<ARRaycastHit> hits = new List<ARRaycastHit>();
    

    private void Awake()
    {
        arRaycastManager = GetComponent<ARRaycastManager>();
    }

    IEnumerator Start()
    {
        if ((ARSession.state == ARSessionState.None) || (ARSession.state == ARSessionState.CheckingAvailability))
        {
            yield return ARSession.CheckAvailability();
        }

        if (ARSession.state == ARSessionState.Unsupported)
        {
            // Start some fallback experience for unsupported devices
            text.gameObject.transform.parent.gameObject.SetActive(true);
            text.text = "AR Core not Supported!";
        }
        else
        {
            // Start the AR session
            //text.gameObject.transform.parent.gameObject.SetActive(true);
            //text.text = "AR Core Supported!";
            m_Session.enabled = true;

        }
    }

    bool TryGetTouchPosition(out Vector2 touchPosition)
    {
        if (Input.touchCount > 0)
        {
            touchPosition = Input.GetTouch(0).position;
            return true;
        }

        touchPosition = default;
        return false;

    }

    // Update is called once per frame
    void Update()
    {
        if (isSunRotating)
            return;

        if (!TryGetTouchPosition(out Vector2 touchPosition))
            return;

        if (arRaycastManager.Raycast(touchPosition, hits, TrackableType.PlaneWithinPolygon))
        {
            var hitpos = hits[0].pose;

            if (spawnedObject == null)
            {
                spawnedObject = Instantiate(objectToPlace[UIManager.index], hitpos.position, objectToPlace[UIManager.index].transform.rotation);
            }
            else
            {
                spawnedObject.transform.position = hitpos.position;
            }
        }
    }

    public void ChangeDayNight()
    {
        sun.transform.eulerAngles = new Vector3(slider.value, -30, 0);
    }

    public void RotateOff()
    {
        isSunRotating = false;
    }

    public void RotateOn()
    {
        isSunRotating = true;
    }

    public void Red()
    {
        spawnedObject.GetComponent<Renderer>().material.color = r;
    }

    public void Green()
    {
        spawnedObject.GetComponent<Renderer>().material.color = g;
    }

    public void Blue()
    {
        spawnedObject.GetComponent<Renderer>().material.color = b;
    }

}

