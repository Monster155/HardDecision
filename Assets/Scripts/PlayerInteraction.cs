using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    [SerializeField] private float interactionRadius = 2f;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            FindInteractableObject()?.Interact();
        }
    }

    private IInteractable FindInteractableObject()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, interactionRadius);

        foreach (Collider collider in colliders)
        {
            if (collider.TryGetComponent(out IInteractable objectInspector))
            {
                return objectInspector;
            }
        }

        return null;
    } 

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, interactionRadius);
    }
}
