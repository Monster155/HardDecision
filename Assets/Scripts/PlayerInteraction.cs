using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    [SerializeField] private float _interactionRadius = 2f;

    private IInteractable FindInteractableObject()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, _interactionRadius);

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
        Gizmos.DrawWireSphere(transform.position, _interactionRadius);
    }
}