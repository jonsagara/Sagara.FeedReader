@echo off

REM Generate markdown docs from the generated XML documentation file.
REM Mad props to DefaultDocumentation, which we have installed as a local tool.
REM See: https://github.com/Doraku/DefaultDocumentation

REM DefaultDocumentation 0.8.2 targets .NET 6. Let it run on the newest installed runtime instead.
set DOTNET_ROLL_FORWARD=Major

REM Sagara.FeedReader
echo [Sagara.FeedReader] Generating docs...
dotnet defaultDocumentation -a "src\Sagara.FeedReader\bin\Debug\net10.0\Sagara.FeedReader.dll" -o "src\Sagara.FeedReader\docs" --ConfigurationFilePath ".\DefaultDocumentation.json"
echo [Sagara.FeedReader] Done.
