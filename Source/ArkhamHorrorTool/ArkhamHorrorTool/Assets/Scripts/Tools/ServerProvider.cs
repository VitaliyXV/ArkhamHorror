using System;
using System.Collections;
using ArkhamHorror.Model;
using UnityEngine;
using UnityEngine.Networking;

namespace ArkhamHorror.Tools
{
    public class ServerProvider : MonoBehaviour
    {
        private string serverAddress = "http://arkhamhorrorcontrolpanel.azurewebsites.net/Home/";
        private readonly string[] _urls = {
            "Colors",
            "Abilities", 
            "AncientOnes",
            "Dimensions",
            "GameExtentions",
            "Heralds",
            "Monsters",
            "MonsterMoveTypes",
            "MonsterTypes"
        };

        private int _loadDataIndex;

        private void Start()
        {
            for (int i = 0; i < _urls.Length; i++)
            {
                LoadModel(_urls[i]);
            }
        }

        void LoadModel(string name)
        {
            StartCoroutine(GetText(serverAddress + name, data =>
            {
                Debug.Log("----  " + name.ToUpper() +"  ---");

                switch (name)
                {
                    case "Colors": ArkhamHorrorModel.Colors = JsonHelper.FromJsonToList<Model.Color>(data);
                        break;
                    case "Abilities":ArkhamHorrorModel.Abilities = JsonHelper.FromJsonToList<Ability>(data);
                        break;
                    case "AncientOnes": ArkhamHorrorModel.AncientOnes = JsonHelper.FromJsonToList<AncientOne>(data);
                        break;
                    case "Dimensions": ArkhamHorrorModel.Dimensions = JsonHelper.FromJsonToList<Dimension>(data);
                        break;
                    case "GameExtentions": ArkhamHorrorModel.GameExtentions = JsonHelper.FromJsonToList<GameExtention>(data);
                        break;
                    case "Heralds": ArkhamHorrorModel.Heralds = JsonHelper.FromJsonToList<Herald>(data);
                        break;
                    case "Monsters": ArkhamHorrorModel.Monsters = JsonHelper.FromJsonToList<Monster>(data);
                        break;
                    case "MonsterMoveTypes": ArkhamHorrorModel.MonsterMoveTypes = JsonHelper.FromJsonToList<MonsterMoveType>(data);
                        break;
                    case "MonsterTypes": ArkhamHorrorModel.MonsterTypes = JsonHelper.FromJsonToList<MonsterType>(data);
                        break;
                }

                _loadDataIndex++;

                if (_loadDataIndex == _urls.Length)
                {
                    Debug.Log("Data Loading");
                }
            }));
        }

        private IEnumerator GetText(string url, Action<string> callback)
        {
            var www = UnityWebRequest.Get(url);
            yield return www.Send();

            if (www.isError)
            {
                Debug.Log(www.error);
            }
            else
            {
                Debug.Log(www.downloadHandler.text);
                if (callback != null) callback(www.downloadHandler.text);
            }
        }
    }
}