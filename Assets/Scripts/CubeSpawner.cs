using UnityEngine;

public class CubeSpawner : MonoBehaviour
{
    [SerializeField] private Cube _cubePrefab;

    [SerializeField] private ExplosionForce _explosionForce;

    [SerializeField] private int _minSpawnCount = 2;
    [SerializeField] private int _maxSpawnCount = 6;

    public void TrySplit(Cube cube)
    {
        float cubeDivider = 2f;
        bool isSplit =Random.value <= cube.SplitChance;

        Vector3 position = cube.transform.position;
        Vector3 scale = cube.transform.localScale;

        if (isSplit)
        {
            int count = Random.Range(_minSpawnCount, _maxSpawnCount + 1);

            for (int i = 0; i < count; i++)
            {
                CreateCube(position, scale, cube.SplitChance / cubeDivider);
            }
        }

        Destroy(cube.gameObject);
    }

    private void CreateCube(Vector3 position, Vector3 scale, float splitChance)
    {
        float cubeDivider = 2f;

        Vector3 randomOffset = Random.insideUnitSphere;

        Cube newCube = Instantiate(_cubePrefab, position + randomOffset, Random.rotationUniform);

        newCube.transform.localScale = scale / cubeDivider;

        newCube.Initialize(splitChance);

        SetRandomColor(newCube);

        _explosionForce.Apply(newCube.GetComponent<Rigidbody>(), position);
    }

    private void SetRandomColor(Cube cube)
    {
        Renderer cubeRenderer = cube.GetComponent<Renderer>();

        cubeRenderer.material.color = new Color(Random.value, Random.value, Random.value);
    }
}
