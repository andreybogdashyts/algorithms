package main

import (
	"fmt"
)

func main() {

	m := [][]int{
		{1, 0, 0, 1, 0, 0, 1},
		{1, 0, 1, 0, 0, 1, 0},
		{0, 1, 0, 1, 1, 0, 1},
		{1, 0, 0, 0, 0, 1, 0},
	}
	fmt.Println("Before", m)
	r := calc(m)
	fmt.Println("After", r)
}

func calc(matrix [][]int) [][]int {
	r := make([][]int, len(matrix))
	for i := range matrix {
		r[i] = make([]int, len(matrix[i]))
		copy(r[i], matrix[i])
	}
	for i := 0; i < len(matrix); i++ {
		for j := 0; j < len(matrix[i]); j++ {
			count := 0
			count += getCountPixels(matrix[i][j], -1, -1, matrix)
			count += getCountPixels(matrix[i][j], -1, 0, matrix)
			count += getCountPixels(matrix[i][j], -1, 1, matrix)
			count += getCountPixels(matrix[i][j], 0, 1, matrix)
			count += getCountPixels(matrix[i][j], 1, 1, matrix)
			count += getCountPixels(matrix[i][j], 1, 0, matrix)
			count += getCountPixels(matrix[i][j], 1, -1, matrix)
			count += getCountPixels(matrix[i][j], 0, -1, matrix)
			if count > 2 {
				r[i][j] = 0
			}
		}
	}
	return r
}

func getCountPixels(pi int, x int, y int, matrix [][]int) int {
	xv := pi + x
	yv := pi + y
	if xv < 0 || yv < 0 {
		return 0
	}
	return matrix[xv][yv]
}
