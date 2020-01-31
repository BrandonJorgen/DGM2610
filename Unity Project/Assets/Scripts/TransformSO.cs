using UnityEngine;

[CreateAssetMenu]
public class TransformSO : ScriptableObject
{
    public Vector3 resetCoords;
    
    public void MoveToPoint(Transform transform)
    {
        transform.position = resetCoords;
    }
}