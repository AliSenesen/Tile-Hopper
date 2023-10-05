using System.Collections;
using System.Collections.Generic;
using GameMng;
using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{
    [SerializeField] private Animator animator;
  
    private PlayerAnimationStates _animationStates;
    


    private void ChangeAnimData(PlayerAnimationStates animationStates)
    {
        animationStates = _animationStates;
    }

    public void IdleAnim()
    {
        ChangeAnimData(PlayerAnimationStates.Idle);
        animator.SetBool("isJumping",false);
        
    }
    public void JumpAnim()
    {
        ChangeAnimData(PlayerAnimationStates.Jump);
        animator.SetBool("isJumping",true);
        
    }
  
}
