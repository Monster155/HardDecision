using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(NPCVision))]
public class NPCVisionEditor : Editor
{
    private void OnSceneGUI()
    {
        NPCVision npcVision = (NPCVision)target;
        Handles.color = Color.white;
        Handles.DrawWireArc(npcVision.transform.position, Vector3.up, Vector3.forward, 360, npcVision.Radius);

        Vector3 viewAngle01 = DirectionFromAngle(npcVision.transform.eulerAngles.y, -npcVision.Angle / 2);
        Vector3 viewAngle02 = DirectionFromAngle(npcVision.transform.eulerAngles.y, npcVision.Angle / 2);

        Handles.color = Color.yellow;
        Handles.DrawLine(npcVision.transform.position, npcVision.transform.position + viewAngle01 * npcVision.Radius);
        Handles.DrawLine(npcVision.transform.position, npcVision.transform.position + viewAngle02 * npcVision.Radius);

        if (npcVision.canSeePlayer)
        {
            Handles.color = Color.red;
            Handles.DrawLine(npcVision.transform.position, npcVision.PlayerRef.transform.position);
        }
    }

    private Vector3 DirectionFromAngle(float eulerY, float angleInDegrees)
    {
        angleInDegrees += eulerY;

        return new Vector3(Mathf.Sin(angleInDegrees * Mathf.Deg2Rad), 0, Mathf.Cos(angleInDegrees * Mathf.Deg2Rad));
    }
}