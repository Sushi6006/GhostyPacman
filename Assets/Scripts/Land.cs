using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Land : MonoBehaviour
{
    Mesh mesh;
    private int size = 65; // The detail level of the landscape, must be 2^n + 1. Higher n means more details
    
    public GameObject Square;

    void Start()
    {

        generateColumn();

    }

   

    // Update is called once per frame
    

    public void generateColumn()
    {
        int distance = 4;
        for (int i = 0; i < size; i++)
        {
            for (int j = 0; j <size; j++)
            {
                if (i == 0 || j == 0 || i == size - 1 || j == size - 1)
                {
                    if((i == 0 && j == (size - 1) / 2) || (i == 0 && j == (size - 1) / 2 + 1) || (i == 0 && j == (size - 1) / 2 - 1))
                    {
                        continue;
                    }
                    else
                    {
                        GameObject pyramid = GameObject.Instantiate<GameObject>(Square);
                        pyramid.transform.position = new Vector3(i - 32.5f, 0, j - 32.5f);
                    }
                }
            }
        }
        while(distance < 16)
        {
            for(int i = distance; i < size - distance; i++)
            {
                for(int j = distance; j < size - distance; j++)
                {
                    if (i == distance || j == distance || i == size - 1 - distance || j == size - 1 - distance)
                    {
                        if (distance == 4)
                        {
                            if ((i == size - 1 - distance && j == (size - 1) / 2) || (i == size - 1 - distance && j == (size - 1) / 2 + 1) || (i == size - 1 - distance && j == (size - 1) / 2 - 1))
                            {
                                continue;
                            }
                            else
                            {
                                GameObject pyramid = GameObject.Instantiate<GameObject>(Square);
                                pyramid.transform.position = new Vector3(i - 32.5f, 0, j - 32.5f);
                            }
                        }else if(distance == 8)
                        {
                            if ((j == size - 1 - distance && i == (size - 1) / 2) || (j == size - 1 - distance && i == (size - 1) / 2 + 1) || (j == size - 1 - distance && i == (size - 1) / 2 - 1))
                            {
                                continue;
                            }
                            else
                            {
                                GameObject pyramid = GameObject.Instantiate<GameObject>(Square);
                                pyramid.transform.position = new Vector3(i - 32.5f, 0, j - 32.5f);
                            }
                        }
                        else
                        {
                            if ((j == distance && i == (size - 1) / 2) || (j == distance && i == (size - 1) / 2 + 1) || (j == distance && i == (size - 1) / 2 - 1))
                            {
                                continue;
                            }else if ((i == distance && j == (size - 1) / 2) || (i == distance && j == (size - 1) / 2 + 1) || (i == distance && j == (size - 1) / 2 - 1))
                            {
                                continue;
                            }else if ((i == size - 1 - distance && j == (size - 1) / 2) || (i == size - 1 - distance && j == (size - 1) / 2 + 1) || (i == size - 1 - distance && j == (size - 1) / 2 - 1))
                            {
                                continue;
                            }else if ((j == size - 1 - distance && i == (size - 1) / 2) || (j == size - 1 - distance && i == (size - 1) / 2 + 1) || (j == size - 1 - distance && i == (size - 1) / 2 - 1))
                            {
                                continue;
                            }
                            else
                            {
                                GameObject pyramid = GameObject.Instantiate<GameObject>(Square);
                                pyramid.transform.position = new Vector3(i - 32.5f, 0, j - 32.5f);
                            }
                        }
                    }
                }
            }
            distance += 4;
        }

    }

  
    
}
