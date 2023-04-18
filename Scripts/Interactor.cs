using UnityEngine;

public class Interactor : MonoBehaviour
{
    [SerializeField] Camera _camera;
    [SerializeField] float _interactionDistance;

    IInteractable _currentInteractable;

    void Update()
    {
        InteractionCheck();

        if (Input.GetMouseButtonDown(0) && _currentInteractable != null)
            _currentInteractable.OnInteract();
    }

    void InteractionCheck()
    {
        if (!TryGetInteractable(out var newInteractable))
        {
            ResetFocus();
            return;
        }

        if (_currentInteractable != newInteractable)
        {
            ResetFocus();
            _currentInteractable = newInteractable;
            _currentInteractable.OnFocus();
        }
    }

    bool TryGetInteractable(out IInteractable interactable)
    {
        Ray ray = _camera.ViewportPointToRay(new Vector3(.5f, .5f));

        if (Physics.Raycast(ray, out RaycastHit hit, _interactionDistance) && hit.collider.TryGetComponent(out interactable))
            return true;

        interactable = null;
        return false;
    }

    void ResetFocus()
    {
        if (_currentInteractable != null)
        {
            _currentInteractable.OnLoseFocus();
            _currentInteractable = null;
        }
    }
}
