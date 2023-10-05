using System;
using GameMng.Score;
using GameMng.UI;
using UnityEngine;
using UnityEngine.Serialization;

namespace GameMng
{
    public class PlayerManager : MonoBehaviour
    {
        [SerializeField] private ScoreManager scoreManager;
        [SerializeField] private UIManager uiManager;


        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Cube"))
            {
                scoreManager.UpdateScoreText();
            }
        }

        private void Update()
        {
            if (transform.position.y <= -7)
            {
                uiManager.GameOverPanel();
            }
        }
    }
}