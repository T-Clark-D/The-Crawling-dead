using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.Windows;
using static TMPro.SpriteAssetUtilities.TexturePacker_JsonArray;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class InputManager : MonoBehaviour
{
    public Vector2 MoveInput;
    public Vector2 AimDirection;

    public GunController GunController;
    public GameManager gameManager;
    private bool isHolding =  false;
    public Player player;

    Coroutine autofire = null;

    // Start is called before the first frame update

    private void Awake()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        StartCoroutine(Autofire());
    }
    public void OnMovement(InputValue input)
    {
        if (player.dead) return;
        MoveInput = input.Get<Vector2>();
    }
        public void OnAim(InputValue input)
    {
        if (player.dead) return;
        AimDirection = input.Get<Vector2>();
    }


    //public void OnFire() => GunController.Fire();

    public void OnStart()
    {
        if (player.dead) return;
        Debug.Log("starting");
        gameManager.playersAreReady = true;
    }

    public void OnEscape()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void OnFireHold()
    {
        if (player.dead) return;
        Debug.Log("Hold");
        //if (isHolding) return;
        //GunController.Fire();
        isHolding = true;
    }

    public void OnFireRelease()
    {
        if (player.dead) return;
        Debug.Log("release");
        isHolding = false;
    }
    IEnumerator Autofire()
    {
        while (true)
        {
            if (player.dead) break;
            if (!isHolding)
                yield return new WaitUntil(() => isHolding );
            GunController.Fire();
            yield return new WaitForSeconds(0.2f);
        }
        
    }

}
