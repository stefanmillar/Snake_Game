using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class snakeGrid
{
    public Vector2Int foodPos;
    public GameObject food;
    public snakeHead SnakeHead;

    public snakeGrid() {
        foodPos = new Vector2Int();
        food = new GameObject("Food", typeof(SpriteRenderer));
        food.GetComponent<SpriteRenderer>().sprite = GameAssets.i.food;
        randomFoodPos();
    }

    public void randomFoodPos() {
        foodPos.x = 5 * Random.Range(1, 40);
        foodPos.y = 5 * Random.Range(1, 20);
        food.transform.position = new Vector3Int(foodPos.x, foodPos.y, 0);
    }

    public void getSnakeHead(snakeHead theSnake) {
        SnakeHead = theSnake;
    }
}
