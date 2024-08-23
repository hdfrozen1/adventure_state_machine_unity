using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdventureWalkState : AdventureBaseState
{
    public AdventureWalkState(AdventureStateMachine currentContext,StateFactory stateFactory):base(currentContext,stateFactory){
        
    }
    public override void CheckSwitchState()
    {
        // if(Input.GetKeyDown(KeyCode.W)){
        //     SwitchState(_factory.Jump());
        // }
        if(_context.Dir.x == 0){
            SwitchState(_factory.Grounded());
        }
    }

    public override void EnterState()
    {
        
        _context.Anim.Play("walk");
    }

    public override void ExitState()
    {
        _context.RunTimeCooldown = 0.1f;
    }

    public override void InitialSubState()
    {
        throw new System.NotImplementedException();
    }

    public override void UpdateState()
    {
        CheckSwitchState();
        _context.AdventureRb.velocity = new Vector2(_context.Dir.x*_context.Speed,_context.AdventureRb.velocity.y);
        

    }
}
