using UnityEngine;

[CreateAssetMenu(fileName = "Spawn Probability", menuName = "Apple")]
public class AppleSpawnProbability : ScriptableObject
{
    [Range(1, 100)]
    public int Probability;
}
