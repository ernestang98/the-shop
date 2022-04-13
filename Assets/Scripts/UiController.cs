using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.XR.ARSubsystems;
using UnityEngine.XR.ARFoundation;
using UnityEngine.Networking;
using UnityEngine.UI;

public class UiController : MonoBehaviour
{

    private WebViewObject webViewObject;
    private const string url = "https://cz4001team1.herokuapp.com/checkout?";

    public GameObject g1Info;
    public GameObject g2Info;
    public GameObject g3Info;
    public GameObject g4Info;
    public GameObject g5Info;

    public GameObject InfoCanvas;
    public GameObject Menu;

    public Material g1Material;
    public Material g2Material;
    public Material g3Material;
    public Material g4Material;
    public Material g5Material;


    //glasses color
    public TMP_Text ARnamePlaceholder;
    public string ARCategory;
    public readonly string accessoryStr = "Accessories";
    public Material[] MaterialPlaceholder;
    public Color r, g, b, black;
    private Color gray = Color.gray;

    //public GameObject ARCam;

    // Start is called before the first frame update
    void Start()
    {
       // m_Session.Reset();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Disable()
    {
        InfoCanvas.SetActive(false);
        Menu.SetActive(true);
    }

    public void BackButton()
    {

        SceneManager.LoadScene(0);
    }

    public void G1InfoBoxEnable()
    {

        InfoCanvas.SetActive(true);
        g1Material.color = ARCategory != null && ARCategory.Equals(accessoryStr) ? gray : black;
        //g1Info.SetActive(true);
        //ARCam.SetActive(true);

    }

    public void G1InfoBoxDisable()
    {
   
        g1Info.SetActive(false);
        Menu.SetActive(true);
    }

    public void G2InfoBoxEnable()
    {
        InfoCanvas.SetActive(true);
        g2Material.color = ARCategory != null && ARCategory.Equals(accessoryStr) ? gray : black;
        //g2Info.SetActive(true);
        // ARCam.SetActive(true);
    }

    public void G2InfoBoxDisable()
    {
        
        g2Info.SetActive(false);
        Menu.SetActive(true);
    }

    public void G3InfoBoxEnable()
    {
        InfoCanvas.SetActive(true);
        g3Material.color = ARCategory != null && ARCategory.Equals(accessoryStr) ? gray : black;
        // g3Info.SetActive(true);

    }

    public void G3InfoBoxDisable()
    {
        g3Info.SetActive(false);
        Menu.SetActive(true);
    }

    public void G4InfoBoxEnable()
    {
        InfoCanvas.SetActive(true);
        g4Material.color = ARCategory != null && ARCategory.Equals(accessoryStr) ? gray : black;
        // g4Info.SetActive(true);

    }

    public void G4InfoBoxDisable()
    {
        g4Info.SetActive(false);
        Menu.SetActive(true);
    }

    public void G5InfoBoxEnable()
    {
        InfoCanvas.SetActive(true);
        g5Material.color = ARCategory != null && ARCategory.Equals(accessoryStr) ? gray : black;
        // g5Info.SetActive(true);

    }

    public void G5InfoBoxDisable()
    {
        g5Info.SetActive(false);
        Menu.SetActive(true);
    }

    public void ToggleColor()
    {
        string check;
        int glassindex = 0;
        //red,green,blue,black
        check = ARnamePlaceholder.GetParsedText();
        Debug.Log(check);

        if (check == "Roanne" || check == "Alien Mask")
        {
            glassindex = 0;
            string buttonName = EventSystem.current.currentSelectedGameObject.name;


            if (buttonName == "Color1")
            {
                g1Material.color = r;
            }

            if (buttonName == "Color2")
            {
                g1Material.color = g;
            }

            if (buttonName == "Color3")
            {
                g1Material.color = b;
            }
        }
        else if (check == "Raybans" || check == "Beast Mask")
        {
            glassindex = 1;
            glassindex = 0;
            string buttonName = EventSystem.current.currentSelectedGameObject.name;


            if (buttonName == "Color1")
            {
                g2Material.color = r;
            }

            if (buttonName == "Color2")
            {
                g2Material.color = g;
            }

            if (buttonName == "Color3")
            {
                g2Material.color = b;
            }
        }
        else if (check == " Judith" || check == "Clown Mask")
        {
            glassindex = 2;
            glassindex = 0;
            string buttonName = EventSystem.current.currentSelectedGameObject.name;


            if (buttonName == "Color1")
            {
                g3Material.color = r;
            }

            if (buttonName == "Color2")
            {
                g3Material.color = g;
            }

            if (buttonName == "Color3")
            {
                g3Material.color = b;
            }
        }
        else if (check == "Fancy Mask")
        {
            glassindex = 3;
            glassindex = 0;
            string buttonName = EventSystem.current.currentSelectedGameObject.name;


            if (buttonName == "Color1")
            {
                g4Material.color = r;
            }

            if (buttonName == "Color2")
            {
                g4Material.color = g;
            }

            if (buttonName == "Color3")
            {
                g4Material.color = b;
            }
        }
        else if (check == "Skull Mask")
        {
            glassindex = 4;
            glassindex = 0;
            string buttonName = EventSystem.current.currentSelectedGameObject.name;


            if (buttonName == "Color1")
            {
                g5Material.color = r;
            }

            if (buttonName == "Color2")
            {
                g5Material.color = g;
            }

            if (buttonName == "Color3")
            {
                g5Material.color = b;
            }
        }
        else
        {
            glassindex = 0;
        }
    }

    public void ToggleAllColor()
    {
        string buttonName = EventSystem.current.currentSelectedGameObject.name;

        if (buttonName == "Color1")
        {
            g1Material.color = r;
            g2Material.color = r;
            g3Material.color = r;
            g4Material.color = r;
            g5Material.color = r;
        }

        if (buttonName == "Color2")
        {
            g1Material.color = g;
            g2Material.color = g;
            g3Material.color = g;
            g4Material.color = g;
            g5Material.color = g;
        }

        if (buttonName == "Color3")
        {
            g1Material.color = b;
            g2Material.color = b;
            g3Material.color = b;
            g4Material.color = b;
            g5Material.color = b;
        }

        if (buttonName == "Color4")
        {
            g1Material.color = black;
            g2Material.color = black;
            g3Material.color = black;
            g4Material.color = black;
            g5Material.color = black;
        }
    }
           
        


    public void Glasses1ColorChange()
    {
       string buttonName = EventSystem.current.currentSelectedGameObject.name;

        if (buttonName == "BlackColorButton")
        {
            g1Material.color = new Color(0, 0, 0);
        }

        if (buttonName == "PinkColorButton")
        {
            g1Material.color = new Color(244f/255f, 194f/255f, 194f / 255f);
        }
    }

    public void Glasses2ColorChange()
    {

        string buttonName = EventSystem.current.currentSelectedGameObject.name;
        if (buttonName == "BlackColorButton")
        {
            g2Material.color = new Color(0, 0, 0);
        }

        if (buttonName == "PinkColorButton")
        {
            g2Material.color = new Color(244f / 255f, 194f / 255f, 194f / 255f);
        }
    }

    public void Glasses3ColorChange()
    {

        string buttonName = EventSystem.current.currentSelectedGameObject.name;
        if (buttonName == "BlackColorButton")
        {
            g3Material.color = new Color(0, 0, 0);
        }

        if (buttonName == "PinkColorButton")
        {
            g3Material.color = new Color(244f / 255f, 194f / 255f, 194f / 255f);
        }
    }

    public void Glasses4ColorChange()
    {

        string buttonName = EventSystem.current.currentSelectedGameObject.name;
        if (buttonName == "BlackColorButton")
        {
            g4Material.color = new Color(0, 0, 0);
        }

        if (buttonName == "PinkColorButton")
        {
            g4Material.color = new Color(244f / 255f, 194f / 255f, 194f / 255f);
        }
    }

    public void Glasses5ColorChange()
    {

        string buttonName = EventSystem.current.currentSelectedGameObject.name;
        if (buttonName == "BlackColorButton")
        {
            g5Material.color = new Color(0, 0, 0);
        }

        if (buttonName == "PinkColorButton")
        {
            g5Material.color = new Color(244f / 255f, 194f / 255f, 194f / 255f);
        }
    }

    public void BuyG1()
    {
/*        Application.OpenURL("https://www.amazon.in/Blueray-Protected-Bluecut-Computer-Rectangle/dp/B0825WJML8");*/
        callPaymentGateway();
    }

    public void BuyG2()
    {
        callPaymentGateway();
    }

    public void BuyG3()
    {
        callPaymentGateway();
    }

    public void BuyG4()
    {
        callPaymentGateway();
    }

    public void BuyG5()
    {
        callPaymentGateway();
    }

    private void callPaymentGateway()
    {
        string stripe_id = PlayerPrefs.GetString("stripe_id");
        this.webViewObject = new GameObject("WebViewObject").AddComponent<WebViewObject>();

        // Find the margin
        int mX = Screen.width / 18;
        int mY = Screen.height / 10;

        this.webViewObject.Init((msg) =>
        {
            switch (msg)
            {
                case "scene name":
                    this.webViewObject.SetVisibility(false);
                    Destroy(this.webViewObject);
                    SceneManager.LoadScene(msg);
                    break;

                case "close":
                    this.webViewObject.SetVisibility(false);
                    Destroy(this.webViewObject);
                    Destroy(GameObject.Find("WebViewObjectOrigin (Clone)").gameObject);
                    break;
            }
        });

        /*        string sample_description = System.Uri.EscapeUriString("Hello I am a descirption with special chars !@#$");*/
        string sample_description = UnityWebRequest.EscapeURL("TESTING with special chars !@#$");
        int sample_amount = 1000;
        /*        string sample_customer = PlayerPrefs.GetString("stripe_id");*/
        string sample_customer = "cus_LKzYeuTWB0Qr3U";
        string sample_currency = "SGD";

        this.webViewObject.LoadURL(generatePaymentGatewayUrl(sample_description, sample_amount, sample_customer, sample_currency));
/*        this.webViewObject.SetMargins(mX, mY, mX, mY);*/
        this.webViewObject.SetMargins(mX, mX, mX, mX);
        this.webViewObject.SetVisibility(true);
        
        StartCoroutine(hotfixForCreateButton(this.webViewObject));
/*         createCloseButtonForPaymentGatewayUnityWebView(); */

    }

    private string generatePaymentGatewayUrl(string description, int amount, string sample_customer, string sample_currency)
    {
        return url +
            "amount=" + amount.ToString() +
            "&description=" + description +
            "&customer=" + sample_customer +
            "&currency=" + sample_currency +
            "&transaction=true";
    }


    void createCloseButtonForPaymentGatewayUnityWebView()
    {
        GameObject mCanvas = GameObject.Find("MyCanvas");
        GameObject button = new GameObject();
        button.AddComponent<CanvasRenderer>();
        button.AddComponent<RectTransform>();

        Button mButton = button.AddComponent<Button>();
        Image mImage = button.AddComponent<Image>();
        mButton.targetGraphic = mImage;

        mButton.GetComponent<RectTransform>().anchorMin = new Vector2(50.0f, 50.0f);
        mButton.GetComponent<RectTransform>().anchorMax = new Vector2(1000.0f, 1000.0f);

        button.transform.position = new Vector3(Screen.width + 10, Screen.height + 10, 0);
        button.transform.SetParent(mCanvas.transform);
        button.GetComponent<Button>().onClick.AddListener(CompletePayment);
    }

    void CompletePayment()
    {
        this.webViewObject.SetVisibility(false);
        Destroy(this.webViewObject);
        Destroy(GameObject.Find("WebViewObjectOrigin (Clone)").gameObject);
        GameObject button = GameObject.Find("New Game Object");
        Destroy(button);
    }
    
    IEnumerator hotfixForCreateButton(WebViewObject hotfix)
    {
        yield return new WaitForSeconds(15);
        Destroy(hotfix);
        this.webViewObject.SetVisibility(false);
        Destroy(this.webViewObject);
        Destroy(GameObject.Find("WebViewObjectOrigin (Clone)").gameObject);
        Debug.Log("ByeBye");
    }

}
