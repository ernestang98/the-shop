using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TestPlayerPref : MonoBehaviour
{
    public GameObject Custom1;
    public GameObject Custom2;

    //History

    public GameObject Image1;
    public GameObject Image2;
    public GameObject Image3;
    public GameObject Image4;
    public GameObject Image5;

    public TMP_Text Image1Name;
    public TMP_Text Image2Name;
    public TMP_Text Image3Name;
    public TMP_Text Image4Name;
    public TMP_Text Image5Name;

    public TMP_Text Image1Price;
    public TMP_Text Image2Price;
    public TMP_Text Image3Price;
    public TMP_Text Image4Price;
    public TMP_Text Image5Price;

    public Sprite Glass1;
    public Sprite Glass2;
    public Sprite Glass3;

    public string Glass1Name;
    public string Glass2Name;
    public string Glass3Name;

    public string Glass1Price;
    public string Glass2Price;
    public string Glass3Price;

    //Masks
    public GameObject Image6;
    public GameObject Image7;
    public GameObject Image8;
    public GameObject Image9;
    public GameObject Image10;

    public TMP_Text Image6Name;
    public TMP_Text Image7Name;
    public TMP_Text Image8Name;
    public TMP_Text Image9Name;
    public TMP_Text Image10Name;

    public TMP_Text Image6Price;
    public TMP_Text Image7Price;
    public TMP_Text Image8Price;
    public TMP_Text Image9Price;
    public TMP_Text Image10Price;

    public Sprite Mask1;
    public Sprite Mask2;
    public Sprite Mask3;
    public Sprite Mask4;
    public Sprite Mask5;

    public string Mask1Name;
    public string Mask2Name;
    public string Mask3Name;
    public string Mask4Name;
    public string Mask5Name;

    public string Mask1Price;
    public string Mask2Price;
    public string Mask3Price;
    public string Mask4Price;
    public string Mask5Price;

    //Acessories
    public GameObject Image11;
    public GameObject Image12;
    public GameObject Image13;
    public GameObject Image14;
    public GameObject Image15;

    public TMP_Text Image11Name;
    public TMP_Text Image12Name;
    public TMP_Text Image13Name;
    public TMP_Text Image14Name;
    public TMP_Text Image15Name;

    public TMP_Text Image11Price;
    public TMP_Text Image12Price;
    public TMP_Text Image13Price;
    public TMP_Text Image14Price;
    public TMP_Text Image15Price;

    public Sprite Acc1;
    public Sprite Acc2;
    public Sprite Acc3;
    public Sprite Acc4;
    public Sprite Acc5;

    public string Acc1Name;
    public string Acc2Name;
    public string Acc3Name;
    public string Acc4Name;
    public string Acc5Name;

    public string Acc1Price;
    public string Acc2Price;
    public string Acc3Price;
    public string Acc4Price;
    public string Acc5Price;


    public Sprite sofa;

    
    //index 1 = roanne, $99 
    //index 2 = raybans, $200
    //index 3 = judith, $85
    //index 4 = Janice, $99
    //index 5 = nancy, $399

    public void ResetWidth()
    {
        PlayerPrefs.DeleteKey("width");
        PlayerPrefs.DeleteKey("depth");
        Debug.Log("resetted");
      

    }

    public void setWidth()
    {
        PlayerPrefs.SetFloat("width",10f);
        PlayerPrefs.SetFloat("depth",12f);
        Debug.Log("setted");

    }

    public void mockHistory()
    {
        int i = Random.Range(1, 4);
        Debug.Log("random number generated = " + i);

        addRecommendation(i);

     
    }

    public void clearHistory()
    {
        PlayerPrefs.DeleteKey("history_1");
        PlayerPrefs.DeleteKey("history_2");
        PlayerPrefs.DeleteKey("history_3");
        PlayerPrefs.DeleteKey("history_4");
        PlayerPrefs.DeleteKey("history_5");
    }

    public void addRecommendation(int val)
    {
        int i = PlayerPrefs.GetInt("count");
            i++;
        Debug.Log("current count " + i);

        if(i <6)
        { PlayerPrefs.SetInt("history_" + i, val); }
        else 
        {
            i = 1;
            PlayerPrefs.SetInt("history_" + i, val);
        }

        PlayerPrefs.SetInt("count", i);
        
        
    }

    public void SetImage()
    {
        //clearHistory();
        int index = 0;
        //Sprite FULLHP = Resources.Load<Sprite>("Assets/CYKO/Neumorphism UI Mega Pack/Jackson Wing Chair.G03.watermarked.2k.png");
        //gameObject.GetComponent<Image>().sprite = sofa;
        for (int i = 1; i<=5; i++)
        {
            index = PlayerPrefs.GetInt("history_" + i);

            GameObject ImageI = GameObject.Find("Image"+i);
            TMP_Text NameI = GameObject.Find("Name" + i).GetComponent<TMP_Text>();
            TMP_Text PriceI = GameObject.Find("Price" + i).GetComponent<TMP_Text>();


            switch (index)
            {
                case 1:
                    ImageI.GetComponent<Image>().sprite = Glass1;
                    NameI.text = Glass1Name;
                    PriceI.text = Glass1Price;
                    break;
                case 2:
                    ImageI.GetComponent<Image>().sprite = Glass2;
                    NameI.text = Glass2Name;
                    PriceI.text = Glass2Price;
                    break;
                case 3:
                    ImageI.GetComponent<Image>().sprite = Glass3;
                    NameI.text = Glass3Name;
                    PriceI.text = Glass3Price;
                    break;
                case 4:
                    ImageI.GetComponent<Image>().sprite = Glass1;
                    NameI.text = Glass1Name;
                    PriceI.text = Glass1Price;
                    break;
                case 5:
                    ImageI.GetComponent<Image>().sprite = Glass2;
                    NameI.text = Glass2Name;
                    PriceI.text = Glass2Price;
                    break;
                case 6:
                    ImageI.GetComponent<Image>().sprite = Mask1;
                    NameI.text = Mask1Name;
                    PriceI.text = Mask1Price;
                    break;
                case 7:
                    ImageI.GetComponent<Image>().sprite = Mask2;
                    NameI.text = Mask2Name;
                    PriceI.text = Mask2Price;
                    break;
                case 8:
                    ImageI.GetComponent<Image>().sprite = Mask3;
                    NameI.text = Mask3Name;
                    PriceI.text = Mask3Price;
                    break;
                case 9:
                    ImageI.GetComponent<Image>().sprite = Mask4;
                    NameI.text = Mask4Name;
                    PriceI.text = Mask4Price;
                    break;
                case 10:
                    ImageI.GetComponent<Image>().sprite = Mask5;
                    NameI.text = Mask5Name;
                    PriceI.text = Mask5Price;
                    break;
                case 11:
                    ImageI.GetComponent<Image>().sprite = Acc1;
                    NameI.text = Acc1Name;
                    PriceI.text = Acc1Price;
                    break;
                case 12:
                    ImageI.GetComponent<Image>().sprite = Acc2;
                    NameI.text = Acc2Name;
                    PriceI.text = Acc1Price;
                    break;
                case 13:
                    ImageI.GetComponent<Image>().sprite = Acc3;
                    NameI.text = Acc3Name;
                    PriceI.text = Acc3Price;
                    break;
                case 14:
                    ImageI.GetComponent<Image>().sprite = Acc4;
                    NameI.text = Acc4Name;
                    PriceI.text = Acc4Price;
                    break;
                case 15:
                    ImageI.GetComponent<Image>().sprite = Acc5;
                    NameI.text = Acc5Name;
                    PriceI.text = Acc5Price;
                    break;
                default:
                    // code block
                    break;
            }

        }
        //Image1.GetComponent<Image>().sprite = sofa;
    }

    public void testCustom()
    {
        PlayerPrefs.SetInt("C2Trait1", 1);
        PlayerPrefs.SetInt("C2Trait2", 0);
        PlayerPrefs.SetInt("C1Trait1", 1);
        PlayerPrefs.SetInt("C3Trait1", 1);
        



        //GameObject Custom1 = GameObject.Find("Logo1").GetComponent<MeshRenderer>();
    }
}
