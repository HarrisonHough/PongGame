using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PaddleMotor))]
public class PaddleAIBasic : MonoBehaviour
{
    [SerializeField]
    private PaddleMotor motor;
    [SerializeField]
    private float precision = 0.2f;
    private Ball ball;
    private Vector3 startPosition;
    
    
    private void Start()
    {
        motor = GetComponent<PaddleMotor>();
        ball = FindObjectOfType<Ball>();
        startPosition = transform.position;
    }
    // Update is called once per frame
    void Update()
    {
        if (ball == null || !ball.gameObject.activeSelf)
        {
            //move to start position
            return;
        }
        motor.MoveToPosition(ball.transform.position);
        //FollowBall();

    }

    private void FollowBall()
    {
        if (Vector3.Distance(ball.transform.position, transform.position) < precision)
        {
            motor.SetDirection(0);
            return;
        }
            
        if (ball.transform.position.x < transform.position.x)
        {
            motor.SetDirection(-1);
        }
        if (ball.transform.position.x > transform.position.x)
        {
            motor.SetDirection(1);
        }

    }
}
