using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using TMPro;
using Newtonsoft.Json;

namespace Assets.Scripts.Services
{
    public class APIManager : MonoBehaviour
    {
        public TMP_Text textCanvas;
        public List<ScoreEntity> scoreEntity;

        void Start()
        {
            scoreEntity = new();
            StartCoroutine(GetAllScores());
        }

        private IEnumerator GetAllScores()
        {
            textCanvas.text = "Connecting...";
            UnityWebRequest www = UnityWebRequest.Get(Routes.BASE_URL+Routes.GET_ALL_SCORES);
            yield return www.SendWebRequest();

            if (www.result == UnityWebRequest.Result.ConnectionError || www.result == UnityWebRequest.Result.ProtocolError)
            {
                textCanvas.text += "\nError: " + www.error;
                yield break;
            }

            string jsonResponse = www.downloadHandler.text;

            textCanvas.text += "\nReading JSON...";
            scoreEntity = JsonConvert.DeserializeObject<List<ScoreEntity>>(jsonResponse);

            textCanvas.text += "\nWriting on Canvas...\n";
            foreach (var score in scoreEntity)
            {
                textCanvas.text += $"\nId       : {score.Id}";
                textCanvas.text += $"\nGameCode : {score.GameCode}";
                textCanvas.text += $"\nPlayer   : {score.PlayerName}";
                textCanvas.text += $"\nScore    : {score.PlayerScore}";
                textCanvas.text += $"\nDate     : {score.CreateTime}";
                textCanvas.text += $"\n";
            }
        }
    }
}
