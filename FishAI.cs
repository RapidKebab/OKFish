using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishAI : MonoBehaviour
{
    [SerializeField] private float speed;   //max forward move speed of the fish.
    [SerializeField] private int framesBeforeSwap;  //The fish will slowly rotate left or right. After a random interval between 10 to this value, the fish will reconsider and potentially change the rotation direction.
    [SerializeField] private float maxZ;    //Bounds of the area the fish are allowed in.
    [SerializeField] private float minZ;    //Bounds of the area the fish are allowed in.
    [SerializeField] private float maxX;    //Bounds of the area the fish are allowed in.
    [SerializeField] private float minX;    //Bounds of the area the fish are allowed in.
    private int swapframes = 0;
    bool left = true; //determines direction


    private void FixedUpdate()
    {
        Move();
    }

    void Move() //the fish move on the x-z plane only on this version.
    {
        transform.Translate(Vector3.forward * Time.deltaTime * Random.Range(speed * 0.8f, speed));
        if (swapframes < 1)
        {
            swapframes = Random.Range(10, framesBeforeSwap);
            float rand = Random.Range(-1f, 1f);
            if (rand > 0)
            {
                left = false;
            }
            else if (rand <= 0)
            {
                left = true;
            }
        }
        if (left)
        {
            transform.Rotate(0, Random.Range(-0.5f, 0f), 0);
            swapframes--;
        }
        else
        {
            transform.Rotate(0, Random.Range(0f, 0.5f), 0);
            swapframes--;
        }

        if (transform.position.x > maxX || transform.position.z > maxZ || transform.position.x < minX || transform.position.z < minZ)
        {
            transform.Rotate(0, transform.rotation.eulerAngles.y + 180, 0);
        }
    }
}
