using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class snakeHead : MonoBehaviour
{
    public Vector2Int gridPosition;
    //1 = up, 2 = down, 3 = left, 4 = right
    public int arrowDirection;
    public snakeGrid theGrid;
    public ArrayList snake;
    public ArrayList snakePos;
    public playAgain PlayAgain;
    public double timer;
    [SerializeField] public GameObject score;
    public int numScore;
    // Start is called before the first frame update
    private void Awake() {
        gridPosition = new Vector2Int(100, 50);
        snakePos = new ArrayList();
        snake = new ArrayList();
        arrowDirection = 0;
        numScore = 0;
        timer = 0.0;
    }

    //Update is called once per frame
    void Update() {
        handleInput();
        handleMovement();
        checkBoundaries();
        checkHeadBodyTouch();
        handleFood();
    }

    //Handle user arrow key input
    private void handleInput() {
        if(Input.GetKey("up"))
            arrowDirection = 1;
        else if(Input.GetKey("down"))
            arrowDirection = 2;
        else if(Input.GetKey("left"))
            arrowDirection = 3;
        else if(Input.GetKey("right"))
            arrowDirection = 4;
    }

    //Moves the snake by one position (5)
    private void handleMovement() {
        if(timer > 0.1)
        {
            Vector2Int curPos = new Vector2Int(gridPosition.x, gridPosition.y);
            int curDir = arrowDirection;
            moveHead();
            moveBody(curPos, curDir);
            timer = 0;
        }
        timer = timer + Time.deltaTime;
    }

    //Moves the head by one position (5)
    private void moveHead() {
        if(arrowDirection == 1)
            gridPosition.y += 5;
        else if(arrowDirection == 2)
            gridPosition.y -= 5;
        else if(arrowDirection == 3)
            gridPosition.x -= 5;
        else if(arrowDirection == 4)
            gridPosition.x += 5;
        transform.position = new Vector3Int(gridPosition.x, gridPosition.y, 0);
    }

    //Moves all body parts by one position (5)
    private void moveBody(Vector2Int curPos, int curDir) {
        Vector2Int prevPos;
        int prevDir;

        for(int i = 0; i < snake.Count; i++)
        {
            prevPos = ((snake)snakePos[i]).gridPosition;
            prevDir = ((snake)snakePos[i]).direction;

            ((snake)snakePos[i]).gridPosition = curPos;
            ((snake)snakePos[i]).direction = curDir;
            ((GameObject)snake[i]).transform.position 
            = new Vector3Int(((snake)snakePos[i]).gridPosition.x, ((snake)snakePos[i]).gridPosition.y, 0);

            curPos = prevPos;
            curDir = prevDir;
        }
    }

    //Check if snake is out of bounds
    private void checkBoundaries() {
        if((gridPosition.x > 200) || (gridPosition.x < 5) || (gridPosition.y < 5) || (gridPosition.y > 100))
        {
            enabled = false;
            PlayAgain.show();
        }
    }

    //Check if food has been eaten
    private void handleFood() {
        if((theGrid.foodPos.x == gridPosition.x) && (theGrid.foodPos.y == gridPosition.y))
        {
            theGrid.randomFoodPos();
            addBody();
            updateScore();
        }
    }

    public void getGrid(snakeGrid sGrid) {
        theGrid = sGrid;
    }

    public void getPlayAgain(playAgain play) {
        PlayAgain = play;
    }

    //Add body part to snake
    public void addBody() {

        if(snake.Count == 0)
            attachSnakeHead();
        else
            attachSnakeBody();
    }

    //Attaches body part to head
    public void attachSnakeHead() {
        GameObject body = new GameObject("snake1", typeof(SpriteRenderer));
        body.GetComponent<SpriteRenderer>().sprite = GameAssets.i.snake;
        snake tempSnake;

        //Set to one space before snake head
        if(arrowDirection == 1)
            tempSnake = new snake(gridPosition.x, gridPosition.y - 5, arrowDirection);
        else if(arrowDirection == 2)
            tempSnake = new snake(gridPosition.x, gridPosition.y + 5, arrowDirection);
        else if(arrowDirection == 3)
            tempSnake = new snake(gridPosition.x + 5, gridPosition.y, arrowDirection);
        else if(arrowDirection == 4)
            tempSnake = new snake(gridPosition.x - 5, gridPosition.y, arrowDirection);
        else
            tempSnake = null;

        snake.Add(body);
        snakePos.Add(tempSnake);
        body.transform.position = new Vector3Int(tempSnake.gridPosition.x, tempSnake.gridPosition.y, 0);
    }

    //Attaches body part to another body part
    public void attachSnakeBody() {
        GameObject body = new GameObject("snake" + (snake.Count + 1), typeof(SpriteRenderer));
        body.GetComponent<SpriteRenderer>().sprite = GameAssets.i.snake;
        snake tempSnake;

        //Set to one space before snake head
        if(((snake)snakePos[snakePos.Count - 1]).direction == 1)
            tempSnake = new snake(((snake)snakePos[snakePos.Count - 1]).gridPosition.x, ((snake)snakePos[snakePos.Count - 1]).gridPosition.y - 5, 1);
        else if(((snake)snakePos[snakePos.Count - 1]).direction == 2)
            tempSnake = new snake(((snake)snakePos[snakePos.Count - 1]).gridPosition.x, ((snake)snakePos[snakePos.Count - 1]).gridPosition.y + 5, 2);
        else if(((snake)snakePos[snakePos.Count - 1]).direction == 3)
            tempSnake = new snake(((snake)snakePos[snakePos.Count - 1]).gridPosition.x + 5, ((snake)snakePos[snakePos.Count - 1]).gridPosition.y, 3);
        else if(((snake)snakePos[snakePos.Count - 1]).direction == 4)
            tempSnake = new snake(((snake)snakePos[snakePos.Count - 1]).gridPosition.x - 5, ((snake)snakePos[snakePos.Count - 1]).gridPosition.y, 4);
        else
            tempSnake = null;

        snake.Add(body);
        snakePos.Add(tempSnake);
        body.transform.position = new Vector3Int(tempSnake.gridPosition.x, tempSnake.gridPosition.y, 0);
    }

    public void checkHeadBodyTouch()
    {
        foreach(snake element in snakePos)
        {
            if((element.gridPosition.x == gridPosition.x) && (element.gridPosition.y == gridPosition.y))
            {
                enabled = false;
                PlayAgain.show();
                return;
            }
        }
    }

    public void updateScore() {
        numScore = numScore + 10;
        Text theScore = score.GetComponent<Text>();
        theScore.text = numScore.ToString();
    }
}
