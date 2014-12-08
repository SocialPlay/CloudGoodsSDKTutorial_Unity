using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;
using System.Collections.Generic;

public class PersistantUserDataExample : MonoBehaviour
{

    public InputField SaveKey;
    public InputField SaveValue;
    public Text saveResponse;

    public InputField RetrieveKey;
    public Text loadResponse;

    public InputField DeleteKey;
    public Text DeleteResponse;

    public Text RetrieveAllUserResponse;

    public InputField RetrieveAllValuesOfKey;
    public Text RetrieveAllValuesOfKeyResponse;


    void Awake()
    {
        CloudGoods.OnRegisteredUserToSession += (r) => { ShowChildren(true); };
        ShowChildren(false);
    }

    void ShowChildren(bool isShown)
    {
        for (int childIndex = 0; childIndex < this.transform.childCount; childIndex++)
        {
            this.transform.GetChild(childIndex).gameObject.SetActive(isShown);
        }
    }






    public void SaveUserData()
    {
        //string key, string value
        CloudGoods.SaveUserData(SaveKey.text, SaveValue.text, (r) => {
            saveResponse.text = string.Format("Value {0} has been stored in {1}", SaveValue.text, SaveKey.text);
        });
    }

    public void RetrieveUserDataValue()
    {
        //Guid userID, string key
        CloudGoods.RetrieveUserDataValue(RetrieveKey.text, (r) => { loadResponse.text = string.Format("Value {0} was retrieved from {1}", r, RetrieveKey.text); });
    }

    public void DeleteUserDateValue()
    {
        //Guid userID, string key
        CloudGoods.DeleteUserDataValue(DeleteKey.text, (r) => { DeleteResponse.text = string.Format("Key {0}, has been deleted", DeleteKey.text); });
    }

    public void RetrieveAllUsersData()
    {
        CloudGoods.RetrieveAllUserDataValues((r) =>
        {
            RetrieveAllUserResponse.text = "";
            foreach (KeyValuePair<string, string> data in r)
            {
                RetrieveAllUserResponse.text += data.Key.ToRichColor(Color.white) + ":" + (data.Value != null ? data.Value : "Null") + "\n";
            }

        });
    }

    public void RetrieveAllUserDataOfKey()
    {
        CloudGoods.RetrieveAllUserDataOfKey(RetrieveAllValuesOfKey.text, (r) => {
            RetrieveAllValuesOfKeyResponse.text = "";
            for (int i = 0; i < r.Count; i++)
            {             
                RetrieveAllValuesOfKeyResponse.text += r[i].user.userName.ToRichColor(Color.white) + " : " + r[i].value + "\n";
            }
        });
    }
}
