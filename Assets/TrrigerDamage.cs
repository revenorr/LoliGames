using System.Collections;
using UnityEngine;


public class TrrigerDamage : MonoBehaviour
{
    public GameObject die;
    public int damage;
    public GameObject TakeDamageSound;
    public Animator animator;

    [SerializeField] PlayerController _player;
    // Start is called before the first frame update


    void OnTriggerEnter(Collider collider)
    {
        GameObject col = collider.gameObject;
        Collider currentCol = GetComponent<Collider>();
        currentCol.GetComponent<Collider>();

        PlayerController playerTakeDamage = col.GetComponent<PlayerController>();


        if (playerTakeDamage != null)
        {

            playerTakeDamage.health -= damage;
            GameObject effect = Instantiate(die, transform.position, Quaternion.identity);
            Destroy(effect, 5f);
            Instantiate(TakeDamageSound, transform.position, Quaternion.identity); ;
            animator.SetTrigger("Damage");
            currentCol.enabled = false;
            Invoke(nameof(currentColEnable),1f);
        }

    }
    private void currentColEnable()
    {
        Collider currentCol = GetComponent<Collider>();
        currentCol.GetComponent<Collider>();
        currentCol.enabled = true;
    }
}

