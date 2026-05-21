using UnityEngine;

public class Game : MonoBehaviour
{
    [SerializeField] private InputReader _inputReader;
    [SerializeField] private CubeRaycaster _raycaster;
    [SerializeField] private CubeSpawner _spawner;
    [SerializeField] private CubeExplosion _explosion;
    [SerializeField] private float _splitExplosionForce = 5f;
    [SerializeField] private float _splitExplosionRadius = 3f;
    [SerializeField] private float _splitExplosionLiftModifier = 0f;

    private void OnEnable()
    {
        _inputReader.Clicked += OnClicked;
    }

    private void OnDisable()
    {
        _inputReader.Clicked -= OnClicked;
    }

    private void OnClicked(Vector3 clickPosition)
    {
        if (_raycaster.TryGetCube(clickPosition, out Cube cube))
        {
            ProcessCube(cube);
        }
    }

    private void ProcessCube(Cube cube)
    {
        if (Random.value <= cube.SplitChance)
        {
            Cube[] cubes = _spawner.Spawn(cube);

            foreach (Cube newCube in cubes)
            {
                newCube.Rigidbody.AddExplosionForce(_splitExplosionForce, cube.transform.position,
                    _splitExplosionRadius, _splitExplosionLiftModifier, ForceMode.Impulse);
            }
        }
        else
        {
            _explosion.Explode(cube);
        }

        _spawner.DestroyCube(cube);
    }
}
