using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRecord : MonoBehaviour
{
    public List<Player> playerList;
    public string[] level;
    public Color[] playerColours;

    private void OnEnable()
    {
        playerList = new List<Player>();
        DontDestroyOnLoad(this.gameObject);
    }
    public void AddPLayer(string name)
    {
      playerList.Add(new Player(name, playerColours[playerList.Count], level.Length));
    }


    public class Player
    {
        public string name;
        public Color colour;
        int[] putts;

        public Player(string newName, Color newColor, int levelCount)
        {
            name = newName;
            colour = newColor;
            putts = new int[levelCount];
        }
    }
}
