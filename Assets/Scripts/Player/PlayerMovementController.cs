using System;
using GameMng;
using UnityEngine;
using DG.Tweening;

public class PlayerMovementController : MonoBehaviour
{
    [SerializeField] private PlayerAnimationController animationController;
    [SerializeField] private GameObject playerMesh;

    private MovementDirections _movementDirections = MovementDirections.Forward;
    private Vector3 _jumpDistance;
    private bool _canJump;


    private void Awake()
    {
        _jumpDistance = transform.forward * 2;
    }

    private void Update()
    {
        UpdateJumpDirection();

        if (transform.position.y == 0)
        {
            _canJump = true;
        }
        else
        {
            _canJump = false;
        }

        if (_canJump)
        {
            animationController.IdleAnim();
            if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.D) ||
                Input.GetKeyDown(KeyCode.A))
            {
                Jump();
            }
        }
    }

    private void UpdateJumpDirection()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            _movementDirections = MovementDirections.Forward;
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            _movementDirections = MovementDirections.Back;
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            _movementDirections = MovementDirections.Right;
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            _movementDirections = MovementDirections.Left;
        }


        switch (_movementDirections)
        {
            case MovementDirections.Forward:
                _jumpDistance = transform.forward * 2;
                playerMesh.transform.rotation = Quaternion.LookRotation(Vector3.forward);


                break;

            case MovementDirections.Back:
                _jumpDistance = transform.forward * -2;
                playerMesh.transform.rotation = Quaternion.LookRotation(Vector3.back);

                break;

            case MovementDirections.Right:
                _jumpDistance = transform.right * 2;
                playerMesh.transform.rotation = Quaternion.LookRotation(Vector3.right);

                break;

            case MovementDirections.Left:
                _jumpDistance = transform.right * -2;
                playerMesh.transform.rotation = Quaternion.LookRotation(Vector3.left);

                break;
        }
    }

    private void Jump()
    {
        transform.DOJump(transform.position + _jumpDistance, 1f, 1, 0.25f);
        animationController.JumpAnim();
    }
}