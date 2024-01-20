using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Windows;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class InputManager : MonoBehaviour
{
    public Vector2 MoveInput;
    // Start is called before the first frame update
    public void OnMovement(InputValue input) => MoveInput = input.Get<Vector2>();


}
