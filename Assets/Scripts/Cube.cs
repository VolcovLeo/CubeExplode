using UnityEngine;

[RequireComponent(typeof(Renderer))]
[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Collider))]

public class Cube : MonoBehaviour
{
    public Renderer Renderer { get; private set; }

    public Rigidbody Rigidbody { get; private set; }

    public float SplitChance { get; private set; } = 1f;

    private void Awake()
    {
        Renderer = GetComponent<Renderer>();
        Rigidbody = GetComponent<Rigidbody>();
    }

    public void Init(float splitChance)
    {
        SplitChance = splitChance;
    }
}
