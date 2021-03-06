﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static DialogueElement;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public float speed = 5f;

    public bool canMove = true;

    public Dictionary<Characters, bool> keyItems;

    #region Raycast Collision Variables
    private Vector3 velocity;
    private float skinWidth = 0.1f;

    // X-Direction collisions
    public int xRayCount = 5;
    public float xRaySpacing = 0.2f;

    private Vector3 bottomLeft;
    private Vector3 bottomRight;

    private bool leftCollision = false;
    private bool rightCollision = false;

    // Z-Direction collisions
    public int zRayCount = 6;
    public float zRaySpacing = 0.4f;

    private Vector3 topLeft;
    private Vector3 topRight;

    private bool topCollision = false;
    private bool bottomCollision = false;
    #endregion

    #region Dialogue System Variables


    #endregion

    public AudioSource audioSource;

    public AudioClip clip1;
    public AudioClip clip2;
    
    // Start is called before the first frame update
    void Start()
    {
        canMove = true;
        keyItems = new Dictionary<Characters, bool>();
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        UpdateRayCastOrigins();
        ResetCollisions();

        if (canMove)
        {
            if (Input.GetKey(KeyCode.A))
            {
                velocity.x -= speed;
                XCollisions();
                if (leftCollision)
                {
                    velocity.x += speed;
                }
            }
            if (!rightCollision && Input.GetKey(KeyCode.D))
            {
                velocity.x += speed;
                XCollisions();
                if (rightCollision)
                {
                    velocity.x -= speed;
                }
            }
            if (Input.GetKey(KeyCode.S))
            {
                velocity.z -= speed;
                ZCollisions();
                if (bottomCollision)
                {
                    velocity.z += speed;
                }
            }
            if (Input.GetKey(KeyCode.W))
            {
                velocity.z += speed;
                ZCollisions();
                if (topCollision)
                {
                    velocity.z -= speed;
                }
            }


            transform.position += velocity;
            velocity = Vector3.zero;
        }
    }

    #region Collisions
    void UpdateRayCastOrigins()
    {
        bottomLeft = new Vector3(GetComponent<Collider>().bounds.min.x, GetComponent<Collider>().bounds.min.y, GetComponent<Collider>().bounds.min.z);
        bottomRight = new Vector3(GetComponent<Collider>().bounds.max.x, GetComponent<Collider>().bounds.min.y, GetComponent<Collider>().bounds.min.z);

        topLeft = new Vector3(GetComponent<Collider>().bounds.min.x, GetComponent<Collider>().bounds.min.y, GetComponent<Collider>().bounds.max.z);
        topRight = new Vector3(GetComponent<Collider>().bounds.max.x, GetComponent<Collider>().bounds.min.y, GetComponent<Collider>().bounds.max.z);
    }

    void ResetCollisions()
    {
        leftCollision = false;
        rightCollision = false;
        bottomCollision = false;
        topCollision = false;
    }

    void XCollisions()
    {
        float dirX = Mathf.Sign(velocity.x);
        float rayLength = Mathf.Abs(velocity.x) + skinWidth;

        for (int i = 0; i < xRayCount; i++)
        {
            Vector3 rayOrigin = (dirX == -1) ? bottomLeft : bottomRight;
            rayOrigin += Vector3.forward * (xRaySpacing * i);

            Debug.DrawRay(rayOrigin, Vector3.right * dirX * rayLength, Color.red);

            RaycastHit hit;
            if (Physics.Raycast(rayOrigin, Vector3.right * dirX, out hit, rayLength))
            {
                if (LayerMask.LayerToName(hit.transform.gameObject.layer).Equals("CollidableObject"))
                {
                    // Set collision info
                    leftCollision = (dirX == -1);
                    rightCollision = (dirX == 1);
                }

                //velocity.x = (hit.distance - skinWidth) * dirX;
                //rayLength = hit.distance;
            }
        }
    }

    void ZCollisions()
    {
        float dirZ = Mathf.Sign(velocity.z);
        float rayLength = Mathf.Abs(velocity.z) + skinWidth;

        for (int i = 0; i < zRayCount; i++)
        {
            Vector3 rayOrigin = (dirZ == -1) ? bottomLeft : topLeft;
            rayOrigin += Vector3.right * (zRaySpacing * i);

            Debug.DrawRay(rayOrigin, Vector3.forward * dirZ * rayLength, Color.red);

            RaycastHit hit;
            if (Physics.Raycast(rayOrigin, Vector3.forward * dirZ, out hit, rayLength))
            {
                if (LayerMask.LayerToName(hit.transform.gameObject.layer).Equals("CollidableObject"))
                {
                    // Set collision info
                    bottomCollision = (dirZ == -1);
                    topCollision = (dirZ == 1);
                }

                //velocity.x = (hit.distance - skinWidth) * dirX;
                //rayLength = hit.distance;
            }
        }
    }

    void OnCollisionStay(Collision collisionInfo)
    {
        Debug.Log("This..");
        if (collisionInfo.gameObject.tag == "Edge")
        {
            
            SceneManager.LoadScene("Scenes/Engineer/Alex");
        }
    }

    private void OnTriggerStay(Collider other)
    {

    }
    #endregion
}
