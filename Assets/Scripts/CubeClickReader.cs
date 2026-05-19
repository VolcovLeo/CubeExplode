using UnityEngine;

public class CubeClickReader : MonoBehaviour
{
    [SerializeField] private CubeRaycaster _raycaster;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _raycaster.TryCast();
        }
    }
}
