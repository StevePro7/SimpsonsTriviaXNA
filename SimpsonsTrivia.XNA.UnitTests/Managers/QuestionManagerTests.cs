using System;
using NUnit.Framework;
using WindowsGame.Common.Managers;
using WindowsGame.Common.Objects;

namespace WindowsGame.UnitTests.Managers
{
	[TestFixture]
	public class QuestionManagerTests : BaseUnitTests
	{
		[SetUp]
		public new void SetUp()
		{
			QuestionManager = new QuestionManager();
		}

		[Test]
		public void LoadQuestionDataTest()
		{
			String text = "3;WHICH OF THE FOLLOWING|CHARACTERS IS A NON-SMOKER?;KRUSTY;NELSON;GRAMPA SIMPSON;MRS. KRABAPPLE;page01;02-GeneralSimpsonsTrivia.csv";
			//DifficultyType type = DifficultyType.Easy;

			Question question = QuestionManager.LoadQuestion(text);

			Assert.That(question, Is.Null);
		}

		[TearDown]
		public void TearDown()
		{
			QuestionManager = null;
		}

	}
}