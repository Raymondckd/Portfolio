using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RandomLootDrop : MonoBehaviour {

    // Use this for initialization
    [SerializeField]
    List<GameObject> ItemList = null;
    int ItemDrop;
    int randomNum;
	void Start () {
        randomNum = Random.seed % 100;

        if (randomNum >= 30)
        {
            ItemDrop = 0;       //none
        }
        else if (randomNum >= 20)
        {
            ItemDrop = Random.Range(1, ItemList.Count / 2);                 //20 percent drop rate for the first half of items
        }
        else
        {
            ItemDrop = Random.Range((ItemList.Count / 2) + 1, ItemList.Count);  //10 percent drop rate for the second half of items
        }

    }
	
	// Update is called once per frame
	void Update () {
	
	}
    void OnDestroy()
    {
        Instantiate(ItemList[ItemDrop-1], transform.position, transform.rotation);
    }
}
