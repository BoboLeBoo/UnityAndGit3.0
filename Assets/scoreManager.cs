using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class scoreManager : MonoBehaviour
{
    public static scoreManager isntance;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI currentMoneyText;

    int score = 0;
    int currentMoney = 0;

   private void Awake()
   {
    isntance = this;
   }

    void Start()
    {
        currentMoney = PlayerPrefs.GetInt("currentMoney");
        scoreText.text = score.ToString() + "$";
        currentMoneyText.text = currentMoney.ToString() + "$";
    }

    public void addPoint()
    {
        score += 1;
        scoreText.text = score.ToString() + "$";
        PlayerPrefs.SetInt("currentMoney", score + currentMoney);
        
    }
}
