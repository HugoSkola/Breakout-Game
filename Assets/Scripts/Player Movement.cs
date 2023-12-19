using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    float PlayerSpeed = 1;
    Rigidbody MyRigidBody;

    // Start is called before the first frame update
    void Start()
    {
        MyRigidBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKey(KeyCode.D))
        {
            MyRigidBody.AddForce(new Vector3(PlayerSpeed, 0, 0));
        }
        if (Input.GetKey(KeyCode.A))
        {
            MyRigidBody.AddForce(new Vector3(-PlayerSpeed, 0, 0));
        }
       
    }
}
 