using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class AdventureStateMachine : MonoBehaviour
{
    public Animator Anim { get; private set; }
    public Rigidbody2D AdventureRb{ get;set; }
    private BoxCollider2D _adventureBox;
    // public float HorizontalInput{get;private set;}
    // public float VerticalInput{get;private set;}
    private AdventureBaseState _currentState;
    public AdventureBaseState CurrentState{get {return _currentState;} set{_currentState = value;}}
    private StateFactory _state;
    private Vector2 _dir = Vector2.zero;
    public Vector2 Dir { get { return _dir; } set{_dir = value;} }
    public float Speed {get;set;}
    public float RunTimeCooldown{get;set;}
    public bool AttackPressed{get;set;}
    [SerializeField] private LayerMask _groundLayer;
    public int TotalJump {get;set;}
    [SerializeField] private Transform _groundPoint;

    private void Awake()
    {
        TotalJump = 0;
        _adventureBox = GetComponent<BoxCollider2D>();
        AttackPressed = false;
        Speed = 5;
        Anim = GetComponent<Animator>();
        AdventureRb = GetComponent<Rigidbody2D>();
        _state = new StateFactory(this);
        
        
    }
    private void Start() {
        
        if(IsGrounded()){
            _currentState = _state.Grounded();
            
        }else{
            _currentState = _state.Fall();
        }
        _currentState.EnterState();
        // _currentState = _state.Grounded();
        // _currentState.EnterState();
    }
    private void Update()
    {
        _dir = Vector2.zero;
        if (Input.GetKey(KeyCode.A))
        {
            _dir.x = -1;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            _dir.x = 1;
        }
        
        
        if(_dir.x * transform.localScale.x < 0){
            transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x) * _dir.x,transform.localScale.y,transform.localScale.z);
        }
        //_dir.y = AdventureRb.velocity.y;
        //Debug.Log("velocity:" + _dir.y);
        _currentState.UpdateState();
    }

    public bool IsGrounded()
    {
        return Physics2D.OverlapCapsule(_groundPoint.position,new Vector2(0.09f,0.005f),CapsuleDirection2D.Horizontal,0,_groundLayer);
    }

    public bool AnimatorIsPlaying()
    {
        // ham chi hoat dong neu loop time cua animation ko duoc bat
        // (this only work if animation's "loop time" was disable)
        return Anim.GetCurrentAnimatorStateInfo(0).length >
           Anim.GetCurrentAnimatorStateInfo(0).normalizedTime;
    }

}
