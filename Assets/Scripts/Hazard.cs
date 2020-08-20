using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hazard : MonoBehaviour
{
    private Transform player;
    private HUDCanvas hudCanvas;

    // Start is called before the first frame update
    void Start()
    {
        hudCanvas = GameObject.FindWithTag("HUDCanvas").GetComponent<HUDCanvas>(); 
        player = GameObject.FindWithTag("Player").transform;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            StartCoroutine(PlayerOut());
        }
    }

    IEnumerator PlayerOut()
    {
        PlayerController playerScript = player.GetComponent<PlayerController>();

        // hide player and disable controls
        playerScript.enabled = false;
        playerScript.SpawnParticles();
        playerScript.GetComponent<MeshRenderer>().enabled = false;
        playerScript.shades.enabled = false;

        // deduct 1 from life
        hudCanvas.DeductLife();

        // wait for 2 seconds
        yield return new WaitForSeconds(3f);
        
        // game over
        if (hudCanvas.lifeCount == 0)
        {
            Debug.Log("game over!");
        }
        else
        {
            // spawn back to start point
            player.transform.position = new Vector3(0, 0, 0);
            player.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
            player.GetComponent<PlayerController>().enabled = true;
            playerScript.GetComponent<MeshRenderer>().enabled = true;
            playerScript.shades.enabled = true;
        }
        
    }
}
