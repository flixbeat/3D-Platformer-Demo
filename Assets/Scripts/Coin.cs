using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Coin : MonoBehaviour
{
    private int rotationSpeed;
    private HUDCanvas hudCanvas;
    private Text coinsValue;

    // Start is called before the first frame update
    void Start()
    {
        hudCanvas = GameObject.FindWithTag("HUDCanvas").GetComponent<HUDCanvas>();
        rotationSpeed = 150;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(1,1,1) * Time.deltaTime * rotationSpeed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // increase coins count
            hudCanvas.AddCoin();

            Destroy(gameObject);
        }
    }
}
