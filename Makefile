install: snippet.vsix
	code --install-extension dest/snippet.vsix

extension:
	snipgen --config config.json src dest/extension

snippet.vsix: extension
	cd dest/extension; vsce package -o ../snippet.vsix
