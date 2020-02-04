using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class btn_actualizar_datos_controller : MonoBehaviour
{
    public InputField inp_row_limit;
    public GameObject obj_instanciador_row_users;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void btn_actualizar_on() {
        obj_instanciador_row_users.GetComponent<main_screen_controller>().RefrescarListadeUsuarios(inp_row_limit.text);
    }
}
