using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AniimationToStateMachine : MonoBehaviour
{
    public AttackState attackState;
    public BossAttackState bossAttackState;
    private void TriggerAttack()
    {
        attackState.TriggerAttack();
        bossAttackState.TriggerAttack();
    }
    private void FinishAttacK()
    {
        attackState.FinishAttack();
        bossAttackState.FinishAttack();
    }
}
