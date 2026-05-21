using UnityEngine;

public class CubeSpawner : MonoBehaviour
{
    private const float CubeDivider = 2f;
    private const float SplitChanceDivider = 2f;

    [SerializeField] private Cube _cubePrefab;
    [SerializeField] private int _minSpawn = 2;
    [SerializeField] private int _maxSpawn = 6;

    public Cube[] Spawn(Cube cube)
    {
        int count = Random.Range(_minSpawn, _maxSpawn + 1);

        Cube[] cubes = new Cube[count];

        Vector3 position = cube.transform.position;
        Vector3 scale = cube.transform.localScale;

        for (int i = 0; i < count; i++)
        {
            Vector3 offset = Random.insideUnitSphere;

            Cube newCube = Instantiate(_cubePrefab, position + offset, Random.rotationUniform);

            newCube.transform.localScale = scale / CubeDivider;
            newCube.Init(cube.SplitChance / SplitChanceDivider);
            newCube.Renderer.material.color = Random.ColorHSV();

            cubes[i] = newCube;
        }

        return cubes;
    }

    public void DestroyCube(Cube cube)
    {
        Destroy(cube.gameObject);
    }
}