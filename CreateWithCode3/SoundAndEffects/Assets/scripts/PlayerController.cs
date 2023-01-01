using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;
    public float jumpForce = 10.0f;
    public float gravityModifier;
    public bool isOnGround = true;
    public bool gameOver;
    private Animator playerAnim;
    public ParticleSystem explosionParticle;
    public ParticleSystem dirtParticle;
    public AudioClip jumpSound;
    public AudioClip crashSound;
    private AudioSource playerAudio;
    public int jumps_left = 2;
    public float speed;
    public float orig_speed = 10;
    public int score = 0;
    public float maxTime = 2;
    public float time = 0;
    public int dash;
    public bool start = false;
    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        Physics.gravity *= gravityModifier;
        playerAnim = GetComponent<Animator>();
        playerAudio = GetComponent<AudioSource>();
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Score " + score);

        if(start)
        {
            updateLoop();
        }
        else
        {
            playStartAnimation();
        }
                
       
    }
    
    private void updateLoop()
    {
        time += Time.deltaTime * dash;
        if (time >= maxTime && !gameOver)
        {
            time = 0;
            score++;
        }
        if (Input.GetKeyDown(KeyCode.Space) && !gameOver && jumps_left > 0)
        {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            playerAnim.SetTrigger("Jump_trig");
            dirtParticle.Stop();
            playerAudio.PlayOneShot(jumpSound, 1.0f);
            jumps_left--;
            isOnGround = false;

        }
        else if (isOnGround && !gameOver)
        {
            jumps_left = 2;
            if (Input.GetKey(KeyCode.UpArrow))
            {
                speed = 20 * orig_speed;
                dash = 50;
            }
            else
            {
                maxTime = 2;
                speed = orig_speed;
                dash = 1;
            }

        }
    }

    private void playStartAnimation()
    {
        if(transform.position.x<0)
        {
            transform.Translate(Vector3.forward * 2 * Time.deltaTime);
        }
        else
        {
            start = true;
        }
        
    }

    private void OnCollisionEnter(Collision col)
    {
        

        if (col.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
            dirtParticle.Play();
        }
        else if (col.gameObject.CompareTag("Obstacle"))
        {
            gameOver = true;
            Debug.Log("Game Over. Score: "+ score);
            playerAnim.SetBool("Death_b", true);
            playerAnim.SetInteger("DeathType_int", 1);
            explosionParticle.Play();
            dirtParticle.Stop();
            playerAudio.PlayOneShot(crashSound, 1.0f);
        }
    }
}
