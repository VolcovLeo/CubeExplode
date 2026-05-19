using UnityEngine;

public class CubeSplitHandler : MonoBehaviour
{
    [SerializeField] private CubeSpawner _spawner;
    [SerializeField] private CubeExplosion _explosion;

    public void Handle(Cube cube)
    {
        if (Random.value > cube.SplitChance)
        {
            Destroy(cube.gameObject);

            return;
        }

        Cube[] cubes = _spawner.Spawn(cube);

        foreach (Cube newCube in cubes)
        {
            _explosion.Explode(newCube.Rigidbody, cube.transform.position);
        }

        Destroy(cube.gameObject);
    }
}
