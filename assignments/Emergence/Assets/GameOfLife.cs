using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameOfLife : MonoBehaviour
{

    public GameObject cellprefab;

    CellScript[,] cellMatrix;
    bool[,] tempCellMatrix;
    int playerX;
    int playerY;
    // Start is called before the first frame update
    void Start()
    {
        cellMatrix = new CellScript[40, 80];
        tempCellMatrix = new bool[40, 80];
        for (int x = 0; x < 40; x++){
            for (int y = 0; y < 80; y++){
                Vector3 pos = transform.position;
                float cellWidth = 1f;
                float cellSpacing = 0.1f;
                pos.x = pos.x + x * (cellWidth + cellSpacing);
                pos.z = pos.z + y * (cellWidth + cellSpacing);
                GameObject cellobj = Instantiate(cellprefab, pos, transform.rotation);

                cellMatrix[x, y] = cellobj.GetComponent<CellScript>();
                tempCellMatrix[x, y] = false;
            }
        }
        playerX = 29;
        playerY = 59;
        cellMatrix[10,11].GetComponent<CellScript>().alive = true;
        cellMatrix[10,10].GetComponent<CellScript>().alive = true;
        cellMatrix[10,12].GetComponent<CellScript>().alive = true;
        cellMatrix[9,11].GetComponent<CellScript>().alive = true;
        cellMatrix[9,12].GetComponent<CellScript>().alive = true;
        cellMatrix[9,10].GetComponent<CellScript>().alive = true;
        cellMatrix[11,11].GetComponent<CellScript>().alive = true;
        cellMatrix[11,10].GetComponent<CellScript>().alive = true;
        cellMatrix[11,12].GetComponent<CellScript>().alive = true;

        cellMatrix[playerX, playerY].GetComponent<CellScript>().isPlayer = true;
    }

    // Update is called once per frame
    void Update()
    {
        for(int x = 0; x < 40; x++){
            for(int y = 0; y < 80; y++){
                int count = 0;
                if(x==0 && y==0){
                    count += TopLeft(x, y);
                } else if(x == 0 && y == 79){
                    count += TopRight(x, y);
                } else if(x == 39 && y == 0){
                    count += BottomLeft(x, y);
                } else if(x == 39 && y == 79){
                    count += BottomRight(x, y);
                } else if(x == 0){
                    count += Top(x, y);
                } else if(x == 39){
                    count += Bottom(x, y);
                } else if(y == 0){
                    count += Left(x, y);
                } else if(y == 79) {
                    count += Right(x, y);
                } else {
                    count += Center(x, y);
                }
                if(count < 2 && cellMatrix[x, y].GetComponent<CellScript>().alive){
                    tempCellMatrix[x, y] = false;
                }
                if(count > 3 && cellMatrix[x, y].GetComponent<CellScript>().alive){
                    tempCellMatrix[x, y] = false;
                }
                if(count == 3 && cellMatrix[x, y].GetComponent<CellScript>().alive == false){
                    tempCellMatrix[x, y] = true;
                }
                if(count == 2 && cellMatrix[x, y].GetComponent<CellScript>().alive || count == 3 && cellMatrix[x, y].GetComponent<CellScript>().alive){
                    tempCellMatrix[x, y] = true;
                }
            }
        }
        if(Input.GetKeyDown(KeyCode.UpArrow)){
            cellMatrix[playerX, playerY].GetComponent<CellScript>().isPlayer = false;
            cellMatrix[playerX - 1, playerY].GetComponent<CellScript>().isPlayer = true;
            playerX--;
        }
        if(Input.GetKeyDown(KeyCode.DownArrow)){
            cellMatrix[playerX, playerY].GetComponent<CellScript>().isPlayer = false;
            cellMatrix[playerX + 1, playerY].GetComponent<CellScript>().isPlayer = true;
            playerX++;
        }
        if(Input.GetKeyDown(KeyCode.LeftArrow)){
            cellMatrix[playerX, playerY].GetComponent<CellScript>().isPlayer = false;
            cellMatrix[playerX, playerY - 1].GetComponent<CellScript>().isPlayer = true;
            playerY--;
        }
        if(Input.GetKeyDown(KeyCode.RightArrow)){
            cellMatrix[playerX, playerY].GetComponent<CellScript>().isPlayer = false;
            cellMatrix[playerX, playerY + 1].GetComponent<CellScript>().isPlayer = true;
            playerY++;
        }
        for(int x = 0; x < 40; x++){
            for(int y = 0; y < 80; y++){
                if(tempCellMatrix[x, y]){
                    cellMatrix[x , y].GetComponent<CellScript>().alive = true;
                } else {
                    cellMatrix[x , y].GetComponent<CellScript>().alive = false;
                }
                if(cellMatrix[x, y].GetComponent<CellScript>().alive && cellMatrix[x, y].GetComponent<CellScript>().isPlayer){
                    Debug.Log("You are Dead");
                }
            }
        }
    }

    int TopLeft(int x, int y){
        int count = 0;
        if(cellMatrix[x+1, y].GetComponent<CellScript>().alive){
                count++;
            }
        if(cellMatrix[x+1, y+1].GetComponent<CellScript>().alive){
                count++;
            }
        if(cellMatrix[x, y+1].GetComponent<CellScript>().alive){
                count++;
            }
        return count;
    }
    int TopRight(int x, int y){
        int count = 0;
        if(cellMatrix[x + 1, y].GetComponent<CellScript>().alive){
            count++;
        }
        if(cellMatrix[x+1, y-1].GetComponent<CellScript>().alive){
            count++;
        }
        if(cellMatrix[x, y-1].GetComponent<CellScript>().alive){
            count++;
        }
        return count;
    }
    int BottomLeft(int x, int y){
        int count = 0;
        if(cellMatrix[x - 1, y].GetComponent<CellScript>().alive){
            count++;
        }
        if(cellMatrix[x - 1, y + 1].GetComponent<CellScript>().alive){
            count++;
        }
        if(cellMatrix[x, y + 1].GetComponent<CellScript>().alive){
            count++;
        }
        return count;
    }
    int BottomRight(int x, int y){
        int count = 0;
        if(cellMatrix[x - 1, y].GetComponent<CellScript>().alive){
            count++;
        }
        if(cellMatrix[x - 1, y - 1].GetComponent<CellScript>().alive){
            count++;
        }
        if(cellMatrix[x, y - 1].GetComponent<CellScript>().alive){
            count++;
        }
        return count;
    }
    int Top(int x, int y){
        int count = 0;
        if(cellMatrix[x + 1, y].GetComponent<CellScript>().alive){
            count++;
        }
        if(cellMatrix[x + 1, y + 1].GetComponent<CellScript>().alive){
            count++;
        }
        if(cellMatrix[x + 1, y - 1].GetComponent<CellScript>().alive){
            count++;
        }
        if(cellMatrix[x, y + 1].GetComponent<CellScript>().alive){
            count++;
        }
        if(cellMatrix[x, y - 1].GetComponent<CellScript>().alive){
            count++;
        }
        return count;
    }
    int Bottom(int x, int y){
        int count = 0;
        if(cellMatrix[x - 1, y].GetComponent<CellScript>().alive){
            count++;
        }
        if(cellMatrix[x - 1, y + 1].GetComponent<CellScript>().alive){
            count++;
        }
        if(cellMatrix[x - 1, y - 1].GetComponent<CellScript>().alive){
            count++;
        }
        if(cellMatrix[x, y + 1].GetComponent<CellScript>().alive){
            count++;
        }
        if(cellMatrix[x, y - 1].GetComponent<CellScript>().alive){
            count++;
        }
        return count;
    }
    int Left(int x, int y){
        int count = 0;
        if(cellMatrix[x, y + 1].GetComponent<CellScript>().alive){
            count++;
        }
        if(cellMatrix[x - 1, y + 1].GetComponent<CellScript>().alive){
            count++;
        }
        if(cellMatrix[x + 1, y + 1].GetComponent<CellScript>().alive){
            count++;
        }
        if(cellMatrix[x - 1, y].GetComponent<CellScript>().alive){
            count++;
        }
        if(cellMatrix[x + 1, y].GetComponent<CellScript>().alive){
            count++;
        }
        return count;
    }
    int Right(int x, int y){
        int count = 0;
        if(cellMatrix[x, y - 1].GetComponent<CellScript>().alive){
            count++;
        }
        if(cellMatrix[x - 1, y - 1].GetComponent<CellScript>().alive){
            count++;
        }
        if(cellMatrix[x + 1, y - 1].GetComponent<CellScript>().alive){
            count++;
        }
        if(cellMatrix[x - 1, y].GetComponent<CellScript>().alive){
            count++;
        }
        if(cellMatrix[x + 1, y].GetComponent<CellScript>().alive){
            count++;
        }
        return count;
    }
    int Center(int x, int y){
        int count = 0;
        if(cellMatrix[x, y - 1].GetComponent<CellScript>().alive){
            count++;
        }
        if(cellMatrix[x - 1, y - 1].GetComponent<CellScript>().alive){
            count++;
        }
        if(cellMatrix[x + 1, y - 1].GetComponent<CellScript>().alive){
            count++;
        }
        if(cellMatrix[x - 1, y].GetComponent<CellScript>().alive){
            count++;
        }
        if(cellMatrix[x + 1, y].GetComponent<CellScript>().alive){
            count++;
        }
        if(cellMatrix[x + 1, y + 1].GetComponent<CellScript>().alive){
            count++;
        }
        if(cellMatrix[x, y + 1].GetComponent<CellScript>().alive){
            count++;
        }
        if(cellMatrix[x - 1, y + 1].GetComponent<CellScript>().alive){
            count++;
        }
        return count;
    }
}
