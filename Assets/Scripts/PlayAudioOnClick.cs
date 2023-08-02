using UnityEngine;

public class PlayAudioOnClick : MonoBehaviour
{
    public AudioSource audioClip;




    private void Update()
    {
        // Mendeteksi klik pada layar
        if (Input.GetMouseButtonDown(0))
        {
            // Memeriksa apakah audio belum sedang diputar
            if (!audioClip.isPlaying)
            {
                // Memutar audio
                audioClip.Play();
            }
        }
    }
}
