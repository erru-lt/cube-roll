using Assets.Scripts.Services;
using System.Collections;
using UnityEngine;

public class CubeRoll : MonoBehaviour
{
    [SerializeField] private float _rollSpeed = 3.0f;
    private readonly float _delay = 0.01f;
    private bool _isMoving = false;

    private IInputService _inputService;

    private void Start()
    {
        _inputService = new InputService();
    }

    private void Update() => 
        Rolling();

    private void Rolling()
    {
        if (_isMoving) return;

        if (JoystickPressed())
        {
            PerformRoll(_inputService.Axis);
        }
    }

    private void PerformRoll(Vector3 rollDirection)
    {
        Vector3 rotationAnchor = transform.position + (Vector3.down + rollDirection) / 2;
        Vector3 rotationAxis = Vector3.Cross(Vector3.up, rollDirection);

        StartCoroutine(Roll(rotationAnchor, rotationAxis, rollDirection));
    }

    private IEnumerator Roll(Vector3 rotationAnchor, Vector3 rotationAxis, Vector3 rollDirection)
    {
        _isMoving = true;

        for (int i = 0; i < (90 / _rollSpeed); i++)
        {
            transform.RotateAround(rotationAnchor, rotationAxis, _rollSpeed);
            yield return new WaitForSeconds(_delay);
        }

        _isMoving = false;
    }
    
    private bool JoystickPressed() =>
        _inputService.Axis.sqrMagnitude != 0;
}
