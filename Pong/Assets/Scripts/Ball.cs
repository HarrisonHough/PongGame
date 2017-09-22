using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Pong
{
    public class Ball : MonoBehaviour
    {

        public float speed = 30f;
        private Rigidbody2D _rb;
        private SpriteRenderer _sprite;
        // Use this for initialization
        void Awake()
        {
            _sprite = GetComponent<SpriteRenderer>();
            _rb = GetComponent<Rigidbody2D>();
            _sprite.enabled = false;
        }

        public void StopAndHide()
        {
            Debug.Log("Stop and hide");
            _rb.velocity = Vector3.zero;
            _sprite.enabled = false;
        }

        public void ShowAndMove()
        {
            _rb.velocity = transform.up * speed;
            _sprite.enabled = true;
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            // Play bounce audio
            if(collision.gameObject.tag == "Player")
                CheckVelocity();

        }

        private void CheckVelocity()
        {


            Vector2 tweak = new Vector2(Random.Range(0, 0.2f), Random.Range(0, 0.2f));

            //tweak += Mathf.Clamp( rb.velocity, 0f ,of);
            if (Mathf.Abs(_rb.velocity.x) < 0.2f)
            {
                if (_rb.velocity.x >= 0)
                {
                    tweak.x = 1f;

                }
                else
                {
                    tweak.x = -1f;
                }

                tweak.x *= 3f;
                Debug.Log("LOW Ball Velocity.x = " + _rb.velocity.x);
            }
            if (Mathf.Abs(_rb.velocity.y) < 2f)
            {
                if (_rb.velocity.y >= 0)
                {
                    tweak.x = 1f;

                }
                else
                {
                    tweak.x = -1f;
                }

                tweak.y *= 3f;
                Debug.Log("LOW Ball Velocity.y = " + _rb.velocity.y);
            }
            _rb.velocity += tweak;
            
        }
    }
}
