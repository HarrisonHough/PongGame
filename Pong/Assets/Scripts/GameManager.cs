using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Pong
{
    public class GameManager : MonoBehaviour
    {

        public static GameManager instance;
        public Player playerOne;
        public Player playerTwo;

        public int maxScore = 10;
        private int lastPlayerToScore = 0;
        public int LastPlayerToScore
        {
            get { return lastPlayerToScore; }
        }
        public float roundDelay = 2f;

        [SerializeField]
        private GameMenu gameMenu;
        [SerializeField]
        private BallSpawner ballSpawner;


        private void Reset()
        {
            gameMenu = FindObjectOfType<GameMenu>();
            ballSpawner = FindObjectOfType<BallSpawner>();
        }
        private void Awake()
        {
            if (instance == null)
                instance = this;
            else
            {
                Destroy(gameObject);
                return;
            }
        }

        // Use this for initialization
        void Start()
        {
            if (gameMenu == null)
                gameMenu = FindObjectOfType<GameMenu>();
            if (ballSpawner == null)
                ballSpawner = FindObjectOfType<BallSpawner>();
        }

        public void Player1ScoreAdd()
        {
            // Add score to player
            playerOne.AddScore();
            // Update last player to score
            lastPlayerToScore = 1;
            // Update Score UI
            gameMenu.UpdatePlayerOneScore(playerOne.Score);

            // Check for game over
            if (playerOne.Score == maxScore)
            {
                GameOver(playerOne);
                gameMenu.ShowPlayerOneWins();
                return;
            }
            // Start next round
            StartCoroutine(NextRound());
        }

        public void Player2ScoreAdd()
        {
            // Add score to player
            playerTwo.AddScore();
            // Update last player to score
            lastPlayerToScore = 2;
            // Update Score UI
            gameMenu.UpdatePlayerTwoScore(playerTwo.Score);

            // Check for game over
            if (playerTwo.Score == maxScore)
            {
                GameOver(playerTwo);
                gameMenu.ShowPlayerTwoWins();
                return;
            }
            // Start next round
            StartCoroutine(NextRound());
        }

        public void StartGame()
        {
            playerOne.ResetScore();
            playerTwo.ResetScore();
            StartCoroutine(NextRound());
        }

        void GameOver(Player winner)
        {
            Debug.Log("Player wins");
            gameMenu.ShowMenu();
        }

        IEnumerator NextRound()
        {
            gameMenu.ToggleReadyText(true);
            yield return new WaitForSeconds(roundDelay);
            gameMenu.ToggleReadyText(false);
            ballSpawner.SpawnBall();
        }


    }
}
