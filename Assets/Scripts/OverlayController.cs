using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OverlayController : MonoBehaviour
{
    List<GameObject> playerOverlays;
    public PlayerUIView PlayerUIViewOne, PlayerUIViewTwo, PlayerUIViewThree, PlayerUIViewFour;

    public int NumberOfPlayers = 0;
    public PlayerUIView GetUIView()
    {
        NumberOfPlayers++;
        switch (NumberOfPlayers)
        {

            case 1:
                PlayerUIViewOne.gameObject.SetActive(true);
                return PlayerUIViewOne;
            case 2:
                PlayerUIViewTwo.gameObject.SetActive(true);
                return PlayerUIViewTwo;
            case 3:
                PlayerUIViewThree.gameObject.SetActive(true);
                return PlayerUIViewThree;
            case 4:
                PlayerUIViewFour.gameObject.SetActive(true);
                return PlayerUIViewFour;
            default:
                Debug.Log("SOMETHING WENT WRONG");
                return PlayerUIViewOne;
        }
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
