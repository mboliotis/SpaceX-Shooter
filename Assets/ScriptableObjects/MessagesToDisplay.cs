using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Messages", menuName = "Messages", order = 1)]
public class MessagesToDisplay : ScriptableObject
{
    [TextArea]
    public string message;
}
