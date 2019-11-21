﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCtrl : MonoBehaviour
{
    public GameObject sparkParticle;
    public float damage = 20f;
    public float speed;

    
    
    void Start()
    {
        GetComponent<Rigidbody>().AddForce(transform.forward * 3000f);
    }
    private void Update()
    {
        Destroy(this.gameObject, 5f);
    }

    private void OnCollisionEnter(Collision coll)
    {
        ContactPoint contact = coll.contacts[0];
        Vector3 _normal = contact.normal; //coll(부딫힌 Cube)의 법선벡터            

        GameObject _sparkParticle = Instantiate(sparkParticle, contact.point, Quaternion.LookRotation(_normal));
        Destroy(this.gameObject);
        Destroy(_sparkParticle, 1.5f);

        //if (coll.transform.CompareTag("REDMON"))
        //{
        //    ContactPoint contact = coll.contacts[0];
        //    Vector3 _normal = contact.normal; //coll(부딫힌 Cube)의 법선벡터            
            
        //    GameObject _sparkParticle = Instantiate(sparkParticle, contact.point, Quaternion.LookRotation(_normal));
        //    Destroy(this.gameObject);
        //    Destroy(_sparkParticle, 1.5f);
        //}
        if(coll.transform.CompareTag("REDMON"))
        {
            RedMonCtrl redMonCtrl = coll.transform.GetComponentInParent<RedMonCtrl>();
            redMonCtrl.R_MonHP--;
        }
    }
}
