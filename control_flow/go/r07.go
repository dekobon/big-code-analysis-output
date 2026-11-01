package p
func chain(a int) int {
	if a == 1 { return 1 } else if a == 2 { return 2 } else { return 0 }
}
func nested(a int) int {
	if a == 1 { return 1 } else { if a == 2 { return 2 }; return 0 }
}
func initif(m map[int]int) int { if v, ok := m[1]; ok { return v }; return 0 }
func loops(xs []int) {
	for i := 0; i < 3; i++ { }
	for _, x := range xs { _ = x }
	for { break }
outer:
	for { for { continue outer } }
}
func sw(a int) int { switch a { case 1: return 1; case 2, 3: return 2; default: return 0 } }
func tsw(x interface{}) int { switch x.(type) { case int: return 1; default: return 0 } }
func sel(c chan int) { select { case <-c: ; default: } }
func exit() { panic("x") }
func notexit(f struct{ panic func() }) { f.panic() }
func jump() { goto done; done: }
