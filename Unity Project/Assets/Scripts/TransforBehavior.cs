using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class TransforBehavior : MonoBehaviour
{
    public CharacterController controller;

    private void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    public void DisableController()
    {
        controller.enabled = false;
    }
}