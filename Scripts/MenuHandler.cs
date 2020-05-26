using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuHandler : MonoBehaviour
{
    public Button start;

    private void Awake() {
        start.onClick.AddListener( delegate() {
            loader.load(loader.Scene.SnakeScene);
        });
    }
}
