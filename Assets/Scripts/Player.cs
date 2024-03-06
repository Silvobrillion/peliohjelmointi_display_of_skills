using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private float movementSpeed = 6f;
    private Rigidbody myRigidBody;
    public GameManager gm;
    private byte enemies = 11;

    public bool cubeCollected = false;


    // Start is called before the first frame update
    void Start()
    {
        myRigidBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void FixedUpdate() 
    {
        //player movememnt
        Vector3 m_Input = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        myRigidBody.MovePosition(transform.position + m_Input * Time.deltaTime * movementSpeed);

    }

    private void OnCollisionEnter(Collision collision)
    {
        // if yellow cube collected
        if (collision.gameObject.tag == "Collect")
        {
            Debug.Log("The Cube collected!");
            Destroy(collision.gameObject);
            gm.ChangeColor();
            cubeCollected = true;
        }

        //if collision with enemy and cube wasn't collected
        if (collision.gameObject.tag == "Enemy" && !cubeCollected)
        {
            gm.GameOver();
            Destroy(gameObject);
        }

        //if collision with enemy and cube was collected
        else if (collision.gameObject.tag == "Enemy" && cubeCollected)
        {
            Destroy(collision.gameObject);
            enemies--;
            if (enemies == 0)
            {
                gm.GameOver();
            }

        }
    }
}
