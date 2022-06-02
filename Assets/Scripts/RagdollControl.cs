using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RagdollControl : MonoBehaviour
{
    public Animator anim;
    public Rigidbody[] AllRigidBodys;
    private WaypointMover waypoint;
    [SerializeField] private int MaxHP;
    [SerializeField] private int CurrentHP;
    public HealthSlider HPslider;
    public Camera camera;
    public Canvas canvas;
    private void Awake()
    {
        waypoint = GameObject.FindObjectOfType<WaypointMover>();
        for (int i = 0; i < AllRigidBodys.Length; i++)
        {
            AllRigidBodys[i].isKinematic = true;
        }
        CurrentHP = MaxHP;
    }
    void FixedUpdate()
    {
        HPslider = GameObject.FindObjectOfType<HealthSlider>();
        if (waypoint.CanShoot == false && this.gameObject.tag == "Hero" && waypoint.FirstTap == false)
        {
            anim.Play("RUN");
            anim.SetBool("IsRunning", true);
        }
        if (waypoint.CanShoot == true && this.gameObject.tag == "Hero")
        {
            anim.Play("IDLE");
            anim.SetBool("IsRunning", false);
        }
    }
    public void MakePhysical()
    {
        anim.enabled = false;
        for (int i = 0; i < AllRigidBodys.Length; i++)
        {
            AllRigidBodys[i].isKinematic = false;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Bullet")
        {
            CurrentHP--;
           //HPslider.SetUphpBar(canvas, camera);
            HPslider.SetHealthValue(CurrentHP, MaxHP);
            Destroy(other.gameObject);
            if (CurrentHP == 0)
            {
                waypoint.NowKills++;
                MakePhysical();
                Collider col = GetComponent<Collider>();
                col.GetComponent<Collider>();
                col.enabled = false;
            }
        }
    }
}
