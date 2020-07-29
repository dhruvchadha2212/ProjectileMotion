using System;
using UnityEngine;
public class Task
{
    public AudioClip TaskAudio { get; set; }
    public string TaskString { get; set; }
    public Func<bool> IsCompleted;
}
