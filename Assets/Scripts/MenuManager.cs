using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class MenuManager : MonoBehaviour
{
    public TMP_InputField PlayerName;
    public PlayerRecord playerRecord;
    public Button StartButtton;
    public Button ButtonAddplayer;
    
    public void addplayerButton()
    {
        playerRecord.AddPLayer(PlayerName.text);
        StartButtton.interactable = true;

            if(playerRecord.playerList.Count == playerRecord .playerColours.Length)
        {
            ButtonAddplayer.interactable = false;
        }
    }
    public void Buttonstart()
    {
        SceneManager.LoadScene(playerRecord.level[0]);
    }
}
