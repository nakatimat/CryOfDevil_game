using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{
    //component
    Animator animator;

    [SerializeField]
    private int _VelocityZ;
    private float _maxWalkSpeed = 0.4f;
    private float _maxRunSpeed = 2f;
    private float acceleration = 2f;
    private float deceleration = 2f;

    private float _animationSpeed = 0f;

    //setting booleans to Input and Handle
    public bool IsWalking { get; private set; }
    public bool IsRunning { get; private set; }

    void Start()
    {
        animator = GetComponent<Animator>();
        _VelocityZ = Animator.StringToHash("Velocity");
    }

    void Update()
    {
        IsWalking = Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0;
        IsRunning = Input.GetKey(KeyCode.LeftShift);

        HandleMovement(IsWalking, IsRunning);
    }

    void HandleMovement(bool IsWalking, bool IsRunning)
    {
        if (IsWalking && _animationSpeed < _maxWalkSpeed)
        {
            _animationSpeed += Time.deltaTime * acceleration;
        }

        if (IsWalking && IsRunning && _animationSpeed < _maxRunSpeed)
        {
            _animationSpeed += Time.deltaTime * acceleration; //velocidade da animacao += tempo real * aceleracao
        }

        if (!IsRunning && _animationSpeed > 0.4f)
        {
            _animationSpeed -= Time.deltaTime * deceleration;
        }

        if (!IsWalking && _animationSpeed > 0f)
        {
            _animationSpeed -= Time.deltaTime * deceleration;
        }

        animator.SetFloat(_VelocityZ, _animationSpeed);
    }
}
