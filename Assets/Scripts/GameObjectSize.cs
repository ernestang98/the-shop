using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameObjectSize : MonoBehaviour
{
    // public Text x;
    // public Text y;
    // public Text z;

    float currentTime = 0f;
    float startingTime = 1f;

    // Start is called before the first frame update
    void Start()
    {
        // Vector3 size = GetComponent<Collider>().bounds.size;
        //  x.text = size.x.ToString();
        // y.text = size.y.ToString();
        // z.text = size.z.ToString();

        currentTime = startingTime;


        Canvas errorY = GameObject.Find("Canvas/ErrorCanvasY").GetComponent<Canvas>();
        Canvas errorZ = GameObject.Find("Canvas/ErrorCanvasZ").GetComponent<Canvas>();
        Canvas noerror = GameObject.Find("Canvas/NoErrorCanvas").GetComponent<Canvas>();
        

        Quaternion rotate = GetComponent<Collider>().transform.rotation;

        // Vector3 size = GetComponent<Collider>().bounds.size;
        // x.text = size.x.ToString();
        // y.text = size.y.ToString();
        // z.text = size.z.ToString();
        Text r = GameObject.Find("Canvas/rotation").GetComponent<Text>();

        r.text = rotate.z.ToString();

    }

    // Update is called once per frame
    void Update()
    {
        

        Quaternion rotate = GetComponent<Collider>().transform.rotation;
        Canvas errorY = GameObject.Find("Canvas/ErrorCanvasY").GetComponent<Canvas>();
        Canvas errorZ = GameObject.Find("Canvas/ErrorCanvasZ").GetComponent<Canvas>();
        Canvas noerror = GameObject.Find("Canvas/NoErrorCanvas").GetComponent<Canvas>();
        Canvas faceerror = GameObject.Find("Canvas/NoErrorCanvas/FaceErrorCanvas").GetComponent<Canvas>();

        // Vector3 size = GetComponent<Collider>().bounds.size;
        // x.text = size.x.ToString();
        // y.text = size.y.ToString();
        // z.text = size.z.ToString();
        Text r = GameObject.Find("Canvas/rotation").GetComponent<Text>();
        Text rY = GameObject.Find("Canvas/rotationY").GetComponent<Text>();
        Vector3 size = GetComponent<Collider>().bounds.size;

        rY.text = rotate.y.ToString();
        r.text = rotate.z.ToString();

       if ((rotate.z > 0.03 || rotate.z <-0.03))
        {
            noerror.enabled = false;
            errorZ.enabled = true;
            currentTime = startingTime;
        }

        else if ((rotate.y > 0.02 || rotate.y < -0.02))
        {
            noerror.enabled = false;
            errorY.enabled = true;
            currentTime = startingTime;
        }

        else
        {


            noerror.enabled = true;
            errorY.enabled = false;
            errorZ.enabled = false;
            if (size.x > 0.14)
            {
                faceerror.enabled = true;
            }
            else
            {
                faceerror.enabled = false;
            }
            Text time = GameObject.Find("Canvas/NoErrorCanvas/CountdownTimer").GetComponent<Text>();
            TextMeshProUGUI reason = GameObject.Find("Canvas/NoErrorCanvas/ScanningFacePanel/ReasonBox/ReasonText").GetComponent<TextMeshProUGUI>();
            TextMeshProUGUI secondsText = GameObject.Find("Canvas/NoErrorCanvas/ScanningFacePanel/ReasonBox/SecondsText").GetComponent<TextMeshProUGUI>();
            

            time.text = currentTime.ToString("0");
            currentTime -= 1 * Time.deltaTime;

            if (currentTime <= 0)
            {
                currentTime = 0;
                time.text = "";
                reason.text = "Scan Success";
                secondsText.text = "";

                Text w = GameObject.Find("Canvas/width").GetComponent<Text>();
                Text d = GameObject.Find("Canvas/depth").GetComponent<Text>();

                // Debug.Log("Width Text: " + w.text.ToString());
                float.TryParse(w.text.ToString(), out float widthresult);
                float.TryParse(d.text.ToString(), out float depthresult);

                PlayerPrefs.SetFloat("width", widthresult);
                PlayerPrefs.SetFloat("depth", depthresult);

                
                SceneManager.LoadScene(0);
            }

        }

       
       
     
    }
}
