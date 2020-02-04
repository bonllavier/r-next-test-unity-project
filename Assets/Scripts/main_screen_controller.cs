using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using SimpleJSON;

public class main_screen_controller : MonoBehaviour
{
    public InputField row_limit;
    public GameObject user_row_prefab;

    // Start is called before the first frame update
    void Start()
    {

        StartCoroutine(Upload("50"));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Upload(string row_limit)
    {
        WWWForm form = new WWWForm();
        form.AddField("row_limit", row_limit);

        using (UnityWebRequest www = UnityWebRequest.Post("https://javb92.000webhostapp.com/get_users_records.php", form))
        {
            yield return www.SendWebRequest();

            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log(www.error);
            }
            else
            {
                Debug.Log(www.downloadHandler.text + "LIMITED BY: " + row_limit);
                var data = JSON.Parse(www.downloadHandler.text);
                for (int x = 0; x < data["data"].Count; x++) {
                    var obj = (GameObject)Instantiate(user_row_prefab, Vector3.zero, Quaternion.identity, this.transform);
                    obj.GetComponent<row_main_data>().id_user = data["data"][x]["id"];
                    obj.GetComponent<row_main_data>().picture_url = data["data"][x]["image"];
                    obj.GetComponent<row_main_data>().fullname = data["data"][x]["fullname"];
                    obj.GetComponent<row_main_data>().content = data["data"][x]["content"];
                }
                //Debug.Log(name);
                Debug.Log("Form upload complete!");
            }
        }
    }

    public void RefrescarListadeUsuarios(string row_limit) {
        int childs = this.transform.childCount;
        for (int i = childs - 1; i >= 0; i--)
        {
            GameObject.DestroyImmediate(this.transform.GetChild(i).gameObject);
        }
        StartCoroutine(Upload(row_limit));
    }

}
