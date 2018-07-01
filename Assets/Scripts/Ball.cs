using UnityEngine;
using UnityEngine.UI;

/*
* AUTHOR: Harrison Hough   
* COPYRIGHT: Harrison Hough 2018
* VERSION: 1.0
* SCRIPT: Ball Class 
*/

namespace Pong
{
    /// <summary>
    /// This class controls ball movement and interactions
    /// with physics objects
    /// </summary>
    public class Ball : MonoBehaviour
    {

        [SerializeField]
        private float constantSpeed = 10f;

        private Vector3 lastFrameVelocity;
        private Rigidbody2D rb;
        private SpriteRenderer sprite;

        /// <summary>
        /// Used for Initialization
        /// </summary>
        private void Start()
        {
            rb = GetComponent<Rigidbody2D>();
            sprite = GetComponent<SpriteRenderer>();
            sprite.enabled = false;
        }

        /// <summary>
        /// reset position and display values
        /// </summary>
        public void Restart()
        {
            transform.position = Vector3.zero;
            sprite.enabled = true;

            StartRandomBallMovement();
        }

        /// <summary>
        /// Start moving in random direction
        /// </summary>
        public void StartRandomBallMovement()
        {
            rb.velocity = new Vector3(RandomStartVelocity(), RandomStartVelocity(), 0);
        }

        /// <summary>
        /// Stop movement and hide
        /// </summary>
        public void StopAndHide()
        {
            //Debug.Log("Stop and hide");
            rb.velocity = Vector3.zero;
            sprite.enabled = false;
            
        }

        /// <summary>
        /// Called once every frame
        /// </summary>
        private void Update()
        {
            //check veloctiy of last frame
            lastFrameVelocity = rb.velocity;
        }

        /// <summary>
        /// Called on collisions
        /// </summary>
        /// <param name="collision"></param>
        private void OnCollisionEnter2D(Collision2D collision)
        {
                Bounce(collision.contacts[0].normal);
        }

        /// <summary>
        /// Controls ad normalizes the angle at which the ball bounces
        /// </summary>
        /// <param name="collisionNormal"></param>
        private void Bounce(Vector3 collisionNormal)
        {
            var direction = Vector3.Reflect(lastFrameVelocity.normalized, collisionNormal);


            //Debug.Log("Out Direction: " + direction);
            Vector3 velocity = Vector3.zero;
            velocity.x = constantSpeed;
            velocity.y = constantSpeed;
            if (direction.x < 0)
            {
                velocity.x *= -1;
            }
            if (direction.y < 0)
            {
                velocity.y *= -1;
            }
            rb.velocity = velocity;
            //rb.velocity = direction * Mathf.Max(speed, minVelocity);
        }

        /// <summary>
        /// Randomly generates a velocity
        /// </summary>
        /// <returns></returns>
        private float RandomStartVelocity()
        {
            
            float randomVelocity = 1;

            //randomly negative
            if (Random.Range(-1f, 1f) < 0)
            {
                randomVelocity = -1;
            }

            randomVelocity *= constantSpeed;

            return randomVelocity;
        }
    }
}