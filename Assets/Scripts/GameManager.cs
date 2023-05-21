using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private GameManager gm;
    public GameObject[] spawnObjects;
    public GameObject[] spawnPoints;
    public float timer;
    public float timeBetweenSpawns;
    public float speedMultiplier;
    private float survivedTime;
    public int score = 0;
    public Text scoreText;
    public Text survivedTimeText;
    public GameObject GameOverScreen;
    public GameObject PauseScreen;
    private bool isPaused;


    void Awake()
    {
        gm = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
    }

    void Update()
    {
        survivedTimeText.text = survivedTime.ToString("F2");

        speedMultiplier += Time.deltaTime * 0.15f;

        timer += Time.deltaTime;

        survivedTime += Time.deltaTime;

        if (timer > timeBetweenSpawns)
        {
            int randSpawnObject = Random.Range(0, spawnObjects.Length);
            int randSpawnPoint = Random.Range(0, spawnPoints.Length);
            Instantiate(spawnObjects[randSpawnObject], spawnPoints[randSpawnPoint].transform.position, Quaternion.identity);
            timeBetweenSpawns *= 0.98f;

            timer = 0;
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    void PauseGame()
    {
        PauseScreen.SetActive(true);
        Time.timeScale = 0;
        isPaused = true;
    }

    void ResumeGame()
    {
        PauseScreen.SetActive(false);
        Time.timeScale = 1;
        isPaused = false;
    }
}
