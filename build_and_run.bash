#!/usr/bin/bash

today=$(date +'%m-%d-%Y')

build_and_run_csharp() {
	echo "building"
	mcs "$today.cs" -out:builds/$today.exe || {
		echo 'failed to build'
		exit 1
	}
	echo "running $today.exe"
	echo "----------------------------------------"
	mono "builds/$today.exe"
}

build_and_run_typescript() {
	echo "building"
	tsc "$today" --outDir "builds" --module commonjs --lib es2021 --target es2021 || {
		echo 'failed to build'
		exit 1
	}
	echo "running $today.js"
	echo "----------------------------------------"
	node "builds/$today.js"
}

show_help() {
	echo "Usage: $0 [OPTION]..."
	echo "Build and run code"

	echo "  -d, run code for custom date"
	echo "  -h, show this help"
	echo "  -y, run code for yesterday"
}

while getopts "hyd:" OPTION; do
	case $OPTION in
	h)
		show_help
		exit 0
		;;
	y)
		today=$(date -d "yesterday" +'%m-%d-%Y')
		;;
	d)
		today=$OPTARG
		;;
	*)
		echo "invalid argument '$OPTION'"
		show_help
		exit 1
		;;
	esac
done

if [ -f "$today.ts" ]; then
	build_and_run_typescript
else
	if [ -f "$today.cs" ]; then
		build_and_run_csharp
	else

		echo "File extension is not .ts or .cs"
		exit 1

	fi
fi
