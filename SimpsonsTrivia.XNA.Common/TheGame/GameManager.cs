using System;
using WindowsGame.Common.Library.Interfaces;
using WindowsGame.Common.Managers;

namespace WindowsGame.Common.TheGame
{
	public interface IGameManager
	{
		IButtonManager ButtonManager { get; }
		IConfigManager ConfigManager { get; }
		IContentManager ContentManager { get; }
		IImageManager ImageManager { get; }
		IInputManager InputManager { get; }
		IQuestionManager QuestionManager { get; }
		IRandomManager RandomManager { get; }
		IResolutionManager ResolutionManager { get; }
		IScoreManager ScoreManager { get; }
		IScreenManager ScreenManager { get; }
		ISoundManager SoundManager { get; }
		ISpriteManager SpriteManager { get; }
		ITextManager TextManager { get; }
		IThreadManager ThreadManager { get; }
		IFileManager FileManager { get; }
		ILogger Logger { get; }
	}

	public class GameManager : IGameManager
	{
		public GameManager
		(
			IButtonManager buttonManager,
			IConfigManager configManager,
			IContentManager contentManager,
			IImageManager imageManager,
			IInputManager inputManager,
			IQuestionManager questionManager,
			IRandomManager randomManager,
			IResolutionManager resolutionManager,
			IScoreManager scoreManager,
			IScreenManager screenManager,
			ISoundManager soundManager,
			ISpriteManager spriteManager,
			ITextManager textManager,
			IThreadManager threadManager,
			IFileManager fileManager,
			ILogger logger
		)
		{
			ButtonManager = buttonManager;
			ConfigManager = configManager;
			ContentManager = contentManager;
			ImageManager = imageManager;
			InputManager = inputManager;
			QuestionManager = questionManager;
			RandomManager = randomManager;
			ResolutionManager = resolutionManager;
			ScoreManager = scoreManager;
			ScreenManager = screenManager;
			SoundManager = soundManager;
			SpriteManager = spriteManager;
			TextManager = textManager;
			ThreadManager = threadManager;
			FileManager = fileManager;
			Logger = logger;
		}

		public IButtonManager ButtonManager { get; private set; }
		public IConfigManager ConfigManager { get; private set; }
		public IContentManager ContentManager { get; private set; }
		public IImageManager ImageManager { get; private set; }
		public IInputManager InputManager { get; private set; }
		public IQuestionManager QuestionManager { get; private set; }
		public IRandomManager RandomManager { get; private set; }
		public IResolutionManager ResolutionManager { get; private set; }
		public IScoreManager ScoreManager { get; private set; }
		public IScreenManager ScreenManager { get; private set; }
		public ISoundManager SoundManager { get; private set; }
		public ISpriteManager SpriteManager { get; private set; }
		public ITextManager TextManager { get; private set; }
		public IThreadManager ThreadManager { get; private set; }
		public IFileManager FileManager { get; private set; }
		public ILogger Logger { get; private set; }
	}
}