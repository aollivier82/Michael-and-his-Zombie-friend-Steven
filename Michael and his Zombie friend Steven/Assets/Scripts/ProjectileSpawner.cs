using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileSpawner : MonoBehaviour
{
    public Fireball fireballprefab;
    public float spawnSpeed = 1;
    public float spawnRadius = 20;
    List<Fireball> fireballs;
    private int numFireballs = 50;
    

    // Start is called before the first frame update
    void Start()
    {
        fireballs = new List<Fireball>();
        for (int x = 0; x < numFireballs; x++)
        {
            Fireball fireball = Instantiate(fireballprefab);
            fireball.gameObject.SetActive(false);
            fireballs.Add(fireball);
        }

        StartCoroutine(Shoot());

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Shoot()
    {
        //Shooting code
        //Spawn projectile, put it at a random position around the edge of the map, have it come inwards
        Fireball projectile = GetPooledObject();
        projectile.gameObject.SetActive(true);

        projectile.transform.position = new Vector3(Random.Range(-200, 200) + transform.position.x, transform.position.y, transform.position.z);
        //projectile.transform.LookAt(transform.up);

        //projectile.gameObject.transform.position = RandomCircle(transform.position, 5.0f);
        //projectile.transform.LookAt(transform.position);
        
        yield return new WaitForSeconds(spawnSpeed);
        StartCoroutine(Shoot());
    }

    public Fireball GetPooledObject()
    {
        //1
        for (int i = 0; i < fireballs.Count; i++)
        {
            //2
            if (!fireballs[i].gameObject.activeInHierarchy)
            {
                return fireballs[i];
            }
        }
        //3   
        return null;
    }

    Vector3 RandomCircle(Vector3 center, float radius)
    {
        float ang = Random.value * 360;
        Vector3 pos;
        pos.x = center.x + radius * Mathf.Sin(ang * Mathf.Deg2Rad);
        pos.y = center.y;
        pos.z = center.z + radius * Mathf.Cos(ang * Mathf.Deg2Rad); 
        return pos;
    }


}
