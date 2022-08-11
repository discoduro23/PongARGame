using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerController : MonoBehaviour
{
    public GameObject player1TextGameObject;
    public GameObject player2TextGameObject;
    public GameObject statusTextGameObject;
    public float winTime = 5.0f;

    private SimpleHelvetica player1Text;
    private SimpleHelvetica player2Text;
    private SimpleHelvetica statusText;

    private int player1Points = 0;
    private int player2Points = 0;

    private string status = "";
    private bool winTimer;
    private float currentTime = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        player1Text = player1TextGameObject.GetComponent<SimpleHelvetica>();
        player2Text = player2TextGameObject.GetComponent<SimpleHelvetica>();
        statusText = statusTextGameObject.GetComponent<SimpleHelvetica>();
        status = "";
        winTimer = false;
        currentTime = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        player1Points = PlayerPrefs.GetInt("Player1Score", 0);
        player2Points = PlayerPrefs.GetInt("Player2Score", 0);

        Debug.Log("Player1Poitns: " + player1Points);
        Debug.Log("Player2Points: " + player2Points);
        
        player1Text.Text = player1Points.ToString();
        player2Text.Text = player2Points.ToString();
        statusText.Text = status;
        
        player1Text.GenerateText();
        player2Text.GenerateText();
        statusText.GenerateText();

        if (player1Points >= 10 && player2Points >= 10)
        {
            if (player1Points >= 12)
            {
                status = "You Win !";
                winTimer = true;
            }
            else if (player2Points >= 12)
            {
                status = "You lose !";
                winTimer = true;
            }
        }
        else if (player1Points >= 11)
        {
            status = "You Win !";
            winTimer = true;
        }
        else if (player2Points >= 11)
        {
            status = "You lose !";
            winTimer = true;
        }

        
        if (winTimer)
        {
            currentTime += Time.deltaTime;
        }

        if (currentTime >= winTime)
        {
            SceneManager.LoadScene("MenuScene");
        }
    }
        
}
