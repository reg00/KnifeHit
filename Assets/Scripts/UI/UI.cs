using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UI : MonoBehaviour
{
    public static UI Instance;

    private string currThrows;

    private void Awake()
    {
        Instance = this;
    }

    public void UpdateScore()
    {
        transform.Find("CurrScore").GetComponent<TextMeshProUGUI>().text = $"Текущий счет: {Manager.currentThrows}";
        transform.Find("CurrStage").GetComponent<TextMeshProUGUI>().text = $"Уровень: {Manager.currentStages}";
    }
}
