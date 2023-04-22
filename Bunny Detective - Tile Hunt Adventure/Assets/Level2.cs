using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level2 : MonoBehaviour
{
    public CharacterController controller;
    public float speed = 12f;
    public float gravity = -9.81f;
    public float MoveSpeed = 5;
    public float SteerSpeed = 100f;

    Vector3 velocity;
    private bool isCollidingWithSpecialTile = false; 

    public AudioSource audioSource;

    // Update is called once per frame
    void Update()
    {

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");


        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);

        
        float steerDirection = Input.GetAxis("Horizontal");
        transform.Rotate(Vector3.up * steerDirection * SteerSpeed * Time.deltaTime);

        
        if (Input.GetKeyDown(KeyCode.R))
        {
            RestartGame();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "SpecialTile")
        {
            
            isCollidingWithSpecialTile = true;



            
            Collider otherCollider = other.GetComponent<Collider>();
            if (otherCollider != null)
            {
                Physics.IgnoreCollision(controller, otherCollider, true);
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "SpecialTile")
        {
            
            isCollidingWithSpecialTile = false;

            
            Collider otherCollider = other.GetComponent<Collider>();
            if (otherCollider != null)
            {
                Physics.IgnoreCollision(controller, otherCollider, false);
            }
        }
    }

    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.collider != null && hit.collider.tag == "SpecialTile" && !isCollidingWithSpecialTile)
        {
            
            Physics.IgnoreCollision(controller, hit.collider, true);

            
            isCollidingWithSpecialTile = true;

            audioSource.Play();

            
            StartCoroutine(LoadLevel2WithDelay());
        }
    }

    IEnumerator LoadLevel2WithDelay()
    {
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("Level3"); 
    }

    // Function to restart the game
    void RestartGame()
    {
       
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
