using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class Player : MonoBehaviour
{
    PlayerControls controls;

    Vector2 movement;
    Rigidbody2D rb;
    [SerializeField] private float movementSpeed;
    [SerializeField] private SpriteRenderer sr;
    [SerializeField] private Sprite devil;
    [SerializeField] private GameObject haloAnchor;
    [SerializeField] private GameObject gameOver;

    private void Awake()
    {
        controls = new PlayerControls();
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        movement = controls.Player.Movement.ReadValue<Vector2>();
        rb.AddForce(movement * movementSpeed);
        rb.MovePosition(rb.position + movement * movementSpeed * Time.fixedDeltaTime);
    }


    public void Die()
    {
        controls.Disable();
        sr.sprite = devil;
        Destroy(haloAnchor);
        gameOver.SetActive(true);
    }


    private void OnEnable()
    {
        controls.Enable();
    }
    private void OnDisable()
    {
        controls.Disable();
    }
}
