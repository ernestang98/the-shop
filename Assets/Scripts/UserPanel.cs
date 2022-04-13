using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class UserPanel : MonoBehaviour
{
    public TMP_Text MainMenuName;
    public TMP_Text UserPanelName;
    public GameObject ScanFaceFirst;
    bool scanned = false;
    public TMP_Text width;
    public TMP_Text depth;
    public string popUp;
    // Start is called before the first frame update
    public void Login()
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
}
