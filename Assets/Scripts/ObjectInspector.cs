using UnityEngine;

public class ObjectInspector : MonoBehaviour, IInteractable
{
    [SerializeField] private string descriptionMessage;

    public void Interact()
    {
        Debug.Log(descriptionMessage);
    }
}
