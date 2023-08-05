using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class recharge : MonoBehaviour
{
    public Stats Stats;
    
    // Start is called before the first frame update
    void Start()
    {
        Invoke("rechargee", 120);
    }

    public void rechargee()
    {
        int total = PlayerPrefs.GetInt("energy");
        total += 50;
        PlayerPrefs.SetInt("energy", total);
        Invoke("rechargee", 120);

    }

    public void relog()
    {
        SceneManager.LoadScene("Menu");
        Stats.DefaultStats();
    }
}
