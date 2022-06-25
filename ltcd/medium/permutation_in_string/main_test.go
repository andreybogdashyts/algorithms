package main

// import (
// 	"fmt"
// 	"testing"

// 	"github.com/stretchr/testify/assert"
// )

// func TestIsPermutated(t *testing.T) {
// 	cases := []struct {
// 		s1  string
// 		s2  string
// 		res bool
// 	}{
// 		{s1: "ab", s2: "ab", res: true},
// 		{s1: "sab", s2: "asb", res: true},
// 		{s1: "bas", s2: "asb", res: true},
// 		{s1: "db", s2: "ab", res: false},
// 		{s1: "oa", s2: "ab", res: false},
// 		{s1: "oooll", s2: "hello", res: false},
// 	}

// 	for _, c := range cases {
// 		if r := isPermutated(c.s1, c.s2); !assert.Equal(t, c.res, r) {
// 			fmt.Printf("failed: strings %s and %s, got %v", c.s1, c.s2, c.res)
// 		}
// 	}
// }
