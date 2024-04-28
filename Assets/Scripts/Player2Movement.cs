using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2Movement : MonoBehaviour
{
    private GameManager gameManager;

    private Rigidbody playerRB;
    public MenuController menuController;

    public KeyCode left;
    public KeyCode right;
    public KeyCode up;
    public KeyCode down;
    public KeyCode jump;

    [SerializeField] private float speed;
    [SerializeField] private float jumpForce;
    [SerializeField] private float gravity;
    Vector3 velocity;

    public Transform cam;

    public bool isPoweredUp;
    public float powerBounceStrength;
    public float powerUpTime = 7f;

    public Transform respawnPoint;
    public float playerlifecount = 2f;

    bool isGrounded()
    {
        return Physics.Raycast(transform.position, -Vector3.up, 0.5f);
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
                Player1Win();
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

         if (Input.GetKey(left))
        {
            playerRB.AddForce(Vector3.left * speed);
        }
 
         if (Input.GetKey(right))
        {
            playerRB.AddForce(Vector3.right * speed);
        }
 
         if (Input.GetKey(up))
        {
            playerRB.AddForce(Vector3.forward * speed);
        }
 
        if (Input.GetKey(down))
        {
            playerRB.AddForce(Vector3.back * speed);
        }

    
    }

    private void Jump()
    {
        if(isGrounded() == true)
        {
            playerRB.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
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
        menuController.player2lives--;
    }

    void Player1Win() {
        menuController.Player1Win();
        gameObject.SetActive(false);
    }

    public void SetMoveSpeed(float newSpeedAdjustment)
    {
        speed += newSpeedAdjustment;
    }
}
