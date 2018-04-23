using System;
using NUnit.Framework;
using WindowsGame.Common.Managers;
using WindowsGame.Common.Objects;

namespace WindowsGame.UnitTests.Managers
{
	[TestFixture]
	public class QuestionManagerUnitTests : BaseUnitTests
	{
		[SetUp]
		public new void SetUp()
		{
			QuestionManager = new QuestionManager();
		}

		[Test]
		public void LoadQuestionDataTest()
		{
			String line = "3;WHICH OF THE FOLLOWING|CHARACTERS IS A NON-SMOKER?;KRUSTY;NELSON;GRAMPA SIMPSON;MRS. KRABAPPLE;page01;02-GeneralSimpsonsTrivia.csv";

			Question question = QuestionManager.LoadQuestion(line);

			Assert.That(question, Is.Null);
		}

		[TearDown]
		public void TearDown()
		{
			QuestionManager = null;
		}

	}
}