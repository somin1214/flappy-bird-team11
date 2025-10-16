using UnityEngine;
using UnityEngine.Analytics;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class GameManager : MonoBehaviour
{

    public static GameManager instance;
    public GameObject gameOverUI;

    [SerializeField] private UIManager uiManager;
    [SerializeField] private PlayerController player;
    [SerializeField] private GameObject pipeSpawner; // pipe
    private PipeSpawner spawnerScript;

    private int currentScore = 0;
    private int bestScore = 0;
    private bool isGameOver = false;

    void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    private void Start()
    {
        Time.timeScale = 0.0f;
        UIManager.instance.ShowMain();

        //Caching the PipeSpawner component
        if (pipeSpawner != null)
            spawnerScript = pipeSpawner.GetComponent<PipeSpawner>();
    }

    public void StartGame()
    {
        Time.timeScale = 1.0f;
        isGameOver = false;
        currentScore = 0;
        UIManager.instance.ShowInGame();
        UIManager.instance.DisplayInGameScore(currentScore);
        UIManager.instance.RunScrolling(true);
        spawnerScript.StartCoroutine("AutoSpawnCo");

        if (player != null)
            player.StartPlay();

        if (spawnerScript != null)
            spawnerScript.StartSpawning();
    }
    
    public void AddScore()
    {
        if (isGameOver) return;

        currentScore++;
        uiManager.DisplayInGameScore(currentScore);
    }
    public void GameOver()
    {
        isGameOver = true;
        Time.timeScale = 0.0f;

        uiManager.RunScrolling(false);

        if (currentScore > bestScore)
            bestScore = currentScore;

        uiManager.ShowGameOver(currentScore, bestScore);
    }
    public void RestartGame()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
