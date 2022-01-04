today=$(date +'%m-%d-%Y')

echo "building"
mcs "$today.cs" -out:builds/$today.exe || { echo 'failed to build' ; exit 1;}
echo "running"
mono "builds/$today.exe"
