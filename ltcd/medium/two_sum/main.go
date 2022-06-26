package main

import "fmt"

func main() {
	fmt.Println(twoSum([]int{3, 3, 1, 4, 2}, 7))
	fmt.Println(twoSum([]int{3, 2, 3}, 6))
	fmt.Println(twoSum([]int{3, 2, 4}, 6))
}

func twoSum(nums []int, target int) []int {
	for i, c := range nums {
		res := []int{}
		res = append(res, i)
		for j := i + 1; j < len(nums); j++ {
			s := c + nums[j]
			if s == target {
				res = append(res, j)
				return res
			}
		}
	}
	return []int{}
}
