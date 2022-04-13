using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GetUserWidth : MonoBehaviour
{
    public GameObject ScanFaceFirst;
    bool scanned = false;
    public Text width;
    public Text depth;
    public string popUp;
    // Start is called before the first frame update
    void Start()
    {   
        if (PlayerPrefs.GetFloat("width", 0) != 0)
        { width.text = PlayerPrefs.GetFloat("width").ToString(); }
        else
        {
            width.text = "no width yet";
        }

        if (PlayerPrefs.GetFloat("depth", 0) != 0)
        { depth.text = PlayerPrefs.GetFloat("depth").ToString(); }
        else
        {
            depth.text = "no depth yet";
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ResetWidth()
    {
        PlayerPrefs.DeleteKey("width");
        PlayerPrefs.DeleteAll();

        if (PlayerPrefs.GetFloat("width", 0) != 0)
        { width.text = PlayerPrefs.GetFloat("width").ToString(); }
        else
        {
            width.text = "no width yet";
        }

        if (PlayerPrefs.GetFloat("depth", 0) != 0)
        { width.text = PlayerPrefs.GetFloat("depth").ToString(); }
        else
        {
            depth.text = "no depth yet";
        }
    }

    public void ScanFace()
    {
        SceneManager.LoadScene(1);
    }

    public void StartShopping()
  
    {
        if (PlayerPrefs.GetFloat("width", 0) == 0)
        {
           // ScanFaceFirst.enabled = true;

           // ScanFaceFirst.gameObject.SetActive(true);

            PopUpSystem pop = GameObject.FindGameObjectWithTag("GameController").GetComponent<PopUpSystem>();
            pop.PopUp(popUp);

        }
        else
        {
            SceneManager.LoadScene(2);
        }
        
    }

 

}
