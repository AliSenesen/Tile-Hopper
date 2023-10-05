using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace GameMng.UI
{
    public class UIManager : MonoBehaviour
    {
        [SerializeField] private UIPanelController UIPanelController;

        private void Start()
        {
            InGamePanel();
        }

        public void InGamePanel()
        {
            UIPanelController.OnOpenPanel(UIPanels.InGamePanel);
            Time.timeScale = 1;
        }

        public void GameOverPanel()
        {
            UIPanelController.OnClosePanel(UIPanels.InGamePanel);
            UIPanelController.OnOpenPanel(UIPanels.GameOverPanel);
            Time.timeScale = 0;
        }

        public void RestartButton()
        {
            SceneManager.LoadScene("GameScene");
        }
    }
}