using UnityEngine;
using UnityEngine.UI;

public class Stats : MonoBehaviour
{
    Text textStats;
    public bool energy;
    private int totalEnergy, totalCoin;

    public void Update()
    {
        totalCoin = PlayerPrefs.GetInt("coin"); 
        totalEnergy = PlayerPrefs.GetInt("energy");
    }
    private void Start()
    {
        textStats = GetComponent<Text>();
        // Menginisialisasi total energi awal

        if(PlayerPrefs.GetInt("NP") == 1)
        {
            totalEnergy = PlayerPrefs.GetInt("energy");
            totalCoin = PlayerPrefs.GetInt("coin");
        }
        else
        {
            totalEnergy = 80;
            totalCoin = 100;
            PlayerPrefs.SetInt("energy", totalEnergy);
            PlayerPrefs.SetInt("coin", totalCoin);

            PlayerPrefs.SetInt("NP", 1);
        }
        

        // Memperbarui tampilan teks energi
        UpdatetextStats();
    }

    private void UpdatetextStats()
    {

        if(energy == true)
        {
            textStats.text = "" + totalEnergy.ToString();
        }
        else
        {
            textStats.text = "" + totalCoin.ToString();
        }
        // Memperbarui teks dengan nilai total energi
        
      

    }

    public void DecreaseEnergy(string amount)
    {
        if (energy == true)
        {


            int energyAmount = int.Parse(amount);

            // Mengurangi total energi
            totalEnergy -= energyAmount;

            // Memastikan total energi tidak negatif
            totalEnergy = Mathf.Max(totalEnergy, 0);
            PlayerPrefs.SetInt("energy", totalEnergy);
        }
        else
        {

            int coinAmount = int.Parse(amount);

            // Mengurangi total energi
            totalCoin -= coinAmount;

            // Memastikan total energi tidak negatif
            totalCoin = Mathf.Max(totalCoin, 0);
            PlayerPrefs.SetInt("coin", totalCoin);
        }
        // Memperbarui tampilan teks energi
        UpdatetextStats();
    }
}
