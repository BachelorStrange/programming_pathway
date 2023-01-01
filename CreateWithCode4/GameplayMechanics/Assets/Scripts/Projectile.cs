using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed;
    private Rigidbody projectileRb;
    private GameObject player;
    public Enemy enemy;
    Vector3 lookDirection;
    // Start is called before the first frame update
    void Start()
    {
        projectileRb = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
        lookDirection = (enemy.transform.position - player.transform.position).normalized;

    }

    // Update is called once per frame
    void Update()
    {   
        
        projectileRb.AddForce(lookDirection * speed);

        if (transform.position.x < -10 || transform.position.x > 10 || transform.position.z < -10 || transform.position.z > 10 || transform.position.y < -10 || transform.position.y > 10)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("enemy"))
        {
           
            Rigidbody enemyRigidbody = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 awayFromPlayer = (collision.gameObject.transform.position - transform.position);
            enemyRigidbody.AddForce(awayFromPlayer * 10, ForceMode.Impulse);
            Destroy(gameObject);
        }
    }
}
