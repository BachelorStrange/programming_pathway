using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public bool hasPowerUp;
    public bool hasPowerUp2;
    public bool hasPowerUp3;
    private GameObject focalPoint;
    public float speed = 5.0f;
    private Rigidbody playerRb;
    private float powerupStrength = 15.0f;
    public GameObject powerupIndicator;
    public SpawnManager manager;
    public bool stompAttack;
   
    
    
    // Start is called before the first frame update
    void Start()
    {
        focalPoint = GameObject.Find("FocalPoint");
        playerRb = GetComponent<Rigidbody>();
        manager = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();
    }

    // Update is called once per frame
    void Update()
    {
        float forwardInput = Input.GetAxis("Vertical");
        playerRb.AddForce(focalPoint.transform.forward * speed * forwardInput);
        powerupIndicator.transform.position = transform.position + new Vector3(0, 0.5f, 0);

        if (hasPowerUp2 && Input.GetKeyDown(KeyCode.Space))
        {
            for(int i= 0; i<=manager.enemyCount; i++)
            {
                manager.spawnProjectiles = true;
            }
        }

        if(Input.GetKeyDown(KeyCode.LeftControl) && hasPowerUp3)
        {
            playerRb.AddForce(new Vector3(0, 5,0), ForceMode.VelocityChange);
            StartCoroutine(jumpCountDown());
        }
      
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.tag != "enemy");
        if(other.tag != "enemy")
        {
            powerupIndicator.gameObject.SetActive(true);
            Destroy(other.gameObject);
            StartCoroutine(PowerUpCountdownRoutine());

            if (other.CompareTag("powerup"))
            {
                hasPowerUp = true;
            }
            else if (other.CompareTag("powerup2"))
            {
                hasPowerUp2 = true;
            }
            else if (other.CompareTag("powerup3"))
            {
                hasPowerUp3 = true;
            }
        }
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("enemy") && hasPowerUp)
        {
            Rigidbody enemyRigidbody = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 awayFromPlayer = (collision.gameObject.transform.position-transform.position);
            enemyRigidbody.AddForce(awayFromPlayer * powerupStrength, ForceMode.Impulse);
        } 
    }

    private IEnumerator PowerUpCountdownRoutine()
    {
        yield return new WaitForSeconds(7);
        hasPowerUp = false;
        hasPowerUp2 = false;
        hasPowerUp3 = false;
        powerupIndicator.gameObject.SetActive(false);
    }

    private IEnumerator jumpCountDown()
    {
        yield return new WaitForSecondsRealtime(0.4f);
        playerRb.AddForce(new Vector3(0, -20, 0), ForceMode.VelocityChange);
        stompAttack = true;
    }

    


}
