using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class DragDrop : MonoBehaviour
{
    [Header("----------Input Ref---------------")]

    public InputActionReference trackingAction;

    public InputActionReference clickingAction;

    [Header("----------Cam Ref-----------------")]

    public Camera cam;

    public LayerMask dragLayer;

    private Vector2 currentTouchPos;

    private Transform selectedObject;

    private Vector3 offset;

    private Plane dragPlane;

    private void OnEnable()
    {
        trackingAction.action.Enable();
        clickingAction.action.Enable();

        trackingAction.action.performed += OnTouchPosition;
        clickingAction.action.performed += OnTouchPress;
        clickingAction.action.canceled += OnTouchRelease;

    }

    private void OnDisable()
    {
        trackingAction.action.performed -= OnTouchPosition;
        clickingAction.action.performed -= OnTouchPress;
        clickingAction.action.canceled -= OnTouchRelease;


        trackingAction.action.Disable();
        clickingAction.action.Disable();

    }

    private void OnTouchPress(InputAction.CallbackContext context)
    {
        Debug.Log("On Ray");
        Ray ray = cam.ScreenPointToRay(currentTouchPos);
        Ray2D ray2 = new Ray2D(ray.origin, ray.direction);


        RaycastHit2D hit = Physics2D.Raycast(ray2.origin, ray2.direction,dragLayer);
        if (hit.collider != null)
        {
            Debug.Log("hit");

            if (hit.collider.TryGetComponent(out IPressable com))
            {
                com.Press();
                return;
            }


            selectedObject = hit.transform;
            dragPlane = new Plane(-cam.transform.forward, hit.point);
            offset = new Vector2(selectedObject.position.x,selectedObject.position.y) - hit.point;

        }




    }

    private void OnTouchRelease(InputAction.CallbackContext context)
    {
        Debug.Log("OnRelaese");

        selectedObject = null;
    }

    private void OnTouchPosition(InputAction.CallbackContext context)
    {
        Debug.Log("OnLook");

        currentTouchPos = context.ReadValue<Vector2>();

        if (selectedObject != null)
        {
            Debug.Log("On Dragray");

            Ray ray = cam.ScreenPointToRay(currentTouchPos);
            if (dragPlane.Raycast(ray, out float distance))
            {
                Debug.Log("Draggin");

                selectedObject.position = ray.GetPoint(distance) + offset;
            }
        }
    }




}
