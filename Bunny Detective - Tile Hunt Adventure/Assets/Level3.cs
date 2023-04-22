using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level3 : MonoBehaviour
{
    public CharacterController controller;
    public float speed = 12f;
    public float gravity = -9.81f;
    public float MoveSpeed = 5;
    public float SteerSpeed = 100f;

    Vector3 velocity;
    private bool isCollidingWithSpecialTile = false; // Flag to track if bunny is colliding with SpecialTile

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

        // Handle rotation
        float steerDirection = Input.GetAxis("Horizontal");
        transform.Rotate(Vector3.up * steerDirection * SteerSpeed * Time.deltaTime);

        // Check for 'R' key press to restart the game
        if (Input.GetKeyDown(KeyCode.R))
        {
            RestartGame();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "SpecialTile")
        {
            // Check if the collision is with a special tile

            // Set the flag to indicate collision with SpecialTile
            isCollidingWithSpecialTile = true;



            // Disable collision between bunny and SpecialTile
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
            // Check if the collision with the special tile has ended

            // Reset the flag for collision with SpecialTile
            isCollidingWithSpecialTile = false;

            // Enable collision between bunny and SpecialTile
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
            // Check if the collision is with a special tile and the flag is not set

            // Fall through the SpecialTile
            Physics.IgnoreCollision(controller, hit.collider, true);

            // Set the flag to indicate that the bunny is colliding with the special tile
            isCollidingWithSpecialTile = true;

            audioSource.Play();

            // Load the Level2 scene after a delay of 1 second
            StartCoroutine(LoadLevel2WithDelay());
        }
    }

    IEnumerator LoadLevel2WithDelay()
    {
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("Level4"); // Load the Level2 scene
    }

    // Function to restart the game
    void RestartGame()
    {
        // Load the current scene again to restart the game
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
