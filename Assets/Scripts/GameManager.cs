using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public float player1lifecount;
    public float player2lifecount;

    private PlayerMovement playerMovement;
    private Player2Movement player2Movement;


    void Start()
    {
        
    }
    public string lifeDisplay1()
    {
       
        return Mathf.RoundToInt(player1lifecount).ToString();

    }

    public string lifeDisplay2()
    {
       
        return Mathf.RoundToInt(player2lifecount).ToString();
    }

    // Update is called once per frame
    void Update()
    {
         player1lifecount = playerMovement.playerlifecount; 
        player2lifecount = player2Movement.playerlifecount;
    }
}
