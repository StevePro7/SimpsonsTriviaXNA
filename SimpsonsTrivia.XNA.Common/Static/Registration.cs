using WindowsGame.Common.Library.IoC;
using WindowsGame.Common.TheGame;
using WindowsGame.Common.Library.Interfaces;
using WindowsGame.Common.Managers;
using WindowsGame.Common.Implementation;
using WindowsGame.Common.Library.Managers;

namespace WindowsGame.Common.Static
{
	public static class Registration
	{
		public static void Initialize()
		{
			IoCContainer.Initialize<IGameManager, GameManager>();

			IoCContainer.Initialize<IQuestionManager, QuestionManager>();
			IoCContainer.Initialize<IRandomManager, RandomManager>();

			IoCContainer.Initialize<IFileProxy, RealFileProxy>();
			IoCContainer.Initialize<IFileManager, FileManager>();

#if WINDOWS
			//IoCContainer.Initialize<IDeviceFactory, WorkDeviceFactory>();
			//IoCContainer.Initialize<IInputFactory, WorkInputFactory>();
			IoCContainer.Initialize<ILogger, Logger.Implementation.RealLogger>();
#endif
#if !WINDOWS
			//IoCContainer.Initialize<IDeviceFactory, FoneDeviceFactory>();
			//IoCContainer.Initialize<IInputFactory, FoneInputFactory>();
			IoCContainer.Initialize<ILogger, Library.Implementation.TestLogger>();
#endif
		}
	}
}