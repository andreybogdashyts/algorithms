package challenge

func Decode(roman string) int {
	out := 0
	lr := len(roman)
	for i := 0; i < lr; i++ {
		c := string(roman[i])
		vc := m[c]
		if i < lr-1 {
			cn := string(roman[i+1])
			vcnext := m[cn]
			if vc < vcnext {
				out += vcnext - vc
				i++
			} else {
				out += vc
			}
		} else {
			out += vc
		}
	}
	return out
}

var m = map[string]int{
	"I": 1,
	"V": 5,
	"X": 10,
	"L": 50,
	"C": 100,
	"D": 500,
	"M": 1000,
}
