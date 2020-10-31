using UnityEditor;
using Lean.Gui;
using System;

[Serializable]
public class EnumLeanButtonDictionary : SerializableDictionary<Buttons, LeanButton> {}

[CustomPropertyDrawer(typeof(EnumLeanButtonDictionary))]
public class AnySerializableDictionaryPropertyDrawer : SerializableDictionaryPropertyDrawer { }
