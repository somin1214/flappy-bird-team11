using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;
    private bool isGameOver = false;

    void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    public void ShowGameOver()
    {

    }
}
