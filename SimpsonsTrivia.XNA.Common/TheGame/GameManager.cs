using System;
using WindowsGame.Common.Library.Interfaces;
using WindowsGame.Common.Managers;

namespace WindowsGame.Common.TheGame
{
	public interface IGameManager
	{
		IFileManager FileManager { get; }
		IQuestionManager QuestionManager { get; }
		IRandomManager RandomManager { get; }
		IResolutionManager ResolutionManager { get; }
		ILogger Logger { get; }
	}

	public class GameManager : IGameManager
	{
		public GameManager
		(
			IFileManager fileManager,
			IQuestionManager questionManager,
			IRandomManager randomManager,
			IResolutionManager resolutionManager,
			ILogger logger
		)
		{
			FileManager = fileManager;
			QuestionManager = questionManager;
			RandomManager = randomManager;
			ResolutionManager = resolutionManager;
			Logger = logger;
		}

		public IFileManager FileManager { get; private set; }
		public IQuestionManager QuestionManager { get; private set; }
		public IRandomManager RandomManager { get; private set; }
		public IResolutionManager ResolutionManager { get; private set; }
		public ILogger Logger { get; private set; }
	}
}