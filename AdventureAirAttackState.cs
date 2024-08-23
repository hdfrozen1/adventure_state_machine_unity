using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdventureAirAttackState : AdventureBaseState
{
    int _attackPhase = -1;
    bool _continueAttack = false;
    string[] _airAttackName = {"air-attack1","air-attack2","air-attack3-loop","air-attack-3-end"};
    public AdventureAirAttackState(AdventureStateMachine currentContext, StateFactory stateFactory) : base(currentContext, stateFactory)
    {

    }
    public override void CheckSwitchState()
    {
        
        if(_attackPhase == 3 && !_context.AnimatorIsPlaying()){
            _attackPhase = -1;
            SwitchState(_factory.Grounded());
        }
        else if((_continueAttack && !_context.AnimatorIsPlaying()) || (_context.IsGrounded() && _attackPhase != 3) ){
            //Debug.Log("next attack");
            
            SwitchState(_factory.AirAttack());
        }
        else if(!_continueAttack && !_context.AnimatorIsPlaying() && _attackPhase != 2){
            
            //Debug.Log("grounded");
            SwitchState(_factory.Fall());
        }
    }

    public override void EnterState()
    {
        _attackPhase += 1;
        _continueAttack = false;
        Debug.Log("air attack phase:" + _attackPhase);
        _context.Anim.Play(_airAttackName[_attackPhase]);
        if(_attackPhase == 2){
            _context.AdventureRb.velocity = new Vector2(_context.AdventureRb.velocity.x,-15);
        }
    }

    public override void ExitState()
    {
        if(_attackPhase == 3){
            _attackPhase = -1;
        }
    }

    public override void InitialSubState()
    {
        throw new System.NotImplementedException();
    }

    public override void UpdateState()
    {
        _context.AdventureRb.velocity = new Vector2(_context.Dir.x*_context.Speed,_context.AdventureRb.velocity.y);
        if( (-1 < _attackPhase && _attackPhase <2)  && Input.GetKeyDown(KeyCode.J) && _context.AnimatorIsPlaying()  ){
            _continueAttack = true; 
        }
        
        CheckSwitchState();
    }
}
