package main

import (
	"testing"
)

// func TestHelloName(t *testing.T) {
// 	//
// 	assert.Eq
// }

func BenchmarkTestA(b *testing.B) {
	for i := 0; i < b.N; i++ {
		RunTestA()
	}
}

func BenchmarkTestB(b *testing.B) {
	for i := 0; i < b.N; i++ {
		RunTestB()
	}
}
