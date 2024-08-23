using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdventureGroundedState : AdventureBaseState
{
    public AdventureGroundedState(AdventureStateMachine currentContext,StateFactory stateFactory):base(currentContext,stateFactory){
        
    }
    public override void CheckSwitchState()
    {
        // if(Input.GetKeyDown(KeyCode.W)){
        //     SwitchState(_factory.Jump());
        // }
        if(_context.IsGrounded() && Input.GetKeyDown(KeyCode.W)){
            SwitchState(_factory.Jump());
        }
        else if(_context.Dir.x  != 0 && (_context.RunTimeCooldown < 0.1 && _context.RunTimeCooldown > 0 )){
            SwitchState(_factory.Run());
        }
        else if(_context.Dir.x  != 0){
            SwitchState(_factory.Walk());
        }
        else if(Input.GetKeyDown(KeyCode.J)){
            SwitchState(_factory.Attack());
        }
        
    }

    public override void EnterState()
    {
        _context.Anim.Play("idle");
        _context.TotalJump = 2;
    }

    public override void ExitState()
    {
        
    }

    public override void InitialSubState()
    {
        throw new System.NotImplementedException();
    }

    public override void UpdateState()
    {
        CheckSwitchState();
        if(_context.RunTimeCooldown != 0){
            _context.RunTimeCooldown -= Time.deltaTime;
        }
    }
}
