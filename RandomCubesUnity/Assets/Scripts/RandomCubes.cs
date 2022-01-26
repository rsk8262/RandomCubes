/****
 * Created by: Rohit Khanolkar
 * Date Created: Jan 24, 2022
 * 
 * Last Edited by: NA
 * Last Edited: Jan 26, 2022
 * 
 * Description: Spawn multiple prefabs into the scene.
 ****/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomCubes : MonoBehaviour
{
    public GameObject cubePrefab; //new GameObject
    public float scalingFactor = 0.95f; //amount each cube will shrink each frame
    public int numberOfCubes = 0; //total number of cubes instatied

    [HideInInspector]
    public List<GameObject> gameObjectList; // list for all cubes

    // Start is called before the first frame update
    void Start()
    {
        gameObjectList = new List<GameObject>(); // instantiate the list
    }

    // Update is called once per frame
    void Update()
    {
        numberOfCubes++; // add to the number of cubes

        GameObject gObj = Instantiate<GameObject>(cubePrefab); //creates cube instance

        gObj.name = "Cube" + numberOfCubes; //Name of cube instance

        //Color randColor = new Color(Random.value, Random.value, Random.value); 
        //gObj.GetComponent()

        gObj.transform.position = Random.insideUnitSphere; //ramdom location inside a sphere radius if 1 out from 0,0,0

        gameObjectList.Add(gObj); //add to list

        List<GameObject> removeList = new List<GameObject>(); //list for removed objects

        foreach (GameObject goTemp in gameObjectList) {
            float scale = goTemp.transform.localScale.x; //records current scale 
            scale *= scalingFactor; //scale multiplied by acale factor
            goTemp.transform.localScale = Vector3.one * scale; //transform scale

            if (scale <= 0.1f) {
                removeList.Add(goTemp);
            } //end if

        }

        foreach(GameObject goTemp in removeList)
        {
            gameObjectList.Remove(goTemp); //remove from game object list
            Destroy(goTemp); 
        }

        Debug.Log(removeList.Count);


    }
}
