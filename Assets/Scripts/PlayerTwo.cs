using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerTwo : MonoBehaviour
{
    public Text countText;
    public Text levelText;

    private Rigidbody rb;
    private int count;
    protected Joystick joystick;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        SetCountText();
        joystick = FindObjectOfType<Joystick>();

    }

    void FixedUpdate()
    {
     
        rb.velocity = new Vector3(joystick.Horizontal * 13f,
                                         rb.velocity.y,
                                         joystick.Vertical * 13f);
        if (Input.GetKey("escape"))
        {
            SceneManager.LoadScene("MainMenu");
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pick Up"))
        {
            other.gameObject.SetActive(false);
            count = count + 1;
            SetCountText();
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            SceneManager.LoadScene("SecondLevel");
        }
    }

    void SetCountText()
    {
        countText.text = ("P: " + count.ToString());
        levelText.text = ("L: 2");
        if (count >= 8)
        {
            SceneManager.LoadScene("ThirdLevel");

        }
    }


}
