using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputUsername : MonoBehaviour
{
    public InputField UserInputField;
    public GameObject Warning;
    public GameObject NextScene;
    
    public string Username;

    public bool sameUsername = false;

    public void SubmitName()
    {
        SaveName(UserInputField.text);
        UserInputField.enabled = false;
    }

    public void SaveName(string newName)
    {
        Username = newName;
        Debug.Log(Username);

        for (int i = 0; i < SaveData.SaveInstance.Leaderboard_1.Count; i++)
        {
            if (SaveData.SaveInstance.Leaderboard_1[i].Username.Contains(Username))
            {
                sameUsername = true;
                break;
            }
        }

        if(sameUsername)
        {
            Warning.SetActive(true);
            
            UserInputField.text = "";
            Invoke("Deactive", 1.3f);
            return;
        }

        SaveData.SaveInstance.SetUsername(Username);
        NextScene.SetActive(true);
    }

    private void Deactive()
    {
        Warning.SetActive(false);
        UserInputField.enabled = true;
        sameUsername = false;
    }
}
