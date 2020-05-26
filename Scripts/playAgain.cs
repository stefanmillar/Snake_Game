using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playAgain : MonoBehaviour
{
    public Button playButton;
    public GameObject button;
    private void Awake() {
        playButton = this.GetComponent<Button>();
        button.SetActive(false);
        playButton.onClick.AddListener(delegate() { 
            loader.load(loader.Scene.SnakeScene); 
            button.SetActive(false);
        });
    }

    public void show() {
        button.SetActive(true);
    }
}