@echo off

REM Generate markdown docs from the generated XML documentation file.
REM Mad props to DefaultDocumentation, which we have installed as a local tool.
REM See: https://github.com/Doraku/DefaultDocumentation

REM Sagara.FeedReader
echo [Sagara.FeedReader] Generating docs...
dotnet defaultDocumentation -a "src\Sagara.FeedReader\bin\Debug\net8.0\Sagara.FeedReader.dll" -o "src\Sagara.FeedReader\docs" --ConfigurationFilePath ".\DefaultDocumentation.json"
echo [Sagara.FeedReader] Done.
