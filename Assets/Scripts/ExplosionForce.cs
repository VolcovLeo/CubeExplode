using UnityEngine;

public class ExplosionService : MonoBehaviour
{
    [SerializeField] private float _force = 5f;
    [SerializeField] private float _radius = 3f;

    public void Explode(Rigidbody cubeRigitbody, Vector3 position)
    {
        cubeRigitbody.AddExplosionForce(_force, position, _radius, 0f, ForceMode.Impulse);
    }
}
