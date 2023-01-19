using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public List<GameObject> targets;
    private float spawnRate = 1.0f;
    private int score;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI livesText;
    public TextMeshProUGUI gameOverText;
    public bool isGameActive;
    public Button restartButton;
    public GameObject titleScreen;
    public int lives;
    public GameObject music;
    public GameObject slider;
    public GameObject pauseScreen;
    public Camera cam;
    public TrailRenderer trail;

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        trail = GetComponent<TrailRenderer>();
        trail.Clear();
    }

    private void OnGUI()
    {

        Vector3 point = new Vector3();
        Vector2 mousePos = new Vector2();
        Event m_Event = Event.current;
       
        if(m_Event.type == EventType.MouseDrag)
        {
            mousePos.x = m_Event.mousePosition.x;
            mousePos.y = cam.pixelHeight - m_Event.mousePosition.y;
            trail.enabled = true;

            point = cam.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, cam.nearClipPlane));
            transform.position = point;
            
           
           


        }
        else
        {
            trail.enabled = false;
        }    
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (Time.timeScale == 0)
            {
                Time.timeScale = 1;
                pauseScreen.SetActive(false);
            }
            else
            {
                Time.timeScale = 0;
                pauseScreen.SetActive(true);
            }
            
        }
    }

    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = "Score: " + score;
    }

    IEnumerator SpawnTarget()
    {
        while (isGameActive)
        {
            yield return new WaitForSeconds(spawnRate);
            int index = Random.Range(0, targets.Count);
            Instantiate(targets[index]);
        }
    }

    public void GameOver()
    {
        lives--;
        gameOverText.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);
        isGameActive = false;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }

    public void StartGame(int difficulty)
    {
        score = 0;
        lives = 3;
        livesText.text = "Lives: " + lives;
        isGameActive = true;
        spawnRate /= difficulty;
        titleScreen.gameObject.SetActive(false);
        StartCoroutine(SpawnTarget());
    }

    public void changeVolume()
    {
        music.GetComponent<AudioSource>().volume = slider.GetComponent<Slider>().value;
    }
}
