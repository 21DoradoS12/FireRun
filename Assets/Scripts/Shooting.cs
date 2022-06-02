using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public RagdollControl ragdoll;
    public GameObject Bullet;
    public float BulletSpeed = 10f;
    public Vector3 TargetPos;
    private WaypointMover waypoint;
    void Start()
    {
        waypoint = GameObject.FindObjectOfType<WaypointMover>();
    }
    void FixedUpdate()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 1));
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                TargetPos = new Vector3(hit.point.x, hit.point.y, hit.point.z);
                if (waypoint.CanShoot == true)
                {
                    Instantiate(Bullet, new Vector3(transform.position.x - 0.0673002f, transform.position.y + 0.344f, transform.position.z + 0.16f), Quaternion.identity);
                }
            }
        }
    }
}
