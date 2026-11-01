import java.util.*;
public class C {
    int chain(int a) {
        if (a == 1) { return 1; } else if (a == 2) { return 2; } else if (a == 3) { return 3; } else { return 0; }
    }
    int nested(int a) {
        if (a == 1) { return 1; } else { if (a == 2) { return 2; } return 0; }
    }
    void loops(List<Integer> xs) {
        for (int i = 0; i < 3; i++) { }
        for (Integer x : xs) { }
        while (xs.isEmpty()) { break; }
        do { } while (false);
        outer: for (;;) { for (;;) { continue outer; } }
    }
    int sw(int a) {
        switch (a) { case 1: return 1; case 2: case 3: return 2; default: return 0; }
    }
    int swe(int a, boolean b) {
        return switch (b ? a : 0) { case 1 -> 1; case 2, 3 -> { yield 2; } default -> 0; };
    }
    int guarded(Object o) { return switch (o) { case Integer i when i > 0 -> 1; default -> 0; }; }
    void exc() {
        try { throw new RuntimeException(); } catch (RuntimeException e) { } catch (Exception e) { } finally { }
    }
    int tern(int a) { return a > 0 ? a : -a; }
    void jumps(int a) { while (true) { if (a > 0) break; else continue; } }
    static { if (true) { } }
    int yieldIn(int a) { return switch (a) { default -> { yield a; } }; }
}
