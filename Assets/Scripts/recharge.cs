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
        Invoke("rechargee", 60);
    }

    [ContextMenu("rechare enegry")]
    public void rechargee()
    {
        int total = PlayerPrefs.GetInt("energy");
        Debug.Log(total);
        if(total >= 50)
        {
            return;
        }

        int currentEnergy = total;
        Debug.Log("Before rechareg: " + currentEnergy);
        total += 50;
        Debug.Log("Rechare: " + total);
        if(total > 50)
        {
            total -= currentEnergy;
            Debug.Log("after limitation " + total);
        }

        Debug.Log("After recharge if more than 50: " + total);

        PlayerPrefs.SetInt("energy", total);
        Invoke("rechargee", 60);

    }

    public void relog()
    {
        SceneManager.LoadScene("Menu");
        Stats.DefaultStats();
    }
}
