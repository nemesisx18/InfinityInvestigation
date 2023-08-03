using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputUsername : MonoBehaviour
{
    public InputField UserInputField;
    
    public string Username;

    public void SubmitName()
    {
        SaveName(UserInputField.text);
        UserInputField.enabled = false;
    }

    public void SaveName(string newName)
    {
        Username = newName;
        Debug.Log(Username);

        SaveData.SaveInstance.SetUsername(Username);
    }
}
