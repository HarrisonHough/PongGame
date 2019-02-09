using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameUI : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI player1Score;
    [SerializeField]
    private TextMeshProUGUI player2Score;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void UpdateScores(int score1, int score2)
    {
        player1Score.text = score1.ToString();
        player2Score.text = score2.ToString();
    }
}
