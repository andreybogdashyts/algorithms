package challenge_test

import (
	"testing"

	. "github.com/onsi/ginkgo"
	. "github.com/onsi/gomega"
)

func TestChallengeTest(t *testing.T) {
	RegisterFailHandler(Fail)
	RunSpecs(t, "ChallengeTest Suite")
}
