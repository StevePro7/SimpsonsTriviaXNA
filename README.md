# SimpsonsTriviaXNA
Test repo for Simpsons Trivia XNA

View menu | Other Windows | Package Manager console
Install-Package Ninject -Version 3.2.2
Install-Package NUnit -Version 3.4.1
Install-Package log4net -Version 2.0.5
Install-Package RhinoMocks -Version 3.6.1

01.
https://stackoverflow.com/questions/10113532/how-do-i-fix-the-visual-studio-compile-error-mismatch-between-processor-archit
<PropertyGroup>
  <ResolveAssemblyWarnOrErrorOnTargetArchitectureMismatch>None</ResolveAssemblyWarnOrErrorOnTargetArchitectureMismatch>
</PropertyGroup>


02.
Launch cmd prompt as admin
mklink /D C:\SimpsonsTrivia.XNA.Content C:\GithubX\StevePro7\SimpsonsTriviaXNA\SimpsonsTrivia.XNA\SimpsonsTrivia.XNA\bin\x86\Debug\
mklink /D C:\SimpsonsTrivia.XNA.Content E:\Github\StevePro7\SimpsonsTriviaXNA\SimpsonsTrivia.XNA\SimpsonsTrivia.XNA\bin\x86\Debug\


03.
Add Manager class - need to update
SimpsonsTrivia.XNA.Common
Registration.cs
GameManager.cs

SimpsonsTrivia.XNA.SystemTests
BaseSystemTests.cs

SimpsonsTrivia.XNA.UnitTests
BaseUnitTests.cs


MUSIC
Bart vs. The Space Mutants
http://www.smspower.org/Music/BartVsTheSpaceMutants-SMS
Bart vs. the Space Mutants - 02 - Stage 2 - Mall.vgm


Converting WAV to MP3
Run Audacity and click File > Open.
Choose the WAV file you want to convert and then click the Open button.
When the file has loaded into Audacity, click File > Export Audio.
Click the Save As Type drop-down menu and choose the MP3 Files option.

IMPORTANT
Had to download and install Lame_v3.99.3_for_Windows.exe 
https://lame.buanzo.org/#lamewindl
https://lame.buanzo.org/Lame_v3.99.3_for_Windows.exe

Now could Export Audio WAV to MP3 from before



iOS prototype
Visual Studio for Mac
D:\stevepro\CandyKid\CandyKid.PROD.iOS\trunk
Had to manually copy the SVN externals from
D:\stevepro\CandyKid\CandyKid.XNA\trunk\CandyKid.XNA\Common

Launch CandyKid.PROD.iOS.sln
ERRORS
01.
error MT0073: Xamarin.iOS 11.9.1 does not support a deployment target of 5.2 for iOS (the minimum is 6.0)
Please select a newer deployment target in your project's Info.plist
Info.plist
change 5.2 to 6.0
OR
change Deployment Target in IDE [Info.plist]
Now will build OK

02.
Can't deploy 32-bit apps to 64-bit only supported
error MT0117: Can't launch a 32-bit app on a simulator that only supports 64-bit apps (iPhone 6s)
https://stackoverflow.com/questions/46315504/error-mt0117-cant-launch-a-32-bit-app-on-a-simulator-that-only-supports-64-bit
Right click on project
CandyKid.PROD.iOS
Options
iOS Build
Supported architectures
i386
change this to
i386 + x86_64
Now will deploy to device


IMAGES
This is where I am updating the sprite sheet
E:\Steven\Personal\Simpsons\NewContent
E:\Steven\Personal\Simpsons\_Simpsons\Image


SOUND FX
Load up test SMS project
Build SFX to output.sms
Unplug speaker cable from audio jack
Speakers Realtek High Definition Audio
Plug black cable from microphone to headphones
Start recorder
Play output.sms
Stop recorder

Convert WMA to WAV file online
https://www.zamzar.com/convert/wma-to-wav


Sound Manager TODO fade out the volume
e.g. Ready Screen

sample code here
https://stackoverflow.com/questions/7513746/mediaplayer-volume-control


SVN
15/05/2018
SimpsonsTrivia.IOS

Sound effects
Build Windows content and get 3x XNB files from bin\Debug\Content
Cheat.xnb

copy to SimpsonsTrivia.IOS Content folder
Properties
Content
Copy if newer
This should work 


SimpsonsTrivia.AND
Had to downgrade to v3.4 as there is a Null Reference bug in v3.5
this is for playing sound effects via SoundEffectInstance
http://community.monogame.net/t/soundeffectinstance-not-working-on-android/1003


MonoGame Windows build
https://gamedev.stackexchange.com/questions/86696/loading-song-in-monogame-windows

DATA
*.txt
*.xml
Build Action				None
Copy to Output Directory	Copy if newer

FONT
*.xnb
Build Action				Content
Copy to Output Directory	Copy if newer

MUSIC	*.mp3
*.wma
*.xnb
Build Action				Content
Copy to Output Directory	Copy if newer

SOUND	*.wav
*.xnb
Build Action				Content
Copy to Output Directory	Copy if newer

TEXTURE
*.xnb
Build Action				Content
Copy to Output Directory	Copy if newer


ANDROID strange
Could not build + run out from VS2015 to Android [Samsung] device - not detected
Not sure if this had anything to do with the fact that I installed Xamarin Studio simulator updates earlier??

But could build + run out from VS2017 Not sure what changed / happened
Android device is totally connected to the PC
Can't seem to archive now...!

Also, Android had another issue when I did manually build out via VS2015
Game was "installed" twice
SOLUTION
https://stackoverflow.com/questions/29735527/why-the-app-is-installed-twice

I had MainLauncher = true in both SplashActivity and GameActivity
This should be in the SplashActivity only!!


Sat, 19th May
Checked that I had OK to archive Android builds on BFG PC
This still setup
Went to check iOS but would have to connect to the iMac so good opportunity to get screen shots here...


Android deploy
Build SVN and update on secondary PC
Launch VS2015
Release mode
Right click project
Archive
Distribute...
Ad Hoc
Selete signing identity	steveproxna	password
Save As
Copy the APK to mount drive
Can install from primary PC
https://www.dropbox.com/sh/lgsgjyahshaogj9/AACpkGp9Ksp27Ze4VIQd82yia?dl=0

Test input