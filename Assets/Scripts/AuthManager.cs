using System.Collections;
using UnityEngine;
using Firebase;
using Firebase.Auth;
using TMPro;
using UnityEngine.SceneManagement;

using UnityEngine.Networking;
using SimpleJSON;
using Firebase.Database;

public class AuthManager : MonoBehaviour
{
    //Firebase variables
    [Header("Firebase")]
    public DependencyStatus dependencyStatus;
    public FirebaseAuth auth;
    public FirebaseUser User;
    public DatabaseReference DBreference;

    //Login variables
    [Header("Login")]
    public TMP_InputField emailLoginField;
    public TMP_InputField passwordLoginField;
    public TMP_Text warningLoginText;
    public TMP_Text confirmLoginText;

    

    //Register variables
    [Header("Register")]
    public TMP_InputField usernameRegisterField;
    public TMP_InputField emailRegisterField;
    public TMP_InputField passwordRegisterField;
    public TMP_InputField passwordRegisterVerifyField;
    public TMP_Text warningRegisterText;

    public GameObject RegMenu;
    public GameObject CreateMenu;
    public GameObject MainMenu;
    public TMP_Text MainMenuName;
    public TMP_Text UserPanelName;
    public TMP_Text width;
    public TMP_Text depth;
    public string popUp;
    public GameObject Popup;

