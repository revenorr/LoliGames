using UnityEngine;

public class DestroyBomb : MonoBehaviour
{
    public GameObject bomb;
    public float CbombLifeTime;
    private bool Scale = false;
    private Vector3 scaleChange;
    public float bombLifeTime=2f;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            GameObject newbomb = Instantiate(bomb, transform.position, Quaternion.identity);
            Scale = true;
            scaleChange = new Vector3(0.25f, 0.25f, 0.25f);
            Destroy(newbomb, CbombLifeTime);
            Destroy(gameObject,bombLifeTime);

        }
        
    }
    private void Update()
    {
        if (Scale == true)
        {
            gameObject.transform.localScale -= scaleChange * Time.deltaTime; 
        }
    }
}
