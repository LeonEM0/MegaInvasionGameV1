using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapController : MonoBehaviour
{
    public GameObject mapUI;
    public GameObject player;

    public RectTransform playerMarker;

    private bool isMapOpen = false;

    private void Start()
    {
        mapUI.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            ToggleMap();
        }

        if (isMapOpen)
        {
            UpdatePlayerMarkerPosition();
        }
    }

    void UpdatePlayerMarkerPosition()
    {
        Vector2 screenPos = Camera.main.WorldToScreenPoint(player.transform.position);
        playerMarker.anchoredPosition = screenPos;
    }

    void ToggleMap()
    {
        isMapOpen = !isMapOpen;
        mapUI.SetActive(isMapOpen);
    }
}
