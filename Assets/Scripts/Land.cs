using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Land : MonoBehaviour
{
    Mesh mesh;
    private int size = 65; // The detail level of the landscape, must be 2^n + 1. Higher n means more details
    private float MaxHeight;
    private float MinHeight;
    private Vector3[,] GeneratePoint;  // A 2D array of Vector3, used to generate all the points.
    List<Vector3> GetAllPoints = new List<Vector3>(); // An array of Vector3, which contained all the points of GenratePoint, it is used to update the vertices of Mesh.
    List<int> triangles = new List<int>();
    List<Color> colors = new List<Color>();
    public GameObject Square;

    void Start()
    {
        mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = mesh;
        CreateShape();
        UpdateMesh();
        generateColumn();

    }

   

    // Update is called once per frame
    void CreateShape()
    {
        System.Random random = new System.Random();

        GeneratePoint = new Vector3[size, size];
        /* Initialize all the points with constant X and Z coordiantes and random height, which will be changed in Diamond Square part.
         */
        for (int i = 0; i < size; i++)
        {
            for (int j = 0; j < size; j++)
            {
                GeneratePoint[i, j] = new Vector3(i, 0, j);

            }
        }

       

        

        for (int i = 0; i < size - 1; i++)
        {
            for (int j = 0; j < size - 1; j++)
            {
                int topLeft = (i + 1) * size + j;
                int botLeft = i * size + j;

                triangles.Add(botLeft);
                triangles.Add(botLeft + 1);
                triangles.Add(topLeft);

                triangles.Add(botLeft + 1);
                triangles.Add(topLeft + 1);
                triangles.Add(topLeft);
            }
        }

        MaxHeight = GeneratePoint[0, 0].y;
        MinHeight = GeneratePoint[0, 0].y;
        List<float> HeightArray = new List<float>();
        for (int i = 0; i < size; i++)
        {
            for (int j = 0; j < size; j++)
            {
                GetAllPoints.Add(GeneratePoint[i, j]);
                HeightArray.Add(GeneratePoint[i, j].y);
                if (GeneratePoint[i, j].y > MaxHeight)
                {
                    MaxHeight = GeneratePoint[i, j].y;
                }
                if (GeneratePoint[i, j].y < MinHeight)
                {
                    MinHeight = GeneratePoint[i, j].y;
                }
            }
        }
        /*
         * Set the SeaLevel to the median Number of the Height
         */
        HeightArray.Sort();
        float[] Result = HeightArray.ToArray();
        //color change

        float SandAreaMinHeight = MinHeight;
        float SandAreaMaxHeight = Result[7 * Result.Length / 12];

        float GrassAreaMinHeight = Result[7 * Result.Length / 13];
        float GrassAreaMaxHeight = Result[7 * Result.Length / 8];

        Color Sand = new Color32(194, 178, 128, 1);
        Color Grass = new Color32(126, 200, 8, 1);
        Color Soil = new Color32(115, 118, 83, 1);
        Color Snow = new Color32(255, 250, 250, 1);

        for (int i = 0; i < size; i++)
        {
            for (int j = 0; j < size; j++)
            {
                if (GeneratePoint[i, j].y <= SandAreaMaxHeight)
                {
                    colors.Add(Sand);
                }
                else if (GeneratePoint[i, j].y <= GrassAreaMaxHeight)
                {
                    colors.Add(Grass + (Soil - Grass) * ((GeneratePoint[i, j].y - GrassAreaMinHeight) / (GrassAreaMaxHeight - GrassAreaMinHeight)));
                }
                else
                {
                    colors.Add(Snow);
                }
            }
        }
    }


    void UpdateMesh()
    {
        mesh.Clear();

        mesh.vertices = GetAllPoints.ToArray();
        mesh.triangles = triangles.ToArray();
        mesh.colors = colors.ToArray();
        mesh.RecalculateNormals();
        mesh.RecalculateBounds();

        MeshCollider meshc = gameObject.AddComponent(typeof(MeshCollider)) as MeshCollider;
        meshc.sharedMesh = mesh;
    }

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
