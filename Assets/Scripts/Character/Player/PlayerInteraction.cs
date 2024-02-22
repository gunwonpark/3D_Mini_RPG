using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    private IInteractable _currentInteractObject;
    public KeyCode InteractKey => KeyCode.F;

    private void Update()
    {
        if(Input.GetKeyDown(InteractKey))
        {
            _currentInteractObject?.OnInteract();
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Interactable"))
        {
            _currentInteractObject = other.gameObject.GetComponent<IInteractable>();
            _currentInteractObject?.OnInteractionEnter();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Interactable"))
        {
            _currentInteractObject?.OnInteractionExit();
            _currentInteractObject = null;
        }
    }
}
