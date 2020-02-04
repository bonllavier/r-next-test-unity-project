using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class btn_save_all_data : MonoBehaviour
{
    public GameObject[] obj_row_users;
    public Text lbl_last_save_status;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void btn_save_data_on() {
        obj_row_users = GameObject.FindGameObjectsWithTag("row_user_data");
        for (int x = 0; x < obj_row_users.Length; x++) {
            if (obj_row_users[x].GetComponent<row_main_data>().row_was_modified == true) {
                StartCoroutine(Upload(obj_row_users[x].GetComponent<row_main_data>().id_user, obj_row_users[x].GetComponent<row_main_data>().fullname));
            }
        }
    }

    IEnumerator Upload(string user_id,string fullname)
    {
        WWWForm form = new WWWForm();
        
        form.AddField("user_id", user_id);
        form.AddField("fullname", fullname);

        using (UnityWebRequest www = UnityWebRequest.Post("https://javb92.000webhostapp.com/save_updated_users.php", form))
        {
            yield return www.SendWebRequest();

            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log(www.error);
            }
            else
            {
                lbl_last_save_status.text = www.downloadHandler.text;
                Debug.Log("User: " + fullname + " Updated at:" + www.downloadHandler.text);
            }
        }
    }
}
