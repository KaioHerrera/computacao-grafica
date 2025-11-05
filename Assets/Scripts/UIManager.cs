
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI timerText;

    public void UpdateScore(int score)
    {
        if (scoreText) scoreText.text = $"Sementes: {score}";
    }

    public void UpdateTimer(float t)
    {
        if (timerText)
        {
            int seconds = Mathf.CeilToInt(t);
            timerText.text = $"Tempo: {seconds}s";
        }
    }
}
