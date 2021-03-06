﻿using Lean.Gui;
using System;

//GameButton enum to LeanButton
[Serializable]
public class GameButtonToLeanButtonDictionary : SerializableDictionary<GameButton, LeanButton> {}

//GameButton enum to Question
[Serializable]
public class GameButtonToQuestionDictionary : SerializableDictionary<GameButton, Question> {}

//QuestionName to Question
[Serializable]
public class QuestionNameToQuestionDictionary : SerializableDictionary<QuestionName, Question> {}
