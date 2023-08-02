using UnityEngine;
using UnityEngine.UI;

public class TimerScript : MonoBehaviour
{
    public float timeLimit = 120; // Waktu total dalam detik
    private float currentTime; // Waktu saat ini
    public Text timerText; // Komponen Text untuk menampilkan timer

    private void Start()
    {
        currentTime = 0; // Mengatur waktu saat ini menjadi 0
    }

    private void Update()
    {
        // Menambah waktu saat ini dengan waktu yang telah berlalu
        currentTime += Time.deltaTime;

        // Mengubah waktu dalam detik menjadi menit dan detik terpisah
        int minutes = Mathf.FloorToInt(currentTime / 60);
        int seconds = Mathf.FloorToInt(currentTime % 60);

        // Format string untuk menampilkan waktu dengan angka menit di sebelah kiri, angka detik di sebelah kanan, dan ":" di tengahnya
        string timerString = string.Format("{0:00}:{1:00}", minutes, seconds);

        // Menampilkan waktu pada komponen Text
        timerText.text = timerString;

        // Jika waktu mencapai batas waktu, lakukan sesuatu di sini
        if (currentTime >= timeLimit)
        {
            // Lakukan sesuatu di sini
            // Contoh: GameManager.instance.EndGame();
        }
    }
}
