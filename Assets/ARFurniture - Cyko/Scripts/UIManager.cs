using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    public static int index;
    public Sprite[] sprites;
    public TMP_Text[] names;
    public TMP_Text[] prices;
    public TMP_Text[] descripts;
    public TMP_Text[] w;
    public TMP_Text[] l;
    public TMP_Text[] d;
    public Image chairImage;
    public TMP_Text namePlaceholder;
    public TMP_Text pricesPlaceholder;
    public TMP_Text descriptsPlaceholder;
    public TMP_Text wPlaceholder;
    public TMP_Text lPlaceholder;
    public TMP_Text dPlaceholder;

    public Button[] buttonPlaceholder;
    public GameObject[] infoPlaceholder;
    public GameObject Menu;

    //AR UI
    public TMP_Text ARnamePlaceholder;
    public TMP_Text ARpricePlaceholder;

    //payment & Success UI
    public Image PaymentPlaceholder;
    public TMP_Text PaymentnamePlaceholder;
    public TMP_Text PaymentpricePlaceholder;

    public Image SuccessPlaceholder;
    public TMP_Text SuccessnamePlaceholder;
    public TMP_Text SuccesspricePlaceholder;

    public GameObject glasses1;
    public GameObject glasses2;
    public GameObject glasses3;
    public GameObject glasses4;
    public GameObject glasses5;


    private void Awake()
    {
        index = 0;
    }

   

    public void SetImage(int i)
    {
        index = i;
        chairImage.sprite = sprites[i];
        namePlaceholder.SetText(names[i].GetParsedText());
        pricesPlaceholder.SetText(prices[i].GetParsedText());
        descriptsPlaceholder.SetText(descripts[i].GetParsedText());
        wPlaceholder.SetText(w[i].GetParsedText());
        lPlaceholder.SetText(l[i].GetParsedText());
        dPlaceholder.SetText(d[i].GetParsedText());

        //AR UI
        ARpricePlaceholder.SetText(prices[i].GetParsedText());
        ARnamePlaceholder.SetText(names[i].GetParsedText());

        //Payment & Success Canvas
        PaymentPlaceholder.sprite = sprites[i];
        PaymentpricePlaceholder.SetText(prices[i].GetParsedText());
        PaymentnamePlaceholder.SetText(names[i].GetParsedText());

        SuccessPlaceholder.sprite = sprites[i];
        SuccesspricePlaceholder.SetText(prices[i].GetParsedText());
        SuccessnamePlaceholder.SetText(names[i].GetParsedText());


    }

    public void SetActive()
    {
       
        Menu.SetActive(false);
        buttonPlaceholder[index].onClick.Invoke();
        //infoPlaceholder[i].SetActive(true);
     

    }

}
