using UnityEngine;
using UnityEngine.SceneManagement;

public class Manager : MonoBehaviour
{
    public static Manager instance;

    public static int recordThrows { get; private set; }
    public static int recordStages { get; private set; }
    public static int apples { get; private set; }

    public static int currentThrows { get; private set; }
    public static int currentStages { get; private set; }

    public GameObject StartMenu;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        currentThrows = 0;
        currentStages = 1;
    }

    public void AddThrow()
    {
        currentThrows++;
        UI.Instance.UpdateScore();
    }

    public void AddStage()
    {
        currentStages++;
        UI.Instance.UpdateScore();
    }

    public static void UpdateScore()
    {
        if (currentThrows > recordThrows)
            recordThrows = currentThrows;
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public static void StartGame()
    {
        SceneManager.LoadScene(1);
    }
}
