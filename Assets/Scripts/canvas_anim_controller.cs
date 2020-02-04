using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class canvas_anim_controller : MonoBehaviour
{
    public static Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void login_form_btn_on() {
        anim.SetBool("register_on", true);
    }

    public void register_form_btn_on()
    {
        anim.SetBool("register_on", false);
    }

    public void logged_succesfull()
    {
        anim.SetBool("user_logged", true);
    }

    public void logout()
    {
        anim.SetBool("user_logged", false);
    }
}
