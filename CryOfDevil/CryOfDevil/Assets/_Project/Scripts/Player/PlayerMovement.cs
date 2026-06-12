using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    private CharacterController _controller;
    private PlayerAnimationController _playerAnim;

    //------RUNNING HANDLE VARIABLES---------
    [SerializeField]
    private float _Speed = 3f;

    [SerializeField]
    private float _maxSpeed = 3f;

    [SerializeField]
    private float _minSpeed = 3f;
    private float _accelerationSpeed = 3f;
    private float _decelerationSpeed = 3f;

    //---------------------------------------

    private Ray rayToInteract;
    private RaycastHit hitInteract;
    public float rangeInteract;

    //--------------------------
    Vector3 forward;
    Vector3 strafe;
    Vector3 vertical;

    private float forwardSpeed_ = 3f;
    private float strafeSpeed_ = 3f;

    //controle de gravidade
    private float gravity = -4.5f;
    private Vector3 velocityY;

    //----PlayerLife----
    public Renderer feedBackEnemy;
    public float scare = 0;
    public float recoverscare;

    //------------------

    void Start()
    {
        _controller = GetComponent<CharacterController>();
        _playerAnim = GetComponent<PlayerAnimationController>();
    }

    void Update()
    {
        float vertical = Input.GetAxisRaw("Vertical");
        float horizontal = Input.GetAxisRaw("Horizontal");

        if (scare > 0)
        {
            scare -= recoverscare;
            if (scare < 0)
            {
                scare = 0;
            }
        }
        SetFeedBackAlpha(scare);

        if (scare >= 1)
        {
            Die();
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            rayToInteract = Camera.main.ScreenPointToRay(
                new Vector3(Screen.width / 2, Screen.height / 2, 0)
            );
            if (Physics.Raycast(rayToInteract, out hitInteract, rangeInteract))
            {
                if (hitInteract.collider.tag == "Pages")
                {
                    hitInteract.collider.GetComponent<ObjectiveController>().Interact();
                }
            }
        }

        HandlePlaceMovements(horizontal, vertical);
        HandleGravity();
    }

    void HandlePlaceMovements(float horizontal, float vertical)
    {
        forward = vertical * forwardSpeed_ * transform.forward;
        strafe = horizontal * strafeSpeed_ * transform.right;

        Vector3 finalVelocity = forward + strafe;

        WalkToRun();

        _controller.Move(finalVelocity * _Speed * Time.deltaTime);
    }

    void WalkToRun()
    {
        if (_playerAnim.IsRunning && _Speed < _maxSpeed)
        {
            _Speed += _accelerationSpeed * Time.deltaTime;
        }

        if (!_playerAnim.IsRunning && _Speed > _minSpeed)
        {
            if (_Speed < _minSpeed)
            {
                _Speed = _minSpeed;
            }
            else
            {
                _Speed -= _decelerationSpeed * Time.deltaTime;
            }
        }
    }

    void HandleGravity()
    {
        if (!_controller.isGrounded)
        {
            velocityY.y += gravity * Time.deltaTime;
            _controller.Move(velocityY);
        }
    }

    private void SetFeedBackAlpha(float alpha)
    {
        Color currentAlpha = feedBackEnemy.material.color;
        currentAlpha.a = alpha;

        feedBackEnemy.material.color = currentAlpha;
    }

    private void Die()
    {
        Application.LoadLevel("EndGame");
    }
}
