using UnityEngine;

public class CubeSplitter : MonoBehaviour
{
    [Header("Split Settings")]

    [SerializeField] private GameObject _cubePrefab;

    [SerializeField] private int _minSpawnCount = 2;
    [SerializeField] private int _maxSpawnCount = 6;

    [SerializeField] private float _explosionForce = 5f;
    [SerializeField] private float _explosionRadius = 3f;

    private float _splitChance = 1f;

    public void Initialize(float chance)
    {
        _splitChance = chance;
    }

    private void OnMouseDown()
    {
        TrySplit();
    }

    private void TrySplit()
    {
        float cubeDivider = 2f;
        bool isSplitting = Random.value <= _splitChance;

        Vector3 position = transform.position;
        Vector3 scale = transform.localScale;

        if (isSplitting)
        {
            int count = Random.Range(_minSpawnCount, _maxSpawnCount + 1);

            for (int i = 0; i < count; i++)
            {
                Vector3 randomOffset = Random.insideUnitSphere;

                GameObject newCube = Instantiate(_cubePrefab, position + randomOffset, Random.rotation);

                newCube.transform.localScale = scale / cubeDivider;

                Renderer renderer = newCube.GetComponent<Renderer>();

                renderer.material.color = new Color(Random.value, Random.value, Random.value);

                CubeSplitter splitter = newCube.GetComponent<CubeSplitter>();

                splitter.Initialize(_splitChance / cubeDivider);

                Rigidbody cubeRigidbody = newCube.GetComponent<Rigidbody>();

                cubeRigidbody.AddExplosionForce(_explosionForce, position, _explosionRadius);
            }
        }

        Destroy(gameObject);
    }
}
