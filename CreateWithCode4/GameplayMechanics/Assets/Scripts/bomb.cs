using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bomb : MonoBehaviour
{
    public ParticleSystem smoke;
    public GameObject player;
    public Rigidbody playerRb;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        playerRb = player.GetComponent<Rigidbody>();
        Invoke("explode", 3);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void explode()
    {
        smoke.Play();
        Destroy(gameObject, smoke.duration);
        float distance = (player.transform.position - transform.position).magnitude;
        if (distance < 7)
        {
            playerRb.AddForce(new Vector3(0, 10, 0), ForceMode.Impulse);
        }

    }
}
