using System;
using WindowsGame.Common.Managers;
using WindowsGame.Common.Objects;
using NUnit.Framework;

namespace WindowsGame.UnitTests.Managers
{
	[TestFixture]
	public class QuestionManagerTests : BaseUnitTests
	{
		private IQuestionManager questionManager;

		[SetUp]
		public void SetUp()
		{
			questionManager = new QuestionManager();
		}

		[Test]
		public void LoadQuestionDataTest()
		{
			String text = "3;WHICH OF THE FOLLOWING|CHARACTERS IS A NON-SMOKER?;KRUSTY;NELSON;GRAMPA SIMPSON;MRS. KRABAPPLE;page01;02-GeneralSimpsonsTrivia.csv";
			//DifficultyType type = DifficultyType.Easy;

			Question question = questionManager.LoadQuestion(text);

			Assert.That(question, Is.Null);
		}

		[TearDown]
		public void TearDown()
		{
			questionManager = null;
		}

	}
}