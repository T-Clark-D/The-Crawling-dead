using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Windows;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class InputManager : MonoBehaviour
{
    public Vector2 MoveInput;
    public Vector2 AimDirection;

    public GunController GunController;
    // Start is called before the first frame update
    public void OnMovement(InputValue input) => MoveInput = input.Get<Vector2>();
    public void OnAim(InputValue input) => AimDirection = input.Get<Vector2>();

    public void OnFire() => GunController.Fire();


}
