using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveGame : MonoBehaviour
{

    public GameObject k1, k2 ,k3;
    public int checkpoint;

    // Start is called before the first frame update
    void Awake()
    {
        checkpoint = PlayerPrefs.GetInt("save");
    }

    void Start()
    {
        if(checkpoint == 1)
        {
            k1.SetActive(true);
        }
        if (checkpoint == 2)
        {
            k2.SetActive(true);
        }
        if (checkpoint == 3)
        {
            k3.SetActive(true);
        }
    }


    public void save(int savekeberapa)
    {
        PlayerPrefs.SetInt("save", savekeberapa);
    }

}
