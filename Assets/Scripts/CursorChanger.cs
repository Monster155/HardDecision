using UnityEngine;

public class CursorChanger : MonoBehaviour
{
    [SerializeField] private Texture2D texture;
    [SerializeField] private Vector2 cursorOffset;
    void Start()
    {
        Cursor.SetCursor(texture,cursorOffset, CursorMode.ForceSoftware);
    }
}
