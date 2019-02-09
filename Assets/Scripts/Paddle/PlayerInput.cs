using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PaddleMotor))]
public class PlayerInput : MonoBehaviour
{
    private PaddleMotor motor;
    // Start is called before the first frame update
    void Start()
    {
        motor = GetComponent<PaddleMotor>();
    }

    // Update is called once per frame
    void Update()
    {
        GetInput();
    }

    void GetInput()
    {
        motor.SetDirection(Input.GetAxis("Horizontal"));
    }
}
