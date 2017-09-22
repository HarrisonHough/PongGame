using UnityEngine;


namespace Pong
{
    public class Player : MonoBehaviour
    {

        private int score;
        public int Score
        {
            get { return score; }
        }

        private void Start()
        {
            score = 0;
        }

        public void ResetScore()
        {
            score = 0;
        }

        public void AddScore()
        {
            score++;
        }
    }
}
