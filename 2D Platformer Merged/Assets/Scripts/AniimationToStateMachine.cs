using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AniimationToStateMachine : MonoBehaviour
{
    public AttackState attackState;
    public BossAttackState bossAttackState;
    public Boss_melee_attack_state boss;
    private void TriggerAttack()
    {
        attackState.TriggerAttack();
        bossAttackState.TriggerAttack();
        boss.TriggerAttack();
    }
    private void FinishAttacK()
    {
        attackState.FinishAttack();
        bossAttackState.FinishAttack();
        boss.FinishAttack();
    }
}
