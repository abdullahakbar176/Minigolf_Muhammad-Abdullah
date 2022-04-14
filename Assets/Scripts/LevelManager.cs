using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; 
public class LevelManager : MonoBehaviour
{
    public BallController ball;
    public TextMeshProUGUI PlayerName;
    private PlayerRecord playerRecord;
    private int playerIndex;

    // Start is called before the first frame update
    void Start()
    {
       playerRecord = GameObject.Find("Player Record").GetComponent<PlayerRecord>();
        playerIndex = 0;
        setupBall();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void setupBall()
    {
        ball.setupball(playerRecord.playerColours[playerIndex]);
        PlayerName.text = playerRecord.playerList[playerIndex].name;
    }
}
