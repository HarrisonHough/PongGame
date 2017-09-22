using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Pong
{
    public class BallSpawner : MonoBehaviour
    {

        [SerializeField]
        private Transform spawnPointLeft;
        [SerializeField]
        private Transform spawnPointRight;
        public Ball ball;

        private void Reset()
        {
            spawnPointLeft = transform.GetChild(0);
            spawnPointRight = transform.GetChild(1);
        }

        public void SpawnBall()
        {
            Vector3 startPosition = new Vector3();
            startPosition.x = Random.Range(spawnPointLeft.position.x, spawnPointRight.position.x);
            ball.transform.position = startPosition;

            if (GameManager.instance.LastPlayerToScore == 2)
                ball.transform.rotation = Quaternion.Euler(0, 0, Random.Range(35, -35));
            else
                ball.transform.rotation = Quaternion.Euler(0, 0, Random.Range(215, 125));

            ball.ShowAndMove();

        }
    }
}
