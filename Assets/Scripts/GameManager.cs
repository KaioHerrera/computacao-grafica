
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public int score = 0;
    public float timeLimit = 90f;
    public bool isRunning = false;

    public UIManager uiManager;

    private float timer;

    void Awake()
    {
        if (Instance != null && Instance != this) { Destroy(this.gameObject); return; }
        Instance = this;
        DontDestroyOnLoad(this.gameObject);
    }

    void Start()
    {
        timer = timeLimit;
        isRunning = true;
        if (uiManager) uiManager.UpdateScore(score);
        if (uiManager) uiManager.UpdateTimer(timer);
    }

    void Update()
    {
        if (!isRunning) return;
        timer -= Time.deltaTime;
        if (uiManager) uiManager.UpdateTimer(timer);
        if (timer <= 0f)
        {
            EndGame();
        }
    }

    public void AddScore(int value)
    {
        score += value;
        if (uiManager) uiManager.UpdateScore(score);
    }

    public void OnPlayerHit()
    {
        // called when player hits an obstacle
        // optionally reduce score or show feedback
        AddScore(-2);
    }

    public void EndGame()
    {
        isRunning = false;
        // load EndScene or show end UI
        SceneManager.LoadScene("EndScene");
    }
}
