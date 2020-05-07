using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FiniteStateMachine 
{
    public State currentState {get; private set; } //getter -> any class function can get it and setter ->only this class can set the functions
    public void Initialize(State startingState)
    {
        currentState= startingState;
        currentState.Enter();
    }

    public void ChangeState(State newState)
    {
        currentState.Exit();
        currentState = newState;
        currentState.Enter();
        
    }
    
}
