

.PHONY: clean snippet

#本当はsrc/**/*.csxを依存させたかったが、挫折…
snippet: 
	dotnet run -p SnippetGenerator/CSSnippetGenerator/CSSnippetGenerator.csproj ./

clean: 
	rm -r snippets

