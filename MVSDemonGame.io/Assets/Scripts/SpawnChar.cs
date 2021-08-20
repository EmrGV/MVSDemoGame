using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore;
public class SpawnChar : MonoBehaviour
{
    [SerializeField] Follow follow;
    TextMesh textMesh;
    public Vector3 center;
    public Vector3 center2;
    public Vector3 size;
    public Vector3 size2;
    public GameObject BoostObj;
    public GameObject PoolObj;
    public int amountToPool=10;
    public float spawnTime;
    public float spawnDelay;
    public int spawnUnit;
        Sc_Spawner dataBase;
    int charamount = 7;
    public Rigidbody karakter;
    public GameObject canvas;

    void Start()
    {
        follow = FindObjectOfType<Follow>();

        // CharSpawn();
        InvokeRepeating("SpawnBoost", spawnTime, spawnDelay);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            canvas.SetActive(false);
        }
    }
    public void SpawnBoost()
    {

      
      
        for (int i = 0; i < amountToPool; i++)
        {

            Vector3 pos = center + new Vector3(Random.Range(-size.x / 2, size.x / 2), Random.Range(-size.y / 2, size.y / 2), Random.Range(-size.z / 2, size.z / 2));
            Instantiate(BoostObj, pos, Quaternion.identity);
            
        }
        

    }

    public void CharSpawn()
    {
        for (int i = 0; i < charamount; i++)
        {
            Vector3 pos = center2 + new Vector3(Random.Range(-size2.x / 2, size2.x / 2), Random.Range(-size2.y / 2, size2.y / 2), Random.Range(-size2.z / 2, size2.z / 2));
            Instantiate(PoolObj, pos, Quaternion.identity);

        }

    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = new Color(1, 0, 0, 0.5f);
        Gizmos.DrawCube(center, size);
    }
    IEnumerator TimeSpawn()
    {
        
        yield return new WaitForSeconds(3f);
        
    }
   

    
}
