using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Pong
{
    public class GameMenu : MonoBehaviour
    {

        [SerializeField]
        private Text playerOneScore;
        [SerializeField]
        private Text playerTwoScore;
        [SerializeField]
        private GameObject menu;
        [SerializeField]
        private GameObject readyText;
        [SerializeField]
        private GameObject playerOneWinsText;
        [SerializeField]
        private GameObject playerTwoWinsText;
        [SerializeField]
        private Text debugText;

        // Use this for initialization
        void Start()
        {
            ResetScores();
        }


        public void UpdatePlayerOneScore(int score)
        {
            playerOneScore.text = "" + score;
        }

        public void UpdatePlayerTwoScore(int score)
        {
            playerTwoScore.text = "" + score;
        }

        public void ResetScores()
        {
            playerOneScore.text = "" + 0;
            playerTwoScore.text = "" + 0;
        }

        public void ShowMenu()
        {
            menu.SetActive(true);
        }

        public void HideMenu()
        {
            menu.SetActive(false);
        }

        public void ShowPlayerOneWins()
        {
            playerOneWinsText.SetActive(true);
        }

        public void ShowPlayerTwoWins()
        {
            playerTwoWinsText.SetActive(true);
        }

        public void ToggleReadyText(bool isVisible)
        {
            readyText.SetActive(isVisible);
        }

        public void HideWinner()
        {
            playerOneWinsText.SetActive(false);
            playerTwoWinsText.SetActive(false);
        }

        public void AddDebugText(string textToAdd)
        {
            debugText.text += "/n" + textToAdd;
        }
    }
}
