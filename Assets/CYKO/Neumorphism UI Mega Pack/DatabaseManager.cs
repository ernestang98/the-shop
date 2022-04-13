using Firebase.Database;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DatabaseManager : MonoBehaviour
{
    public TMP_Text email;
    public TMP_Text width;
    public TMP_Text depth;
    public TMP_Text model;

    private string userID;
    private DatabaseReference dbReference;
    // Start is called before the first frame update
    void Start()
    {
        userID = SystemInfo.deviceUniqueIdentifier;
       //DatabaseReference reference = FirebaseDatabase.DefaultInstance.RootReference;
    }

    public void CreateUser()
    {
        string email = "test@hotmail.com";
        float width = 12.5f;
        float depth = 12.6f;
        string model = "raybans";
        User newUser = new User(email, width, depth, model);
        //User newUser = new User(email.text, float.Parse(width.text), float.Parse(depth.text), model.text);
        string json = JsonUtility.ToJson(newUser);

       dbReference.Child("users").Child(userID).SetRawJsonValueAsync(json);
    }
}
