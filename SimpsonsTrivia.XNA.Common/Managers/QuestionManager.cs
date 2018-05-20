using System;
using System.Collections.Generic;
using WindowsGame.Common.Objects;
using WindowsGame.Common.Static;
using Microsoft.Xna.Framework;

namespace WindowsGame.Common.Managers
{
	public interface IQuestionManager
	{
		void Initialize();
		void Initialize(String root);
		void LoadContent();

		void LoadQuestionList(DifficultyType type);
		Question LoadQuestion(Byte index);
		Question LoadQuestion(String line);
		void DrawQuestion(Byte index);

		IList<Question> QuestionList { get; }
	}

	public class QuestionManager : IQuestionManager
	{
		private String questionRoot;
		private Vector2[] questionPosn;
		private Vector2[] answerAPosn, answerBPosn, answerCPosn, answerDPosn;

		private static readonly char[] semicolon = { ';' };
		private static readonly char[] pipe = { '|' };

		public void Initialize()
		{
			Initialize(String.Empty);
		}
		public void Initialize(String root)
		{
			questionRoot = root;
			QuestionList = new List<Question>();
		}

		public void LoadContent()
		{
			questionPosn = GetQuestionPosn();
			answerAPosn = GetAnswerAPosn();
			answerBPosn = GetAnswerBPosn();
			answerCPosn = GetAnswerCPosn();
			answerDPosn = GetAnswerDPosn();
		}

		public void LoadQuestionList(DifficultyType type)
		{
			QuestionList.Clear();

			String file = String.Format("{0}{1}/{2}/{3}/{4}.txt", questionRoot, Constants.CONTENT_DIRECTORY, Constants.DATA_DIRECTORY,
				Constants.LEVELS_DIRECTORY, type);

			var lines = MyGame.Manager.FileManager.LoadTxt(file);
			foreach (String line in lines)
			{
				Question question = LoadQuestion(line);
				QuestionList.Add(question);
			}
		}

		public Question LoadQuestion(Byte index)
		{
			return QuestionList[index];
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

		public void DrawQuestion(Byte index)
		{
			Question question = QuestionList[index];

			for (Byte line = 0; line < Constants.NUMBER_LINES; line++)
			{
				if (line < question.QuestionText.Length)
				{
					DrawLine(question.QuestionText[line], questionPosn[line]);
				}

				if (line < question.AnswerAText.Length)
				{
					DrawLine(question.AnswerAText[line], answerAPosn[line]);
				}
				if (line < question.AnswerBText.Length)
				{
					DrawLine(question.AnswerBText[line], answerBPosn[line]);
				}
				if (line < question.AnswerCText.Length)
				{
					DrawLine(question.AnswerCText[line], answerCPosn[line]);
				}
				if (line < question.AnswerDText.Length)
				{
					DrawLine(question.AnswerDText[line], answerDPosn[line]);
				}
			}
		}

		public IList<Question> QuestionList { get; private set; }

		private void DrawLine(String line, Vector2 posn)
		{
			if (String.IsNullOrEmpty(line))
			{
				return;
			}

			MyGame.Manager.TextManager.DrawText(line, posn);
		}

		private static Vector2[] GetQuestionPosn()
		{
			Vector2[] positions = new Vector2[Constants.NUMBER_LINES];
			positions[0] = MyGame.Manager.TextManager.GetTextPosition(2, 5);
			positions[1] = MyGame.Manager.TextManager.GetTextPosition(2, 6);
			positions[2] = MyGame.Manager.TextManager.GetTextPosition(2, 7);
			return positions;
		}
		private static Vector2[] GetAnswerAPosn()
		{
			Vector2[] answerPosn = new Vector2[Constants.NUMBER_LINES];
			answerPosn[0] = MyGame.Manager.TextManager.GetTextPosition(4, 9);
			answerPosn[1] = MyGame.Manager.TextManager.GetTextPosition(4, 10);
			answerPosn[2] = MyGame.Manager.TextManager.GetTextPosition(4, 11);
			return answerPosn;
		}
		private static Vector2[] GetAnswerBPosn()
		{
			Vector2[] answerPosn = new Vector2[Constants.NUMBER_LINES];
			answerPosn[0] = MyGame.Manager.TextManager.GetTextPosition(4, 13);
			answerPosn[1] = MyGame.Manager.TextManager.GetTextPosition(4, 14);
			answerPosn[2] = MyGame.Manager.TextManager.GetTextPosition(4, 15);
			return answerPosn;
		}
		private static Vector2[] GetAnswerCPosn()
		{
			Vector2[] answerPosn = new Vector2[Constants.NUMBER_LINES];
			answerPosn[0] = MyGame.Manager.TextManager.GetTextPosition(4, 17);
			answerPosn[1] = MyGame.Manager.TextManager.GetTextPosition(4, 18);
			answerPosn[2] = MyGame.Manager.TextManager.GetTextPosition(4, 19);
			return answerPosn;
		}
		private static Vector2[] GetAnswerDPosn()
		{
			Vector2[] answerPosn = new Vector2[Constants.NUMBER_LINES];
			answerPosn[0] = MyGame.Manager.TextManager.GetTextPosition(4, 21);
			answerPosn[1] = MyGame.Manager.TextManager.GetTextPosition(4, 22);
			answerPosn[2] = MyGame.Manager.TextManager.GetTextPosition(4, 23);
			return answerPosn;
		}

	}
}