using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowStar : MonoBehaviour
{
    [SerializeField] private GameObject[] starProgess;
    private int currentScore;

    private void Start()
    {
        currentScore = Manager.ManagerInstance.score;

        if(currentScore == 100)
        {
            starProgess[2].SetActive(true);
        }
        else if(currentScore <= 60 && currentScore > 20)
        {
            starProgess[1].SetActive(true);
        }
        else if(currentScore <= 20)
        {
            starProgess[0].SetActive(true);
        }
    }
}
