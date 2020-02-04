using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class register_controller : MonoBehaviour
{
    public Text username_field;
    public Text fullname_field;
    public Text email_field;
    public InputField password_field;
    public InputField re_password_field;
    public Text information_label;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void btn_register_pressed()
    {
        if (string.IsNullOrEmpty(username_field.text) && string.IsNullOrEmpty(fullname_field.text) && string.IsNullOrEmpty(email_field.text) && string.IsNullOrEmpty(password_field.text) && string.IsNullOrEmpty(re_password_field.text))
        {
            information_label.text = "Error: Campos vacios";
        }
        else
        {
            information_label.text = "Comprobando...";
            StartCoroutine(Upload(username_field.text.ToString(),fullname_field.text.ToString(),email_field.text.ToString(),password_field.text.ToString(),re_password_field.text.ToString()));
        }
    }
    IEnumerator Upload(string username,string fullname,string email, string password, string re_password)
    {
        WWWForm form = new WWWForm();
        form.AddField("username", username);
        form.AddField("name", fullname);
        form.AddField("email", email);
        form.AddField("password", password);
        form.AddField("confirm_password", re_password);

        using (UnityWebRequest www = UnityWebRequest.Post("https://javb92.000webhostapp.com/register_validation.php", form))
        {
            yield return www.SendWebRequest();

            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log(www.error);
            }
            else
            {
                information_label.text = www.downloadHandler.text;
                Debug.Log("Form upload complete!");
            }
        }
    }
}
