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
        jumping, canJump, isRolling, canRoll, attacking, onSlope;

    private bool inAir, yReset;

    public void ResetBools()
    {
        canMove.boolData = true;
        canMoveUp.boolData = true;
        canMoveDown.boolData = true;
        canMoveLeft.boolData = true;
        canMoveRight.boolData = true;
        faceMoveDirection.boolData = true;
    }
    
    //BUG need to make position.y set to 0 due to the build up of gravity making falling off ledges incredibly fast
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

                    if (!yReset)
                    {
                        position.y = 0;
                        yReset = true;
                        offGroundTime = 0.25f;
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
                    else
                    {
                        position.y -= gravity * Time.deltaTime;
                    }
                }
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
        if (jumping.boolData)
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

            position.y += 1;
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

    public void CannotRoll()
    {
        canRoll.boolData = false;
    }

    public void KnockbackMovement(CharacterController controller)
    {
        controller.transform.localPosition -= controller.transform.TransformDirection(Vector3.forward) * knockbackDistance;
    }
}