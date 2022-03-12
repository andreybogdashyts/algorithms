package main

import (
	"fmt"
	"unsafe"
)

type A struct {
	Bool      bool
	Integer64 int64
	Integer32 int32
	ABool     ABool
}
type ABool struct {
	Bool      bool
	Integer64 int64
}

func (a A) TestA() {
	a.Integer32 = 4
	a.Integer64 = 6
}

func (a *A) TestB() ABool {
	a.Integer32 = 8
	a.Integer64 = 12
	a.ABool = ABool{
		Bool: true,
	}
	return a.ABool
}

func main() {
	var info ABool
	const infoSize = unsafe.Sizeof(info)
	fmt.Println(infoSize)

	t := &A{}
	t.TestA()
	fmt.Println(t.Integer32)
	fmt.Println(t.Integer64)

	tr := &A{}
	tr.TestB()
	fmt.Println(tr.Integer32)
	fmt.Println(tr.Integer64)
}

func RunTestA() {
	var b ABool
	for i := 1; i <= 100000; i++ {
		t := &A{}
		b = t.TestB()
	}
	b.Bool = false
}

func RunTestB() {
	t := &A{}
	t.TestB()
}
