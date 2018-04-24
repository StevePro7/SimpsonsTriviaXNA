using NUnit.Framework;
using Rhino.Mocks;
using WindowsGame.Common.Library.Interfaces;
using WindowsGame.Common.Managers;
using WindowsGame.Common.TheGame;

namespace WindowsGame.UnitTests
{
	public abstract class BaseUnitTests
	{
		protected IFileManager FileManager;
		protected IQuestionManager QuestionManager;
		protected IRandomManager RandomManager;
		protected IResolutionManager ResolutionManager;
		protected ILogger Logger;

#pragma warning disable 618
		[TestFixtureSetUp]
#pragma warning restore 618
		public void TestFixtureSetUp()
		{
			FileManager = MockRepository.GenerateStub<IFileManager>();
			QuestionManager = MockRepository.GenerateStub<IQuestionManager>();
			RandomManager = MockRepository.GenerateStub<IRandomManager>();
			ResolutionManager = MockRepository.GenerateStub<IResolutionManager>();
			Logger = MockRepository.GenerateStub<ILogger>();
		}

		protected void SetUp()
		{
			IGameManager manager = new GameManager
			(
				FileManager,
				QuestionManager,
				RandomManager,
				ResolutionManager,
				Logger
			);

			MyGame.Construct(manager);
		}

#pragma warning disable 618
		[TestFixtureTearDown]
#pragma warning restore 618
		public void TestFixtureTearDown()
		{
			FileManager = null;
			QuestionManager = null;
			RandomManager = null;
			ResolutionManager = null;
			Logger = null;
		}

	}
}