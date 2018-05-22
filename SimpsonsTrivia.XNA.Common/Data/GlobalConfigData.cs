using System;
using WindowsGame.Common.Static;

namespace WindowsGame.Common.Data
{
	public struct GlobalConfigData
	{
		public ScreenType ScreenType;
		public UInt16 SplashDelay;
		public Boolean BlankSplash;
		public UInt16 TitleDelay;
		public Byte ActorIndex;
		public Boolean FlashTitle;
		public Boolean PlaySound;
		public Boolean CheatMode;
		public Byte Question;
		public Boolean RandomQuestions;
		public Boolean RandomAnswers;
		public Boolean QuitsToExit;
	}
}