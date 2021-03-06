﻿using System.Collections;
using UnityEngine;

public class TestCoroutines : MonoBehaviour
{
    IEnumerator currentCoroutine;
    [SerializeField]
    private Transform[] path;
    // Start is called before the first frame update
    void Start()
    {
        string[] messages = { "Welcome", "to", "game", "Development. ", "It\'s", "Awesome." };
        StartCoroutine(MessagePrint(messages,0.5f));
        StartCoroutine(FollowPath());
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) {
            if (currentCoroutine != null) {
                StopCoroutine(currentCoroutine);
            }
            Debug.Log("Hello");
            currentCoroutine = Move(Random.onUnitSphere * 5, 10);
            StartCoroutine(currentCoroutine);
        }
    }

    IEnumerator FollowPath() {
        foreach (Transform wayPoint in path) {
            yield return Move(wayPoint.position, 8);
        }
    }
    IEnumerator Move(Vector3 destination,float speed) {
        while (transform.position!=destination) {
            transform.position = Vector3.MoveTowards(transform.position, destination, speed * Time.deltaTime);
            yield return null;
        }
    }
    IEnumerator MessagePrint(string[] messages,float delay) {

        foreach (string message in messages) {
            print(message);
            yield return new WaitForSeconds(delay);
        }
        
    }
}
