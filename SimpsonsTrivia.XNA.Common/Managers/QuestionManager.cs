using System;
using System.Collections.Generic;
using WindowsGame.Common.Objects;
using WindowsGame.Common.Static;

namespace WindowsGame.Common.Managers
{
	public interface IQuestionManager
	{
		void Initialize();
		void Initialize(String root);
		IList<Question> LoadQuestionList(DifficultyType type);
		Question LoadQuestion(String line);
	}

	public class QuestionManager : IQuestionManager
	{
		private String questionRoot;

		private static char[] semicolon = new char[] { ';' };
		private static char[] pipe = new char[] { '|' };

		public void Initialize()
		{
			Initialize(String.Empty);
		}
		public void Initialize(String root)
		{
			questionRoot = root;
		}

		public IList<Question> LoadQuestionList(DifficultyType type)
		{
			IList<Question> questionList = new List<Question>();

			String file = String.Format("{0}{1}/{2}/{3}/{4}.txt", questionRoot, Constants.CONTENT_DIRECTORY, Constants.DATA_DIRECTORY,
				Constants.LEVELS_DIRECTORY, type);

			var lines = MyGame.Manager.FileManager.LoadTxt(file);
			foreach (String line in lines)
			{
				Question question = LoadQuestion(line);
				questionList.Add(question);
			}

			return questionList;
		}

		public Question LoadQuestion(String line)
		{
			String[] texts = line.Split(semicolon);

			String[] questionText = texts[1].Split(pipe);
			String[] answerAText = texts[2].Split(pipe);
			String[] answerBText = texts[3].Split(pipe);
			String[] answerCText = texts[4].Split(pipe);
			String[] answerDText = texts[5].Split(pipe);
			Byte answerCode = Convert.ToByte(texts[0]);

			return new Question(questionText, answerAText, answerBText, answerCText, answerDText, answerCode);
		}


		public string CONTENT_ROOT { get; set; }
	}
}