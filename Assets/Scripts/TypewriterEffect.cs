using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TypewriterEffect : MonoBehaviour
{
    public float typingSpeed = 0.04f; // Kecepatan pengetikan
    public string fullText = "Hello, World!"; // Teks yang akan diketik

    private string currentText = "";
    private Text textComponent;

    void Start()
    {
        textComponent = GetComponent<Text>();
        StartCoroutine(TypeText());
    }

    IEnumerator TypeText()
    {
        for (int i = 0; i <= fullText.Length; i++)
        {
            currentText = fullText.Substring(0, i);
            textComponent.text = currentText;
            yield return new WaitForSeconds(typingSpeed);
        }
    }
}
