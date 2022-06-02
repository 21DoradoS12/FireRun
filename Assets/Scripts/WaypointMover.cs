using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class WaypointMover : MonoBehaviour
{
    public Waypoints waypoints;
    public float MoveSpeed = 0.5f;
    public float DistanceMin = 0.001f;
    private Transform CurrentWaypoint;
    public bool FirstTap = true;
    public GameObject PlayText;
    public int CountNeedKillsToMoveForward;
    public int NowKills;
    public bool CanShoot;
    void Start()
    {
        CountNeedKillsToMoveForward = 3;
    }
    void FixedUpdate()
    {
        if (FirstTap == false)
        {
            PlayText.SetActive(false);
        }
        if ((Input.GetKeyDown("space") || Input.touchCount > 0) && FirstTap == true)
        {
            FirstTap = false;
            CurrentWaypoint = waypoints.GoToTheNextWaypoint(CurrentWaypoint);
            transform.position = CurrentWaypoint.position;

            CurrentWaypoint = waypoints.GoToTheNextWaypoint(CurrentWaypoint);
            transform.LookAt(CurrentWaypoint);
            waypoints.MayContinueMovement = false;
        }
        transform.position = Vector3.MoveTowards(transform.position, CurrentWaypoint.position, MoveSpeed * Time.deltaTime);
        if (NowKills == CountNeedKillsToMoveForward)
        {
            NowKills -= 3;
            waypoints.MayContinueMovement = true;
        }
        if (Vector3.Distance(transform.position, CurrentWaypoint.position) < DistanceMin && waypoints.MayContinueMovement == true)
        {
            waypoints.MayContinueMovement = false;
            CurrentWaypoint = waypoints.GoToTheNextWaypoint(CurrentWaypoint);
            if (CurrentWaypoint == null)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
            transform.LookAt(CurrentWaypoint);
        }
        if (Vector3.Distance(transform.position, CurrentWaypoint.position) < DistanceMin)
        {
            CanShoot = true;
        }
        else
        {
            CanShoot = false;
        }
    }
}
