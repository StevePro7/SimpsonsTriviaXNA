using System.Collections.Generic;
using NUnit.Framework;
using WindowsGame.Common.Managers;
using WindowsGame.Common.Objects;
using WindowsGame.Common.Static;

namespace WindowsGame.SystemTests.Managers
{
	[TestFixture]
	public class QuestionManagerTests : BaseSystemTests
	{
		[SetUp]
		public void SetUp()
		{
			QuestionManager = MyGame.Manager.QuestionManager;
		}

		[Test]
		public void LoadQuestionListTest()
		{
			DifficultyType type = DifficultyType.Easy;

			IList<Question> questionList = QuestionManager.LoadQuestionList(type);

			Assert.That(3, Is.EqualTo(questionList.Count));
		}

		[TearDown]
		public void TearDown()
		{
			QuestionManager = null;
		}

	}
}