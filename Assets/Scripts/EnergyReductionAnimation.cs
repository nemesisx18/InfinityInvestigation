using UnityEngine;
using UnityEngine.UI;

public class EnergyReductionAnimation : MonoBehaviour
{
    public GameObject setAktive;
    public Image energyImagePrefab; // Prefab dari objek gambar energy yang ingin digandakan
    public Transform targetParent; // Parent Transform tempat gambar-gambar energi akan ditempatkan
    public Vector2 targetPosition; // Posisi target yang ingin dicapai
    public float animationDuration = 1f; // Durasi animasi dalam detik
    public float delayBetweenDuplicates = 0.1f; // Waktu jeda antara setiap duplikat
    bool cd;
    private void Start()
    {

    }

    public void klikKurangin()
    {
        if (cd == false)
        {
            // Memulai animasi pada saat awal permainan
            StartEnergyReductionAnimation();
            Invoke("pindahScene", 4.3f);
            cd = true;
        }
    }

    void pindahScene()
    {
        setAktive.SetActive(true);
        cd = false;

    }

    public void StartEnergyReductionAnimation()
    {
        // Menduplikasi gambar energy menjadi 20 salinan
        for (int i = 0; i < 20; i++)
        {
            Image duplicatedEnergy = Instantiate(energyImagePrefab, targetParent);
            duplicatedEnergy.rectTransform.anchoredPosition = Vector2.zero;
            duplicatedEnergy.gameObject.SetActive(true);

            // Menganimasikan pergerakan setiap salinan gambar energy ke posisi target menggunakan LeanTween
            LeanTween.move(duplicatedEnergy.rectTransform, targetPosition, animationDuration)
                .setDelay(i * delayBetweenDuplicates)
                .setEase(LeanTweenType.easeOutQuad)
                .setOnComplete(() => Destroy(duplicatedEnergy.gameObject));
        }
    }
}
