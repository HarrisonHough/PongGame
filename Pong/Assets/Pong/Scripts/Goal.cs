using UnityEngine;

namespace Pong
{
    /// <summary>
    /// 
    /// </summary>
    public class Goal : MonoBehaviour
    {
        //used to ID which player has scored the goal
        public enum playerNum { none, one, two };
        public playerNum playersGoal;


        /// <summary>
        /// Runs when object enters collider
        /// </summary>
        /// <param name="other"></param>
        private void OnTriggerEnter2D(Collider2D other)
        {
           //Debug.Log("Collision detected");
            if (other.tag == "Ball")
            {
                //Debug.Log("collision with ball");
                other.GetComponent<Ball>().StopAndHide();
                GoalScored();
            }
        }

        /// <summary>
        /// Adds to players score
        /// </summary>
        private void GoalScored()
        {
            if (playersGoal == playerNum.one)
            {
                GameManager.instance.Player1ScoreAdd();
            }
            else
            {
                GameManager.instance.Player2ScoreAdd();
            }
        }
    }
}
