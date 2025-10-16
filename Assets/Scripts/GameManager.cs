using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    private bool isGameOver = false;

    void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    public void GameOver()
    {
        if (isGameOver) return;

        isGameOver = true;
<<<<<<< HEAD
        // UIManager.instance.ShowGameOver();
=======
        //UIManager.instance.ShowGameOver();
>>>>>>> 210de02f7ae364dddcaebd41b04eb8746ba8e826
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
