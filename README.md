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


03.
Add Manager class - need to update
SimpsonsTrivia.XNA.Common
Registration.cs
GameManager.cs

SimpsonsTrivia.XNA.SystemTests
BaseSystemTests.cs

SimpsonsTrivia.XNA.UnitTests
BaseUnitTests.cs