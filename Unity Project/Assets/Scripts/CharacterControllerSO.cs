using System.Data.Common;
using UnityEngine;

[CreateAssetMenu]
public class CharacterControllerSO : ScriptableObject
{
    public Vector3 position = Vector3.zero;
    
    public float jumpSpeed = 10f, rollSpeed = 100f, gravity = 9.81f, swingMomentumSpeed = 5f, vaultDistance = 5f, 
        slopeRayLength, slopeMultiplier, knockbackDistance = 1f;
    public FloatDataSO moveSpeed;

    private float offGroundTime = 0.25f;

    private float horizontalInput, verticalInput;

    private RaycastHit hit;

    public BoolDataSO canMove, canMoveLeft, canMoveRight, canMoveUp, canMoveDown, faceMoveDirection, 
        jumping, canJump, isRolling, canRoll, onSlope, grabbing;

    private bool inAir, yReset, jumpAttack;

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
        
        OnSlope(controller);

        if (!isRolling.boolData)
        {
            if (canMove.boolData)
            {
                if (controller.isGrounded)
                {
                    if (jumping.boolData)
                    {
                        jumping.boolData = false;
                    }

                    if (jumpAttack)
                    {
                        jumpAttack = false;
                    }

                    if (!yReset)
                    {
                        position.y = 0;
                        yReset = true;
                        offGroundTime = 0.25f;
                    }

                    if (grabbing.boolData)
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
                    }

                    if (horizontalInput != 0 && verticalInput != 0)
                    {
                        position.x = horizontalInput * moveSpeed.value * 0.75f;
                        position.z = verticalInput * moveSpeed.value * 0.75f;
                    }
                    else
                    {
                        position.x = horizontalInput * moveSpeed.value;
                        position.z = verticalInput * moveSpeed.value;
                    }
    
                    if (faceMoveDirection.boolData)
                    {
                        if (position.x != 0 || position.z != 0)
                        {
                            controller.transform.forward = new Vector3(position.x, 0, position.z);
                        }
                    }
                }
                
                if (!controller.isGrounded)
                {
                    if (!jumping.boolData)
                    {
                        if (onSlope.boolData && (position.x != 0 || position.z != 0))
                        {
                            position.y -= gravity * slopeMultiplier * Time.deltaTime;
                        }
                        else
                        {
                            position.y -= gravity * Time.deltaTime;
                        }

                        offGroundTime -= Time.deltaTime;

                        if (offGroundTime <= 0)
                        {
                            yReset = false;
                        }
                    }

                    if (jumping.boolData && jumpAttack)
                    {
                        Debug.Log("jumping and attacking so extra gravity is in effect");
                        Debug.Log(jumpAttack);
                        position.y -= gravity * slopeMultiplier * Time.deltaTime * 2;
                    }
                    else
                    {
                        position.y -= gravity * Time.deltaTime;
                    }
                }
                
                controller.Move(position * Time.deltaTime);
            }
        }
    }
    
    private void OnSlope(CharacterController controller)
    {
        if (canJump.boolData && jumping.boolData)
        {
            onSlope.boolData = false;
        }
        else if (Physics.Raycast(controller.transform.position, Vector3.down, out hit, controller.height / 2 * slopeRayLength))
        {
            Debug.DrawRay(controller.transform.position, Vector3.down * slopeRayLength);
            
            if (hit.normal != Vector3.up)
            {
                onSlope.boolData = true;
                

                if (hit.normal.y <= 0.3f)
                {
                    onSlope.boolData = false;
                } 
                else if (hit.normal.y <= 0 && onSlope.boolData)
                {
                    onSlope.boolData = false;
                }
            }
            else
            {
                onSlope.boolData = false;
            }
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
                        yReset = false;
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
            if (isRolling.boolData)
            {
                if (!jumping.boolData)
                {
                    if (canMove.boolData)
                    {
                        if (controller.isGrounded)
                        {
                            position.Set(Input.GetAxis("Horizontal") * rollSpeed, 0, Input.GetAxis("Vertical") * rollSpeed);
                        }

                        position.y -= gravity * slopeMultiplier * Time.deltaTime;
                        controller.Move(position * Time.deltaTime);
                    }
                }
            }
        }
    }

    //Can't vault after being in the air for an amount of time?
    public void VaultEdge(CharacterController controller)
    {
        faceMoveDirection.boolData = false;
        position += controller.transform.TransformDirection(Vector3.forward) * vaultDistance;
        
        if (position.x > vaultDistance)
        {
            position.x = vaultDistance;
        }
        else if (position.x < -vaultDistance)
        {
            position.x = -vaultDistance;
        }

        if (position.z > vaultDistance)
        {
            position.z = vaultDistance;
        } 
        else if (position.z < -vaultDistance)
        {
            position.z = -vaultDistance;
        }

        position.y = 0;
        position.y += 8;
        
        controller.Move(position * Time.deltaTime);
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
        if (!jumping.boolData)
        {
            canMove.boolData = false;
            position = Vector3.zero;
            position += controller.transform.TransformDirection(Vector3.forward) * swingMomentumSpeed;
        }

        controller.Move(position);
    }

    public void CannotRoll()
    {
        canRoll.boolData = false;
    }

    public void KnockbackMovement(CharacterController controller)
    {
        controller.transform.localPosition -= controller.transform.TransformDirection(Vector3.forward) * knockbackDistance; //change this to character controller
    }

    public void JumpAttackMovement(CharacterController controller)
    {
        if (!controller.isGrounded)
        {
            position.x = 0;
            position.z = 0;
            faceMoveDirection.boolData = false;
            position += controller.transform.TransformDirection(Vector3.forward) * 5;
            position.y = 0;
            jumpAttack = true;
        }
    }
}