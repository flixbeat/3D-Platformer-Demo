using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    [SerializeField] float rotationSpeed;
    [SerializeField] float jumpForce;
    [SerializeField] ParticleSystem particles;
    public MeshRenderer shades;

    private Rigidbody rb;
    private bool onPlatform;
    private int jumpCount;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        // forward and backward movement
        transform.Translate(new Vector3(0, 0, Input.GetAxis("Vertical")) * Time.deltaTime * moveSpeed);

        // rotation
        transform.Rotate(new Vector3(0, Input.GetAxisRaw("Horizontal"), 0) * Time.deltaTime * rotationSpeed);

        // jump
        if (Input.GetButtonDown("Jump")) Jump();
    }

    void Jump()
    {
        jumpCount += 1;
        if (jumpCount < 2) rb.AddForce(new Vector3(0, jumpForce, 0), ForceMode.Impulse);
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Platform"))
        {
            onPlatform = true;
            jumpCount = 0;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Platform")) onPlatform = false;
    }

    public void SpawnParticles()
    {
        particles.Play();
    }
}
