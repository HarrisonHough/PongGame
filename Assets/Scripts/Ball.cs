using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Ball : MonoBehaviour
{
    private Rigidbody2D rigidbody;
    [SerializeField]
    private Transform spawnPoint;
    [SerializeField]
    private float speed = 6f;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
       
        if(Input.GetKeyDown(KeyCode.Space))
        {
            SpawnBallWithVelocity();
        }
    }

    private void FixedUpdate()
    {
        Vector2 velocity = rigidbody.velocity;
        velocity.x = Mathf.Clamp(velocity.x, -speed, speed);
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        Paddle paddle = collision.gameObject.GetComponent<Paddle>();
        if (paddle != null)
        {
            float yDirection = 1;
            //if this ball is below paddle at collision then it must
            //be heading back in -y direction
            if (transform.position.y < paddle.transform.position.y)
                yDirection = -1;

            //calculate direction
            Vector2 direction = new Vector2(BounceFactor(paddle.transform.position,paddle.sizeX), yDirection).normalized;
            rigidbody.velocity = direction * speed;
        }
    }

    private float BounceFactor(Vector2 paddlePosition, float paddleWidth)
    {
        return (transform.position.x - paddlePosition.x) / paddleWidth;
    }

    public void SpawnBallWithVelocity()
    {
        rigidbody.velocity = Vector2.zero;
        transform.position = spawnPoint.position;
        gameObject.SetActive(true);
        rigidbody.velocity = RandomStartDirection() * speed;
    }

    private Vector2 RandomStartDirection()
    {
        float randomDirection = 1;

        //randomly negative
        if (Random.Range(0, 2f) < 1)
        {
            randomDirection = -1;
        }

        Vector2 newVelocity = new Vector2(0, randomDirection * speed);
        //get random X amount
        randomDirection = Random.Range(-1f, 1f);
        newVelocity.x = randomDirection * speed;
        //apply ratio

       float pythagoras = ((newVelocity.x * newVelocity.x) + (newVelocity.y * newVelocity.y));
        if (pythagoras > (speed * speed))
        {
            float magnitude = Mathf.Sqrt(pythagoras);
            float multiplier = speed / magnitude;
            newVelocity.x *= multiplier;
            newVelocity.y *= multiplier;
        }

        return newVelocity.normalized;
    }

    public void Disable()
    {
        rigidbody.velocity = Vector2.zero;
        gameObject.SetActive(false);
        transform.position = spawnPoint.position;
    }
}
