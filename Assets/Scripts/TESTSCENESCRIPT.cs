using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using SimpleJSON;
using Firebase.Database;
using Firebase;
using Firebase.Auth;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TESTSCENESCRIPT : MonoBehaviour
{
    private WebViewObject webViewObject;
    //Firebase variables
    [Header("Firebase")]
    public DependencyStatus dependencyStatus;
    public FirebaseAuth auth;
    public FirebaseUser User;
    public DatabaseReference DBreference;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Awake()
    {
        /*        //Check that all of the necessary dependencies for Firebase are present on the system
                FirebaseApp.CheckAndFixDependenciesAsync().ContinueWith(task =>
                {
                    dependencyStatus = task.Result;
                    if (dependencyStatus == DependencyStatus.Available)
                    {
                        //If they are avalible Initialize Firebase
                        InitializeFirebase();
                    }
                    else
                    {
                        Debug.LogError("Could not resolve all Firebase dependencies: " + dependencyStatus);
                    }
                });*/
             callPaymentGateway();

        testFunc();
    }

    private void InitializeFirebase()
    {
        Debug.Log("Setting up Firebase Auth");
        //Set the authentication instance object
        auth = FirebaseAuth.DefaultInstance;
        DBreference = FirebaseDatabase.DefaultInstance.RootReference;
        StartCoroutine(CreateStripeCustomerCoroutine("asd"));
        StartCoroutine(CreateStripeCustomerCoroutine("asd"));
    }

    private IEnumerator CreateStripeCustomerCoroutine(string name)
    {
        string secret_string = "sk_test_51KcPbQL4OxezbF8Iwn5FwUy3aF6QFVhNNRnVSOTrNlYv6pmmLhhDd0gc4QzslO1jVV8yUkt8o8cFkvC8N9JNWXug00JmQq6Koe";
        WWWForm form = new WWWForm();
        form.AddField("description", $"{name}");
        form.AddField("email", $"{name}@{name}.com");
        form.AddField("name", $"{name}");

        UnityWebRequest www = UnityWebRequest.Post("https://api.stripe.com/v1/customers", form);
        www.SetRequestHeader("Content-Type", "application/x-www-form-urlencoded");
        www.SetRequestHeader("Authorization", $"Bearer {secret_string}");

        yield return www.SendWebRequest();

        if (www.result != UnityWebRequest.Result.Success)
        {
            Debug.Log(www.error);
        }

        else
        {
            // Copy pasted from SSAD project, not sure if it will work or not lol...
            Debug.Log("Form upload complete!");
            var jsonstring = www.downloadHandler.text;
            Debug.Log($"Output: {jsonstring}");
            var json = JSON.Parse(jsonstring);
            // var obj = json[0];
            string customer_id = json["id"];
            // Add logic to create firebase record with stripe details
            // Download and add SimpleJSON parser to project https://github.com/Bunny83/SimpleJSON   
            StartCoroutine(CreateNewUserInFirebaseDatabaseCoroutine(name, customer_id));
        }
    }

    private IEnumerator CreateNewUserInFirebaseDatabaseCoroutine(string name, string stripe_id)
    {
        //Set the currently logged in user xp
        var DBTask = DBreference.Child("users").Child(NameConversion(name)).GetValueAsync();

        yield return new WaitUntil(predicate: () => DBTask.IsCompleted);

        if (DBTask.Exception != null)
        {
            Debug.LogWarning(message: $"Failed to register task with {DBTask.Exception}");
        }
        else
        {
            if (DBTask.Result.GetValue(true) == null)
            {
                var DBTask1 = DBreference.Child("users").Child(NameConversion(name)).Child("name").SetValueAsync(name);
                yield return new WaitUntil(predicate: () => DBTask1.IsCompleted);
                if (DBTask1.Exception != null)
                {
                    Debug.LogWarning(message: $"Failed to register task 1 with {DBTask1.Exception}");
                }
                else
                {
                    var DBTask2 = DBreference.Child("users").Child(NameConversion(name)).Child("stripe_id").SetValueAsync(stripe_id);
                    yield return new WaitUntil(predicate: () => DBTask2.IsCompleted);
                    if (DBTask2.Exception != null)
                    {
                        Debug.LogWarning(message: $"Failed to register task 2 with {DBTask2.Exception}");
                    }
                    else
                    {

                    }
                }
            }
            else
            {
                Debug.LogWarning(message: $"User {name} already exists...");
            }
        }
    }

    private string NameConversion(string name, bool toRemoveSpace = true)
    {
        if (toRemoveSpace)
        {
            return name.Replace(" ", "_");
        }
        return name.Replace("_", " ");
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
        string sample_description = UnityWebRequest.EscapeURL("Hello I !@#$");
        int sample_amount = 1255;
        /*        string sample_customer = PlayerPrefs.GetString("stripe_id");*/
        string sample_customer = "cus_LKzYeuTWB0Qr3U";
        string sample_currency = "SGD";

        this.webViewObject.LoadURL(generatePaymentGatewayUrl(sample_description, sample_amount, sample_customer, sample_currency));
        this.webViewObject.SetMargins(mX, mY, mX, mY);
        this.webViewObject.SetVisibility(true);
    }

    private string generatePaymentGatewayUrl(string description, int amount, string sample_customer, string sample_currency)
    {
        return "https://cz4001team1.herokuapp.com/checkout?" +
            "amount=" + amount.ToString() +
            "&description=" + description +
            "&customer=" + sample_customer +
            "&currency=" + sample_currency +
            "&transaction=true";
    }

    void testFunc()
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

        button.transform.position = new Vector3(Screen.width + 50, Screen.height + 50, 0);
        button.transform.SetParent(mCanvas.transform);
        button.GetComponent<Button>().onClick.AddListener(TestMethod);

    }

    void TestMethod()
    {
        Debug.Log("Button pressed");
        GameObject button = GameObject.Find("New Game Object");
        Destroy(this.webViewObject);
        Destroy(GameObject.Find("WebViewObjectOrigin(Clone)").gameObject);
       
        Destroy(button);
        
    }

}
