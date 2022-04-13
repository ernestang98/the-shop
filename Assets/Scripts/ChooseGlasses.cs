using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChooseGlasses : MonoBehaviour
{
    public GameObject glasses1;
    public GameObject glasses2;
    public GameObject glasses3;
    public GameObject glasses4;
    public GameObject glasses5;

    Button glasses1Button;
    Button glasses2Button;
    Button glasses3Button;
    Button glasses4Button;
    Button glasses5Button;

    public int glass1active;
    public int glass2active;
    public int glass3active;
    public int glass4active;
    public int glass5active;


    // Start is called before the first frame update
    void Start()
    {
        glasses1Button = GameObject.Find("Canvas/glasses1button").GetComponent<Button>();
        glasses2Button = GameObject.Find("Canvas/glasses2button").GetComponent<Button>();
        glasses3Button = GameObject.Find("Canvas/glasses3button").GetComponent<Button>();
        glasses4Button = GameObject.Find("Canvas/glasses4button").GetComponent<Button>();
        glasses5Button = GameObject.Find("Canvas/glasses5button").GetComponent<Button>();

        glasses1Button.onClick.AddListener(Glasses1Selected);
        glasses2Button.onClick.AddListener(Glasses2Selected);
        glasses3Button.onClick.AddListener(Glasses3Selected);
        glasses4Button.onClick.AddListener(Glasses4Selected);
        glasses5Button.onClick.AddListener(Glasses5Selected);

        glass1active = PlayerPrefs.GetInt("G1");
        glass2active = PlayerPrefs.GetInt("G2");
        glass3active = PlayerPrefs.GetInt("G3");
        glass4active = PlayerPrefs.GetInt("G4");
        glass5active = PlayerPrefs.GetInt("G5");

        if (glass1active > 0)
        {
            glasses1.SetActive(true);
            glasses2.SetActive(false);
            glasses3.SetActive(false);
            glasses4.SetActive(false);
            glasses5.SetActive(false);
        }

        if (glass2active > 0)
        {
            glasses1.SetActive(false);
            glasses2.SetActive(true);
            glasses3.SetActive(false);
            glasses4.SetActive(false);
            glasses5.SetActive(false);
        }
        if (glass3active > 0)
        {
            glasses1.SetActive(false);
            glasses2.SetActive(false);
            glasses3.SetActive(true);
            glasses4.SetActive(false);
            glasses5.SetActive(false);
        }
        if (glass4active > 0)
        {
            glasses1.SetActive(false);
            glasses2.SetActive(false);
            glasses3.SetActive(false);
            glasses4.SetActive(true);
            glasses5.SetActive(false);
        }
        if (glass5active > 0)
        {
            glasses1.SetActive(false);
            glasses2.SetActive(false);
            glasses3.SetActive(false);
            glasses4.SetActive(false);
            glasses5.SetActive(true);
        }


    }

    // Update is called once per frame
    void Update()
    {
    }

    public void Glasses1Selected()
    {
        PlayerPrefs.SetInt("G1", 1);
        PlayerPrefs.SetInt("G2", 0);
        PlayerPrefs.SetInt("G3", 0);
        PlayerPrefs.SetInt("G4", 0);
        PlayerPrefs.SetInt("G5", 0);
        glasses1.SetActive(true);
        glasses2.SetActive(false);
        glasses3.SetActive(false);
        glasses4.SetActive(false);
        glasses5.SetActive(false);
    }
    public void Glasses2Selected()
    {
        PlayerPrefs.SetInt("G1", 0);
        PlayerPrefs.SetInt("G2", 1);
        PlayerPrefs.SetInt("G3", 0);
        PlayerPrefs.SetInt("G4", 0);
        PlayerPrefs.SetInt("G5", 0);
        glasses1.SetActive(false);
        glasses2.SetActive(true);
        glasses3.SetActive(false);
        glasses4.SetActive(false);
        glasses5.SetActive(false);
    }
    public void Glasses3Selected()
    {
        PlayerPrefs.SetInt("G1", 0);
        PlayerPrefs.SetInt("G2", 0);
        PlayerPrefs.SetInt("G3", 1);
        PlayerPrefs.SetInt("G4", 0);
        PlayerPrefs.SetInt("G5", 0);
        glasses1.SetActive(false);
        glasses2.SetActive(false);
        glasses3.SetActive(true);
        glasses4.SetActive(false);
        glasses5.SetActive(false);
    }
    public void Glasses4Selected()
    {
        PlayerPrefs.SetInt("G1", 0);
        PlayerPrefs.SetInt("G2", 0);
        PlayerPrefs.SetInt("G3", 0);
        PlayerPrefs.SetInt("G4", 1);
        PlayerPrefs.SetInt("G5", 0);
        glasses1.SetActive(false);
        glasses2.SetActive(false);
        glasses3.SetActive(false);
        glasses4.SetActive(true);
        glasses5.SetActive(false);
    }
    public void Glasses5Selected()
    {
        PlayerPrefs.SetInt("G1", 0);
        PlayerPrefs.SetInt("G2", 0);
        PlayerPrefs.SetInt("G3", 0);
        PlayerPrefs.SetInt("G4", 0);
        PlayerPrefs.SetInt("G5", 1);
        glasses1.SetActive(false);
        glasses2.SetActive(false);
        glasses3.SetActive(false);
        glasses4.SetActive(false);
        glasses5.SetActive(true);
    }
}
