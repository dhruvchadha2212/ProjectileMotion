using UnityEditor;
using Lean.Gui;
using System;

[Serializable]
public class EnumLeanButtonDictionary : SerializableDictionary<GameButton, LeanButton> {}

[CustomPropertyDrawer(typeof(EnumLeanButtonDictionary))]
public class AnySerializableDictionaryPropertyDrawer : SerializableDictionaryPropertyDrawer { }
