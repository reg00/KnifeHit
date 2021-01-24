using UnityEngine;

public class Apple : MonoBehaviour
{
    [SerializeField]
    public AppleSpawnProbability appleProb;

    public void SetActiveByProbability()
    {
        if (appleProb.Probability >= Random.Range(1, 100))
            gameObject.SetActive(true);
        else
            gameObject.SetActive(false);
    }
}
