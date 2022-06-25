using UnityEngine;
using System.Collections;

public class BGLooper : MonoBehaviour {

    int numBGPanels = 6;

    float pipemax = -0.178f;
    float pipemin = -1.47f;

    void Start ()
    {
        GameObject[] pipes = GameObject.FindGameObjectsWithTag("Pipes");
        Debug.Log("in start: ");
        Debug.Log("num of pipe: " + pipes.Length);

        foreach (GameObject pipe in pipes)
        {
            Debug.Log("pipe: " + pipe.name);
            Vector3 pos = pipe.transform.position;
            pos.y = Random.Range(pipemin, pipemax);
            pipe.transform.position = pos; //assign the new position
        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        

        float widthOfBGObject = ((BoxCollider2D)collider).size.x;
        Vector3 pos = collider.transform.position;
        pos.x += widthOfBGObject*numBGPanels; //repositioning the background panel
        

        if(collider.tag == "Pipes")
        {
            pos.y = Random.Range(pipemin, pipemax);
        }

        collider.transform.position = pos; //assign the new position
    }
}
