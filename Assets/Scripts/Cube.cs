using UnityEngine;

public class Cube : MonoBehaviour
{
    private float _splitChance = 1f;

    public float SplitChance => _splitChance;

    public void Initialize(float splitChance)
    {
        _splitChance = splitChance;
    }
}