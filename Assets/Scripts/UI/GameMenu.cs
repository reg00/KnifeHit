using UnityEngine;
using TMPro;

public class GameMenu : MonoBehaviour
{
    [SerializeField]
    public GameObject CompleteMenu;
    [SerializeField]
    public GameObject LoseMenu;

    public void GetScores(bool isComplete)
    {
        var menuObj = isComplete ? CompleteMenu : LoseMenu;

        menuObj.transform.Find("Panel").Find("Scores").Find("Stage").GetComponent<TextMeshProUGUI>().text = $"{Manager.currentStages}\n STAGES";
        menuObj.transform.Find("Panel").Find("Scores").Find("Score").GetComponent<TextMeshProUGUI>().text = $"SCORE - {Manager.currentThrows}";
    }

    public void SetActive(bool isComplete, bool isActive)
    {
        var menuObj = isComplete ? CompleteMenu : LoseMenu;
        menuObj.SetActive(isActive);
    }
}
