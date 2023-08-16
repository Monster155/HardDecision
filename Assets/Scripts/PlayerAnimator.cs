using System;
using System.Collections;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [Space]
    [SerializeField] private AnimationClip _idle;
    [SerializeField] private AnimationClip _walk;
    [SerializeField] private AnimationClip _pick;
    [SerializeField] private AnimationClip _attack;
    [SerializeField] private AnimationClip _hide;

    private AnimationClip GetAnimClip(PlayerAnimationsNames animName)
    {
        switch (animName)
        {
            case PlayerAnimationsNames.Idle:
                return _idle;
            case PlayerAnimationsNames.Walk:
                return _walk;
            case PlayerAnimationsNames.Run:
                return _walk;
            case PlayerAnimationsNames.KnifeAttack:
                return _attack;
            case PlayerAnimationsNames.Hide:
                return _hide;
            case PlayerAnimationsNames.Pick:
                return _pick;
            default:
                throw new ArgumentOutOfRangeException(nameof(animName), animName, null);
        }
    }

    public void PlayAnim(PlayerAnimationsNames animName)
    {
        _animator.Play(GetAnimClip(animName).name);
    }

    public void PlayAnimOnce(PlayerAnimationsNames animName, Action whenAnimEnds)
    {
        PlayAnim(animName);
        StartCoroutine(WaitAnimationEnds(GetAnimClip(animName).length, whenAnimEnds));
    }

    private IEnumerator WaitAnimationEnds(float time, Action actionOnEnd)
    {
        yield return new WaitForSeconds(time);

        actionOnEnd.Invoke();
    }
}