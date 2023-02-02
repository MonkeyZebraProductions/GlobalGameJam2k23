using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{

    public float Score;
    public TextMeshProUGUI ScoreText,FinalScore;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ScoreText.text = FinalScore.text = "Score: " + Score;
    }

    public void AddPoints(float points)
    {
        Score += points;
    }
}
