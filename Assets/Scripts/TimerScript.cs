using UnityEngine;
using UnityEngine.UI;

public class TimerScript : MonoBehaviour
{
    //public float timeLimit = 120; // Waktu total dalam detik
    public float currentTime; // Waktu saat ini
    public Text timerText; // Komponen Text untuk menampilkan timer

    public bool timerIsRunning = true;

    private void Start()
    {
        currentTime = 120; // Mengatur waktu saat ini menjadi 0
    }

    private void Update()
    {
        if (timerIsRunning)
        {
            // Menambah waktu saat ini dengan waktu yang telah berlalu
            currentTime -= Time.deltaTime;

            // Mengubah waktu dalam detik menjadi menit dan detik terpisah
            int minutes = Mathf.FloorToInt(currentTime / 60);
            int seconds = Mathf.FloorToInt(currentTime % 60);

            // Format string untuk menampilkan waktu dengan angka menit di sebelah kiri, angka detik di sebelah kanan, dan ":" di tengahnya
            string timerString = string.Format("{0:00}:{1:00}", minutes, seconds);

            // Menampilkan waktu pada komponen Text
            timerText.text = timerString;
        }

        // Jika waktu mencapai batas waktu, lakukan sesuatu di sini
        if (currentTime <= 0)
        {
            timerIsRunning = false;
            string timerString = string.Format("{0:00}:{1:00}", 0, 0);
            timerText.text = timerString;
        }
    }
}
