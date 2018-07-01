using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
* AUTHOR: Harrison Hough   
* COPYRIGHT: Harrison Hough 2018
* VERSION: 1.0
* SCRIPT: Game Menu Class 
*/

namespace Pong
{
    /// <summary>
    /// This class controls the game menu interactions
    /// </summary>
    public class GameMenu : MonoBehaviour
    {

        //Reference to UI elements

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

        /// <summary>
        /// Use this for initialization
        /// </summary>
        void Start()
        {
            //reset scores on start
            ResetScores();
        }


        /// <summary>
        /// Updates player 1 score
        /// </summary>
        /// <param name="score"></param>
        public void UpdatePlayerOneScore(int score)
        {
            playerOneScore.text = "" + score;
        }

        /// <summary>
        /// Updates player 2 score
        /// </summary>
        /// <param name="score"></param>
        public void UpdatePlayerTwoScore(int score)
        {
            playerTwoScore.text = "" + score;
        }

        /// <summary>
        /// Resets both score texts 
        /// </summary>
        public void ResetScores()
        {
            playerOneScore.text = "" + 0;
            playerTwoScore.text = "" + 0;
        }

        /// <summary>
        /// Shows menu
        /// </summary>
        public void ShowMenu()
        {
            menu.SetActive(true);
        }

        /// <summary>
        /// Hides menu
        /// </summary>
        public void HideMenu()
        {
            menu.SetActive(false);
        }

        /// <summary>
        /// Displays text
        /// </summary>
        public void ShowPlayerOneWins()
        {
            playerOneWinsText.SetActive(true);
        }

        /// <summary>
        /// Displays text
        /// </summary>
        public void ShowPlayerTwoWins()
        {
            playerTwoWinsText.SetActive(true);
        }

        /// <summary>
        /// Toggles text
        /// </summary>
        /// <param name="isVisible"></param>
        public void ToggleReadyText(bool isVisible)
        {
            readyText.SetActive(isVisible);
        }

        /// <summary>
        /// Hides winner display text
        /// </summary>
        public void HideWinner()
        {
            playerOneWinsText.SetActive(false);
            playerTwoWinsText.SetActive(false);
        }

        /// <summary>
        /// Displays debug text on screen
        /// </summary>
        /// <param name="textToAdd"></param>
        public void AddDebugText(string textToAdd)
        {
            debugText.text += "/n" + textToAdd;
        }
    }
}
