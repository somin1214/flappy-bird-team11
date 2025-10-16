using UnityEngine;
using UnityEngine.Analytics;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public GameObject gameOverUI;

    [SerializeField] private PlayerController player;
    [SerializeField] private GameObject pipeSpawner; // pipe
    private PipeSpawner spawnerScript;
   
    private int currentScore = 0;
    private int bestScore = 0;

    void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);

        if (pipeSpawner != null)
            spawnerScript = pipeSpawner.GetComponent<PipeSpawner>();
    }

    private void Start()
    {
        UIManager.instance.ShowMain();
    }

    public void StartGame()
    {
        currentScore = 0;
        UIManager.instance.ShowInGame();
        UIManager.instance.DisplayInGameScore(currentScore);
        UIManager.instance.RunScrolling(true);

        if (player != null)
            player.StartPlay();

        if (spawnerScript != null)
            spawnerScript.StartSpawning();
    }
    
    public void AddScore()
    {
        currentScore++;
        UIManager.instance.DisplayInGameScore(currentScore);
    }
    public void GameOver()
    {
        UIManager.instance.RunScrolling(false);

        if (spawnerScript != null)
            spawnerScript.StopSpawning();

        if (currentScore > bestScore)
            bestScore = currentScore;

        UIManager.instance.ShowGameOver(currentScore, bestScore);
    }
    public void RestartGame()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
