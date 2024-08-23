using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdventureJumpState : AdventureBaseState
{
    private string[] _jumpsName = {"jump","smrslt"};
    private int _jumpIndex = 0;
    public AdventureJumpState(AdventureStateMachine currentContext,StateFactory stateFactory):base(currentContext,stateFactory){
        
    }
    public override void CheckSwitchState()
    {
        if(_context.AdventureRb.velocity.y < 0){
            SwitchState(_factory.Fall());
        }
        else if(Input.GetKeyDown(KeyCode.W) && _context.TotalJump >0){
            
            SwitchState(_factory.Jump());
        }
    }

    public override void EnterState()
    {
        if(_context.TotalJump == 2){
            _context.AdventureRb.velocity = new Vector2(_context.AdventureRb.velocity.x,7.5f);
            _jumpIndex = 0;
        }else if(_context.TotalJump == 1){
            _jumpIndex = 1;
            _context.AdventureRb.velocity = new Vector2(_context.AdventureRb.velocity.x,11.5f); 
        }
        _context.Anim.Play(_jumpsName[_jumpIndex]);
        
    }

    public override void ExitState()
    {
        _context.TotalJump -= 1;
    }

    public override void InitialSubState()
    {
        throw new System.NotImplementedException();
    }

    public override void UpdateState()
    {
        //Debug.Log("jumping");
        CheckSwitchState();
        _context.AdventureRb.velocity = new Vector2(_context.Dir.x*_context.Speed,_context.AdventureRb.velocity.y);
        
    }
}
