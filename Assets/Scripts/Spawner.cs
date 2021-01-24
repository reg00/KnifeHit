using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Spawner : MonoBehaviour
{
    GameObject knife;
    ObjectPooler pooler;

    [SerializeField]
    public float force;
    public GameObject knifePrefab;

    void Awake()
    {
        pooler = ObjectPooler.Instance;
        pooler.GenerateNewPool();
        knife = pooler.SpawnFromPool(transform.position);
    }

    void Update()
    {
        if(Input.GetMouseButtonDown(0) && knife != null)
        {
            knife.transform.parent = null;
            knife.GetComponent<Rigidbody2D>().AddForce(Vector2.up * force, ForceMode2D.Impulse);
            knife = pooler.SpawnFromPool(transform.position);
        }
    }

    public void Lose()
    {
        Debug.Log(Manager.currentThrows);
        Destroy(this.knife);

        var knifes = GameObject.FindGameObjectsWithTag("Knife");

        foreach (var knife in knifes)
        {
            knife.transform.parent = null;
            knife.GetComponent<Rigidbody2D>().gravityScale = 1;
            knife.GetComponent<Rigidbody2D>().AddForce(Random.insideUnitCircle * Random.Range(1,10), ForceMode2D.Impulse); 
        }

        //retry
        //StartCoroutine("WaitForLose");
        Manager.StartGame();
    }

    private void DestroyOldKnifes()
    {
        var activeKnifes = GameObject.FindGameObjectsWithTag("Knife");

        foreach (var knife in activeKnifes)
            Destroy(knife);
    }

    private void ScatterKnifes()
    {
        var activeKnifes = GameObject.FindGameObjectsWithTag("Knife");
        foreach (var knife in activeKnifes)
        {
            knife.transform.parent = null;
            knife.GetComponent<Knife>().enabled = false;
            knife.GetComponent<Rigidbody2D>().gravityScale = 1f;
            knife.GetComponent<Rigidbody2D>().AddForce(Random.insideUnitCircle, ForceMode2D.Impulse);
        }
    }

    #region EndGame

    public void OpenNextLvlUI()
    {
        StartCoroutine(DelayBeforeUI(true));
    }

    public void OpenLoseUI()
    {
        ScatterKnifes();
        StartCoroutine(DelayBeforeUI(false));
    }

    public void NextLvl()
    {
        Time.timeScale = 1f;
        Manager.instance.AddStage();
        DestroyOldKnifes();
        pooler.GenerateNewPool();
        knife = pooler.SpawnFromPool(transform.position);
    }

    public void Retry()
    {
        Time.timeScale = 1f;
        Manager.StartGame();
    }

    IEnumerator DelayBeforeUI(bool complete)
    {
        yield return new WaitForSeconds(1);
        Time.timeScale = 0f;

        GameObject.FindGameObjectWithTag("Menu").GetComponent<GameMenu>().SetActive(complete, true);
        GameObject.FindGameObjectWithTag("Menu").GetComponent<GameMenu>().GetScores(complete);
    }

    #endregion
}
