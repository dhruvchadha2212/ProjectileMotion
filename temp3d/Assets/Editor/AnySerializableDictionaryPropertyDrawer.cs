using UnityEditor;

[CustomPropertyDrawer(typeof(GameButtonToLeanButtonDictionary))]
[CustomPropertyDrawer(typeof(GameButtonToQuestionDictionary))]
[CustomPropertyDrawer(typeof(QuestionNameToQuestionDictionary))]
public class AnySerializableDictionaryPropertyDrawer : SerializableDictionaryPropertyDrawer { }