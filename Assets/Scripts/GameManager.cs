using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    // UI related objects
    public Text scoreText;
    public GameObject gameOverPanel;
    public GameObject startGamePanel;
    public GameObject pauseGamePanel;
    public GameObject pauseButton;
    public Button resumeButton;
    public Button tryAgainButton;
    public Button restartButton;
    public Button playButton;
    public Button exitButton;
    public Button secondExitButton;
    public GameObject player;

    private float score;
    private bool isGameOver;

    void Awake()
    {
        Instance = this;
        Time.timeScale = 0f;
        OnGameEntered();
        pauseButton.GetComponent<Button>().onClick.AddListener(OnPause);
        resumeButton.onClick.AddListener(OnResume);
        restartButton.onClick.AddListener(OnRestartGame);
        playButton.onClick.AddListener(OnPlay);
        tryAgainButton.onClick.AddListener(OnTryAgain);
        exitButton.onClick.AddListener(OnExit);
        secondExitButton.onClick.AddListener(OnExit);
    }

    void Start()
    {
        AudioManager.Instance.PlayTheme();
    }

    void Update()
    {
        if (isGameOver) return;

        score += Time.deltaTime;
        UpdateScoreUI();
    }

    public void OnGameEntered()
    {
        startGamePanel.SetActive(true);
        pauseButton.SetActive(false);
        gameOverPanel.SetActive(false);
        pauseGamePanel.SetActive(false);
    }

    public void AddPoints(int pts)
    {
        score += pts;
        UpdateScoreUI();
    }

    void UpdateScoreUI()
    {
        scoreText.text = "Score: " + Mathf.FloorToInt(score).ToString();
    }

    public void GameOver()
    {
        AudioManager.Instance.PlayGameOver();
        isGameOver = true;
        Time.timeScale = 0f;
        pauseButton.SetActive(false);
        gameOverPanel.SetActive(true);
    }
    public void OnPlay()
    {
        score = 0;
        AudioManager.Instance.stopTheme();
        isGameOver = false;
        gameOverPanel.SetActive(false);
        startGamePanel.SetActive(false);
        pauseButton.SetActive(true);
        Time.timeScale = 1f;
    }

    public void OnRestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void OnExit()
    {
        Application.Quit();
    }

    public void OnTryAgain()
    {
        ResetGame();
    }
    public void OnPause()
    {
        pauseButton.SetActive(false);
        pauseGamePanel.SetActive(true);
        Time.timeScale = 0f;
    }
    public void OnResume()
    {
        pauseButton.SetActive(true);
        pauseGamePanel.SetActive(false);
        Time.timeScale = 1f;
    }
    public void ResetGame()
    {
        score = 0;
        isGameOver = false;

        gameOverPanel.SetActive(false);
        pauseButton.SetActive(true);
        player.SetActive(true);
        Time.timeScale = 1f;
    }
}
