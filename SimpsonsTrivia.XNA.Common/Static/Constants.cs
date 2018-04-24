using System;

namespace WindowsGame.Common.Static
{
	public static class Constants
	{
		public const String CONTENT_DIRECTORY = "Content";

		public const String DATA_DIRECTORY = "Data";
		public const String CONFIG_DIRECTORY = "Config";
		public const String LEVELS_DIRECTORY = "Levels";
		public const String TEXTS_DIRECTORY = "Texts";

		public const String FONTS_DIRECTORY = "Fonts";
		public const String SOUND_DIRECTORY = "Sound";
		public const String TEXTURES_DIRECTORY = "Textures";

		public const String GLOBAL_CONFIG_FILENAME = "GlobalConfig.xml";
		public const String PLATFORM_CONFIG_FILENAME = "PlatformConfig{0}.xml";

		public const Byte NUMBER_LINES = 3;

#if WINDOWS && DEBUG
		public const Boolean IsFullScreen = false;
		public const Boolean IsMouseVisible = true;
#endif
#if WINDOWS && !DEBUG
		public const Boolean IsFullScreen = true;
		public const Boolean IsMouseVisible = true;
#endif
#if WINDOWS
		public const UInt16 ScreenWide = 640;
		public const UInt16 ScreenHigh = 480;

		public const Boolean UseExposed = true;
		public const UInt16 ExposeWide = 640;
		public const UInt16 ExposeHigh = 480;

		public const Byte GameOffsetX = 0;
		public const SByte FontOffsetX = -1;
		public const SByte FontOffsetY = -4;
#endif
#if !WINDOWS
		public const Boolean IsFullScreen = true;
		public const Boolean IsMouseVisible = false;
		public const UInt16 ScreenWide = 800;
		public const UInt16 ScreenHigh = 480;

		public const Boolean UseExposed = false;
		public const UInt16 ExposeWide = 800;
		public const UInt16 ExposeHigh = 480;

		public const Byte GameOffsetX = 80;
		public const SByte FontOffsetX = -1;
		public const SByte FontOffsetY = -4;
#endif
	}
}