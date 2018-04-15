using UnityEngine;


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
