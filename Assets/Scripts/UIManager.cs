using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    [Header("Number Sprites")]
    [SerializeField] private Sprite[] numberSprites;

    [Header("Main UI")]
    [SerializeField] private GameObject mainPanel;

    [Header("In-Game Score UI")]
    [SerializeField] private GameObject inGameScorePanel;
    [SerializeField] private Image[] gameScoreDigits;
    [SerializeField] private float digitSpacing = 80f;

    [Header("Game Over UI")]
    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private Image[] currentScoreDigits;
    [SerializeField] private Image[] bestScoreDigits;

    [SerializeField] private TilemapScroller[] tilemapScrollers;

    void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    //private void Start()
    //{

    //    // ���� UI
    //    //ShowMain();


    //    // �ΰ��� UI
    //    //ShowInGame();
    //    //DisplayInGameScore(123);

    //    // ���ӿ��� UI
    //    //ShowGameOver(23, 789);
    //}

    private bool HideAllPanels()
    {
        if (mainPanel == null)
        {
            Debug.LogWarning("UIManager�� mainPanel �߰����ּ���");
            return false;
        }
        if (inGameScorePanel == null)
        {
            Debug.LogWarning("UIManager�� inGameScorePanel �߰����ּ���");
            return false;
        }
        if (gameOverPanel == null)
        {
            Debug.LogWarning("UIManager�� gameOverPanel �߰����ּ���");
            return false;
        }

        mainPanel.SetActive(false);
        inGameScorePanel.SetActive(false);
        gameOverPanel.SetActive(false);

        return true;
    }

    // ����ȭ�� UI ����
    public void ShowMain()
    {
        // ��� ��ũ�� �ѱ�
        RunScrolling(true);

        if (HideAllPanels())
            mainPanel.SetActive(true);
    }

    // �ΰ��� UI ����
    public void ShowInGame()
    {
        if (HideAllPanels())
            inGameScorePanel.SetActive(true);
    }

    // ���ӿ��� UI ����
    public void ShowGameOver(int currentScore, int bestScore)
    {
        // ��� ��ũ�� ����
        RunScrolling(false);

        if (HideAllPanels())
            gameOverPanel.SetActive(true);

        if (currentScoreDigits != null)
        {
            DisplayScore(currentScore, currentScoreDigits);
        }

        DisplayScore(bestScore, bestScoreDigits);
    }

    // �ΰ��� ���� ǥ��
    public void DisplayInGameScore(int score)
    {
        string scoreText = score.ToString();
        int digitCount = scoreText.Length;

        // ��ü �ʺ� ���
        float totalWidth = (digitCount - 1) * digitSpacing;
        float startX = -totalWidth / 2f; // �߾� ���� ������

        HideNumberDigits(gameScoreDigits);


        // �ʿ��� �ڸ����� Ȱ��ȭ �� ��ġ
        for (int i = 0; i < digitCount; i++)
        {
            int digit = scoreText[i] - '0';
            gameScoreDigits[i].sprite = numberSprites[digit];
            gameScoreDigits[i].gameObject.SetActive(true);

            // �߾� ���� ��ġ ����
            Vector3 pos = gameScoreDigits[i].transform.localPosition;
            pos.x = startX + (i * digitSpacing);
            gameScoreDigits[i].transform.localPosition = pos;
        }
    }

    // ��� ��ũ�� ����
    public void RunScrolling(bool enabled)
    {
        foreach (TilemapScroller map in tilemapScrollers)
        {
            map.autoScroll = enabled;
        }
    }


    // ��������Ʈ�� ���� ǥ��
    private void DisplayScore(int score, Image[] digitImages)
    {
        HideNumberDigits(digitImages);

        string scoreText = score.ToString();

        for (int i = 0; i < scoreText.Length; i++)
        {
            int digit = int.Parse(scoreText[i].ToString());
            digitImages[i].sprite = numberSprites[digit];
            digitImages[i].gameObject.SetActive(true);
        }
    }

    // ��� �ڸ��� ��Ȱ��ȭ
    private void HideNumberDigits(Image[] digits)
    {

        foreach (var digit in digits)
        {
            digit.gameObject.SetActive(false);
        }
    }
}
