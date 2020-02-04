using UnityEngine;

[CreateAssetMenu]
public class CharacterControllerSO : ScriptableObject
{
    public Vector3 position;
    
    public float jumpSpeed = 10f, rollSpeed = 100f, gravity = 9.81f, swingMomentumSpeed = 5f;
    public FloatDataSO moveSpeed;

    private float horizontalInput, verticalInput;

    public BoolDataSO canMove, canMoveLeft, canMoveRight, canMoveUp, canMoveDown, faceMoveDirection;

    public void ResetBools()
    {
        canMove.boolData = true;
        canMoveUp.boolData = true;
        canMoveDown.boolData = true;
        canMoveLeft.boolData = true;
        canMoveRight.boolData = true;
        faceMoveDirection.boolData = true;
    }
    
    public void MoveCharacter(CharacterController controller)
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");
        
        if (canMove.boolData)
        {
            if (controller.isGrounded)
            {
                if (!canMoveUp.boolData && verticalInput > 0)
                {
                    verticalInput = 0;
                }

                if (!canMoveDown.boolData && verticalInput < 0)
                {
                    verticalInput = 0;
                }

                if (!canMoveLeft.boolData && horizontalInput < 0)
                {
                    horizontalInput = 0;
                }

                if (!canMoveRight.boolData && horizontalInput > 0)
                {
                    horizontalInput = 0;
                }
            
                position.Set(horizontalInput * moveSpeed.value, 0, verticalInput * moveSpeed.value);

                if (faceMoveDirection.boolData)
                {
                    if (position != Vector3.zero)
                    {
                        controller.transform.forward = position;
                    }
                }
            }
        
            position.y -= gravity * Time.deltaTime;
            controller.Move(position * Time.deltaTime);
        }
    }

    public void Jump(CharacterController controller)
    {
        if (canMove.boolData)
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
        if (canMove.boolData)
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
        canMove.boolData = false;
        position = Vector3.zero;
    }

    public void ResumeMovement(CharacterController controller)
    {
        canMove.boolData = true;
    }
}