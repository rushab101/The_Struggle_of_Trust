using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtState : State
{
    public HurtState(Entity etity, FiniteStateMachine stateMachine, string animBoolName) : base(etity, stateMachine, animBoolName) {
    }

    public override void DoChecks() {
        base.DoChecks();
    }

    public override void Enter() {
        base.Enter();
    }

    public override bool Equals(object obj) {
        return base.Equals(obj);
    }

    public override void Exit() {
        base.Exit();
    }

    public override int GetHashCode() {
        return base.GetHashCode();
    }

    public override void LogicUpdate() {
        base.LogicUpdate();
    }

    public override void PhysicsUpdate() {
        base.PhysicsUpdate();
    }

    public override string ToString() {
        return base.ToString();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
