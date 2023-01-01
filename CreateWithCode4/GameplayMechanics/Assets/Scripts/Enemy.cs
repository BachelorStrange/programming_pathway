using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed;
    private Rigidbody enemyRb;
    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        enemyRb = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        float distance = (player.transform.position - transform.position).magnitude;
        Vector3 lookDirection = (player.transform.position - transform.position).normalized;
        enemyRb.AddForce(lookDirection * speed);

        if(transform.position.y < -10)
        {
            Destroy(gameObject);
        }

        if (player.GetComponent<PlayerController>().stompAttack && distance < 5)
        {
            enemyRb.AddForce(-lookDirection * 0.3f * speed, ForceMode.Impulse);
            StartCoroutine(stompCountdownRoutine());
        }

        
    }


    private IEnumerator stompCountdownRoutine()
    {
        yield return new WaitForSecondsRealtime(0.5f);
        player.GetComponent<PlayerController>().stompAttack = false;
    }

}
