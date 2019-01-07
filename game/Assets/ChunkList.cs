using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChunkList : MonoBehaviour
{
    public Transform generationpoint;
    public List<GameObject> List;
    private int ListLength;
    private List<GameObject> ShuffledList;
    private float platformHeight;
    private float[] platformHeights;

    void Start()
    {
        platformHeights = new float[ListLength];
        
        //Shuffle List

        //Spawn List Objects
        ListLength = List.Count;
        for (int i = 1; i < ListLength; i++)
        {
            platformHeights[i] = ShuffledList[i].GetComponent<BoxCollider2D>().size.y;
            GameObject obj = (GameObject)Instantiate(List[i]);
            obj.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {

        if (transform.position.y < generationpoint.position.y)
        {
            for (int i = 1; i < ListLength; i++)
            {
                if (!ShuffledList[i].activeInHierarchy)
                {
                    transform.position = new Vector2(transform.position.x, transform.position.y + platformHeights[i]);
                    ShuffledList[i].SetActive(true);
                }
            }
        }
    }
}

