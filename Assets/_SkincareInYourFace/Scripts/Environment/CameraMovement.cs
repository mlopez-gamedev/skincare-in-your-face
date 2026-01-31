using System;
using MiguelGameDev;
using UnityEngine;

namespace Campero.SkincareInYourFace.Environment
{
    [RequireComponent(typeof(Camera))]
    public class CameraMovement : SingletonBehaviour<CameraMovement>
    {
        [SerializeField] private Vector2 _minPosition;
        [SerializeField] private Vector2 _maxPosition;
        [SerializeField] private Vector2 _moveMargin;
        [SerializeField] private float _maxMoveSpeed;

        public bool CanMove { get; set; }

        private float _leftMove;
        private float _rightMove;
        private float _topMove;
        private float _bottomMove;

        private void Start()
        {
            _leftMove = _moveMargin.x;
            _rightMove = Screen.width - _moveMargin.x;
            _bottomMove = _moveMargin.y;
            _topMove = Screen.height - _moveMargin.y;
        }

        private void Update()
        {
            if (!CanMove)
            {
                return;
            }

            MoveCamera();
        }

        private void MoveCamera()
        {
            var move = Vector3.zero;
            var cursorPosition = Input.mousePosition;
            if (cursorPosition.x < _leftMove && cursorPosition.x > 0)
            {
                move.x = (cursorPosition.x - _leftMove) / _moveMargin.x * _maxMoveSpeed;
            }
            else if (cursorPosition.x > _rightMove && cursorPosition.x < Screen.width)
            {
                move.x = (cursorPosition.x - _rightMove) / _moveMargin.x * _maxMoveSpeed;
            }

            if (cursorPosition.y > _topMove && cursorPosition.y < Screen.height)
            {
                move.z = (cursorPosition.y - _topMove) / _moveMargin.y * _maxMoveSpeed;
            }
            else if (cursorPosition.y < _bottomMove && cursorPosition.y > 0)
            {
                move.z = (cursorPosition.y - _bottomMove) / _moveMargin.y * _maxMoveSpeed;
            }

            if (move == Vector3.zero)
            {
                return;
            }

            var newPosition = transform.position + move * Time.deltaTime;
            newPosition.x = Mathf.Clamp(newPosition.x, _minPosition.x, _maxPosition.x);
            newPosition.z = Mathf.Clamp(newPosition.z, _minPosition.y, _maxPosition.y);

            transform.position = newPosition;
        }
    }
}
