using UnityEngine;

[CreateAssetMenu]
public class CharacterControllerSO : ScriptableObject
{
    public Vector3 position;
    
    public float moveSpeed = 5f, jumpSpeed = 10f, rollSpeed = 100f, gravity = 9.81f, swingMomentumSpeed = 5f;

    public bool canMove = true;

    public void ResetPosition()
    {
        position = new Vector3(0, 1, 0);
    }
    
    public void MoveCharacter(CharacterController controller)
    {
        if (canMove)
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
    }

    public void Jump(CharacterController controller)
    {
        if (canMove)
        {
            if (controller.isGrounded)
            {
                position.y = jumpSpeed;
            }
        
            controller.Move(position * Time.deltaTime);
        }
    }

    public void DodgeRoll(CharacterController controller)
    {
        if (canMove)
        {
            if (controller.isGrounded)
            {
                position.Set(Input.GetAxis("Horizontal") * rollSpeed, 0, Input.GetAxis("Vertical") * rollSpeed);
            }
        
            controller.Move(position * Time.deltaTime);
        }
    }

    public void ShrinkHeight(CharacterController controller)
    {
        controller.height = 0.5f;
    }

    public void GrowHeight(CharacterController controller)
    {
        controller.height = 1f;
    }

    public void StopMovement(CharacterController controller)
    {
        canMove = false;
        position = Vector3.zero;
    }

    public void ResumeMovement(CharacterController controller)
    {
        canMove = true;
    }

    public void SwingMomentum(CharacterController controller)
    {
        //Placeholder for attack movement
    }
}