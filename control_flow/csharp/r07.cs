using System;
class C {
    int Chain(int a) {
        if (a == 1) { return 1; } else if (a == 2) { return 2; } else { return 0; }
    }
    int Nested(int a) {
        if (a == 1) { return 1; } else { if (a == 2) { return 2; } return 0; }
    }
    void Loops(int[] xs) {
        for (int i = 0; i < 3; i++) { }
        foreach (var x in xs) { }
        while (xs.Length == 0) { break; }
        do { } while (false);
    }
    int Sw(int a) { switch (a) { case 1: return 1; case 2: case 3: return 2; default: return 0; } }
    int Swe(int a) => a switch { 1 => 1, 2 when a > 0 => 2, _ => 0 };
    void Exc() {
        try { throw new Exception(); } catch (InvalidOperationException e) when (e != null) { } catch (Exception) { } finally { }
    }
    int Tern(int a) => a > 0 ? a : -a;
    int Coalesce(int? a) { int b = a ?? 0; b ??= 1; return b; }
    System.Collections.Generic.IEnumerable<int> Gen() { yield return 1; yield break; }
    int ThrowExpr(string s) => s ?? throw new ArgumentNullException();
    void Jump() { goto done; done: return; }
}
