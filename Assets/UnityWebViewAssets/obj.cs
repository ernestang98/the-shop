using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class obj : MonoBehaviour
{


    private WebViewObject webViewObject;
    public const string url = "https://cz4001team1.herokuapp.com/checkout?amount=5100&description=i%20am%20from%20unity...really&transaction=true";

    // Use this for initialization
    void Start()
    {
        this.gameObject.SetActive(false);
        // Generate
        this.webViewObject = new GameObject("WebViewObject").AddComponent<WebViewObject>();

        // Find the margin
        int mX = Screen.width / 9;
        int mY = Screen.height / 5;

        // Timestamp for avoiding cache
        // string date ='?' + DateTime.Now.ToString ();


        // Callback settings
        this.webViewObject.Init((msg) =>
        {
            switch (msg)
            {
                case "scene name":

                    // Stop WebView

                    this.webViewObject.SetVisibility(false);
                    Destroy(this.webViewObject);

                    // Scene transition
                    SceneManager.LoadScene(msg);
                    break;

                case "close":
                    // Stop WebView
                    this.webViewObject.SetVisibility(false);
                    Destroy(this.webViewObject);

                    Destroy(GameObject.Find("WebViewObjectOrigin (Clone)").gameObject);
                    break;
            }
        });

        // URL setting
        this.webViewObject.LoadURL(url);

        // Margin setting
        this.webViewObject.SetMargins(mX, mY, mX, mY);

        // Enable WebView
        this.webViewObject.SetVisibility(true);
    }
}