using System;
using TMPro;
using UnityEngine;

namespace GameMng.Score
{
    public class ScoreManager : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI scoreText;
        [SerializeField] private TextMeshProUGUI highScoreText;

        private int scoreCount;
        private int highScoreCount;

        private void Start()
        {
            scoreCount = 0;
            highScoreCount = PlayerPrefs.GetInt("HighScore", 0); 

            UpdateUI(); 
        }

        private void OnEnable()
        {
           
            highScoreCount = PlayerPrefs.GetInt("HighScore", 0);
            UpdateUI();
        }
       

        public void UpdateScoreText()
        {
            scoreCount += 1;
            if (scoreCount > highScoreCount)
            {
                highScoreCount = scoreCount;
            }
            UpdateUI(); 
        }

        private void UpdateUI()
        {
            scoreText.text = scoreCount.ToString();
            highScoreText.text =  highScoreCount.ToString();
        }
        private void OnDisable()
        {
            
            PlayerPrefs.SetInt("HighScore", highScoreCount);
            PlayerPrefs.Save();
        }

    }
}