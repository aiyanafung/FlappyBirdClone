using UnityEngine;
using System.Collections;

public class CameraTracksPlayer : MonoBehaviour {

    Transform player;
    float offsetX;

	// Use this for initialization
	void Start () {
        GameObject player_go = GameObject.FindGameObjectWithTag("Player"); //find the game player object first

        if(player_go == null)
        {
            Debug.LogError("Could not find an object with tag 'Player'!");
            return;
        }

        player = player_go.transform; // pass the player object to transform

        offsetX = transform.position.x - player.position.x;
	}
	
	// Update is called once per frame
	void Update () {
        if (player != null)
        {
            //update the position of the camera according to the player's position
            Vector3 pos = transform.position;
            pos.x = player.position.x + offsetX;
            transform.position = pos;
        }
        
	}
}
