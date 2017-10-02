using UnityEngine;

namespace Pong
{
    public class Goal : MonoBehaviour
    {

        public enum playerNum { none, one, two };
        public playerNum playersGoal;


        private void OnTriggerEnter2D(Collider2D other)
        {
            Debug.Log("Collision detected");
            if (other.tag == "Ball")
            {
                Debug.Log("collision with ball");
                other.GetComponent<Ball>().StopAndHide();
                GoalScored();
            }
        }

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
