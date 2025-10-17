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

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            Debug.Log($"✅ GameManager Awake called on {gameObject.name}");
        }
        else
        {
            Debug.LogWarning($"⚠️ Duplicate GameManager destroyed on {gameObject.name}");
            Destroy(gameObject);
        }
            
    }

    private void Start()
    {
        Time.timeScale = 0.0f;
        UIManager.instance.ShowMain();

        //Caching the PipeSpawner component
        if (pipeSpawner != null)
        {
            spawnerScript = pipeSpawner.GetComponent<PipeSpawner>();
            Debug.Log("✅ PipeSpawner component found!");
        }
        else
        {
            Debug.LogError("❌ PipeSpawner GameObject is not assigned in the GameManager.");
        }
        
        if (player != null)
        {
            player.gameObject.SetActive(false); // hide at main menu
        }

    }

    public void StartGame()
    {   
        Debug.Log("▶️ StartGame called!");
        Time.timeScale = 1.0f;
        isGameOver = false;
        currentScore = 0;
        UIManager.instance.ShowInGame();
        UIManager.instance.DisplayInGameScore(currentScore);
        UIManager.instance.RunScrolling(true);

        if (spawnerScript != null)
        {
            Debug.Log("🌀 Starting pipe spawn coroutine...");
            spawnerScript.StartSpawning();
        }
        else
        {
            Debug.LogError("❌ spawnerScript is null!");
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
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
