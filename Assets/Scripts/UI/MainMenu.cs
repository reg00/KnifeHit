using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MainMenu : MonoBehaviour
{
    void Start()
    {
        var scoreText = transform.Find("Scores").GetComponent<TextMeshProUGUI>();
        scoreText.text = $"Stage: {4} Score: {128}";

        var appleScore = transform.Find("AppleScore").GetComponent<TextMeshProUGUI>();
        appleScore.text = 5.ToString();
    }

    public void StartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(1);
    }
}
