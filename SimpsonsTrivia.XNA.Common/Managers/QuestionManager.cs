using System;
using System.Collections.Generic;
using WindowsGame.Common.Objects;
using WindowsGame.Common.Static;

namespace WindowsGame.Common.Managers
{
	public interface IQuestionManager
	{
		IList<Question> LoadQuestionList(DifficultyType type);
		Question LoadQuestion(String text);
	}

	public class QuestionManager : IQuestionManager
	{
		private static char[] semicolon = new char[] { ';' };
		private static char[] pipe = new char[] { '|' };

		public IList<Question> LoadQuestionList(DifficultyType type)
		{
			return null;
		}

		public Question LoadQuestion(String text)
		{
			String[] texts = text.Split(semicolon);

			String[] questionText = texts[1].Split(pipe);
			String[] answerAText = texts[2].Split(pipe);
			String[] answerBText = texts[3].Split(pipe);
			String[] answerCText = texts[4].Split(pipe);
			String[] answerDText = texts[5].Split(pipe);
			Byte answerCode = Convert.ToByte(texts[0]);

			return new Question(questionText, answerAText, answerBText, answerCText, answerDText, answerCode);
		}

	}
}