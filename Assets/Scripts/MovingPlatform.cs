using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField] float xMovement;
    [SerializeField] float yMovement;
    [SerializeField] float zMovement;
    [SerializeField] float speedBoost;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(AlterDirection());
        if (speedBoost == 0) speedBoost = 1; 
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(xMovement, yMovement, zMovement) * Time.deltaTime * speedBoost);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            GameObject player = collision.gameObject;
            player.transform.SetParent(transform);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            GameObject player = collision.gameObject;
            player.transform.parent = null;
        }
    }

    IEnumerator AlterDirection()
    {
        yield return new WaitForSeconds(3f);
        xMovement = InverseNumber(xMovement);
        yMovement = InverseNumber(yMovement);
        zMovement = InverseNumber(zMovement);
        StartCoroutine(AlterDirection());
    }

    private float InverseNumber(float number)
    {
        if (number > 0) return -number;
        else return Mathf.Abs(number);
    }
}
