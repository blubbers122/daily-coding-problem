today=$(date +'%m-%d-%Y')

if [ "$1" = "ts" ] || [ "$1" = "typescript" ]; then
	cp "templates/template.ts" "$today.ts"
	sed -i "s/DailyCodingProblem/DailyCodingProblem_$(date +'%m_%d_%Y')/" "$today.ts"
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