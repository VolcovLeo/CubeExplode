using UnityEngine;

public class CubeExplosion : MonoBehaviour
{
    [SerializeField] private float _force = 5f;
    [SerializeField] private float _radius = 3f;

    public void Explode(Rigidbody rigidbody, Vector3 position)
    {
        rigidbody.AddExplosionForce(_force, position, _radius, 0f, ForceMode.Impulse);
    }
}
