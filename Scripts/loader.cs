using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class loader
{
    public enum Scene {
        SnakeScene,
    }

    public static void load(Scene scene) {
        SceneManager.LoadScene(scene.ToString());
    }
}
