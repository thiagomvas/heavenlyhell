using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class HaloRotate : MonoBehaviour
{
    PlayerControls controls;
    private void Awake()
    {
        controls = new PlayerControls();
    }


    private void OnEnable()
    {
        controls.Enable();
    }

    private void OnDisable()
    {
        controls.Disable();
    }
    private void Update()
    {
        var dir = controls.Player.MousePos.ReadValue<Vector2>() - (Vector2)Camera.main.WorldToScreenPoint(transform.position);
        var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
     }
}
