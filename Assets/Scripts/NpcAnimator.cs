using System;
using UnityEngine;

public class NpcAnimator : MonoBehaviour
{
    [SerializeField] private Animator _animator;

    private const string IDLE_ANIM = "Idle";
    private const string WALK_ANIM = "Walk";
    private const string RUN_ANIM = "Run";
    private const string DEAF_ANIM = "Deaf";

    public void PlayAnim(NpcAnimationsNames animName)
    {
        switch (animName)
        {
            case NpcAnimationsNames.Idle:
                _animator.Play(IDLE_ANIM);
                break;
            case NpcAnimationsNames.Walk:
                _animator.Play(WALK_ANIM);
                break;
            case NpcAnimationsNames.Run:
                _animator.Play(WALK_ANIM);
                break;
            case NpcAnimationsNames.Deaf:
                _animator.Play(DEAF_ANIM);
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(animName), animName, null);
        }
    }
}