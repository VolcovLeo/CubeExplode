using System.IO;
using UnityEngine;

public class CubeSpawner : MonoBehaviour
{
    [SerializeField] private Cube _cubePrefab;
    [SerializeField] private ExplosionService _explosionService;

    [SerializeField] private int _minSpawn = 2;
    [SerializeField] private int _maxSpawn = 6;

    public void Split(Cube cube)
    {
        float cubeDivider = 2f;

        if (Random.value > cube.SplitChance)
        {
            Destroy(cube.gameObject);
            return;
        }

        int count = Random.Range(_minSpawn, _maxSpawn + 1);

        Vector3 position = cube.transform.position;
        Vector3 scale = cube.transform.localScale;

        for (int i = 0; i < count; i++)
        {
            SpawnCube(position, scale, cube.SplitChance / cubeDivider);
        }

        Destroy(cube.gameObject);
    }

    private void SpawnCube(Vector3 position, Vector3 scale, float chance)
    {
        float cubeDivider = 2f;

        Vector3 offset = Random.insideUnitSphere;

        Cube newCube = Instantiate(_cubePrefab, position + offset, Random.rotationUniform);

        newCube.transform.localScale = scale / cubeDivider;
        newCube.Init(chance);

        newCube.Renderer.material.color = new Color(Random.value, Random.value, Random.value);

        _explosionService.Explode(newCube.Rigidbody, position);
    }
}