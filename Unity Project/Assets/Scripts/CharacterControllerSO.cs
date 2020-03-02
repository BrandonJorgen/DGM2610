using System.Data.Common;
using UnityEngine;

[CreateAssetMenu]
public class CharacterControllerSO : ScriptableObject
{
    public Vector3 position = Vector3.zero;
    
    public float jumpSpeed = 10f, rollSpeed = 100f, gravity = 9.81f, swingMomentumSpeed = 5f, vaultDistance = 5f, 
        slopeRayLength, slopeMultiplier;
    public FloatDataSO moveSpeed;

    private float horizontalInput, verticalInput;

    private RaycastHit hit;

    public BoolDataSO canMove, canMoveLeft, canMoveRight, canMoveUp, canMoveDown, faceMoveDirection, 
        jumping, canJump, canRoll, attacking, onSlope;

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
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        if (!canRoll.boolData)
        {
            if (canMove.boolData)
            {
                if (controller.isGrounded)
                {
                    if (jumping.boolData)
                    {
                        jumping.boolData = false;
                    }
                    
                    position.x = horizontalInput * moveSpeed.value;
                    position.z = verticalInput * moveSpeed.value;
    
                    if (faceMoveDirection.boolData)
                    {
                        if (position.x != 0 || position.z != 0)
                        {
                            controller.transform.forward = new Vector3(position.x, 0, position.z);
                        }
                    }
                }
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
            }

            OnSlope(controller);
            
            if ((position.x != 0 || position.z != 0) && onSlope.boolData)
            {
                position.y -= gravity * slopeMultiplier * Time.deltaTime;
            }
            else
            {
                position.y -= gravity * Time.deltaTime;
            }
            
            controller.Move(position * Time.deltaTime);
        }
    }

    private void OnSlope(CharacterController controller)
    {
        if (canJump.boolData && jumping.boolData)
        {
            onSlope.boolData = false;
        }

        if (Physics.Raycast(controller.transform.position, Vector3.down, out hit, controller.height / 2 * slopeRayLength))
        {
            if (hit.normal != Vector3.up)
            {
                onSlope.boolData = true;
            }
        }
        else
        {
            onSlope.boolData = false;
        }
    }

    public void Jump(CharacterController controller)
    {
        if (canJump.boolData)
        {
            if (!jumping.boolData)
            {
                if (canMove.boolData)
                {
                    if (controller.isGrounded)
                    {
                        position.y = jumpSpeed;
                        jumping.boolData = true;
                    }
                }
                
                controller.Move(position * Time.deltaTime);
            }
        }
    }

    public void DodgeRoll(CharacterController controller)
    {
        if (canRoll.boolData)
        {
            if (!jumping.boolData)
            {
                if (canMove.boolData)
                {
                    if (controller.isGrounded)
                    {
                        position.Set(Input.GetAxisRaw("Horizontal") * rollSpeed, 0, Input.GetAxisRaw("Vertical") * rollSpeed);
                    }
        
                    controller.Move(position * Time.deltaTime);
                }
            }
        }
    }

    public void VaultEdge(CharacterController controller)
    {
        if (jumping.boolData)
        {
            faceMoveDirection.boolData = false;
            DisableController(controller);
            //TODO line up delay here with animation length or use a different function
            controller.transform.position += Vector3.up * vaultDistance;
            controller.transform.localPosition += controller.transform.TransformDirection(Vector3.forward) * vaultDistance;
            //Remember to set the controller back to enabled when the player is ready to move again
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

    public void EnableController(CharacterController controller)
    {
        controller.enabled = true;
    }

    public void DisableController(CharacterController controller)
    {
        controller.enabled = false;
    }

    public void SwingMovement(CharacterController controller)
    {
        if (!jumping.boolData && attacking.boolData)
        {
            controller.transform.localPosition += controller.transform.TransformDirection(Vector3.forward) * swingMomentumSpeed;
        }
    }
}