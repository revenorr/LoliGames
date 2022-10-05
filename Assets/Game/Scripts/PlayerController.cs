using UnityEngine;
using UnityEngine.UI;


public class PlayerController : MonoBehaviour
{
    private CharacterController controller;

    public float Speed;
    public float RotationSpeed = 300;
    public float Gravity = 20;
    //public float ShootDeley = 0.1f;
    public float saveSpeed;
    private bool slow = false;
    [HideInInspector] public float slowSpeed = 2;

    public float health;
    public int numOfHearts;
    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;

    private Animator animator;
    private Vector3 moveDirection;

    private Shooting sh;
    public GameObject allEnemy;

    public Vector3 ReghtHendRotationOffset = new Vector3(0, 0, -90);
    public Transform LeftHandTarget;
    public LayerMask LayerMask;
    



    // Start is called before the first frame update
    void Start()
    {
        TryGetComponent(out controller);
        TryGetComponent(out animator);
        saveSpeed = Speed;
        sh = FindObjectOfType<Shooting>();
        
    }
    void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.tag == "Enemy")
        {
            Debug.Log("Касание врага");

        }

    }
    private void FixedUpdate()
    {
        if (health > numOfHearts)
        {
            health = numOfHearts;
        }
        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < Mathf.RoundToInt(health))
                hearts[i].sprite = fullHeart;
            else
                hearts[i].sprite = emptyHeart;
            if (i < numOfHearts)
                hearts[i].enabled = true;
            else
                hearts[i].enabled = false;
            if (health < 1)
            {
                animator.SetBool("Die", true);
                Speed = 0;
                RotationSpeed = 0;
                sh.enabled = false;
                allEnemy.SetActive(false);
            }

        }

    }


    // Update is called once per frame
    void Update()
    {
        Vector2 input = Vector2.ClampMagnitude(new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")), 1);
        Vector3 a = Quaternion.Euler(0, Camera.allCameras[0].transform.eulerAngles.y, 0) * new Vector3(input.x, 0, input.y);

        moveDirection = new Vector3(a.x * Speed, moveDirection.y, a.z * Speed);

        if (controller.isGrounded)
            moveDirection.y = 0;

        moveDirection.y -= Time.deltaTime * Gravity;

        if (Physics.Raycast(Camera.allCameras[0].ScreenPointToRay(Input.mousePosition), out RaycastHit hit))
        {
            Vector3 diff = hit.point - transform.position;
            diff.Normalize();

            float rot = Mathf.Atan2(diff.x, diff.z) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(0, rot, 0), Time.deltaTime * RotationSpeed);
            a = transform.InverseTransformDirection(a);
        }
        controller.Move(moveDirection * Time.deltaTime);

        animator.SetFloat("InputMagnitude", a.magnitude, 0.1f, Time.deltaTime);
        animator.SetFloat("Horizontal", a.x, 0.1f, Time.deltaTime);
        animator.SetFloat("Vertical", a.z, 0.1f, Time.deltaTime);

        sh = FindObjectOfType<Shooting>();

        if (Input.GetMouseButton(0) && slow == false && sh.speedSlow == true)
        {
            Invoke(nameof(Slow), 0);
            slow = true;
            

        }
        else if (Input.GetMouseButtonUp(0) || sh.speedSlow == false)
        {
            slow = false;
        }
            
        if (slow == false) Speed = saveSpeed;
        

    }
    private void OnAnimatorIK()
    {
        animator.SetIKRotation(AvatarIKGoal.RightHand, transform.rotation * Quaternion.Euler(ReghtHendRotationOffset));
        animator.SetIKRotationWeight(AvatarIKGoal.RightHand, 1);

        animator.SetIKPosition(AvatarIKGoal.LeftHand, LeftHandTarget.position);
        animator.SetIKPositionWeight(AvatarIKGoal.LeftHand, 1);
        animator.SetIKRotation(AvatarIKGoal.LeftHand, LeftHandTarget.rotation);
        animator.SetIKRotationWeight(AvatarIKGoal.LeftHand, 1);
    }
    private void Slow()
    {
        Speed /= slowSpeed;       
    }

    private void Normal()
    {
        Speed = saveSpeed;
        //slow = false;
    }

    

}
