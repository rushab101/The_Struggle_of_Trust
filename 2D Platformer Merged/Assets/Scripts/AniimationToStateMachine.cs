using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AniimationToStateMachine : MonoBehaviour
{
    public AttackState attackState;
    private void TriggerAttack()
    {
        attackState.TriggerAttack();
    }
    private void FinishAttacK()
    {
        attackState.FinishAttack();
    }
}
