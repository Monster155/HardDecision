using System;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    [SerializeField] private Animator _animator;

    private const string IDLE_ANIM = "IdleAnim";
    private const string WALK_ANIM = "WalkAnim";
    private const string PICK_ANIM = "PickAnim";
    private const string ATTACK_ANIM = "HandAttackAnim";
    private const string HIDE_ANIM = "HideAnim";

    public void PlayAnim(PlayerAnimationsNames animName)
    {
        switch (animName)
        {
            case PlayerAnimationsNames.Idle:
                _animator.Play(IDLE_ANIM);
                break;
            case PlayerAnimationsNames.Walk:
                _animator.Play(WALK_ANIM);
                break;
            case PlayerAnimationsNames.Run:
                _animator.Play(WALK_ANIM);
                break;
            case PlayerAnimationsNames.KnifeAttack:
                _animator.Play(ATTACK_ANIM);
                break;
            case PlayerAnimationsNames.Hide:
                _animator.Play(HIDE_ANIM);
                break;
            case PlayerAnimationsNames.Pick:
                _animator.Play(PICK_ANIM);
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(animName), animName, null);
        }
    }
}