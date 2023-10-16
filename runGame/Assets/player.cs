using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class player : MonoBehaviour
{
    Rigidbody rb;
    float timer;
    float timer2;
    float jump;
    int count;
    int count2;
    // Start is called before the first frame update
    void Start()
    {
        rb = transform.GetComponent<Rigidbody>();
        jump = 2.5f;
        count = 0;
        count2 = 0;
        transform.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        timer2 += Time.deltaTime;
        if (timer < 1.5)
        {
            gameObject.GetComponent<Rigidbody>().useGravity = false;
            gameObject.GetComponent<MeshRenderer>().enabled = false;
        }
        else
        {
            gameObject.GetComponent<MeshRenderer>().enabled = true;
            gameObject.GetComponent<Rigidbody>().useGravity = true;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            rb.AddForce(new Vector3(8f, 0, 0), ForceMode.Acceleration);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rb.AddForce(new Vector3(-8f, 0, 0), ForceMode.Acceleration);
        }
        if (Input.GetKey(KeyCode.Space) && timer2 > 2)
        {
            Physics.gravity *= -1;
            jump *= -1;
            timer2 = 0;
        }
        if (gameObject.transform.position.y > 6)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            Physics.gravity *= -1;
        }
        if (gameObject.transform.position.y < -1)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
    void OnCollisionStay(Collision collision)
    {
        Debug.Log(collision.gameObject.name);
        if (collision.gameObject.name.Equals("Plane(Clone)"))
        {
            if (Input.GetKey(KeyCode.UpArrow))
            {
                rb.AddForce(new Vector3(0, jump, 0), ForceMode.Impulse);
            }
        }
        if (collision.gameObject.name.Equals("Cube(Clone)") && gameObject.transform.position.y > 4)
        {
            Debug.Log("hitTop");
            Destroy(gameObject);
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            Physics.gravity *= -1;
        }
        else if(collision.gameObject.name.Equals("Cube(Clone)"))
        {
            Debug.Log("hitBottom");
            Destroy(gameObject);
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}