using System;
using System.Collections.Generic;
using WindowsGame.Common.Managers;
using WindowsGame.Common.Objects;
using NUnit.Framework;
using WindowsGame.Common.Static;

namespace WindowsGame.SystemTests.Managers
{
	[TestFixture]
	public class QuestionManagerTests : BaseSystemTests
	{
		private IQuestionManager questionManager;

		[SetUp]
		public void SetUp()
		{
			questionManager = new QuestionManager();
		}

		[Test]
		public void LoadQuestionListTest()
		{
			DifficultyType type = DifficultyType.Easy;

			IList<Question> questionList = questionManager.LoadQuestionList(type);

			Assert.That(3, Is.EqualTo(questionList.Count));
		}

		[TearDown]
		public void TearDown()
		{
			questionManager = null;
		}

	}
}