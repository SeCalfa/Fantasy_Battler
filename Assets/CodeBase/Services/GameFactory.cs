﻿using UnityEngine;

namespace CodeBase.Services
{
    public class GameFactory
    {
        public GameObject CreatePlayer(Transform at)
        {
            GameObject playerPrefab = Resources.Load(Constance.PlayerPath) as GameObject;
            GameObject player = Object.Instantiate(playerPrefab, at.position, at.rotation);
            
            return player;
        }

        public GameObject CreateOrc(Transform at)
        {
            GameObject orcPrefab = Resources.Load(Constance.OrcPath) as GameObject;
            GameObject orc = Object.Instantiate(orcPrefab, at.position, at.rotation);

            return orc;
        }

        public GameObject CreateArrowCanvas(RectTransform at)
        {
            GameObject arrowCanvasPrefab = Resources.Load(Constance.ArrowsPath) as GameObject;
            GameObject arrow = Object.Instantiate(arrowCanvasPrefab, at.position, at.rotation);
            arrow.GetComponent<RectTransform>().sizeDelta = at.sizeDelta;

            return arrow;
        }
    }
}