using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameHandler : MonoBehaviour
{
    private snakeGrid grid;
    [SerializeField] public snakeHead head;
    [SerializeField] public playAgain playButton;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("GameHandler.Start");
        grid = new snakeGrid();
        grid.getSnakeHead(head);
        head.getGrid(grid);
        head.getPlayAgain(playButton);
    }

    // Update is called once per frame
    void Update()
    {
    }
}
