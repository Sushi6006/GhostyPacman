using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pyramid : MonoBehaviour
{
    private int NumberPyramid = 10;
    private int MapSize = 50;
    public GameObject Square;
    public GameObject pacdot;
    // Start is called before the first frame update
    void Start()
    {
        GeneratePyramid();
    }
    private void GeneratePyramid()
    {
        int height = 1;
        while (NumberPyramid >= 0)
        {   
            for (int i = -NumberPyramid; i <= NumberPyramid; i++)
            {
                for (int j = -NumberPyramid; j <= NumberPyramid; j++)
                {
                    if (Mathf.Abs(i) == NumberPyramid || Mathf.Abs(j) == NumberPyramid)
                    {
                        GameObject pyramid = GameObject.Instantiate<GameObject>(Square);
                        pyramid.transform.position = new Vector3(i, height, j);
                        if(i%2 == 0 && j%2  == 0)
                        {
                 
                            GameObject newPacdot = (GameObject)Instantiate(pacdot);
                            newPacdot.transform.position = new Vector3(i, height + 1, j);
                        }

                    }
                }

            }
            NumberPyramid--;
            height++;
        }



    }
    

}
