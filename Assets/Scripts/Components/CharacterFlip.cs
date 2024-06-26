using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterFlip : CharacterComponents
{
    public enum FlipMode
    {
        MovementDirection,
        WeaponDirection
    }

    [SerializeField] private FlipMode flipMode = FlipMode.MovementDirection;
    [SerializeField] private float threshold = 0.1f;       

    protected override void HandleAbility()
    {
        base.HandleAbility();
        
        if (flipMode == FlipMode.MovementDirection)
        {
            FlipToMoveDirection();
        }
        else
        {
            FlipToWeaponDirection();
        }
    }

    // Flips our character by the direction we are moving
    private void FlipToMoveDirection()
    {
        if (controller.CurrentMovement.normalized.magnitude > threshold)
        {
            if (controller.CurrentMovement.normalized.x > 0)
            {
                FaceDirection(1);
            }
            else if (controller.CurrentMovement.normalized.x < 0)
            {
                FaceDirection(-1);
            }
            else
            {
                FaceDirection(transform.localScale.x);
            }
        }
    }

    // Flips our character by our Weapon Aiming
    private void FlipToWeaponDirection()
    {

    }

    // Makes our character face the direction in which is moving
    private void FaceDirection(float newDirection)
    {
        //Get player size
        float OriginalX = System.Math.Abs(transform.localScale.x);
        float OriginalY = System.Math.Abs(transform.localScale.y);
		
        if (newDirection > 0)
        {
            transform.localScale = new Vector3(OriginalX, OriginalY, 1);
        }
        else
        {
            transform.localScale = new Vector3(-OriginalX, OriginalY, 1);
        }		
    }
}
