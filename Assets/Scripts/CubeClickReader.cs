using UnityEngine;

public class CubeClickReader : MonoBehaviour
{
    [SerializeField] private CubeRaycaster _raycaster;
    [SerializeField] private int _interactionButton = 0;

    private void Update()
    {
        if (Input.GetMouseButtonDown(_interactionButton))
        {
            _raycaster.TryCast();
        }
    }
}
