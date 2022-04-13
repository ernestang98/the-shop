using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ToggleAlert : MonoBehaviour
{
    public GameObject alert;
    public GameObject popup;
    float width;
    float depth;

    // Start is called before the first frame update
    void Start()
    {

        


        //glasses1Button = GameObject.Find("Canvas/glasses1button").GetComponent<Image>();
        if (PlayerPrefs.GetFloat("width", 0) != 0)
        { width = PlayerPrefs.GetFloat("width"); }
        else
        {
            width = 13.9f;
        }

        if (PlayerPrefs.GetFloat("depth", 0) != 0)
        { depth = PlayerPrefs.GetFloat("depth"); }
        else
        {
            depth = 13.9f;
        }

    }

        void OnDisable()
        {
            Debug.Log("PrintOnDisable: script was disabled");
        }

    void OnEnable()
    {
       

        TextMeshProUGUI w = GameObject.Find("MenuCanvas/PanelDetails/Details/txtW").GetComponent<TextMeshProUGUI>();
        TextMeshProUGUI d = GameObject.Find("MenuCanvas/PanelDetails/Details/txtD").GetComponent<TextMeshProUGUI>();


        // Debug.Log("Width Text: " + w.text.ToString());
        float.TryParse(w.text.ToString(), out float glasswidth);
        float.TryParse(d.text.ToString(), out float glassdepth);


        //if ((width > glasswidth) || (depth > glassdepth))
           if ((width > glasswidth))
        {
            alert.SetActive(true);
            popup.SetActive(true);
        }

        else
        {
            alert.SetActive(false);
            popup.SetActive(false);
        }
    }


        // Update is called once per frame
        void Update()
    {
        
    }
}
