using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScene : MonoBehaviour
{
    [SerializeField]
    private Paddle player1;
    public Paddle Player1 { get { return player1; } }
    [SerializeField]
    private Paddle player2;
    public Paddle Player2 { get { return player2; } }
    [SerializeField]
    private Ball ball;
    public Ball Ball { get { return ball; } }
    [SerializeField]
    private GameUI gameUI;
    public GameUI GameUI { get { return gameUI; } }

    private void Start()
    {
        GameManager.Instance.OnGameSceneStart(this);
    }

}
