using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControler : MonoBehaviour
{
    Vector3 currentPosition;
    Vector3 newPosition;
    public Vector3 positionOffset = new Vector3(0, 0, 1);
    public float speed = 15.0f;
    public float turnSpeed = 30.0f;
    public float nitroSpeed = 10.0f;
    public float verticalInput;
    public float horizontalInput;
    public bool nitroInput;
    public bool jumpInput;
    public float jumpHeight = 10;
    private bool nitro;
    private bool _grounded;

    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {

        
    }

    // Update is called once per frame
    void Update()
    {
        /*
        currentPosition = transform.position;
        newPosition.x = currentPosition.x;
        newPosition.y = currentPosition.y;
        newPosition.z = currentPosition.z + 1;
        transform.position = newPosition;
        */
        //transform.position = transform.position + new Vector3(0, 0, 1);

        // transform.Translate(positionOffset);

        //transform.Translate(Vector3.forward);

        // transform.Translate(Vector3.forward * speed * Time.deltaTime);

        movement();
        jump();
        StartCoroutine(nitroboost());
    }

    private void jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && _grounded == true)
        {
            rb.AddForce(Vector3.up * jumpHeight, ForceMode.Impulse);
            _grounded = false;
        }
    }

    private void movement()
    {
        verticalInput = Input.GetAxis("Vertical");
        horizontalInput = Input.GetAxis("Horizontal");

        if (verticalInput > 0)
            transform.Rotate(Vector3.up * turnSpeed * Time.deltaTime * horizontalInput);
        if (verticalInput < 0)
            transform.Rotate(Vector3.up * turnSpeed * Time.deltaTime * horizontalInput * -1);

        transform.Translate(Vector3.forward * speed * Time.deltaTime * verticalInput);
    }

    private IEnumerator nitroboost()
    {
        nitroInput = Input.GetButton("NitroBoost");
        if (nitroInput == true)
        {
            if (verticalInput > 0 && nitro == false)
            {
                speed = speed * 3;

                nitro = true;

                yield return new WaitForSeconds(2.0f);

                speed = speed / 3;

                nitro = false;

            }
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            _grounded = true;
        }

    }
}
