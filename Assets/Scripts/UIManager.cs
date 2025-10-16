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

    //    // 메인 UI
    //    //ShowMain();


    //    // 인게임 UI
    //    //ShowInGame();
    //    //DisplayInGameScore(123);

    //    // 게임오버 UI
    //    //ShowGameOver(23, 789);
    //}

    private bool HideAllPanels()
    {
        if (mainPanel == null)
        {
            Debug.LogWarning("UIManager에 mainPanel 추가해주세요");
            return false;
        }
        if (inGameScorePanel == null)
        {
            Debug.LogWarning("UIManager에 inGameScorePanel 추가해주세요");
            return false;
        }
        if (gameOverPanel == null)
        {
            Debug.LogWarning("UIManager에 gameOverPanel 추가해주세요");
            return false;
        }

        mainPanel.SetActive(false);
        inGameScorePanel.SetActive(false);
        gameOverPanel.SetActive(false);

        return true;
    }

    // 메인화면 UI 보기
    public void ShowMain()
    {
        // 배경 스크롤 켜기
        RunScrolling(true);

        if (HideAllPanels())
            mainPanel.SetActive(true);
    }

    // 인게임 UI 보기
    public void ShowInGame()
    {
        if (HideAllPanels())
            inGameScorePanel.SetActive(true);
    }

    // 게임오버 UI 보기
    public void ShowGameOver(int currentScore, int bestScore)
    {
        // 배경 스크롤 끄기
        RunScrolling(false);

        if (HideAllPanels())
            gameOverPanel.SetActive(true);

        if (currentScoreDigits != null)
        {
            DisplayScore(currentScore, currentScoreDigits);
        }

        DisplayScore(bestScore, bestScoreDigits);
    }

    // 인게임 점수 표시
    public void DisplayInGameScore(int score)
    {
        string scoreText = score.ToString();
        int digitCount = scoreText.Length;

        // 전체 너비 계산
        float totalWidth = (digitCount - 1) * digitSpacing;
        float startX = -totalWidth / 2f; // 중앙 기준 시작점

        HideNumberDigits(gameScoreDigits);


        // 필요한 자리수만 활성화 및 배치
        for (int i = 0; i < digitCount; i++)
        {
            int digit = scoreText[i] - '0';
            gameScoreDigits[i].sprite = numberSprites[digit];
            gameScoreDigits[i].gameObject.SetActive(true);

            // 중앙 정렬 위치 설정
            Vector3 pos = gameScoreDigits[i].transform.localPosition;
            pos.x = startX + (i * digitSpacing);
            gameScoreDigits[i].transform.localPosition = pos;
        }
    }

    // 배경 스크롤 조작
    public void RunScrolling(bool enabled)
    {
        foreach (TilemapScroller map in tilemapScrollers)
        {
            map.autoScroll = enabled;
        }
    }


    // 스프라이트로 점수 표시
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

    // 모든 자리수 비활성화
    private void HideNumberDigits(Image[] digits)
    {

        foreach (var digit in digits)
        {
            digit.gameObject.SetActive(false);
        }
    }
}
