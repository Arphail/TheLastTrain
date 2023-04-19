using UnityEngine;

public class Interactor : MonoBehaviour
{
    private [SerializeField] Camera _camera;
    private [SerializeField] float _interactionDistance;

    private IInteractable _currentInteractable;

    private void Update()
    {
        InteractionCheck();

        if (Input.GetMouseButtonDown(0) && _currentInteractable != null)
            _currentInteractable.OnInteract();
    }

    private void InteractionCheck()
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

    private bool TryGetInteractable(out IInteractable interactable)
    {
        Ray ray = _camera.ViewportPointToRay(new Vector3(.5f, .5f));

        if (Physics.Raycast(ray, out RaycastHit hit, _interactionDistance) && hit.collider.TryGetComponent(out interactable))
            return true;

        interactable = null;
        return false;
    }

    private void ResetFocus()
    {
        if (_currentInteractable != null)
        {
            _currentInteractable.OnLoseFocus();
            _currentInteractable = null;
        }
    }
}
