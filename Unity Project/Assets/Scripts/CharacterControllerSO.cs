using UnityEngine;

[CreateAssetMenu]
public class CharacterControllerSO : ScriptableObject
{
    public Vector3 position;

    public float moveSpeed = 5f, jumpSpeed = 10f, rollDistance = 100f, gravity = 9.81f;
    
    public void MoveCharacter(CharacterController controller)
    {
        if (controller.isGrounded)
        {
            position.Set(Input.GetAxis("Horizontal") * moveSpeed, 0, Input.GetAxis("Vertical") * moveSpeed);
            
            if (position != Vector3.zero)
            {
                controller.transform.forward = position;
            }
        }
        
        position.y -= gravity * Time.deltaTime;
        controller.Move(position * Time.deltaTime);
    }

    public void Jump(CharacterController controller)
    {
        if (controller.isGrounded)
        {
            position.y = jumpSpeed;
        }
        
        controller.Move(position * Time.deltaTime);
    }

    public void DodgeRoll(CharacterController controller)
    {
        if (controller.isGrounded)
        {
            //Move forward by a specific amount at a specific speed
            position.Set(Input.GetAxis("Horizontal") * rollDistance, 0, Input.GetAxis("Vertical") * rollDistance);
            //Reduce controller height
        }
        
        controller.Move(position * Time.deltaTime);
    }
}