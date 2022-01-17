using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    [SerializeField] private Animator _anim;

    public void PlayRun(float speed)
    {
        _anim.SetFloat(TagManager.RUNANIMATIONPARAMETR,speed);
    }

    public void PlayJump(bool grounded)
    {
        _anim.SetBool(TagManager.JUMPANIMATIONPARAMETR,grounded);
    }
}
