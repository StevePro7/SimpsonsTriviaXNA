using System;
using WindowsGame.Common.Objects;
using WindowsGame.Common.Static;

namespace WindowsGame.Common.Managers
{
	public interface IQuestionManager
	{
		Question LoadQuestion(String text);
	}

	public class QuestionManager : IQuestionManager
	{
		private static char[] semicolon = new char[] { ';' };
		private static char[] pipe = new char[] { '|' };

		public Question LoadQuestion(String text)
		{
			String[] texts = text.Split(semicolon);

			String[] questionText = BuildArray(texts[1]);
			String[] answerAText = BuildArray(texts[2]);
			String[] answerBText = BuildArray(texts[3]);
			String[] answerCText = BuildArray(texts[4]);
			String[] answerDText = BuildArray(texts[5]);
			Byte answerCode = Convert.ToByte(texts[0]);

			return new Question(questionText, answerAText, answerBText, answerCText, answerDText, answerCode);
		}

		private static String[] BuildArray(String data)
		{
			String[] lines = new String[Constants.NUMBER_LINES];

			String[] tests = data.Split(pipe);
			if (tests.Length > 2)
			{
				lines[2] = tests[2];
			}
			if (tests.Length > 1)
			{
				lines[1] = tests[1];
			}

			lines[0] = tests[0];
			return lines;
		}

	}
}