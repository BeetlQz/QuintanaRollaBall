using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    public GameObject endPanel;
 
    public GameObject startPanel;

    public GameObject Lives;

    [SerializeField] private TextMeshProUGUI lifeDisplay1;
    [SerializeField] private TextMeshProUGUI lifeDisplay2;

    GameManager gameManager;

    private PlayerMovement playerMovement;
    private Player2Movement player2Movement;

    public float player1lives = 2f;
    public float player2lives = 2f;



    // Start is called before the first frame update
    private void Start()
    {
        gameManager = GameManager.Instance;

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnGUI()
    {
        lifeDisplay1.text = ("Player 1: ") + player1lives.ToString();
        lifeDisplay2.text = ("Player 2: ") + player2lives.ToString();
    }

    public void Player2Win() 
    {
        startPanel.SetActive(true);
        Lives.SetActive(false);
        startPanel.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "Player 2 Wins!";
    }

    public void Player1Win() {

        endPanel.SetActive(true);
        Lives.SetActive(false);
        endPanel.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "Player 1 Wins!";
    }

}

