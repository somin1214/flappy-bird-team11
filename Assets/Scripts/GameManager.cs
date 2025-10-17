using UnityEngine;
using UnityEngine.SceneManagement;

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
    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);

        // 안전하게 UIManager 참조
        if (uiManager == null)
            uiManager = UIManager.instance;
    }


    private void Start()
    {
        Time.timeScale = 0.0f;
        uiManager.ShowMain();

        //Caching the PipeSpawner component
        if (pipeSpawner != null)
        {
            spawnerScript = pipeSpawner.GetComponent<PipeSpawner>();
        }
        
        if (player != null)
        {
            player.gameObject.SetActive(false); // hide at main menu
        }

    }

    public void StartGame()
    {   
        Time.timeScale = 1.0f;
        isGameOver = false;
        currentScore = 0;
        uiManager.ShowInGame();
        uiManager.DisplayInGameScore(currentScore);
        uiManager.RunScrolling(true);

        if (spawnerScript != null)
        {
            spawnerScript.StartSpawning();
        }
        
        if(player != null)
        {
            player.gameObject.SetActive(true);
            player.StartPlay();
        }
    }

    public void AddScore()
    {
        if (isGameOver) return;

        currentScore++;
        UIManager.instance.DisplayInGameScore(currentScore); 
    }
    public int GetScore()
    {
        return currentScore;
    }
    public void GameOver()
    {
        isGameOver = true;
        Time.timeScale = 0.0f;

        bestScore = PlayerPrefs.GetInt("HighScore", 0);
        if (currentScore > bestScore)
        {
            bestScore = currentScore;
            PlayerPrefs.SetInt("HighScore", bestScore);
        }

         if (UIManager.instance != null)
        {
            UIManager.instance.RunScrolling(false);
            UIManager.instance.ShowGameOver(currentScore, bestScore);
        }

    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    
}