using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitSpawner : MonoBehaviour
{
    //the time between fruit spawns
    public float timeToSpawn = 1;

    private List<GameObject> fruits = new List<GameObject>();

    // fill the fruits list with all the children of the FruitContainer object and starts the fruit spawning coroutine
    void Start()
    {
        foreach(Transform fruit in transform)
        {
            fruits.Add(fruit.gameObject);
        }

        StartCoroutine(TimedSpawned(timeToSpawn));
    }

    /// <summary>
    /// a timer that waits for a certin amount of seconds between spawing the fruit
    /// </summary>
    /// <param name="timeToSpawn">the amout of seconds to wait before spawing the new fruit</param>
    /// <returns></returns>
    IEnumerator TimedSpawned(float timeToSpawn)
    {
        while(true)
        {
            yield return new WaitForSeconds(timeToSpawn);
            var fruit = fruits[Random.Range(0, fruits.Count - 1)];
            if (fruit.activeSelf != true)
            {
                fruit.SetActive(true);
                fruit.AddComponent<Fruit>();
            }
        }
    }
}