    void Awake()
    {
        //Check that all of the necessary dependencies for Firebase are present on the system
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
        });
    }

    void Start()
    {
        if (PlayerPrefs.GetString("User") != "")
        {
            Login();
            MainMenu.SetActive(true);
        }
       
    }

    public void StartShopping()

    {
        if (PlayerPrefs.GetFloat("width", 0) == 0)
        {
            // ScanFaceFirst.enabled = true;

            // ScanFaceFirst.gameObject.SetActive(true);

            Popup.SetActive(true);

        }
        else
        {
            Debug.Log("load shopping scene here");
           SceneManager.LoadScene(2);
        }

    }

    public void StartShoppingAcc()

    {
        if (PlayerPrefs.GetFloat("width", 0) == 0)
        {
            // ScanFaceFirst.enabled = true;

            // ScanFaceFirst.gameObject.SetActive(true);

            Popup.SetActive(true);

        }
        else
        {
            Debug.Log("load shopping scene here");
            SceneManager.LoadScene(4);
        }

    }

    public void StartShoppingKids()

    {
        if (PlayerPrefs.GetFloat("width", 0) == 0)
        {
            // ScanFaceFirst.enabled = true;

            // ScanFaceFirst.gameObject.SetActive(true);

            Popup.SetActive(true);

        }
        else
        {
            Debug.Log("load shopping scene here");
            SceneManager.LoadScene(3);
        }

    }

    public void ScanFace()
    {
        SceneManager.LoadScene(1);
    }


    // Start is called before the first frame update
    private void Login()
    {
        Debug.Log(PlayerPrefs.GetString("User"));
        MainMenuName.text = PlayerPrefs.GetString("User");
        Debug.Log(PlayerPrefs.GetString("User"));
        UserPanelName.text = PlayerPrefs.GetString("User");

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

    private void InitializeFirebase()
    {
        Debug.Log("Setting up Firebase Auth");
        //Set the authentication instance object
        auth = FirebaseAuth.DefaultInstance;
        DBreference = FirebaseDatabase.DefaultInstance.RootReference;
    }

    public void LogoutButton()
    {
        PlayerPrefs.SetString("User", "");
        
    }

    //Function for the login button
    public void LoginButton()
    {
        //Call the login coroutine passing the email and password
        StartCoroutine(Login(emailLoginField.text, passwordLoginField.text));
    }
    //Function for the register button
    public void RegisterButton()
    {
        //Call the register coroutine passing the email, password, and username
        StartCoroutine(Register(emailRegisterField.text, passwordRegisterField.text, usernameRegisterField.text));
    }

    private IEnumerator Login(string _email, string _password)
    {
        //Call the Firebase auth signin function passing the email and password
        var LoginTask = auth.SignInWithEmailAndPasswordAsync(_email, _password);
        //Wait until the task completes
        yield return new WaitUntil(predicate: () => LoginTask.IsCompleted);

        if (LoginTask.Exception != null)
        {
            //If there are errors handle them
            Debug.LogWarning(message: $"Failed to register task with {LoginTask.Exception}");
            FirebaseException firebaseEx = LoginTask.Exception.GetBaseException() as FirebaseException;
            AuthError errorCode = (AuthError)firebaseEx.ErrorCode;

            string message = "Login Failed!";
            switch (errorCode)
            {
                case AuthError.MissingEmail:
                    message = "Missing Email";
                    break;
                case AuthError.MissingPassword:
                    message = "Missing Password";
                    break;
                case AuthError.WrongPassword:
                    message = "Wrong Password";
                    break;
                case AuthError.InvalidEmail:
                    message = "Invalid Email";
                    break;
                case AuthError.UserNotFound:
                    message = "Account does not exist";
                    break;
            }
            warningLoginText.text = message;
        }
        else
        {
            //User is now logged in
            //Now get the result
            
            User = LoginTask.Result;
            PlayerPrefs.SetString("User", emailLoginField.text);
            Debug.LogFormat("User signed in successfully: {0} ({1})", User.DisplayName, User.Email);
            warningLoginText.text = "";
            //confirmLoginText.text = "Logged In";
            Login();
            MainMenu.SetActive(true);
            StartCoroutine(LoginAndSetStripeCustomerIdPlayerPrefsCoroutine(_email));

        }
    }

    private IEnumerator LoginAndSetStripeCustomerIdPlayerPrefsCoroutine(string email)
    {
        var DBTask = DBreference.Child("users").Child(EmailConversion(email)).Child("stripe_id").GetValueAsync();

        yield return new WaitUntil(predicate: () => DBTask.IsCompleted);

        if (DBTask.Exception != null)
        {
            Debug.LogWarning(message: $"Failed to register task with {DBTask.Exception}");
        }
        else
        {
            if (DBTask.Result.GetValue(true) != null)
            {
                string customer_id = DBTask.Result.GetValue(true).ToString();
                Debug.Log(message: $"customer_id obtained: {customer_id}");
                PlayerPrefs.SetString("stripe_id", customer_id);
            }
            else
            {
                Debug.LogWarning(message: $"User {email} does not exist...");
            }
        }
    }

    private IEnumerator Register(string _email, string _password, string _username)
    {
        if (_username == "")
        {
            //If the username field is blank show a warning
            warningRegisterText.text = "Missing Username";
        }
        else if (passwordRegisterField.text != passwordRegisterVerifyField.text)
        {
            //If the password does not match show a warning
            warningRegisterText.text = "Password Does Not Match!";
        }
        else
        {
            //Call the Firebase auth signin function passing the email and password
            var RegisterTask = auth.CreateUserWithEmailAndPasswordAsync(_email, _password);
            //Wait until the task completes
            yield return new WaitUntil(predicate: () => RegisterTask.IsCompleted);

            if (RegisterTask.Exception != null)
            {
                //If there are errors handle them
                Debug.LogWarning(message: $"Failed to register task with {RegisterTask.Exception}");
                FirebaseException firebaseEx = RegisterTask.Exception.GetBaseException() as FirebaseException;
                AuthError errorCode = (AuthError)firebaseEx.ErrorCode;

                string message = "Register Failed!";
                switch (errorCode)
                {
                    case AuthError.MissingEmail:
                        message = "Missing Email";
                        break;
                    case AuthError.MissingPassword:
                        message = "Missing Password";
                        break;
                    case AuthError.WeakPassword:
                        message = "Weak Password";
                        break;
                    case AuthError.EmailAlreadyInUse:
                        message = "Email Already In Use";
                        break;
                }
                warningRegisterText.text = message;
            }
            else
            {
                //User has now been created
                //Now get the result
                User = RegisterTask.Result;

                if (User != null)
                {
                    //Create a user profile and set the username
                    UserProfile profile = new UserProfile { DisplayName = _username };

                    //Call the Firebase auth update user profile function passing the profile with the username
                    var ProfileTask = User.UpdateUserProfileAsync(profile);
                    //Wait until the task completes
                    yield return new WaitUntil(predicate: () => ProfileTask.IsCompleted);

                    if (ProfileTask.Exception != null)
                    {
                        //If there are errors handle them
                        Debug.LogWarning(message: $"Failed to register task with {ProfileTask.Exception}");
                        FirebaseException firebaseEx = ProfileTask.Exception.GetBaseException() as FirebaseException;
                        AuthError errorCode = (AuthError)firebaseEx.ErrorCode;
                        warningRegisterText.text = "Username Set Failed!";
                    }
                    else
                    {
                        //Username is now set
                        //Now return to login screen
                        //UIManager.instance.LoginScreen();
                        PlayerPrefs.SetString("User", _username);
                        Login();

                        MainMenu.SetActive(true);
                        RegMenu.SetActive(false);
                        CreateMenu.SetActive(false);
                        warningRegisterText.text = "";
                        StartCoroutine(CreateStripeCustomerCoroutine(_username, _email));
                    }
                }
            }
        }
    }

    private IEnumerator CreateStripeCustomerCoroutine(string name, string email)
    {
        string secret_string = "sk_test_51KcPbQL4OxezbF8Iwn5FwUy3aF6QFVhNNRnVSOTrNlYv6pmmLhhDd0gc4QzslO1jVV8yUkt8o8cFkvC8N9JNWXug00JmQq6Koe";
        WWWForm form = new WWWForm();
        form.AddField("description", $"{name}");
        form.AddField("email", $"{email}");
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
            PlayerPrefs.SetString("stripe_id", customer_id);
            StartCoroutine(CreateNewUserInFirebaseDatabaseCoroutine(name, customer_id, email));            
        }
    }

    private IEnumerator CreateNewUserInFirebaseDatabaseCoroutine(string name, string stripe_id, string email)
    {
        //Set the currently logged in user xp
        var DBTask = DBreference.Child("users").Child(EmailConversion(email)).GetValueAsync();

        yield return new WaitUntil(predicate: () => DBTask.IsCompleted);

        if (DBTask.Exception != null)
        {
            Debug.LogWarning(message: $"Failed to register task with {DBTask.Exception}");
        }
        else
        {
            if (DBTask.Result.GetValue(true) == null)
            {
               var DBTask1 = DBreference.Child("users").Child(EmailConversion(email)).Child("name").SetValueAsync(name);
                yield return new WaitUntil(predicate: () => DBTask1.IsCompleted);
                if (DBTask1.Exception != null)
                {
                    Debug.LogWarning(message: $"Failed to register task 1 with {DBTask1.Exception}");
                }
                else
                {
                    var DBTask2 = DBreference.Child("users").Child(EmailConversion(email)).Child("stripe_id").SetValueAsync(stripe_id);
                    yield return new WaitUntil(predicate: () => DBTask2.IsCompleted);
                    if (DBTask2.Exception != null)
                    {
                        Debug.LogWarning(message: $"Failed to register task 2 with {DBTask2.Exception}");
                    }
                    else
                    {
                        var DBTask3 = DBreference.Child("users").Child(EmailConversion(email)).Child("email").SetValueAsync(email);
                        yield return new WaitUntil(predicate: () => DBTask3.IsCompleted);
                        if (DBTask3.Exception != null)
                        {
                            Debug.LogWarning(message: $"Failed to register task 3 with {DBTask3.Exception}");
                        }
                        else
                        {    

                        }

                    }
                }
            }
            else
            {
                Debug.LogWarning(message: $"User {email} already exists...");
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

    private string EmailConversion(string name, bool toRemoveSpace = true)
    {
//         https://stackoverflow.com/questions/20363052/cant-post-data-containing-in-a-key-to-firebase/20363114#20363114
//
//         if (toRemoveSpace)
//         {
//             name = name.Replace("@", "AATT");
//             return name.Replace(".", "DDOOTT");
//         }
//         name = name.Replace("AATT", "@");
//         return name.Replace("DDOOTT", ".");
        
        if (toRemoveSpace)
        {
            return name.Replace(".", "_");
        }
        return name.Replace("_", ".");
    }


}
