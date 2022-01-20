"use strict";

import { performance } from "perf_hooks";

class DailyCodingProblem_01_18_2022 {
  // 	Good morning! Here's your coding interview problem for today.

  // This problem was asked by Google.

  // Suppose we represent our file system by a string in the following manner:

  // The string "dir\n\tsubdir1\n\tsubdir2\n\t\tfile.ext" represents:

  // dir
  //     subdir1
  //     subdir2
  //         file.ext
  // The directory dir contains an empty sub-directory subdir1 and a sub-directory subdir2 containing a file file.ext.

  // The string "dir\n\tsubdir1\n\t\tfile1.ext\n\t\tsubsubdir1\n\tsubdir2\n\t\tsubsubdir2\n\t\t\tfile2.ext" represents:

  // dir
  //     subdir1
  //         file1.ext
  //         subsubdir1
  //     subdir2
  //         subsubdir2
  //             file2.ext
  // The directory dir contains two sub-directories subdir1 and subdir2. subdir1 contains a file file1.ext and an empty second-level sub-directory subsubdir1. subdir2 contains a second-level sub-directory subsubdir2 containing a file file2.ext.

  // We are interested in finding the longest (number of characters) absolute path to a file within our file system. For example, in the second example above, the longest absolute path is "dir/subdir2/subsubdir2/file2.ext", and its length is 32 (not including the double quotes).

  // Given a string representing the file system in the above format, return the length of the longest absolute path to a file in the abstracted file system. If there is no file in the system, return 0.

  // Note:

  // The name of a file contains at least a period and an extension.

  // The name of a directory or sub-directory will not contain a period.

  main = (): void => {
    const startTime = performance.now();
    console.log(
      this.longestAbsolutePath("dir\n\tsubdir1\n\t\tfile1.ext\n\t\tsubsubdir1\n\tsubdir2\n\t\tsubsubdir2\n\t\t\tfile2.ext") // should be 32 "dir/subdir2/subsubdir2/file2.ext"
    );
		console.log(this.longestAbsolutePath('a\n\tb\n\t\tc\n\t\t\td\n\t\t\t\te.abc')); // should be 13 "a/b/c/d/e.abc"
		console.log(this.longestAbsolutePath("dir\n\tsubdir1\n\tsubdir2\n\t\tfile.ext")) // should be 20 "dir/subdir2/file.ext"
		console.log(this.longestAbsolutePath('dir')) // should be 3 "dir"
    const endTime = performance.now();
    console.log(`Execution time: ${endTime - startTime} ms`);
  };

  longestAbsolutePath = (folderStructure: string): number => {
    
    let depth: number = 0;
		let lastDepth: number = 0;
    const itemsInFolder: string[] = folderStructure.split("\n");
		const currentPath: string[] = [itemsInFolder.shift()]
		let longestPath: number = currentPath[0].length;

    itemsInFolder.forEach((item) => {
			let itemName: string = item;

			while (itemName.startsWith('\t')) {
				depth++;
				itemName = itemName.replace('\t', '');
			}

			if (lastDepth != depth) {
				currentPath[depth] = itemName;
			}

			lastDepth = depth;
			longestPath = Math.max(longestPath, currentPath.join('/').length);
      depth = 0;
    });
		
    return longestPath;
  };
}

new DailyCodingProblem_01_18_2022().main();
