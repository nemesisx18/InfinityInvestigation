using UnityEngine;
using UnityEngine.UI;

public class LoadingScript : MonoBehaviour
{
    public Text loadingText;
    public GameObject targetGameObject;

    private int currentPercentage = 0;
    private bool isComplete = false;

    void Start()
    {
        loadingText.text = "0%"; // Mulai dengan 0%
        StartCoroutine(StartLoading());
    }

    private System.Collections.IEnumerator StartLoading()
    {
        while (!isComplete)
        {
            if (currentPercentage < 100)
            {
                currentPercentage++;
                loadingText.text = currentPercentage.ToString() + "%";
            }
            else
            {
                isComplete = true;
                targetGameObject.SetActive(true); // Mengaktifkan GameObject setelah mencapai 100%
            }

            yield return new WaitForSeconds(0.035f); // Penundaan antara peningkatan persentase
        }
    }
}
