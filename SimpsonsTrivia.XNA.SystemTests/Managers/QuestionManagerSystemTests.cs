using System.Collections.Generic;
using NUnit.Framework;
using WindowsGame.Common.Managers;
using WindowsGame.Common.Objects;
using WindowsGame.Common.Static;

namespace WindowsGame.SystemTests.Managers
{
	[TestFixture]
	public class QuestionManagerSystemTests : BaseSystemTests
	{
		[SetUp]
		public void SetUp()
		{
			QuestionManager = MyGame.Manager.QuestionManager;
			QuestionManager.Initialize(CONTENT_ROOT);
		}

		[Test]
		public void LoadQuestionListTest()
		{
			// Arrange.
			DifficultyType type = DifficultyType.Easy;

			// Act.
			IList<Question> questionList = QuestionManager.LoadQuestionList(type);

			// Assert.
			Assert.That(3, Is.EqualTo(questionList.Count));
		}

		[TearDown]
		public void TearDown()
		{
			QuestionManager = null;
		}

	}
}