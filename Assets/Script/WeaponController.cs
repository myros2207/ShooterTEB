using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    // Start is called before the first frame update

    public float range = 10f;

    Transform player;
    void Start()
    {
        player = GameObject.FindWithTag("Playuer").transform;
    }

    // Update is called once per frame
    void Update()
    {
       
       Transform target = TagTargeter("Enemy");
        if (target != transform) {

            transform.LookAt(target.position + Vector3.up);
        }
     //   Debug.Log("Count " + tra.Length);
    }

    Transform TagTargeter(string tag)
    {
        GameObject[] targets = GameObject.FindGameObjectsWithTag(tag);

        Transform clossestTarget = transform;

        float closestDistance = Mathf.Infinity;

        foreach (GameObject target in targets)
        {
            Vector3 diference = target.transform.position - player.position;
            float distance = diference.magnitude;

        if (distance < closestDistance && distance < range)
            {
                clossestTarget = target.transform;

            }
        }
        return clossestTarget;
    }

    Transform PoleTarget()
    {
        Collider[] collidersInRage = Physics.OverlapSphere(transform.position, range);



        Transform target;

        float targetDistance = Mathf.Infinity;

        foreach (Collider colider in collidersInRage)
        {

            GameObject model = colider.gameObject;

            GameObject enemy = model.transform.parent.gameObject;


            if (enemy.CompareTag("Enemy"))
            {

                Vector3 diference = player.position - enemy.transform.position;

                float distance = diference.magnitude;

                if (distance < targetDistance)
                {

                    target = enemy.transform;
                    targetDistance = distance;
                }
            }
        }
        return target;
    }
}
