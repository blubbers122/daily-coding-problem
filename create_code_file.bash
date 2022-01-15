#!/usr/bin/bash


today=$(date +'%m-%d-%Y')
language="cs"
function_name="MyFunction_$(date +'%m_%d_%Y')"
overwrite_existing="false"

show_help()
{
	echo "Usage: $0 [OPTION]..."
	echo "Create a new coding challenge function template"

	echo "  -d, create template for custom date"
	echo "  -f, set the function name (default: MyFunction_$(date +'%m_%d_%Y'))"
	echo "  -h, show this help"
	echo "  -l, set the language to use (default: cs)"
	echo "  -y, create template for yesterday"
	echo "  -o, overwrite existing code file"
	
}

create_code_file_from_template()
{
	if [ "$1" = "ts" ] || [ "$1" = "typescript" ]; then
		file_name="$today.ts"
		if [ -f "$file_name" ] && [ "$overwrite_existing" = "false" ]; then
			echo "File already exists: $file_name"
			echo "Use -o to overwrite the existing file"
			exit 1
		fi
		echo "Creating code file: $file_name"
		cp "templates/template.ts" "$file_name"
		sed -i "s/DailyCodingProblem/DailyCodingProblem_$(date +'%m_%d_%Y')/" "$file_name"
		sed -i "s/functionName/$2/" "$file_name"
		code "$file_name"
	else
		if [ "$1" = "cs" ] || [ "$1" = "csharp" ]; then
			file_name="$today.cs"
			if [ -f "$file_name" ] && [ "$overwrite_existing" = "false" ]; then
				echo "File already exists: $file_name"
				echo "Use -o to overwrite the existing file"
				exit 1
			fi
			cp "templates/template.cs" "$file_name"
			sed -i "s/FunctionName/$2/" "$file_name"
			code "$file_name"
		else
			echo "language must be .ts or .cs"
			exit 1
		fi
	fi
}


# TODO: refactor to use another way to get options since getopts does not support long options
while getopts "yohl:d:f:" OPTION; do
	case $OPTION in
	h)
		show_help
		exit 0
		;;
	l)
		language=$OPTARG
		;;
	y)
		today=$(date -d 'yesterday' +'%m-%d-%Y')
		;;
	d)
		today=$OPTARG
		;;
	f)
		function_name=$OPTARG
		;;
	o)
		overwrite_existing="true"
		;;
	*)
		echo "invalid argument '$OPTION'"
		show_help
		exit 1
		;;
	esac
done

create_code_file_from_template $language $function_name
