using UnityEngine;

/*
* AUTHOR: Harrison Hough   
* COPYRIGHT: Harrison Hough 2018
* VERSION: 1.0
* SCRIPT: Player Class 
*/


namespace Pong
{
    /// <summary>
    /// Class used to track player score
    /// </summary>
    public class Player : MonoBehaviour
    {

        private int score;

        public int Score
        {
            get { return score; }
        }

        /// <summary>
        /// Used for initialization
        /// </summary>
        private void Start()
        {
            score = 0;
        }

        /// <summary>
        /// 
        /// </summary>
        public void ResetScore()
        {
            score = 0;
        }

        /// <summary>
        /// 
        /// </summary>
        public void AddScore()
        {
            score++;
        }
    }
}
