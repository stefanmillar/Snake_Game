using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameAssets : MonoBehaviour
{
    public static GameAssets i;
    public Sprite snakeHead;
    public Sprite food;
    public Sprite snake;
    private void Awake() {
        i = this;
    }

}
