

.PHONY: clean snippet

#–{“–‚Ísrc/**/*.csx‚ğˆË‘¶‚³‚¹‚½‚©‚Á‚½‚ªAÁÜc
snippet: 
	dotnet run -p SnippetGenerator/CSSnippetGenerator/CSSnippetGenerator.csproj ./

clean: 
	rm -r snippets

