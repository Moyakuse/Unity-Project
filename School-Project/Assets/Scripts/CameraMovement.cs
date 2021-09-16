using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    /*
    public Transform target;

    public Vector2 maxPosition;
    public Vector2 minPosition;


    public float smoothTime = 0.3F;
    private Vector3 velocity = Vector3.zero;
    float maxScreenPoint = 0.8f;
    */

    [SerializeField] Camera cam;
    [SerializeField] Transform player;
    [SerializeField] float threshold;


    private void Update()
    {

        Vector3 mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        Vector3 targetPos = (player.position + mousePos) / 2f;

        targetPos.x = Mathf.Clamp(targetPos.x, -threshold + player.position.x, threshold + player.position.x);
        targetPos.y = Mathf.Clamp(targetPos.y, -threshold + player.position.y, threshold + player.position.y);

        this.transform.position = targetPos;
    }
}
