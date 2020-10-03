using System.Collections;
using UnityEngine;

public class TestCoroutines : MonoBehaviour
{
    IEnumerator currentCoroutine;
    // Start is called before the first frame update
    void Start()
    {
        string[] messages = { "Welcome", "to", "game", "Development. ", "It\'s", "Awesome." };
        StartCoroutine(MessagePrint(messages,0.5f));
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) {
            if (currentCoroutine != null) {
                StopCoroutine(currentCoroutine);
            }

            currentCoroutine = Move(Random.onUnitSphere * 5, 10);
            StartCoroutine(currentCoroutine);
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
