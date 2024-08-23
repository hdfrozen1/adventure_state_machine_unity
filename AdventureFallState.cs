using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdventureFallState : AdventureBaseState
{
    // Start is called before the first frame update
    public AdventureFallState(AdventureStateMachine currentContext, StateFactory stateFactory) : base(currentContext, stateFactory)
    {

    }
    public override void CheckSwitchState()
    {
        
        if(_context.IsGrounded()){
            SwitchState(_factory.Grounded());
        }else if(Input.GetKeyDown(KeyCode.J)){
            SwitchState(_factory.AirAttack());
        }
        if(_context.TotalJump > 0 && Input.GetKeyDown(KeyCode.W)){
            Debug.Log("Check Switch State");
            SwitchState(_factory.Jump());
        }
    }

    public override void EnterState()
    {
        _context.Speed = 5f;
        _context.Anim.Play("fall");
    }

    public override void ExitState()
    {
        _context.AdventureRb.velocity = Vector2.zero;
    }

    public override void InitialSubState()
    {
        throw new System.NotImplementedException();
    }

    public override void UpdateState()
    {
        CheckSwitchState();
        if(Input.GetKeyDown(KeyCode.W)){
            Debug.Log("Jumping from falling");
        }
       _context.AdventureRb.velocity = new Vector2(_context.Dir.x*_context.Speed,_context.AdventureRb.velocity.y);
    }
}
