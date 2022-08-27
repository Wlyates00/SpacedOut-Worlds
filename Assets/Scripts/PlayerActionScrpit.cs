using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PlayerActionScrpit : MonoBehaviour
{
    //casual variables
    private Animator anim;
    private Rigidbody2D rb;
    public Transform player;
    public float speed = 5f;
    public float jumpPower = 5f;
    private Vector2 horizontal;
    private bool isFlipped;

    //layers
    public LayerMask environment;
    public Transform groundCheck;
    public LayerMask groundLayer;

    //for arm turning
    public Transform TwistPoint;
    public float returnTime = .8f;
    private float inputX;
    private float inputY;

    public Shooting shooting;
    public float fireRate = .2f;
    private float nextFire = 1f;

    private Vector2 inputs;
    private bool currentlyShooting;

    public int selectedWeapon = 0;
    public Transform firePoint;
    public Transform shottyFirePoint1;
    public Transform shottyFirePoint2;

    public bool pickedUpWeapon;
    int tWeapons;
    public int currentWeaponIndex;
    public GameObject[] guns;
    public GameObject gunHolder;
    public GameObject currentgun;

    //guns in scene
    public GameObject gunOne;
    public GameObject gunTwo;
    //public GameObject launcher;

    //Ui pic holders
    public GameObject uziPic;
    public GameObject shottyPic;
    //public GameObject launcherpic;

    //UI pics
    public GameObject currentWeaponOne;
    public GameObject currentWeaponTwo;
    public GameObject currentWeaponThree;
    //public GameObject currentWeaponFour;

    //pause button
    public GameObject pauseMenu;
    private bool paused;

    //Audiosources
    public AudioSource playerShotSound;
    
    public AudioSource coinSound;

    public bool hasSlid = true;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        shooting = GetComponent<Shooting>();
        //wormUpSound.Play();

        //weapons switch
        tWeapons = gunHolder.transform.childCount;
        guns = new GameObject[tWeapons];

        for (int i = 0; i < tWeapons; i++)
        {
            guns[i] = gunHolder.transform.GetChild(i).gameObject;
            guns[i].SetActive(false);
        }

        guns[0].SetActive(true);
        currentgun = guns[0];
        currentWeaponIndex = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (isFlipped == false)
        {
            TwistPoint.transform.localEulerAngles = new Vector3(0f, 0f, Mathf.Atan2(inputY, inputX) * 180 / Mathf.PI - 90f);
        }
        else if (isFlipped == true)
        {
            TwistPoint.transform.localEulerAngles = new Vector3(0f, 0f, Mathf.Atan2(inputX, inputY) * 180 / Mathf.PI);
        }
        //snaps arm back to position with and without flip
        if (inputX == 0 && !isFlipped)
        {
            TwistPoint.transform.localEulerAngles = new Vector3(0, 0, -90);
        }
        if (inputX == 0 && isFlipped)
        {
            TwistPoint.transform.localEulerAngles = new Vector3(0, 0, -90);
        }

        //setting you gun when you change weapons
        if (gunOne != null)
        {
            pickedUpWeapon = gunOne.GetComponent<WeaponPickup>().hasWeapon1;
            tWeapons = 2;
        }

        else if (gunTwo == null)
        {
            tWeapons = 3;
            shottyPic.SetActive(true);
        }

        if (currentWeaponIndex == 0)
        {
            fireRate = .2f;
            currentWeaponOne.SetActive(true);
            currentWeaponTwo.SetActive(false);
            currentWeaponThree.SetActive(false);
            //currentWeaponFour.SetActive(false);
        }
        else if (currentWeaponIndex == 1)
        {
            fireRate = .08f;
            currentWeaponOne.SetActive(false);
            currentWeaponTwo.SetActive(true);
        }
        else if (currentWeaponIndex == 2)
        {
            fireRate = .8f;
            currentWeaponTwo.SetActive(false);
            currentWeaponThree.SetActive(true);
        }

        //rb.velocity = new Vector2(Mathf.Clamp(rb.velocity.x, -speed, speed), rb.velocity.y);


        //rb.velocity = new Vector2(Mathf.Clamp(rb.velocity.x, -speed, speed), rb.velocity.y);
        //rb.velocity = Vector3.ClampMagnitude(rb.velocity, speed);


        //actual movement
        //transform.Translate(transform.TransformDirection(horizontal) * speed * Time.deltaTime);

        //if (Mathf.Abs(rb.velocity.x) <= speed)
        //{
        //var clampedVector = Vector2.ClampMagnitude(horizontal * speed, speed);
        //rb.AddForce(horizontal * speed * Time.deltaTime, ForceMode2D.Force);
        //}

        FlipCharacter();
        //rb.velocity = horizontal * speed;
        OnShoot();


        //run anim.
        anim.SetFloat("Velocity", Mathf.Abs(horizontal.x));
    }

    private void FixedUpdate()
    {
        
        rb.position = Vector2.Lerp(rb.position, rb.position + horizontal * speed * Time.deltaTime, .15f);
        
        //rb.velocity = new Vector2(horizontal.x * speed * Time.fixedDeltaTime, rb.velocity.y);
    }
    public void Move(InputAction.CallbackContext context)
    {
        //getting input values 
        horizontal = context.ReadValue<Vector2>();
    }

    //flippage of character
    private void FlipCharacter()
    {
        if (horizontal.x < 0)
        {
            transform.localScale = new Vector3(-.45f, transform.localScale.y, transform.localScale.z);
            //transform.eulerAngles = new Vector3(0, 180, 0);
            isFlipped = true;
            firePoint.transform.localEulerAngles = new Vector3(0, 180, 0);
            shottyFirePoint1.transform.localEulerAngles = new Vector3(0, 190, 0);
            shottyFirePoint2.transform.localEulerAngles = new Vector3(0, 170, 0);
        }
        else if (horizontal.x > 0)
        {
            transform.localScale = new Vector3(.45f, transform.localScale.y, transform.localScale.z);
            //transform.eulerAngles = new Vector3(0, 0, 0);
            isFlipped = false;
            firePoint.transform.localEulerAngles = new Vector3(0, 0, 0);
            shottyFirePoint1.transform.localEulerAngles = new Vector3(0, 0, 0);
            shottyFirePoint2.transform.localEulerAngles = new Vector3(0, 0, 0);
        }
    }
    //doing from other script 
    public void ChangeWeapon(InputAction.CallbackContext context)
    {
        if (context.performed && pickedUpWeapon)
        {
            if (currentWeaponIndex < tWeapons - 1)
            {
                guns[currentWeaponIndex].SetActive(false);
                currentWeaponIndex += 1;
                guns[currentWeaponIndex].SetActive(true);
                currentgun = guns[currentWeaponIndex];
            }
            else if (currentWeaponIndex == tWeapons - 1)
            {
                guns[currentWeaponIndex].SetActive(false);
                currentWeaponIndex = 0;
                guns[currentWeaponIndex].SetActive(true);
                currentgun = guns[currentWeaponIndex];
            }
        }
    }

    public void Jump(InputAction.CallbackContext context)
    {
        //jump higher if held
        if (context.performed && IsGrounded())
        {
            //dontPlayFall = false;
            rb.velocity = new Vector2(rb.velocity.x, jumpPower);
            anim.SetTrigger("Jump");
        }
        //jump smaller when cancelled
        //if (context.canceled && rb.velocity.y > 0f)
        //{
           // rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
        //}


    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(groundCheck.position, .1f);
    }
    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.1f, groundLayer) || Physics2D.OverlapCircle(groundCheck.position, 0.1f, environment); ;

    }

    public void Shooting(InputAction.CallbackContext context)
    {
        //getting input
        inputX = context.ReadValue<Vector2>().x;
        inputY = context.ReadValue<Vector2>().y;

        
        //change shooting bool
        if (context.started)
        {
            currentlyShooting = true;
        }
        else if (context.canceled)
        {
            currentlyShooting = false;
        }


    }
    public void OnShoot()
    {
        if (currentlyShooting == true & Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            shooting.PlayerShot();
        }
    }

    public void Pause()
    {
        if (!paused)
        {
            Time.timeScale = 0f;
            paused = true;
            pauseMenu.SetActive(true);
        }
        else if (paused)
        {
            Time.timeScale = 1f;
            paused = false;
            pauseMenu.SetActive(false);
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Coin")
        {
            coinSound.Play();
        }
    }

}
