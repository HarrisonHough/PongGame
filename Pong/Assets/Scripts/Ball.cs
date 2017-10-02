using UnityEngine;
using UnityEngine.UI;

namespace Pong
{
    public class Ball : MonoBehaviour
    {

        [SerializeField]
        private float constantSpeed = 10f;

        private Vector3 lastFrameVelocity;
        private Rigidbody2D rb;
        private SpriteRenderer sprite;

        private void Start()
        {
            rb = GetComponent<Rigidbody2D>();
            sprite = GetComponent<SpriteRenderer>();
            sprite.enabled = false;
        }

        public void Restart()
        {
            transform.position = Vector3.zero;
            sprite.enabled = true;

            StartRandomBallMovement();
        }

        public void StartRandomBallMovement()
        {
            rb.velocity = new Vector3(RandomStartVelocity(), RandomStartVelocity(), 0);
        }

        public void StopAndHide()
        {
            //Debug.Log("Stop and hide");
            rb.velocity = Vector3.zero;
            sprite.enabled = false;
            
        }

        private void Update()
        {
            lastFrameVelocity = rb.velocity;
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
                Bounce(collision.contacts[0].normal);
        }

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