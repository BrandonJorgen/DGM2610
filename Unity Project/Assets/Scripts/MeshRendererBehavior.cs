using UnityEngine;

[RequireComponent(typeof(MeshRenderer))]
public class MeshRendererBehavior : MonoBehaviour
{
    private MeshRenderer meshRenderer;

    private void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
    }

    public void DisableRenderer()
    {
        meshRenderer.enabled = false;
    }

    public void EnableRenderer()
    {
        meshRenderer.enabled = true;
    }
}