using UnityEngine;

public class ExplosionForce : MonoBehaviour
{
    [SerializeField] private float _force = 5f;
    [SerializeField] private float _radius = 3f;

    public void Apply(Rigidbody rigidbody, Vector3 position)
    {
        rigidbody.AddExplosionForce(_force, position, _radius);
    }
}
