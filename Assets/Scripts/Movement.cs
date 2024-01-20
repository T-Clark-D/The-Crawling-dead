using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public InputManager inputManager;
    // Start is called before the first frame update
    public void FixedUpdate()
    {
        transform.Translate(inputManager.MoveInput * Time.deltaTime * 5f, Space.World);
    }
}
