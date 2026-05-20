using UnityEngine;

public class CubeExplosion : MonoBehaviour
{
    [SerializeField] private float _baseForce = 100f;
    [SerializeField] private float _baseRadius = 2f;

    public void Explode(Cube cube)
    {
        Vector3 position = cube.transform.position;

        float BaseExplosionMultiplier = 1f;
        float cubeSize = cube.transform.localScale.x;
        float multiplier = BaseExplosionMultiplier / cubeSize;
        float explosionForce = _baseForce * multiplier;
        float explosionRadius = _baseRadius * multiplier;

        Collider[] colliders = Physics.OverlapSphere(position, explosionRadius);

        foreach (Collider hit in colliders)
        {
            if (hit.TryGetComponent(out Rigidbody rigidbody))
            {
                if (rigidbody == cube.Rigidbody)
                    continue;

                rigidbody.AddExplosionForce(explosionForce, position, explosionRadius, 0f, ForceMode.Impulse);
            }
        }
    }
}
