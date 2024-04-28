using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    
    private GameManager gameManager;

    private Rigidbody playerRB;
    public MenuController menuController;

    public KeyCode w;
    public KeyCode a;
    public KeyCode s;
    public KeyCode d;
    public KeyCode jump;

    [SerializeField] private float speed;
    [SerializeField] private float jumpForce;
    [SerializeField] private float gravity;
    Vector3 velocity;

    public Transform cam;

    public float powerUpTime = 7f;

    public Transform respawnPoint;
    public float playerlifecount = 2f;

    bool isGrounded()
    {
        return Physics.Raycast(transform.position, -Vector3.up, 0.7f);
    }



    private void Awake()
    {
        //references within own object

        playerRB = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        gameManager = GameManager.Instance;
    }

    private void Update()
    {
       

        if(transform.position.y < -15) 
        {
            if(playerlifecount > 0) {
                 Respawn();
                playerlifecount --;
            }
            else {
                Player2Win();
                Destroy(gameObject);
            }
           
        }
    }


    private void FixedUpdate()
    {
      
        
        if(Input.GetKey(jump) && GetComponent<Rigidbody>().transform.position.y <= 3.0f) 
        {
            Vector3 jump = new Vector3(0.0f, 200.0f, 0.0f);
            GetComponent<Rigidbody>().AddForce(jump);
        }
        
         if (Input.GetKey(a))
        {
            playerRB.AddForce(Vector3.left * speed);
        }
 
        if (Input.GetKey(d))
        {
            playerRB.AddForce(Vector3.right * speed);
        }
 
        if (Input.GetKey(w))
        {
            playerRB.AddForce(Vector3.forward * speed);
        }
 
        if (Input.GetKey(s))
        {
            playerRB.AddForce(Vector3.back * speed);
        }

 
    }


    private void OnCollisionEnter(Collision collision)
    {
        
    }

    void Respawn()
    {
        playerRB.velocity = Vector3.zero;
        playerRB.angularVelocity = Vector3.zero;
        playerRB.Sleep();
        transform.position = respawnPoint.position;
        menuController.player1lives--;
    }

    void Player2Win() {
        menuController.Player2Win();
        gameObject.SetActive(false);
    }

    public void SetMoveSpeed( float newSpeedAdjustment)
    {
        speed += newSpeedAdjustment;
    }

}
