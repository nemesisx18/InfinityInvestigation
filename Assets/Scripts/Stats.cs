using UnityEngine;
using UnityEngine.UI;

public class Stats : MonoBehaviour
{
    Text textStats;
    public bool energy;
    private int totalEnergy, totalCoin;

    public EnergyReductionAnimation energyReductionAnimation;

    public void Update()
    {
        //totalCoin = PlayerPrefs.GetInt("coin");
        totalCoin = SaveData.SaveInstance.Coin;
        totalEnergy = PlayerPrefs.GetInt("energy");

        UpdatetextStats();
    }
    private void Start()
    {
        textStats = GetComponent<Text>();
        // Menginisialisasi total energi awal
        totalCoin = SaveData.SaveInstance.Coin;

        Debug.Log(PlayerPrefs.GetInt("NP"));

        if(PlayerPrefs.GetInt("NP") == 1)
        {
            totalEnergy = PlayerPrefs.GetInt("energy");
            //totalCoin = PlayerPrefs.GetInt("coin");
        }
        else
        {
            DefaultStats();
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
            Debug.Log(energyAmount);
            Debug.Log("energy:" + totalEnergy);

            if (totalEnergy < energyAmount)
            {
                Debug.Log("kurang");
                return;
            }

            // Mengurangi total energi
            totalEnergy -= energyAmount;

            // Memastikan total energi tidak negatif
            totalEnergy = Mathf.Max(totalEnergy, 0);
            PlayerPrefs.SetInt("energy", totalEnergy);

            energyReductionAnimation.klikKurangin();
        }
        else
        {

            int coinAmount = int.Parse(amount);
            Debug.Log(coinAmount);
            Debug.Log("coin:" + totalCoin);

            // Mengurangi total energi
            if ( totalCoin < coinAmount)
            {
                return;
            }

            totalCoin -= coinAmount;

            // Memastikan total energi tidak negatif
            totalCoin = Mathf.Max(totalCoin, 0);
            //PlayerPrefs.SetInt("coin", totalCoin);
            SaveData.SaveInstance.ChangeCoinValue(totalCoin);

            energyReductionAnimation.klikKurangin();
        }
        // Memperbarui tampilan teks energi
        UpdatetextStats();
    }

    public void DefaultStats()
    {
        totalEnergy = 50;
        totalCoin = 100;
        PlayerPrefs.SetInt("energy", totalEnergy);
        //PlayerPrefs.SetInt("coin", totalCoin);
        SaveData.SaveInstance.ChangeCoinValue(totalCoin);

        PlayerPrefs.SetInt("NP", 1);
    }
}
