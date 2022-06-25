using UnityEngine;
using System.Collections;

public class SkyMover : MonoBehaviour {

    Rigidbody2D player;

    // Use this for initialization
    void Start()
    {
        GameObject player_go = GameObject.FindGameObjectWithTag("Player"); //find the game player object first

        if (player_go == null)
        {
            Debug.LogError("Could not find an object with tag 'Player'!");
            return;
        }

        player = player_go.GetComponent<Rigidbody2D>(); // pass the player object to transform
    }

    // Update is called once per frame
    void FixedUpdate () {
        float vel = player.velocity.x * 0.75f;
        transform.position = transform.position + Vector3.right * vel * Time.deltaTime;
	}
}
