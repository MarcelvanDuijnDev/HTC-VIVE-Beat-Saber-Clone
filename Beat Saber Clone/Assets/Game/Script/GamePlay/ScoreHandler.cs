using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ScoreHandler : MonoBehaviour
{
    [SerializeField] private Text scoreText;
    [SerializeField] private Text comboText;
    [SerializeField] private Text multiplyText;

    private float score = 0;
    private float combo = 0;
    private float multiply = 0;
    private int hitsToMultiply = 4;
    private int checkHits = 0;

    void Update()
    {
        scoreText.text = score.ToString("0.00");
        comboText.text = combo.ToString();
        multiplyText.text = "x" + multiply.ToString();
    }

    public void Miss()
    {
        combo = 0;
        multiply = 0;
    }

    public void AddScore(float _Score)
    {
        score += _Score * (1 + multiply);
        combo++;
        checkHits++;
        if (checkHits >= 4 && multiply < 8)
        {
            multiply++;
            checkHits = 0;
        }
    }
}
