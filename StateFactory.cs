
using UnityEngine;
public class StateFactory 
{
    private AdventureStateMachine _context;

    private AdventureGroundedState _groundedState;
    private AdventureWalkState _walkState;
    private AdventureJumpState _jumpState;
    private AdventureRunState _runState;
    private AdventureAttackState _attackState;
    private AdventureFallState _fallState;
    private AdventureAirAttackState _airAttackState;

    public StateFactory(AdventureStateMachine currentContext){
        _context = currentContext;
    }

    public AdventureBaseState Grounded(){
        return _groundedState ??= new AdventureGroundedState(_context, this);
    }

    public AdventureBaseState Walk(){
        return _walkState ??= new AdventureWalkState(_context, this);
    }

    public AdventureBaseState Jump(){
        return _jumpState ??= new AdventureJumpState(_context, this);
    }

    public AdventureBaseState Run(){
        return _runState ??= new AdventureRunState(_context, this);
    }
    public AdventureBaseState Attack(){
        return _attackState ??= new AdventureAttackState(_context,this);
    }
    public AdventureBaseState Fall(){
        
        return _fallState ??= new AdventureFallState(_context,this);
    }
    public AdventureBaseState AirAttack(){
        
        return _airAttackState ??= new AdventureAirAttackState(_context,this);
    }
}

