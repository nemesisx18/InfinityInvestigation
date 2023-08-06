using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShareFacebook : MonoBehaviour
{
    public void OnClickShare()
    {
        Application.OpenURL("https://www.facebook.com/sharer.php?u=http%3A%2F%2Ffacebook.com");
    }
}
