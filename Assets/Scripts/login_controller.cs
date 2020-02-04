using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class login_controller : MonoBehaviour
{
    public Text username_field;
    public InputField password_field;
    public Text information_label;

   
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void btn_log_pressed() {
        if (string.IsNullOrEmpty(username_field.text)) 
        {
            information_label.text = "Error: Campos vacios";
        }
        else {
            information_label.text = "Comprobando...";
            StartCoroutine(Upload(username_field.text.ToString(), password_field.text.ToString()));
        }
    }
    IEnumerator Upload(string username, string password)
    {
        WWWForm form = new WWWForm();
        form.AddField("username", username);
        form.AddField("password", password);

        using (UnityWebRequest www = UnityWebRequest.Post("https://javb92.000webhostapp.com/login_validation.php", form))
        {
            yield return www.SendWebRequest();

            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log(www.error);
                information_label.text = www.error;
            }
            else
            {
                information_label.text = www.downloadHandler.text;
                if (www.downloadHandler.text == "Login Correcto") {
                    Debug.Log("Login Correcto!");
                    GameObject.Find("Canvas").GetComponent<canvas_anim_controller>().logged_succesfull();
                }
                Debug.Log("Datos Login Incorrectos");
            }
        }
    }
}
