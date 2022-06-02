using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehavor : MonoBehaviour
{
    public float BulletSpeed;
    public Vector3 TargetPosition;
    private Shooting shoot;
    public bool MayDeleteBullet;
    public void Awake()
    {
        shoot = GameObject.FindObjectOfType<Shooting>();
        TargetPosition = shoot.TargetPos;
    }
    void Start()
    {
        
    }

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(TargetPosition.x, TargetPosition.y, TargetPosition.z), BulletSpeed);

        if (transform.position == new Vector3(TargetPosition.x, TargetPosition.y, TargetPosition.z) && MayDeleteBullet == true)
        {
            Destroy(this.gameObject);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag != "Enemy")
        {
            MayDeleteBullet = true;
        }
    }
}
