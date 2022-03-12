package challenge

import (
	. "github.com/onsi/ginkgo"
	. "github.com/onsi/gomega"
)

var _ = Describe("Decode", func() {
	It("should work for individual characters", func() {
		Expect(Decode("I")).To(Equal(1))
	})

	It("should handle descending values", func() {
		Expect(Decode("XXI")).To(Equal(21))
	})

	It("should handle ascending values", func() {
		Expect(Decode("IV")).To(Equal(4))
	})
})
