﻿using System;
using System.Collections.Generic;
using NUnit.Framework;
using WindowsGame.Common;
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
			Console.WriteLine("Number Questions: " + questionList.Count);
		}

		[TearDown]
		public void TearDown()
		{
			QuestionManager = null;
		}

	}
}