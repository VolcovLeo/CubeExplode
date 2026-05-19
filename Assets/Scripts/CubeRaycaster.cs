using UnityEngine;

public class CubeRaycaster : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private CubeSplitHandler _handler;

    public void TryCast()
    {
        Ray ray = _camera.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            if (hit.collider.TryGetComponent(out Cube cube))
            {
                _handler.Handle(cube);
            }
        }
    }
}
