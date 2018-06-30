using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreDisplay : MonoBehaviour
{ 
    public Text[] rollText;
    public Text[] frameText;

    private void Start()
    {
        rollText[0].text = "X";
        frameText[0].text = "0";
    }

    public void FillRollCard(List<int> rolls) {
        rolls[-1] = 1;
    }
}
