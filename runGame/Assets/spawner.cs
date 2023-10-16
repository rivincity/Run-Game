using System.Collections;
using System.Collections.Generic;
//using System.Numerics;
using UnityEngine;

public class spawner : MonoBehaviour
{
    public GameObject plane;
    public GameObject obstacle;
    int count;
    int randomObstacle;
    int random;
    int randomTop;
    int size;
    // Start is called before the first frame update
    void Start()
    {
        count = 0;
        size = 10;
        InvokeRepeating("RunGame", 1f, 1f);
    }

    // Update is called once per frame
    void RunGame()
    {   
        if (count == 0)
        {
            for (int i = 0; i < 2; i++)
            {
                Vector3 middleV = new Vector3(0, 0, i * size);
                Vector3 rightV = new Vector3(size, 0, i * size);
                Vector3 leftV = new Vector3(-size, 0, i * size);
                Vector3 middleUpV = new Vector3(0, 5, i * size);
                Vector3 rightUpV = new Vector3(size, 5, i * size);
                Vector3 leftUpV = new Vector3(-size, 5, i * size);
                Quaternion k = new Quaternion(0f, 0f, 180, 0f);
                GameObject left = Instantiate(plane, leftV, Quaternion.identity);
                GameObject leftUp = Instantiate(plane, leftUpV, k);
                GameObject middle = Instantiate(plane, middleV, Quaternion.identity);
                GameObject middleUp = Instantiate(plane, middleUpV, k);
                GameObject right = Instantiate(plane, rightV, Quaternion.identity);
                GameObject rightUp = Instantiate(plane, rightUpV, k);
            }
            for (int i = 2; i < 200; i++)
            {
                random = (int)(Random.Range(1, 4));
                randomTop = (int)(Random.Range(1, 4));
                randomObstacle = (int)Random.Range(1, 4);
                Vector3 middleV = new Vector3(0, 0, i * size);
                Vector3 rightV = new Vector3(size, 0, i * size);
                Vector3 leftV = new Vector3(-size, 0, i * size);
                Vector3 middleUpV = new Vector3(0, 5, i * size);
                Vector3 rightUpV = new Vector3(size, 5, i * size);
                Vector3 leftUpV = new Vector3(-size, 5, i * size);
                Quaternion k = new Quaternion(0f, 0f, 180, 0f);
                if (random != 1)
                {
                    GameObject left = Instantiate(plane, leftV, Quaternion.identity);
                }
                if (random != 2)
                {
                    GameObject middle = Instantiate(plane, middleV, Quaternion.identity);
                }
                if (random != 3)
                {
                    GameObject right = Instantiate(plane, rightV, Quaternion.identity);
                }
                if(randomTop != 1)
                {
                    GameObject leftUp = Instantiate(plane, leftUpV, k);
                }
                if(randomTop != 2)
                {
                    GameObject middleUp = Instantiate(plane, middleUpV, k);
                }
                if(randomTop != 3)
                {
                    GameObject rightUp = Instantiate(plane, rightUpV, k);
                }
                if (randomObstacle == 1 && random != 1)
                {
                    GameObject obstacleLeft = Instantiate(obstacle, leftV, Quaternion.identity);
                }
                if (randomObstacle == 2 && random != 2)
                {
                    GameObject obstacleMiddle = Instantiate(obstacle, middleV, Quaternion.identity);
                }
                if (randomObstacle == 3 && random != 3)
                {
                    GameObject obstacleRight = Instantiate(obstacle, rightV, Quaternion.identity);
                }
                if(randomObstacle == 1 && randomTop != 1)
                {
                    GameObject obstacleLeftUp = Instantiate(obstacle, leftUpV, k);
                }
                if(randomObstacle == 2 && randomTop != 2)
                {
                    GameObject obstacleMiddleUp = Instantiate(obstacle, middleUpV, k);
                }
                if(randomObstacle == 3 && randomTop != 3)
                {
                    GameObject obstacleRightUp = Instantiate(obstacle, rightUpV, k);
                }
            }
            count++;
        }
    }
}