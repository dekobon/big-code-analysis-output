class C {
    int chain(int a) {
        if (a == 1) { return 1 } else if (a == 2) { return 2 } else { return 0 }
    }
    int nested(int a) {
        if (a == 1) { return 1 } else { if (a == 2) { return 2 }; return 0 }
    }
    void loops(List xs) {
        for (int i = 0; i < 3; i++) { }
        for (x in xs) { }
        while (xs.isEmpty()) { break }
        do { } while (false)
        outer: for (;;) { for (;;) { continue outer } }
    }
    int sw(int a) {
        switch (a) { case 1: return 1; case 2: case 3: return 2; default: return 0 }
    }
    int swe(int a) { return switch (a) { case 1 -> 1; default -> { yield 0 } } }
    void exc() { try { throw new RuntimeException() } catch (RuntimeException e) { } finally { } }
    int tern(int a) { return a > 0 ? a : -a }
    int elvis(Integer a) { return a ?: 0 }
    void asserts(int a) { assert a > 0 }
    def safe(x) { x?.y }
}
