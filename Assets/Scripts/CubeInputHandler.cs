using UnityEngine;

public class CubeInputHandler : MonoBehaviour
{
    private CubeSpawner _spawner;
    private Cube _cube;

    private void Awake()
    {
        _cube = GetComponent<Cube>();
        _spawner = FindObjectOfType<CubeSpawner>();
    }

    private void OnMouseDown()
    {
        if (_spawner == null || _cube == null)
            return;

        _spawner.TrySplit(_cube);
    }
}