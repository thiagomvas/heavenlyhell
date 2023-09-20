using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PointsSystem : MonoBehaviour
{
    public int points;
    public static PointsSystem instance;
    [SerializeField] private TextMeshProUGUI ptxt;
    private void Start()
    {
        instance = this;
    }

    private void Update()
    {
        ptxt.text = $"Points: {points}";
    }
}
