using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
* AUTHOR: Harrison Hough   
* COPYRIGHT: Harrison Hough 2018
* VERSION: 1.0
* SCRIPT: PlayerAI Class 
*/

namespace Pong
{
    /// <summary>
    /// This class handles the AI of the computer 
    /// controlled paddle
    /// </summary>
    public class PlayerAI : MonoBehaviour
    {

        public float maxSpeed = 8f;
        private float speed = 0f;
        [SerializeField]
        private float acceleration = 1f;
        //public float lerpSpeed = 1f;
        [SerializeField]
        private Transform ball;
        [SerializeField]
        private float playerSize = 1;
        private bool activeAI = false;
        [SerializeField]
        private float detectRadius = 5f;
        private Rigidbody2D rigidbody;

        //[Tooltip("Offset for ball (Target to lerp to)")]
        private float xOffset;

        /// <summary>
        /// Reassigned ball
        /// </summary>
        private void Reset()
        {
            ball = FindObjectOfType<Ball>().GetComponent<Transform>();
        }

        
        /// <summary>
        /// Use this for initialization
        /// </summary>
        void Start()
        {
            ball = FindObjectOfType<Ball>().GetComponent<Transform>();
            rigidbody = GetComponent<Rigidbody2D>();
            StartCoroutine(TrackBall());
        }

        /* private void FixedUpdate()
        {
            if (Mathf.Abs(Vector3.Distance(transform.position, ball.position)) > detectRadius)
            {
                rigidbody.velocity = Vector3.zero;
                return;
            }

            if (ball.position.x > transform.position.x)
            {
                rigidbody.velocity = Vector2.Lerp(rigidbody.velocity, Vector2.right * speed, Time.deltaTime/ lerpSpeed );
            }
            else if (ball.position.x < transform.position.x)
            {
                rigidbody.velocity = Vector3.Lerp(rigidbody.velocity, Vector2.left * speed, Time.deltaTime / lerpSpeed );
            }
            else
            {

            }

            //if()
        } */

            /// <summary>
            /// Runs when object collides with another
            /// </summary>
            /// <param name="collision"></param>
        private void OnCollisionEnter2D(Collision2D collision)
        {
            xOffset = RandomOffset();
            Debug.Log("Offset = " + xOffset);
        }

        /// <summary>
        /// Coroutine that tracks the movement of the ball to
        /// emulate a player AI
        /// </summary>
        /// <returns></returns>
        IEnumerator TrackBall()
        {
            activeAI = true;
            Vector3 targetPosition = new Vector3(ball.position.x, transform.position.y, transform.position.z);
            while (activeAI)
            {
                if (Mathf.Abs(Vector3.Distance(transform.position, ball.position)) < detectRadius)
                {
                    //clamp to play space
                    targetPosition.x = Mathf.Clamp(ball.position.x + xOffset, PlaySpace.xMin + (playerSize / 2), PlaySpace.xMax - (playerSize / 2));

                    speed = Mathf.Lerp(speed, maxSpeed, Time.deltaTime * acceleration);
                    transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * speed);
                }
                else
                {
                    //clamp to play space
                    targetPosition.x = Mathf.Clamp(ball.position.x + xOffset, PlaySpace.xMin + (playerSize / 2), PlaySpace.xMax - (playerSize / 2));

                    speed = Mathf.Lerp(speed, maxSpeed/3, Time.deltaTime * acceleration);
                    transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * speed);
                }
                yield return null;
            }
        }

        /// <summary>
        /// Random offset to simulate human error
        /// </summary>
        /// <returns></returns>
        private float RandomOffset()
        {
            //only apply offset sometimes
            //When detect Radius is increased, game is harder, AI smarter
            //Less common for offset to be applied
            if (Random.Range(0, detectRadius) > 1)
            {
                return 0;
            }
            float randomNumber = 1f;

            if (Random.Range(-1f, 1f) < 0)
            {
                randomNumber = -1f;
            } 

            randomNumber *= Random.Range(0f,1f);

            return randomNumber;
        }

        /// <summary>
        /// Resets ball tracking offset 
        /// </summary>
        public void ResetAI()
        {
            xOffset = 0;
        }

    }
}
