using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class PlayerControl : MonoBehaviour
{
    
    public GameObject scoreText;
    public int theScore=0;
    public int playerscore = 0;
    public float forceApplied = 50;
    int winpoint = 400;
    public GameObject fincanvas;
    public GameObject buton;
     void Start()
    {
        
    }
    void Update()
    {
        
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("collect"))
        {
            theScore += 100;
            playerscore += 100;
            forceApplied += 50; 
            scoreText.GetComponent<Text>().text = "Score : " + playerscore;
            transform.localScale =new Vector3(transform.localScale.x+0.1f, transform.localScale.y + 0.1f, transform.localScale.z + 0.1f);
            Destroy(other.gameObject);

        }
        if (other.gameObject.tag.Equals("engel"))
        {
            theScore += 400;
            playerscore += 400;
            Destroy(this.gameObject);
            fincanvas.SetActive(true);
        }
        
       
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "AddForce")
        {
            Debug.Log("touch");
            collision.rigidbody.AddForce(transform.forward * forceApplied);
            //collision.gameObject.GetComponent<Rigidbody>().AddForce(forceApplied, 0, forceApplied);
        }
    }
    public void replay()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        fincanvas.SetActive(false);
    }
}
