using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    //attaching GridArea
    private List<Transform> _Grow = new List<Transform>();
    public Collider2D SpawnArea;
    public Transform RegularBait;
    //public GameObject ChunkyBait;
    //public GameObject PoisonousBait;
    //public Vector2 SpawnCont;
    private Vector2 _direction = Vector2.right;
    public int FirstThreeCount = 0;
    
    Color defaultColor = new Color(255, 74, 255);

    public int RandomNumber;
    private void Start()
    {
        //cry();
        RegularBaitt();
        //StartCoroutine(FoodSpawn());
    }
    public void Update()
    {
        //wait();
    }
    public void RegularBaitt()
    {
        defaultColor = new Color(255, 74, 255);
        RandomNumber = Random.Range(0, 10);
        //Determining to Range
        Bounds bounds = this.SpawnArea.bounds;
        float x = Random.Range(-24, 24);
        float y = Random.Range(-11f, 10f);
        Debug.Log("randomrange" + x+" "+ y);

        if (RandomNumber > 0 && RandomNumber < 2 && FirstThreeCount > 3)
        {
            this.transform.position = new Vector3(Mathf.Round(x), Mathf.Round(y), 0.0f);
            this.GetComponent<SpriteRenderer>().material.color = Color.black;
            this.transform.localScale = new Vector3(0.7f, 0.7f, 0);
            //Debug.Log("3");
            Debug.Log("y " + y);
        }
        else if (RandomNumber > 5)
        {
            RegularBait.transform.position = new Vector3(Mathf.Round(x), Mathf.Round(y), 0.0f);
            RegularBait.GetComponent<SpriteRenderer>().material.color = Color.white;
            RegularBait.transform.localScale = new Vector3(0.7f, 0.7f, 0);
            FirstThreeCount += 1;
            Debug.Log(x);
        }
        else 
        {
            RegularBait.transform.position = new Vector3(Mathf.Round(x), Mathf.Round(y), 0.0f);
            RegularBait.GetComponent<SpriteRenderer>().material.color = Color.yellow;
            RegularBait.transform.localScale = new Vector3(1.5f, 1.5f, 0);
            FirstThreeCount += 1;
            //Debug.Log("2");

        }

        Debug.Log("10");


        /*Vector3 spawnPosition = new Vector3(Random.Range(-SpawnCont.x, SpawnCont.x),
                -SpawnCont.y, SpawnCont.y);
        Quaternion spawnRotation = Quaternion.identity;
        Instantiate(RegularBait,spawnPosition, spawnRotation);
        Debug.Log(RegularBait);*/

    }






    private void OnTriggerEnter2D(Collider2D other)
    {
        //when snake touch to Food, spawning food in another random position
        if(other.tag == "Snake")
        {
            //Destroy(gameObject);
            RegularBaitt();
        }
       
    }

    /*IEnumerator wait()
    {
        yield return new WaitForSeconds(5);
    }*/
    /*IEnumerator FoodSpawn()
    {
    Vector3 spawnPosition = new Vector3(Random.Range(-SpawnCont.x, SpawnCont.x),
        -SpawnCont.y, SpawnCont.y);
    //RegularBait.transform.position = new Vector3(Mathf.Round(x), Mathf.Round(y), 0.0f);
    Quaternion spawnRotation = Quaternion.identity;
    yield return new WaitForSeconds(1);
    while (true)
    if (RandomNumber > 5)
    {
        Instantiate(RegularBait, spawnPosition, spawnRotation);
    }
    else
    if (RandomNumber > 2 && RandomNumber < 6)
    {
        Instantiate(ChunkyBait, spawnPosition, spawnRotation);
    }
    else
    {
        Instantiate(PoisonousBait, spawnPosition, spawnRotation);
    }
    }*/

}
