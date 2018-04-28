using NUnit.Framework;
using Rhino.Mocks;
using WindowsGame.Common;
using WindowsGame.Common.Library.Interfaces;
using WindowsGame.Common.Managers;
using WindowsGame.Common.TheGame;

namespace WindowsGame.UnitTests
{
	public abstract class BaseUnitTests
	{
		protected IButtonManager ButtonManager;
		protected IConfigManager ConfigManager;
		protected IContentManager ContentManager;
		protected IImageManager ImageManager;
		protected IInputManager InputManager;
		protected IQuestionManager QuestionManager;
		protected IRandomManager RandomManager;
		protected IResolutionManager ResolutionManager;
		protected IScoreManager ScoreManager;
		protected IScreenManager ScreenManager;
		protected ISoundManager SoundManager;
		protected ITextManager TextManager;
		protected IThreadManager ThreadManager;
		protected IFileManager FileManager;
		protected ILogger Logger;

#pragma warning disable 618
		[TestFixtureSetUp]
#pragma warning restore 618
		public void TestFixtureSetUp()
		{
			ButtonManager = MockRepository.GenerateStub<IButtonManager>();
			ConfigManager = MockRepository.GenerateStub<IConfigManager>();
			ContentManager = MockRepository.GenerateStub<IContentManager>();
			ImageManager = MockRepository.GenerateStub<IImageManager>();
			InputManager = MockRepository.GenerateStub<IInputManager>();
			QuestionManager = MockRepository.GenerateStub<IQuestionManager>();
			RandomManager = MockRepository.GenerateStub<IRandomManager>();
			ResolutionManager = MockRepository.GenerateStub<IResolutionManager>();
			ScoreManager = MockRepository.GenerateStub<IScoreManager>();
			ScreenManager = MockRepository.GenerateStub<IScreenManager>();
			SoundManager = MockRepository.GenerateStub<ISoundManager>();
			TextManager = MockRepository.GenerateStub<ITextManager>();
			ThreadManager = MockRepository.GenerateStub<IThreadManager>();
			FileManager = MockRepository.GenerateStub<IFileManager>();
			Logger = MockRepository.GenerateStub<ILogger>();
		}

		protected void SetUp()
		{
			IGameManager manager = new GameManager
			(
				ButtonManager,
				ConfigManager,
				ContentManager,
				ImageManager,
				InputManager,
				QuestionManager,
				RandomManager,
				ResolutionManager,
				ScoreManager,
				ScreenManager,
				SoundManager,
				TextManager,
				ThreadManager,
				FileManager,
				Logger
			);

			MyGame.Construct(manager);
		}

#pragma warning disable 618
		[TestFixtureTearDown]
#pragma warning restore 618
		public void TestFixtureTearDown()
		{
			ButtonManager = null;
			ConfigManager = null;
			ContentManager = null;
			ImageManager = null;
			InputManager = null;
			QuestionManager = null;
			RandomManager = null;
			ResolutionManager = null;
			ScoreManager = null;
			ScreenManager = null;
			SoundManager = null;
			TextManager = null;
			ThreadManager = null;
			FileManager = null;
			Logger = null;
		}

	}
}