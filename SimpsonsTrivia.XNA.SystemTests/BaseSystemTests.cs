using System;
using NUnit.Framework;
using WindowsGame.Common.Library.Interfaces;
using WindowsGame.Common.Library.IoC;
using WindowsGame.Common.Managers;
using WindowsGame.Common.Static;
using WindowsGame.Common.TheGame;
using WindowsGame.SystemTests.Implementation;

namespace WindowsGame.SystemTests
{
	public abstract class BaseSystemTests
	{
		protected IFileManager FileManager;
		protected IQuestionManager QuestionManager;
		protected IRandomManager RandomManager;
		protected ILogger Logger;

		// mklink /D C:\CandyKid.XNA.Content  C:\CandyKid.XNA\bin\x86\Debug\
		protected const String CONTENT_ROOT = @"C:\SimpsonsTrivia.XNA.Content\";

#pragma warning disable 618
		[TestFixtureSetUp]
#pragma warning restore 618
		public void TestFixtureSetUp()
		{
			Registration.Initialize();
			IoCContainer.Initialize<IFileProxy, TestFileProxy>();

			IGameManager manager = GameFactory.Resolve();
			MyGame.Construct(manager);
		}

#pragma warning disable 618
		[TestFixtureTearDown]
#pragma warning restore 618
		public void TestFixtureTearDown()
		{
			GameFactory.Release();
		}

	}
}