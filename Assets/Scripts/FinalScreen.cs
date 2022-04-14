using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class FinalScreen : MonoBehaviour
{
    public PlayerRecord playerRecord;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void restart()
    {
        SceneManager.LoadScene("Level 1");
    }
    public void exit()
    {
        SceneManager.LoadScene("Menu");

    }
}
