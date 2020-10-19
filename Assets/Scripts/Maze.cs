using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Maze : MonoBehaviour
{
    public GameObject Wall;
    public GameObject Floor;
    public int row;
    public int column;

    private int currentrow = 0;
    private int currentcolumn = 0;
    private bool scanComplete = false;

    private MazeCell[,] grid;
    // Start is called before the first frame update
    void Start()
    {
        CreateGrid();
        HuntAndKill();
    }

    // Update is called once per frame
    void CreateGrid()
    {
        float size = Wall.transform.localScale.x;
        grid = new MazeCell[row, column];

        for (int i = 100; i < row + 100; i++)
        {
            for (int j = 0; j < column; j++)
            {
                GameObject floor = Instantiate(Floor, new Vector3(j * size, 0, -i * size), Quaternion.identity);
                GameObject upWall = Instantiate(Wall, new Vector3(j * size, 1.75f, -i * size + 1.25f), Quaternion.identity);
                GameObject downWall = Instantiate(Wall, new Vector3(j * size, 1.75f, -i * size - 1.25f), Quaternion.identity);
                GameObject leftWall = Instantiate(Wall, new Vector3(j * size - 1.25f, 1.75f, -i * size), Quaternion.Euler(0, 90, 0));
                GameObject rightWall = Instantiate(Wall, new Vector3(j * size + 1.25f, 1.75f, -i * size), Quaternion.Euler(0, 90, 0));

                grid[i - 100, j] = new MazeCell();
                grid[i - 100, j].upWall = upWall;
                grid[i - 100, j].downWall = downWall;
                grid[i - 100, j].leftWall = leftWall;
                grid[i - 100, j].rightWall = rightWall;

                floor.transform.parent = transform;
                upWall.transform.parent = transform;
                downWall.transform.parent = transform;
                leftWall.transform.parent = transform;
                rightWall.transform.parent = transform;

            }
        }
    }

    bool checkNeighbour(int rows, int columns)
    {
        if (columns >= 0 && rows >= 0 && rows < row && columns < column
            && !grid[columns, rows].visted)
        {
            return true;
        }
        return false;
    }

    bool VistedNeighbour()
    {
        if (checkNeighbour(currentrow - 1, currentcolumn))
        {
            return true;
        }
        if (checkNeighbour(currentrow + 1, currentcolumn))
        {
            return true;
        }
        if (checkNeighbour(currentrow, currentcolumn + 1))
        {
            return true;
        }
        if (checkNeighbour(currentrow, currentcolumn - 1))
        {
            return true;
        }
        return false;
    }
    void HuntAndKill()
    {

        grid[currentrow, currentcolumn].visted = true;

        while (!scanComplete)
        {
            Walk();
            Hunt();
        }


    }
    void Walk()
    {
        while (VistedNeighbour())
        {
            int direction = Random.Range(0, 4);
            if (direction == 0)
            {
                if (currentrow > 0 && !grid[currentrow - 1, currentcolumn].visted)
                {
                    if (grid[currentrow, currentcolumn].upWall)
                    {
                        Destroy(grid[currentrow, currentcolumn].upWall);
                    }
                    currentrow--;
                    grid[currentrow, currentcolumn].visted = true;
                    if (grid[currentrow, currentcolumn].downWall)
                    {
                        Destroy(grid[currentrow, currentcolumn].downWall);
                    }
                }
            }
            else if (direction == 1)
            {
                if (currentrow < row - 1 && !grid[currentrow + 1, currentcolumn].visted)
                {
                    if (grid[currentrow, currentcolumn].downWall)
                    {
                        Destroy(grid[currentrow, currentcolumn].downWall);
                    }
                    currentrow++;

                    grid[currentrow, currentcolumn].visted = true;
                    if (grid[currentrow, currentcolumn].upWall)
                    {
                        Destroy(grid[currentrow, currentcolumn].upWall);
                    }
                }
            }
            else if (direction == 2)
            {
                if (currentcolumn > 0 && !grid[currentrow, currentcolumn - 1].visted)
                {
                    if (grid[currentrow, currentcolumn].leftWall)
                    {
                        Destroy(grid[currentrow, currentcolumn].leftWall);
                    }
                    currentcolumn--;
                    grid[currentrow, currentcolumn].visted = true;
                    if (grid[currentrow, currentcolumn].rightWall)
                    {
                        Destroy(grid[currentrow, currentcolumn].rightWall);
                    }
                }
            }
            else
            {
                if (currentcolumn < column - 1 && !grid[currentrow, currentcolumn + 1].visted)
                {
                    if (grid[currentrow, currentcolumn].rightWall)
                    {
                        Destroy(grid[currentrow, currentcolumn].rightWall);
                    }
                    currentcolumn++;
                    grid[currentrow, currentcolumn].visted = true;
                    if (grid[currentrow, currentcolumn].leftWall)
                    {
                        Destroy(grid[currentrow, currentcolumn].leftWall);
                    }
                }
            }
        }
    }

    bool AreThereVistedNeighbour(int rows, int columns)
    {
        if (rows > 0 && grid[rows - 1, columns].visted)
        {
            return true;
        }
        if (rows < row - 1 && grid[rows + 1, columns].visted)
        {
            return true;
        }
        if (columns > 0 && grid[rows, columns - 1].visted)
        {
            return true;
        }
        if (columns < column - 1 && grid[rows, columns + 1].visted)
        {
            return true;
        }

        return false;
    }

    void Hunt()
    {
        scanComplete = true;
        for (int i = 0; i < row; i++)
        {
            for (int j = 0; j < column; j++)
            {
                if (!grid[i, j].visted && AreThereVistedNeighbour(i, j))
                {
                    scanComplete = false;
                    currentrow = i;
                    currentcolumn = j;
                    grid[currentrow, currentcolumn].visted = true;
                    DestroyAdjacentWall();
                    return;
                }
            }
        }
    }

    void DestroyAdjacentWall()
    {
        int direction = Random.Range(0, 4);
        Debug.Log(direction);
        if (direction == 0)
        {
            if (currentrow > 0 && grid[currentrow - 1, currentcolumn].visted)
            {
                if (grid[currentrow, currentcolumn].upWall)
                {
                    Destroy(grid[currentrow, currentcolumn].upWall);
                }
                if (grid[currentrow, currentcolumn].downWall)
                {
                    Destroy(grid[currentrow, currentcolumn].downWall);
                }
            }
        }
        else if (direction == 1)
        {
            if (currentrow < row - 1 && grid[currentrow + 1, currentcolumn].visted)
            {
                if (grid[currentrow, currentcolumn].downWall)
                {
                    Destroy(grid[currentrow, currentcolumn].downWall);
                }
                if (grid[currentrow, currentcolumn].upWall)
                {
                    Destroy(grid[currentrow, currentcolumn].upWall);
                }
            }
        }
        else if (direction == 2)
        {
            if (currentcolumn > 0 && grid[currentrow, currentcolumn - 1].visted)
            {
                if (grid[currentrow, currentcolumn].leftWall)
                {
                    Destroy(grid[currentrow, currentcolumn].leftWall);
                }
                if (grid[currentrow, currentcolumn].rightWall)
                {
                    Destroy(grid[currentrow, currentcolumn].rightWall);
                }
            }
        }
        else
        {
            if (currentcolumn < column - 1 && grid[currentrow, currentcolumn + 1].visted)
            {
                if (grid[currentrow, currentcolumn].rightWall)
                {
                    Destroy(grid[currentrow, currentcolumn].rightWall);
                }
                if (grid[currentrow, currentcolumn].leftWall)
                {
                    Destroy(grid[currentrow, currentcolumn].leftWall);
                }
            }
        }
    }
}
