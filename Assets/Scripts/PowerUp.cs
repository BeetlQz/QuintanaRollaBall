using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
  [SerializeField] private float speedBoost;
  [SerializeField] private float powerUpTime;
  [SerializeField] private float speedNorm;
  [SerializeField] private GameObject artToDisable = null;
    [SerializeField] private float timeTillResapwn;

  private Collider collider;
    public Transform respawnPoint;


    private void Awake()
    {
            collider = GetComponent<Collider>();

      
    }
    void Update()
    {
        transform.Rotate(new Vector3(0, 0.2f, 0));
    }

    void OnTriggerEnter(Collider other)
  {
    PlayerMovement PlayerMovement = other.gameObject.GetComponent<PlayerMovement>();

    if(PlayerMovement != null)
    {
        
        StartCoroutine(SpeedPowerUp(PlayerMovement));
    }
  }

  public IEnumerator SpeedPowerUp(PlayerMovement PlayerMovement)
  {
        //speed = speedBoost;
        collider.enabled = false;
        artToDisable.SetActive(false);

        ActivatePowerUp(PlayerMovement);

        yield return new WaitForSeconds(powerUpTime);
        //speed = speedNorm;

        DeactivatePowerUp(PlayerMovement);

        yield return new WaitForSeconds(timeTillResapwn);
        Respawn();

  }

  private void ActivatePowerUp(PlayerMovement PlayerMovement)
  {
    PlayerMovement.SetMoveSpeed(speedBoost);
  }
  private void DeactivatePowerUp(PlayerMovement PlayerMovement)
  {
    PlayerMovement.SetMoveSpeed(-speedBoost);
  }

    void Respawn()
    {
        transform.position = respawnPoint.position;
        collider.enabled = true;
        artToDisable.SetActive(true);
    }


}
