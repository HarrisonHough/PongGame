using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    [SerializeField]
    private string name;
    public string Name { get { return name; } }
    public float sizeX { get; private set; }
    private int score = 0;
    public int Score { get { return score; } }
    // Start is called before the first frame update
    void Start()
    {
        sizeX = GetComponent<BoxCollider2D>().size.x;
    }

    public void AddToScore()
    {
        score++;
    }

    public void Reset()
    {
        score = 0;
    }
}
