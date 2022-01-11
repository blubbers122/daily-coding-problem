today=$(date +'%m-%d-%Y')



build_and_run_csharp() {
	echo "building"
	mcs "$today.cs" -out:builds/$today.exe || {
		echo 'failed to build'
		exit 1
	}
	echo "running"
	echo "----------------------------------------"
	mono "builds/$today.exe"
}

build_and_run_typescript() {
	echo "building"
	tsc "$today.ts" --outDir "builds" || {
		echo 'failed to build'
		exit 1
	}
	echo "running"
	echo "----------------------------------------"
	node "builds/$today.js"
}

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
