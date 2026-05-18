using UnityEngine;

public class InputManager : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private CubeSpawner _spawner;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) == false)
            return;

        Ray ray = _camera.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            if (hit.collider.TryGetComponent<Cube>(out Cube cube))
            {
                _spawner.Split(cube);
            }
        }
    }
}
