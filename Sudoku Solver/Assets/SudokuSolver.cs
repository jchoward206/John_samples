using UnityEngine;
using System.Collections;

public class SudokuSolver : MonoBehaviour {
	private int[,] test_grid = new int[,]
	{
		{ 1, 8, 4, 9, 6, 3, 7, 2, 5 },
		{ 5, 6, 2, 7, 4, 8, 3, 1, 9 },
		{ 3, 9, 7, 5, 1, 2, 8, 6, 4 },
		{ 2, 3, 9, 6, 5, 7, 1, 4, 8 },
		{ 7, 5, 6, 1, 8, 4, 2, 9, 3 },
		{ 4, 1, 8, 2, 3, 9, 6, 5, 7 },
		{ 9, 4, 1, 3, 7, 6, 5, 8, 2 },
		{ 6, 2, 3, 8, 9, 5, 4, 7, 1 },
		{ 8, 7, 5, 4, 2, 1, 9, 3, 6 } 
	};
	
	// Use this for initialization
	void Start () {
		print(IsLegalSudokuGrid(test_grid));
	}
	
	bool IsLegalSudokuGrid(int[,] grid)
	{		
		//
		// check each row == 45 and doesn't contain duplicates
		//
		for (int row = 0; row < 9; row++){
			int sum = 0;
			int[] subArray = new int[9]; 
			for (int column = 0; column < 9; column++){
				sum += grid[row,column];
				subArray[column] = grid[row,column];
			}
			if(sum != 45 || ContainsDuplicates(subArray)){ 	
				return false;
			}
		}

		//
		// check each column == 45 and doesn't contain duplicates
		//
		for (int column = 0; column < 9; column++){
			int sum = 0;
			int[] subArray = new int[9]; 
			for (int row = 0; row < 9; row++){
				sum += grid[row,column];
				subArray[row] = grid[row,column];
			}
			if(sum != 45 || ContainsDuplicates(subArray)){ 
				return false;
			}
		}		
		
		//
		// check each 3x3 mini-grid == 45 
		//
		for(int columnOffset = 0; columnOffset < 9; columnOffset += 3){
			for(int rowOffset = 0; rowOffset < 9; rowOffset += 3){
				int sum = 0;
				for (int row = rowOffset; row < (3 + rowOffset); row++){
					for (int column = columnOffset; column < (3 + columnOffset); column++){
						sum += grid[row,column];
					}
				}
				if(sum !=45){
					return false;
				}
			}
		}
				
		//
		// everyting checks out...
		//
		return true;
	}
	
	//
	// checks for duplicates
	// disclosure: I nabbed this from Stack Overflow...
	//
	bool ContainsDuplicates(int[] a){ 
		for (int i = 0; i < a.Length; i++) { 
			for (int j = i + 1; j < a.Length; j++) {
				if (a[i] == a[j]) return true; 
			} 
		} 
		return false; 
	}	
}
