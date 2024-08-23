using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;

public abstract class AdventureBaseState 
{
    protected AdventureStateMachine _context;
    protected StateFactory _factory;

    public AdventureBaseState(AdventureStateMachine currentContext,StateFactory stateFactory){
        this._context = currentContext;
        this._factory = stateFactory;
    }
    public abstract void EnterState();
    public abstract void UpdateState();
    public abstract void ExitState();

    public abstract void CheckSwitchState();
    public abstract void InitialSubState();

    protected void SwitchState(AdventureBaseState newState){
        ExitState();

        newState.EnterState();
        _context.CurrentState = newState;
        
    }
    protected void SetSuperState(){}
    protected void SetSubState(){}

}
