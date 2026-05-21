using UnityEngine;

public class CubeRaycaster : MonoBehaviour
{
    [SerializeField] private Camera _camera;

    public bool TryGetCube(Vector3 screenPosition, out Cube cube)
    {
        Ray ray = _camera.ScreenPointToRay(screenPosition);

        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            return hit.collider.TryGetComponent(out cube);
        }

        cube = null;

        return false;
    }
}
