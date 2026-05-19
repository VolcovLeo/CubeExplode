using UnityEngine;

public class CubeSpawner : MonoBehaviour
{
    [SerializeField] private Cube _cubePrefab;

    [SerializeField] private int _minSpawn = 2;
    [SerializeField] private int _maxSpawn = 6;

    public Cube[] Spawn(Cube cube)
    {
        float cubeDivider = 2f;
        int count = Random.Range(_minSpawn, _maxSpawn + 1);

        Cube[] cubes = new Cube[count];

        Vector3 position = cube.transform.position;
        Vector3 scale = cube.transform.localScale;

        for (int i = 0; i < count; i++)
        {
            Vector3 offset = Random.insideUnitSphere;

            Cube newCube = Instantiate(_cubePrefab, position + offset, Random.rotationUniform);

            newCube.transform.localScale = scale / cubeDivider;

            newCube.Init(cube.SplitChance / cubeDivider);

            newCube.Renderer.material.color = new Color(Random.value, Random.value, Random.value);

            cubes[i] = newCube;
        }

        return cubes;
    }
}