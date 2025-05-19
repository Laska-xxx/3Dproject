using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    [SerializeField] float rotationSpeed;
    [SerializeField] float jumpForce;
    [SerializeField] KeyCode jumpKey;
    private Rigidbody rb;
    MoneyController money;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        money = FindObjectOfType<MoneyController>();
    }
    void Update()
    {
        HandleMovement();
        HandleRotation();
        HandleJump();
    }
    void HandleMovement()
    {
        float verticalInput = 0f;
        if (Input.GetKey(KeyCode.W)) verticalInput = 1f;
        else if (Input.GetKey(KeyCode.S)) verticalInput = -1f;
        Vector3 movement = transform.forward * verticalInput * moveSpeed * Time.deltaTime;
        transform.position += movement;
    }
    void HandleRotation()
    {
        float horizontalInput = 0f;
        if (Input.GetKey(KeyCode.A)) horizontalInput = -1f;
        else if (Input.GetKey(KeyCode.D)) horizontalInput = 1f;
        float rotation = horizontalInput * rotationSpeed * Time.deltaTime;
        transform.Rotate(0f, rotation, 0f);
    }
    void HandleJump()
    {
        if (Input.GetKeyDown(jumpKey) && IsGrounded()) rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }
    bool IsGrounded()
    {
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position, Vector3.down, out hit, 1f))
            {
                if (hit.collider.CompareTag("Ground")) return true;
            }
            return Physics.CheckSphere(transform.position - Vector3.up * 0.1f, 0.2f, LayerMask.GetMask("Ground"));
        }
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Death") SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        if (collision.gameObject.tag == "Money")
        {
            money.AddMoney(); 
            Destroy(collision.gameObject);
        }
    }
}
