using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FinalScore : MonoBehaviour {

    private Text scoreText;

	void Start () {
        scoreText = GetComponent<Text>();
        scoreText.text = GameManager.finalScore.ToString();
	}
	
}
