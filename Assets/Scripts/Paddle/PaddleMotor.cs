using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleMotor : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D rigidbody2D;
    [SerializeField]
    private float moveSpeed = 5f;
    private BoxCollider2D collider;

    private float directionX = 0f;
    private Vector3 destination;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        collider = GetComponent<BoxCollider2D>();
        destination = transform.position;
    }

    private void FixedUpdate()
    {
        rigidbody2D.MovePosition(destination);
    }

    public void SetDirection(float xAxisInput)
    {
        directionX = xAxisInput;
        MoveInDirection(directionX);
    }

    public void MoveToPosition(Vector3 position)
    {
        Vector3 direction = (position - transform.position).normalized;
        destination = transform.position + transform.right * direction.x * moveSpeed * Time.deltaTime;
        destination.x = Mathf.Clamp(destination.x, PlaySpace.xMin + (collider.size.x / 2), PlaySpace.xMax - (collider.size.x / 2));
    }

    public void MoveInDirection(float MoveDirection)
    {
        destination = transform.position + transform.right * MoveDirection * moveSpeed * Time.deltaTime;
        destination.x = Mathf.Clamp(destination.x, PlaySpace.xMin + (collider.size.x / 2), PlaySpace.xMax - (collider.size.x / 2));
        
    }
}
