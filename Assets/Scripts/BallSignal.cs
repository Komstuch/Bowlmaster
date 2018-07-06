using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallSignal : MonoBehaviour {

    [SerializeField] Sprite[] buttonSprites;

    public bool isBallReady = true;

    public void SignalRed() {
        this.GetComponent<Image>().sprite = buttonSprites[1];
    }

    public void SignalGreen()
    {
        this.GetComponent<Image>().sprite = buttonSprites[0];
    }
}
