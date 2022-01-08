today=$(date +'%m-%d-%Y')

if [ "$1" = "ts" ] || [ "$1" = "typescript" ]; then
	cp "templates/templates.ts" "$today.ts"

	code "$today.ts"
else
	if [ "$1" = "cs" ] || [ "$1" = "csharp" ]; then
		cp "templates/template.cs" "$today.cs"

		code "$today.cs"
	else
		echo "language must be .ts or .cs"
		exit 1
	fi
fi