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
Minimum 5.2 iOS version not supported
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