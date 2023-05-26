using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WinText : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;
    
    void Start()
    {
        _text.SetText($"{GameEnd.WinnerName} win!");
    }
}
