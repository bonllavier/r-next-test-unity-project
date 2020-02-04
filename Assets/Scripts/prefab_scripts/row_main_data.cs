using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class row_main_data : MonoBehaviour
{
    public string id_user;
    public string picture_url;
    public string fullname;
    public string content;
    public bool row_was_modified;

    //row_filler_component selector;
    public GameObject row_pict;
    public InputField row_fullname;
    public Text row_content;
    
    // Start is called before the first frame update
    void Start()
    {
        //Adds a listener to the main input field and invokes a method when the value changes.
        row_fullname.onValueChanged.AddListener(delegate { ValueChangeCheck(); });

        row_was_modified = false;
        row_fullname.text = fullname;
        row_content.text = content;
        StartCoroutine(DownloadImage(picture_url, row_pict));

        //default Image component color for the row user
        this.GetComponent<Image>().color = new Color32(55, 229, 64, 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator DownloadImage(string MediaUrl, GameObject row_pict)
    {
        UnityWebRequest request = UnityWebRequestTexture.GetTexture(MediaUrl);
        yield return request.SendWebRequest();
        if (request.isNetworkError || request.isHttpError) {
            Debug.Log(request.error);
        }
        else { 
            Sprite sprite;
            sprite = Sprite.Create(((DownloadHandlerTexture)request.downloadHandler).texture, new Rect(0, 0, ((DownloadHandlerTexture)request.downloadHandler).texture.width, ((DownloadHandlerTexture)request.downloadHandler).texture.height), Vector2.zero);
            row_pict.GetComponent<UnityEngine.UI.Image>().sprite = sprite;
        }
    }

    public void ValueChangeCheck()
    {
        this.GetComponent<Image>().color = new Color32(55, 229, 64, 100);
        row_was_modified = true;
        fullname = row_fullname.text;
    }

    public void SetInitialDataObj(string _id_user, string _picture_url, string _fullname, string _content) {
        id_user = _id_user;
        picture_url = _picture_url;
        fullname = _fullname;
        content = _content;
    }
}
