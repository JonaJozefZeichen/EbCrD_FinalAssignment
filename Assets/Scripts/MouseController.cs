using UnityEngine;

public class MouseController : MonoBehaviour
{
    [SerializeField] private float sensitivity;

    private MouseInputController _mouseInputController;

    private void Start(){
        _mouseInputController = GetComponent<MouseInputController>();
    }

    private void Update()
    {
        Vector3 positionChange = new Vector3
                                 (_mouseInputController.MouseInputVector.x, 0,
                                     _mouseInputController.MouseInputVector.y) *
                                 Time.deltaTime * sensitivity;

        transform.position += positionChange;
    }
}
