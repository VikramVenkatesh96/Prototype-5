using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterOnExtinguished : MonoBehaviour
{
    //to decelrate it in left direction increase accelerationLeft
    ObjectMovementLeft accelerationLeft;
    //to decelrate it in right direction decrease accelerationRight
    ObjectMovementRight accelerationRight;
    //public GameObject explosion;
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Water")
        {
            if(gameObject.GetComponent<ObjectMovementLeft>() == null)
            {
                gameObject.GetComponent<ObjectMovementRight>().acceleration = new Vector2(-0.5f,0);
            }
            else
            {
                gameObject.GetComponent<ObjectMovementLeft>().acceleration = new Vector2(0.5f, 0);
            }
        }

        if (collider.gameObject.tag == "Extinguished" || collider.gameObject.tag == "Burning")
        {
            Debug.Log("collide");

            //instread of setting the extnguished prefab's animator.setBool to true, make an explosion prefab and set its animator.SetBool to true right here
            //(destroy) the explosion prefab after a few seconds. Something like this:
            //
            //explosion.GetComponent<Animator>().SetBool("collide", true);
            //Destroy(gameObject.transform.parent.gameObject);

            //StartCoroutine(DestroyExplosion());

            animator.SetBool("collide", true);
            //Destroy(gameObject.transform.parent.gameObject);
            Destroy(collider.gameObject.transform.parent.gameObject);
        }
    }

    //IEnumerator DestroyExplosion()
    //{
    //    yield return new WaitForSeconds(2f);
    //    Destroy(explosion);

    //}
}
