using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdventureAttackState : AdventureBaseState
{
    int _attackPhase = 0;
    string _attackName = "attack";
    bool _continueAttack = false;
    public AdventureAttackState(AdventureStateMachine currentContext, StateFactory stateFactory) : base(currentContext, stateFactory)
    {

    }
    public override void CheckSwitchState()
    {
        
        if(_continueAttack && !_context.AnimatorIsPlaying() ){
            //Debug.Log("next attack");
            
            SwitchState(_factory.Attack());
        }
        else if(!_continueAttack && !_context.AnimatorIsPlaying()){
            
            //Debug.Log("grounded");
            _attackPhase = 0;
            SwitchState(_factory.Grounded());
        }
    }

    public override void EnterState()
    {
        _continueAttack = false;
        _attackPhase += 1;
        _context.Anim.Play(_attackName + _attackPhase);
        
    }

    public override void ExitState()
    {
        if(_attackPhase == 3){
            _attackPhase = 0;
        }
    }

    public override void InitialSubState()
    {
        throw new System.NotImplementedException();
    }

    public override void UpdateState()
    {
        
        if( (0 < _attackPhase && _attackPhase <3)  && Input.GetKeyDown(KeyCode.J) && _context.AnimatorIsPlaying()  ){
            _continueAttack = true;
            
        }
        CheckSwitchState();
    }
}
