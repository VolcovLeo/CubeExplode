using UnityEngine;

public class CubeSplitHandler : MonoBehaviour
{
    private const float SplitExplosionForce = 5f;
    private const float SplitExplosionRadius = 3f;
    private const float ExplosionLiftModifier = 0f;

    [SerializeField] private CubeSpawner _spawner;
    [SerializeField] private CubeExplosion _explosion;

    public void Handle(Cube cube)
    {
        bool shouldSplit = Random.value <= cube.SplitChance;

        if (shouldSplit)
        {
            Cube[] cubes = _spawner.Spawn(cube);

            foreach (Cube newCube in cubes)
            {
                newCube.Rigidbody.AddExplosionForce(SplitExplosionForce, cube.transform.position, 
                    SplitExplosionRadius, ExplosionLiftModifier, ForceMode.Impulse);
            }
        }
        else
        {
            _explosion.Explode(cube);
        }

        Destroy(cube.gameObject);
    }
}
